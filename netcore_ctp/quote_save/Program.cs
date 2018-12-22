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

        static string[] RB = new string[] { "rb1812", "rb1901", "rb1902", "rb1903", "rb1904", "rb1905", "rb1906", "rb1907", "rb1908", "rb1909", "rb1910", "rb1911" };
        static string[] I = new string[] { "i1812", "i1901", "i1902", "i1903", "i1904", "i1905", "i1906", "i1907", "i1908", "i1909", "i1910", "i1911" };
        static string[] MA = new string[] { "MA812", "MA901", "MA902", "MA903", "MA904", "MA905", "MA906", "MA907", "MA908", "MA909", "MA910", "MA911" };
        static string[] TA = new string[] { "TA812", "TA901", "TA902", "TA903", "TA904", "TA905", "TA1906", "TA907", "TA908", "TA909", "TA1910", "TA911" };
        static string[] ZN = new string[] { "zn1812", "zn1901", "zn1902", "zn1903", "zn1904", "zn1905", "zn1906", "zn1907", "zn1908", "zn1909", "zn1910", "zn1911" };
        static string[] NI = new string[] { "ni1812", "ni1901", "ni1902", "ni1903", "ni1904", "ni1905", "ni1906", "ni1907", "ni1908", "ni1909", "ni1910", "ni1911" };
        static string[] J = new string[] { "j1812", "j1901", "j1902", "j1903", "j1904", "j1905", "j1906", "j1907", "j1908", "j1909", "j1910", "j1911" };
        static string[] JM = new string[] { "jm1812", "jm1901", "jm1902", "jm1903", "jm1904", "jm1905", "jm1906", "jm1907", "jm1908", "jm1909", "jm1910", "jm1911" };
        static string[] SP = new string[] { "sp1906", "sp1907", "sp1908", "sp1909", "sp1910", "sp1911" };
        static string[] BU = new string[] { "bu1812", "bu1901", "bu1902", "bu1903", "bu1904", "bu1905", "bu1906", "bu1907", "bu1908", "bu1909", "bu1910", "bu1911", "bu2003", "bu2006", "bu2009" };
        static string[] SC = new string[] { "sc1812", "sc1901", "sc1902", "sc1903", "sc1904", "sc1905", "sc1906", "sc1907", "sc1908", "sc1909", "sc1910", "sc1911", "sc2003", "sc2006", "sc2009" };
        static string[] PP = new string[] { "pp1812", "pp1901", "pp1902", "pp1903", "pp1904", "pp1905", "pp1906", "pp1907", "pp1908", "pp1909", "pp1910", "pp1911" };
        static string[] HC = new string[] { "hc1812", "hc1901", "hc1902", "hc1903", "hc1904", "hc1905", "hc1906", "hc1907", "hc1908", "hc1909", "hc1910", "hc1911" };
        static string[] AG = new string[] { "ag1812", "ag1901", "ag1902", "ag1903", "ag1904", "ag1905", "ag1906", "ag1907", "ag1908", "ag1909", "ag1910", "ag1911" };
        static string[] FU = new string[] { "fu1812", "fu1901", "fu1902", "fu1903", "fu1904", "fu1905", "fu1906", "fu1907", "fu1908", "fu1909", "fu1910", "fu1911" };
        static string[] AL = new string[] { "al1812", "al1901", "al1902", "al1903", "al1904", "al1905", "al1906", "al1907", "al1908", "al1909", "al1910", "al1911" };
        static string[] ZC = new string[] { "ZC812", "ZC901", "ZC902", "ZC903", "ZC904", "ZC905", "ZC906", "ZC907", "ZC908", "ZC909", "ZC910", "ZC911" };
        static string[] FG = new string[] { "FG812", "FG901", "FG902", "FG903", "FG904", "FG905", "FG906", "FG907", "FG908", "FG909", "FG910", "FG911" };
        static string[] P = new string[] { "p1812", "p1901", "p1902", "p1903", "p1904", "p1905", "p1906", "p1907", "p1908", "p1909", "p1910", "p1911" };
        static string[] V = new string[] { "v1812", "v1901", "v1902", "v1903", "v1904", "v1905", "v1906", "v1907", "v1908", "v1909", "v1910", "v1911" };
        static string[] L = new string[] { "l1812", "l1901", "l1902", "l1903", "l1904", "l1905", "l1906", "l1907", "l1908", "l1909", "l1910", "l1911" };
        static string[] RU = new string[] { "ru1812", "ru1901", "ru1902", "ru1903", "ru1904", "ru1905", "ru1906", "ru1907", "ru1908", "ru1909", "ru1910", "ru1911" };
        static string[] CU = new string[] { "cu1812", "cu1901", "cu1902", "cu1903", "cu1904", "cu1905", "cu1906", "cu1907", "cu1908", "cu1909", "cu1910", "cu1911" };
        static string[] SF = new string[] { "SF812", "SF901", "SF902", "SF903", "SF904", "SF905", "SF906", "SF907", "SF908", "SF909", "SF910", "SF911" };
        static string[] JD = new string[] { "jd1812", "jd1901", "jd1902", "jd1903", "jd1904", "jd1905", "jd1906", "jd1907", "jd1908", "jd1909", "jd1910", "jd1911" };
        static string[] PB = new string[] { "pb1812", "pb1901", "pb1902", "pb1903", "pb1904", "pb1905", "pb1906", "pb1907", "pb1908", "pb1909", "pb1910", "pb1911" };
        static string[] B = new string[] { "b1812", "b1901", "b1902", "b1903", "b1904", "b1905", "b1906", "b1907", "b1908", "b1909", "b1910", "b1911" };
        static string[] SN = new string[] { "sn1812", "sn1901", "sn1902", "sn1903", "sn1904", "sn1905", "sn1906", "sn1907", "sn1908", "sn1909", "sn1910", "sn1911" };
        static string[] OI = new string[] { "OI901", "OI903", "OI905", "OI907", "OI909", "OI911" };
        static string[] CF = new string[] { "CF901", "CF903", "CF905", "CF907", "CF909", "CF911" };
        static string[] A = new string[] { "a1901", "a1903", "a1905", "a1907", "a1909", "a1911", "a2001" };
        static string[] Y = new string[] { "y1812", "y1901", "y1903", "y1905", "y1907", "y1908", "y1909", "y1911" };
        static string[] CS = new string[] { "cs1901", "cs1903", "cs1905", "cs1907", "cs1909", "cs1911" };
        static string[] AP = new string[] { "AP812", "AP902", "AP903", "AP905", "AP907", "AP910", "AP911" };
        static string[] SR = new string[] { "SR901", "SR903", "SR905", "SR907", "SR909", "SR911" };
        static string[] RM = new string[] { "RM901", "RM903", "RM905", "RM907", "RM908", "RM909", "RM911" };
        static string[] M = new string[] { "m1812", "m1901", "m1903", "m1905", "m1907", "m1908", "m1909", "m1911" };
        static string[] C = new string[] { "c1901", "c1903", "c1905", "c1907", "c1909", "c1911" };
        static string[] AU = new string[] { "au1812", "au1901", "au1902", "au1904", "au1906", "au1908", "au1910", "au1912" };

        static void Main(string[] args)
        {
            List<string> codes = new List<string>();
            codes.AddRange(RM);
            codes.AddRange(AU);
            codes.AddRange(C);
            codes.AddRange(M);
            codes.AddRange(SR);
            codes.AddRange(AP);
            codes.AddRange(CS);
            codes.AddRange(Y);
            codes.AddRange(A);
            codes.AddRange(CF);
            codes.AddRange(OI);
            codes.AddRange(SN);
            codes.AddRange(B);
            codes.AddRange(PB);
            codes.AddRange(JD);
            codes.AddRange(SF);
            codes.AddRange(CU);
            codes.AddRange(RU);
            codes.AddRange(L);
            codes.AddRange(V);
            codes.AddRange(P);
            codes.AddRange(FG);
            codes.AddRange(ZC);
            codes.AddRange(AL);
            codes.AddRange(FU);
            codes.AddRange(AG);
            codes.AddRange(HC);
            codes.AddRange(RB);
            codes.AddRange(I);
            codes.AddRange(MA);
            codes.AddRange(TA);
            codes.AddRange(ZN);
            codes.AddRange(NI);
            codes.AddRange(J);
            codes.AddRange(JM);
            codes.AddRange(SP);
            codes.AddRange(BU);
            codes.AddRange(SC);
            codes.AddRange(PP);

            Logger.Info("code num: {0}", codes.Count);
            var qs = new QuoteSave(investor, pwd, codes.ToArray());
            qs.Run();

            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape
                    || key.Key == ConsoleKey.Spacebar
                    || key.Key == ConsoleKey.Enter)
                    break;
                Thread.Sleep(500);
            }

            qs.Release();
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
