using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Common.Utils;
using Newtonsoft.Json;
using 期货数据爬虫.Common;

namespace 期货数据爬虫.持仓.转换
{
    public class 大商所
    {
        /// <summary>
        ///     解析那天的数据
        /// </summary>
        /// <param name="date"></param>
        public Interest[] Parse(string date)
        {
            var ret = new List<Interest>();
            var saveFile = Path.Combine(Utils.GetDataFileBasePath, $"Interest/DaLian/{date.Substring(0, 4)}/{date}.zip");
            if (!File.Exists(saveFile))
                return ret.ToArray();

            // 这里要读zip文件
            var zip = new System.IO.Compression.ZipArchive(File.OpenRead(saveFile), System.IO.Compression.ZipArchiveMode.Read);

            foreach (var entity in zip.Entries)
            {
                var stream = entity.Open();

                using (var s = new StreamReader(stream))
                {
                    List<string> lines = new List<string>();
                    while (!s.EndOfStream)
                    {
                        lines.Add(s.ReadLine());
                    }

                    var insterst = GetInterest(lines.ToArray());
                    ret.Add(insterst);
                }
            }
            Console.WriteLine(zip.Entries.Count);

            return ret.ToArray();
        }

        Interest GetInterest(string[] txt)
        {
            Interest ret = new Interest();
            List<string> 成交量 = new List<string>();
            List<string> 持买单量 = new List<string>();
            List<string> 持卖单量 = new List<string>();

            List<string> current = null;

            foreach (var line in txt)
            {
                if (line.IndexOf("合约代码") > -1)
                {
                    var 代码 = line.Regex(@"合约代码：\w*\d*").Replace("合约代码：", "");
                    var month = 代码.Regex(@"\d+");   // 这里的日期已经是4位数了
                    ret.品种 = 代码.Regex(@"[a-zA-Z]+");
                    ret.Code = 代码;
                    ret.交割月份 = int.Parse(month.Substring(2, 2));

                    var date = line.Regex("Date：.*").Replace("Date：", "");
                    ret.Date = int.Parse(date.Replace("-", ""));
                    ret.Id = $"{ret.Date}_{ret.Code}";
                }

                if (line.IndexOf("\t成交量") > -1)
                {
                    // 后面的状态进入成交量处理流程中
                    current = 成交量;
                }
                if (line.IndexOf("\t持买单量") > -1)
                {
                    // 后面的状态进入成交量处理流程中
                    current = 持买单量;
                }
                if (line.IndexOf("\t持卖单量") > -1)
                {
                    // 后面的状态进入成交量处理流程中
                    current = 持卖单量;
                }

                if (line.IndexOf("总计") > -1)
                {
                    current = null;
                }

                if (current != null)
                    current.Add(line.FixLineToCsv());
            }

            //Console.WriteLine("成交量" + JsonConvert.SerializeObject(成交量, Formatting.Indented));
            //Console.WriteLine("持卖单量" + JsonConvert.SerializeObject(持卖单量, Formatting.Indented));
            //Console.WriteLine("持买单量" + JsonConvert.SerializeObject(持买单量, Formatting.Indented));

            ret.成交量 = new List<InterestItem>();
            foreach (var line in 成交量.Skip(1))
            {
                var s = line.Split(",").Select(o => o.Trim()).ToArray();
                var rank = int.Parse(s[0]);
                var 成交量机构 = s[1];
                if (!string.IsNullOrEmpty(成交量机构) && 成交量机构 != "-")
                {
                    var 成交量量 = int.Parse(s[2]);
                    var 成交量变化 = int.Parse(s[3]);

                    ret.成交量.Add(new InterestItem
                    {
                        机构名称 = 成交量机构,
                        数量 = 成交量量,
                        变化 = 成交量变化,
                        排名 = rank
                    });
                }
            }

            ret.空单 = new List<InterestItem>();
            foreach (var line in 持卖单量.Skip(1))
            {
                var s = line.Split(",").Select(o => o.Trim()).ToArray();
                var rank = int.Parse(s[0]);
                var 成交量机构 = s[1];
                if (!string.IsNullOrEmpty(成交量机构) && 成交量机构 != "-")
                {
                    var 成交量量 = int.Parse(s[2]);
                    var 成交量变化 = int.Parse(s[3]);

                    ret.空单.Add(new InterestItem
                    {
                        机构名称 = 成交量机构,
                        数量 = 成交量量,
                        变化 = 成交量变化,
                        排名 = rank
                    });
                }
            }


            ret.多单 = new List<InterestItem>();
            foreach (var line in 持买单量.Skip(1))
            {
                var s = line.Split(",").Select(o => o.Trim()).ToArray();
                var rank = int.Parse(s[0]);
                var 成交量机构 = s[1];
                if (!string.IsNullOrEmpty(成交量机构) && 成交量机构 != "-")
                {
                    var 成交量量 = int.Parse(s[2]);
                    var 成交量变化 = int.Parse(s[3]);

                    ret.多单.Add(new InterestItem
                    {
                        机构名称 = 成交量机构,
                        数量 = 成交量量,
                        变化 = 成交量变化,
                        排名 = rank
                    });
                }
            }

            return ret;
        }
    }
}
