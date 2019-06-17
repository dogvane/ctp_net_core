using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Common.Database;
using Common.Entitys;
using Common.Utils;
using Newtonsoft.Json.Linq;
using ServiceStack.OrmLite;
using 期货数据爬虫.Common;
using 期货数据爬虫.持仓;

namespace 期货数据爬虫.持仓.转换
{
    /// <summary>
    /// 上海持仓排名的解析
    /// </summary>
    public class 上期所
    {
        /// <summary>
        ///     解析那天的数据
        /// </summary>
        /// <param name="date"></param>
        public Interest[] Parse(string date)
        {
            var ret = new List<Interest>();
            var saveFile = Path.Combine(Utils.GetDataFileBasePath, $"Interest/Shanghai/{date.Substring(0, 4)}/{date}.txt");
            if (!File.Exists(saveFile))
                return ret.ToArray();

            var txt = File.ReadAllText(saveFile, Encoding.UTF8);

            var obj = JObject.Parse(txt);

            var currentDate = int.Parse(date);

            var array = obj["o_cursor"] as JArray;
            foreach (var itemObj in array)
            {
                var code = itemObj["INSTRUMENTID"].ToString().Trim().Regex(@"[a-z]+");
                var month = itemObj["INSTRUMENTID"].ToString().Trim().Regex(@"\d+");
                var rank = (int) itemObj["RANK"];

                if (rank == 0 || rank == -1 || rank == 999)
                    continue;

                var id = $"{currentDate}_{code}{month}";
                var item = ret.FirstOrDefault(o => o.Id == id);
                if (item == null)
                {
                    item = new Interest
                    {
                        Id = id,
                        Code = code + month,
                        Date = currentDate,
                        交割月份 = int.Parse(month.Substring(2, 2)),
                        品种 = itemObj["PRODUCTNAME"].ToString(),
                        多单 = new List<InterestItem>(),
                        成交量 = new List<InterestItem>(),
                        空单 = new List<InterestItem>()
                    };
                    ret.Add(item);
                }

                var 成交量机构 = itemObj["PARTICIPANTABBR1"].ToString().Trim();
                var 成交量机构Id = itemObj["PARTICIPANTID1"].ToString().Trim();
                var 成交量量 = (int) itemObj["CJ1"];
                var 成交量变化 = (int) itemObj["CJ1_CHG"];

                var 多单机构 = itemObj["PARTICIPANTABBR2"].ToString().Trim();
                var 多单机构Id = itemObj["PARTICIPANTID2"].ToString().Trim();
                var 多单量 = (int) itemObj["CJ2"];
                var 多单变化 = (int) itemObj["CJ2_CHG"];

                var 空单机构 = itemObj["PARTICIPANTABBR3"].ToString().Trim();
                var 空单机构Id = itemObj["PARTICIPANTID3"].ToString().Trim();
                var 空单量 = (int) itemObj["CJ3"];
                var 空单变化 = (int) itemObj["CJ3_CHG"];

                if (!string.IsNullOrEmpty(成交量机构))
                    item.成交量.Add(new InterestItem
                    {
                        机构名称 = 成交量机构,
                        机构Id = 成交量机构Id,
                        数量 = 成交量量,
                        变化 = 成交量变化,
                        排名 = rank
                    });

                if (!string.IsNullOrEmpty(多单机构))
                    item.多单.Add(new InterestItem
                    {
                        机构名称 = 多单机构,
                        机构Id = 多单机构Id,
                        数量 = 多单量,
                        变化 = 多单变化,
                        排名 = rank
                    });

                if (!string.IsNullOrEmpty(空单机构))
                    item.空单.Add(new InterestItem
                    {
                        机构名称 = 空单机构,
                        机构Id = 空单机构Id,
                        数量 = 空单量,
                        变化 = 空单变化,
                        排名 = rank
                    });
            }

            return ret.ToArray();
        }

        public void ParseToDb(string date)
        {
            var interests = Parse(date);
            if (interests.Length > 0)
                using (var db = DbSet.GetDb())
                {
                    db.CreateTableIfNotExists<Interest>();
                    foreach (var item in interests)
                        if (db.Exists<Interest>(o => o.Id == item.Id))
                            db.Update(item);
                        else
                            db.Insert(item);
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