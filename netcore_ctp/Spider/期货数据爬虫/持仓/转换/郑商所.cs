using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Common.Database;
using Common.Entitys;
using Common.Log;
using Common.Utils;
using Newtonsoft.Json.Linq;
using ServiceStack.OrmLite;
using 期货数据爬虫.Common;
using 期货数据爬虫.K线;

namespace 期货数据爬虫.持仓.转换
{
    /// <summary>
    /// 郑商所持仓排名的解析
    /// </summary>
    public class 郑商所
    {
        /// <summary>
        ///     解析那天的数据
        /// </summary>
        /// <param name="date"></param>
        public Interest[] Parse(string date)
        {
            var ret = new List<Interest>();
            var saveFile = Path.Combine(Utils.GetDataFileBasePath, $"Interest/ZhengZhou/{date.Substring(0, 4)}/{date}.txt");
            if (!File.Exists(saveFile))
                return ret.ToArray();

            // 先将数据拆解为一个个持仓基本数据，然后再对数据的做修正保存到数据库里

            var lines = File.ReadAllLines(saveFile, Encoding.UTF8);
            var index = 0;
            List<string> currentParse = new List<string>();
            Dictionary<string, List<string>> allSourceData = new Dictionary<string, List<string>>();

            string codeTxt = string.Empty;
            bool isParseData = false;   // 是否正在解析数据
            while (index < lines.Length)
            {
                var lineData = lines[index];
                if (isParseData)
                {
                    if (lineData.IndexOf("合计") > -1)
                    {
                        // 已经结束解析了
                        allSourceData[codeTxt] = currentParse;
                        codeTxt = string.Empty;
                        currentParse = new List<string>();
                        isParseData = false;
                    }
                    else
                    {
                        if (lineData.IndexOf("名次") > -1)
                        {

                        }
                        else
                        {
                            currentParse.Add(lineData);
                        }
                    }
                }
                else
                {
                    if (lineData.IndexOf("品种") > -1)
                    {                        
                        codeTxt = lineData.Regex(@"品种：\w+").Replace("品种：", "");
                        if (codeTxt == "PTA")
                            codeTxt = "TA";

                        isParseData = true;
                    }

                    if (lineData.IndexOf("合约") > -1)
                    {
                        codeTxt = lineData.Regex(@"合约：\w+").Replace("合约：", "");
                        
                        isParseData = true;
                    }

                }

                index++;
            }

            Console.WriteLine("allSourceData.Count {0}", allSourceData.Count);
            foreach (var item in allSourceData)
            {
                Console.WriteLine($"{item.Key}, {item.Value.Count}");
            }

            var currentDate = int.Parse(date);

            foreach (var sd in allSourceData)
            {
                var codeSource = sd.Key;
                var dline = sd.Value;

                var code = codeSource.Regex(@"[a-zA-Z]+");
                var month = codeSource.Regex(@"\d+");

                if (string.IsNullOrEmpty(month))
                {
                    // 这里要找到主力合约才行
                    month = "0000";
                }
                else
                {
                    month = "1" + month;
                }

                var id = $"{currentDate}_{code}{month}";
                var item = new Interest
                {
                    Id = id,
                    Code = code + month,
                    Date = currentDate,
                    交割月份 = int.Parse(month.Substring(2, 2)),
                    品种 = code,
                    多单 = new List<InterestItem>(),
                    成交量 = new List<InterestItem>(),
                    空单 = new List<InterestItem>()
                };
                ret.Add(item);

                foreach (var line in dline)
                {
                    var s = line.Split("|").Select(o => o.Trim().Replace(",", "")).ToArray();
                    var rank = int.Parse(s[0]);
                    var 成交量机构 = s[1];
                    if (!string.IsNullOrEmpty(成交量机构) && 成交量机构 != "-")
                    {
                        var 成交量量 = int.Parse(s[2]);
                        var 成交量变化 = int.Parse(s[3]);

                        item.成交量.Add(new InterestItem
                        {
                            机构名称 = 成交量机构,
                            数量 = 成交量量,
                            变化 = 成交量变化,
                            排名 = rank
                        });
                    }

                    var 多单机构 = s[4];
                    if (!string.IsNullOrEmpty(多单机构) && 多单机构 != "-")
                    {
                        var 多单量 = int.Parse(s[5]);
                        var 多单变化 = int.Parse(s[6]);
                        item.多单.Add(new InterestItem
                        {
                            机构名称 = 多单机构,
                            数量 = 多单量,
                            变化 = 多单变化,
                            排名 = rank
                        });
                    }

                    var 空单机构 = s[7];
                    if (!string.IsNullOrEmpty(空单机构) && 空单机构 != "-")
                    {
                        var 空单量 = int.Parse(s[8]);
                        var 空单变化 = int.Parse(s[9]);

                        item.空单.Add(new InterestItem
                        {
                            机构名称 = 空单机构,
                            数量 = 空单量,
                            变化 = 空单变化,
                            排名 = rank
                        });
                    }
                }
            }

            return ret.ToArray();
        }

        public void ParseToDb(string date)
        {
            var interests = Parse(date);
            if (interests.Length > 0)
                using (var db = DbSet.GetDb())
                {
                    int idate = int.Parse(date);
                    db.CreateTableIfNotExists<Interest>();
                    foreach (var item in interests)
                    {
                        if (item.交割月份 == 0)
                        {
                            // 获得今天的当前品种的所有交易数据
                            var klines = db.Select<KLine>(o => o.品种 == item.品种 && item.Date == idate).OrderByDescending(o=>o.持仓量).ToArray();
                            foreach (var line in klines)
                            {
                                if (!interests.Any(o => o.Code == line.Code))
                                {
                                    item.Code = line.Code;
                                    item.Date = line.Date;
                                    item.Id = line.Id;
                                    item.交割月份 = line.交割月份;
                                    Console.WriteLine(item.Code);
                                    break;
                                }
                            }

                            if (item.交割月份 == 0)
                            {
                                Logs.Error($"没找到匹配代码 {item.Code}");
                                continue;
                            }
                        }

                        if (db.Exists<Interest>(o => o.Id == item.Id))
                            db.Update(item);
                        else
                            db.Insert(item);
                    }
                }
        }


        public Interest[] GetFromDb(string date)
        {
            using (var db = DbSet.GetDb())
            {
                db.CreateTableIfNotExists<Interest>();
                return db.Select<Interest>(o => o.Date == int.Parse(date)).ToArray();
            }
        }
    }
}