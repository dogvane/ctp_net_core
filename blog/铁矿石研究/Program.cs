using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 铁矿石研究
{
    class Program
    {
        static void Main(string[] args)
        {
            // 到货量处理();
            // 发货量处理();

            var fileName = "周库存.txt";
            var txt = File.ReadAllText(fileName, Encoding.Default);

            var records = ServiceStack.Text.CsvSerializer.DeserializeFromString<List<周库存>>(txt);

            List<周库存> 周库存2019 = new List<周库存>();

            StringBuilder sb = new StringBuilder();
            for (var i = 1; i < records.Count; i++)
            {
                var preItem = records[i - 1];

                var t = DateTime.Parse(records[i].日期);
                var t2 = DateTime.Parse(preItem.日期);
                var timeSpanDays = (t - t2).Days;
                
                var dec = (records[i].库存 - preItem.库存) / timeSpanDays;  // 库存的每日变化量
                Console.WriteLine(dec);

                for (var j = timeSpanDays; j > 0; j--)
                {
                    var st = t.AddDays(-j);
                    var addItem = new 周库存
                    {
                        日期 = st.ToString("yyyy-MM-dd"),
                        库存 = records[i].库存 - dec * j,
                    };

                    周库存2019.Add(addItem);

                    sb.AppendFormat("{0},{1}", st.ToString("yyyy-MM-dd"), addItem.库存);
                    sb.AppendLine();
                }
            }

            File.WriteAllText("kc.csv", sb.ToString());
        }

        private static void 发货量处理()
        {

            var filename = "发货量.txt";

            var txt = File.ReadAllText(filename, Encoding.Default);

            var records = ServiceStack.Text.CsvSerializer.DeserializeFromString<List<发货量>>(txt);


            List<发货量> 发货量2019 = new List<发货量>();

            for (var i = 0; i < records.Count; i++)
            {
                var t = DateTime.Parse(records[i].日期);

                for (var j = 6; j >= 0; j--)
                {
                    var st = t.AddDays(-j);
                    发货量2019.Add(new 发货量
                    {
                        日期 = st.ToString("yyyy-MM-dd"),
                        澳大利亚 = records[i].澳大利亚 / 7,
                        巴西 = records[i].巴西 / 7,
                    });
                }
            }

            // 这里处理预期到货量
            // 澳大利亚 15天到货, 巴西 40天到货

            List<发货量> 到货量 = new List<发货量>();

            foreach (var 发货 in 发货量2019)
            {
                var t = DateTime.Parse(发货.日期);
                var 澳大利亚到货日 = t.AddDays(15).ToString("yyyy-MM-dd");
                var 巴西到货日 = t.AddDays(40).ToString("yyyy-MM-dd");

                var item = 到货量.FirstOrDefault(o => o.日期 == 澳大利亚到货日);

                if (item == null)
                {
                    item = new 发货量
                    {
                        日期 = 澳大利亚到货日,
                    };
                    到货量.Add(item);
                }
                item.澳大利亚 = 发货.澳大利亚;

                item = 到货量.FirstOrDefault(o => o.日期 == 巴西到货日);

                if (item == null)
                {
                    item = new 发货量
                    {
                        日期 = 巴西到货日,
                    };
                    到货量.Add(item);
                }
                item.巴西 = 发货.巴西;
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in 到货量.OrderBy(o => o.日期))
            {
                sb.AppendFormat("{0},{1},{2}", item.日期, item.澳大利亚, item.巴西);
                sb.AppendLine();
            }

            File.WriteAllText("t2.csv", sb.ToString());
        }

        private static void 到货量处理()
        {

            var fileName = "到货量.txt";
            var txt = File.ReadAllText(fileName);

            var records = ServiceStack.Text.CsvSerializer.DeserializeFromString<List<到货量>>(txt);


            List<到货量> 到货量2019 = new List<到货量>();

            var start = DateTime.Parse("2019-1-1");

            for (var i = 0; i < records.Count; i++)
            {
                var t = DateTime.Parse(records[i].日期);

                for (var j = 6; j >= 0; j--)
                {
                    var st = t.AddDays(-j);
                    到货量2019.Add(new 到货量
                    {
                        日期 = st.ToString("yyyy-MM-dd"),
                        到港量 = records[i].到港量 / 7
                    });
                }
            }

            // Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(到货量2019, Newtonsoft.Json.Formatting.Indented));

            // 统计每个月到港量

            foreach (var group in 到货量2019.GroupBy(o => DateTime.Parse(o.日期).Month))
            {
                var s = $"{@group.Sum(o => o.到港量)}\n";
                Console.WriteLine(s);
                File.AppendAllText("t.txt", s);
            }
        }
    }

    public class 到货量
    {
        public string 日期 { get; set; }

        public double 到港量 { get; set; }
    }

    public class 周库存
    {
        public string 日期 { get; set; }

        public double 库存 { get; set; }
    }

    public class 发货量
    {
        public string 日期 { get; set; }

        public double 澳大利亚 { get; set; }
        public double 巴西 { get; set; }
    }
}
