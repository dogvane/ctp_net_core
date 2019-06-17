using System;
using System.Collections.Generic;
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
    /// <summary>
    ///     上海K线解析
    /// </summary>
    public class 上期所
    {
        /// <summary>
        ///     解析那天的数据
        /// </summary>
        /// <param name="date"></param>
        public KLine[] Parse(string date)
        {
            var ret = new List<KLine>();
            var saveFile = Path.Combine(Utils.GetDataFileBasePath, $"KLine/Shanghai/{date.Substring(0, 4)}/{date}.txt");
            if (!File.Exists(saveFile))
                return ret.ToArray();

            var txt = File.ReadAllText(saveFile, Encoding.UTF8);

            var obj = JObject.Parse(txt);

            var currentDate = int.Parse(date);

            var array = obj["o_curinstrument"] as JArray;
            foreach (var itemObj in array)
            {
                var code = itemObj["PRODUCTID"].ToString().Trim().Replace("_f", "");
                var month = itemObj["DELIVERYMONTH"].ToString();
                var productName = itemObj["PRODUCTNAME"].ToString().Trim();
                if (month == "小计" || productName == "总计" || productName == "总计1" || productName == "总计2" || productName.IndexOf("转现") > -1 || month == "合计")
                    continue;

                var 开盘价 = itemObj["OPENPRICE"].GetDouble();
                var 收盘价 = itemObj["CLOSEPRICE"].GetDouble();
                var 最高价 = itemObj["HIGHESTPRICE"].GetDouble();
                var 最低价 = itemObj["LOWESTPRICE"].GetDouble();
                var 开盘持仓量 = (int) itemObj["OPENINTEREST"];
                var 本日持仓变化 = (int) itemObj["OPENINTERESTCHG"];
                var 前日结算价 = itemObj["PRESETTLEMENTPRICE"].GetDouble();
                var 本日结算价 = itemObj["SETTLEMENTPRICE"].GetDouble();
                var 成交量 = (int) itemObj["VOLUME"];

                var kline = new KLine();
                kline.交割月份 = int.Parse(month.Substring(2, 2));
                kline.Code = code + month;
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