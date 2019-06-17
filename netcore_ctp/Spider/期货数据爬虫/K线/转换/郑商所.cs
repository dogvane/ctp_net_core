using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Common.Database;
using Common.Entitys;
using Common.Utils;
using Newtonsoft.Json.Linq;
using ServiceStack.OrmLite;
using 期货数据爬虫.Common;

namespace 期货数据爬虫.K线.转换
{
    public class 郑商所
    {
        /// <summary>
        ///     解析那天的数据
        /// </summary>
        /// <param name="date"></param>
        public KLine[] Parse(string date)
        {
            var ret = new List<KLine>();
            var saveFile = Path.Combine(Utils.GetDataFileBasePath, $"KLine/ZhengZhou/{date.Substring(0, 4)}/{date}.txt");
            if (!File.Exists(saveFile))
                return ret.ToArray();

            var txt = File.ReadAllLines(saveFile, Encoding.UTF8);

            var datas = new List<string[]>();

            foreach (var item in txt)
            {
                if (item.Contains("小计") || item.Contains("品种") || item.Contains("总计") || item.Contains("每日行情表"))
                {
                    continue;
                }

                var d = item.Replace(",", "").Split("|");
                if (d.Length < 14)
                    continue;

                datas.Add(d);
            }
           
            var currentDate = int.Parse(date);

            foreach (var itemObj in datas)
            {
                var code = itemObj[0].Regex(@"[a-zA-Z]+");
                var month = "1" + itemObj[0].Regex(@"\d+");
                var productName = code;

                var 开盘价 = itemObj[2].GetDouble();
                var 收盘价 = itemObj[5].GetDouble();
                var 最高价 = itemObj[3].GetDouble();
                var 最低价 = itemObj[4].GetDouble();
                var 开盘持仓量 = itemObj[10].GetInteger()*2 - itemObj[9].GetInteger();
                var 本日持仓变化 = itemObj[10].GetInteger();
                var 前日结算价 = itemObj[1].GetDouble();
                var 本日结算价 = itemObj[6].GetDouble();
                var 成交量 = itemObj[8].GetInteger();

                var kline = new KLine();
                kline.交割月份 = int.Parse(month.Substring(2, 2));
                kline.Code = itemObj[0].Trim();
                kline.Id = date + "_" + code + month;
                kline.品种 = productName;
                kline.Date = currentDate;
                kline.周期 = 0;
                kline.前结算价 = 前日结算价;
                kline.结算价 = 本日结算价;

                kline.开盘价 = 开盘价;
                kline.收盘价 = 收盘价;

                kline.最高价 = 最高价;
                kline.最低价 = 最低价;

                kline.成交量 = 成交量;
                kline.持仓量 = 开盘持仓量 + 本日持仓变化;

                ret.Add(kline);
            }

            return ret.ToArray();
        }

        public void ParseToDb(string date)
        {
            var d = Parse(date);

            if (d.Length > 0)
                using (var db = DbSet.GetDb())
                {
                    db.CreateTableIfNotExists<KLine>();
                    foreach (var item in d)
                    {
                        var dbItem = db.Single<KLine>(o => o.Id == item.Id);
                        if (dbItem == null)
                            db.Insert(item);
                        else
                            db.Update(item);
                    }
                }
        }
    }
}
