using System;

namespace SpiderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var ret = new 期货数据爬虫.持仓.转换.大商所().Parse("20190522");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(ret, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);

            //var ret = new 期货数据爬虫.交易日历.下载并转换().GetTradeDay();

            //var json = Newtonsoft.Json.JsonConvert.SerializeObject(ret, Newtonsoft.Json.Formatting.Indented);
            //Console.WriteLine(json);
            //Console.WriteLine(ret.Length);
        }
    }
}
