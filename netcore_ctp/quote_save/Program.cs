using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Common;
using CsvHelper;
using HaiFeng;
using ErrorEventArgs = HaiFeng.ErrorEventArgs;

namespace quote_save
{
    /// <summary>
    /// 行情数据收集并保存到本地的csv里
    /// </summary>
    class Program
    {
        private static string investor = "008105";
        private static string pwd = "1";

        static void Main(string[] args)
        {
            QuoteSave qs = null;

            var t = new CTPTrade("ctp_trade");

            t.OnFrontConnected += (sender, e) =>
            {
                t.ReqUserLogin(investor, pwd, "9999");
                t.OnRspUserLogin += (sender2, e2) =>
                {
                    if (e2.Value == 0)
                    {
                        List<string> codes = new List<string>();

                        foreach (var instrument in t.DicInstrumentField.Values)
                        {
                            codes.Add(instrument.InstrumentID);
                        }

                        Logger.Info("code num: {0}", codes.Count);

                        qs = new QuoteSave(investor, pwd, codes.ToArray());
                        qs.Run();
                    }
                    else
                    {
                        Console.WriteLine("登录失败!ret=" + e2.Value);
                    }
                };
            };

            t.ReqConnect("tcp://180.168.146.187:10000");

            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape
                    || key.Key == ConsoleKey.Spacebar
                    || key.Key == ConsoleKey.Enter)
                    break;
                Thread.Sleep(500);
            }

            qs?.Release();
            t?.ReqUserLogout();
        }
    }
    
    public class QuoteSave
    {
        CTPQuote _q = null;
        string _investor, _pwd, _broker = "9999";
        private string[] _inst;

        public QuoteSave(string investor, string pwd, params string[] instrument)
        {
            _investor = investor;
            _pwd = pwd;
            _inst = instrument;

            _q = new CTPQuote("ctp_quote");

            _q.OnFrontConnected += _q_OnFrontConnected;
            _q.OnRspUserLogin += _q_OnRspUserLogin;
            _q.OnRspUserLogout += _q_OnRspUserLogout;
            _q.OnRtnTick += _q_OnRtnTick;
            _q.OnRtnError += _q_OnRtnError;
        }

        public void Release()
        {
            _q.ReqUserLogout();
            FlushWriters();
        }

        void FlushWriters()
        {
            foreach (var stream in this.writers)
            {
                try
                {
                    stream.Flush();
                    stream.Close();
                }
                catch (Exception e)
                {
                    Logger.Error("flush fail.", e);
                }
            }
        }

        public void Run()
        {
            _q.ReqConnect("tcp://180.168.146.187:10010");
        }

        private void _q_OnFrontConnected(object sender, EventArgs e)
        {
            Logger.Info("connected");

            // 如果断线后会自动重连，这里需要刷新历史数据
            // 同时隔天开盘的时候，也是会自动重连的
            FlushWriters();

            map.Clear();
            writers.Clear();

            _q.ReqUserLogin(_investor, _pwd, _broker);
        }

        private void _q_OnRspUserLogin(object sender, IntEventArgs e)
        {
            if (e.Value == 0)
            {
                Logger.Info($"quote 登录成功:{_investor}");

                _q.ReqSubscribeMarketData(_inst);
            }
            else
            {
                //_q.OnFrontConnected -= _q_OnFrontConnected;    //解决登录错误后不断重连导致再不断登录的错误
                Logger.Info($"quote 登录错误：{e.Value}");
                _q.ReqUserLogout();
            }
        }

        private Dictionary<string, CsvWriter> map = new Dictionary<string, CsvWriter>();
        private List<TextWriter> writers = new List<TextWriter>();
        /// <summary>
        /// 根据期货代码，获得保存的文件位置
        /// </summary>
        /// <param name="instrumentId"></param>
        /// <returns></returns>
        CsvWriter GetStream(string instrumentId)
        {
            if (map.TryGetValue(instrumentId, out CsvWriter writer))
            {
                return writer;
            }

            var id = new Regex(@"[a-z|A-Z]*").Match(instrumentId);
            var time = DateTime.Now;
            if (time > DateTime.Now.Date.AddHours(17))
            {
                // 这里是夜盘数据，文件名应该用下一个交易日的文件名
                // todo 这里需要获得交易日日历的功能
                time = time.AddDays(1);
            }
            var path = $"data/{id}/{instrumentId}/{time.ToString("yyyyMMdd")}.csv";
            var fi = new FileInfo(path);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }

            bool isNew = !File.Exists(path);

            var stream = new StreamWriter(path, true, Encoding.Default);
            writers.Add(stream);

            writer = new CsvWriter(stream);
            map[instrumentId] = writer;
            if (isNew)
            {
                writer.WriteHeader<MarketData>();
            }

            return writer;
        }

        int i = 0;
        private void _q_OnRtnTick(object sender, TickEventArgs e)
        {
            var tick = e.Tick;
            var writer = GetStream(tick.InstrumentID);
            writer.WriteRecord(tick);
            writer.NextRecord();

            if (i++ % 100 == 0)
                Logger.Info(e.Tick.InstrumentID);
        }

        private void _q_OnRspUserLogout(object sender, IntEventArgs e)
        {
            Logger.Info($"quote logout: {e.Value}");
        }

        private void _q_OnRtnError(object sender, ErrorEventArgs e)
        {
            Logger.Info(e.ErrorMsg);
        }
    }
}
