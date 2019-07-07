using System;

namespace SpiderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var date = "20190704";
            new 期货数据爬虫.持仓.下载.大商所().下载(date, true);

            var ret = new 期货数据爬虫.持仓.转换.大商所().Parse(date);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(ret, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);

            //var ret = new 期货数据爬虫.交易日历.下载并转换().GetTradeDay();

            //var json = Newtonsoft.Json.JsonConvert.SerializeObject(ret, Newtonsoft.Json.Formatting.Indented);
            //Console.WriteLine(json);
            //Console.WriteLine(ret.Length);
        }
    }
}
