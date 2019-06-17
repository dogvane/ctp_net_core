using System.Text;
using Newtonsoft.Json;
using ServiceStack.DataAnnotations;

namespace 期货数据爬虫.K线
{
    /// <summary>
    ///     k线
    /// </summary>
    public class KLine
    {
        [PrimaryKey] public string Id { get; set; }

        public string 品种 { get; set; }

        public string Code { get; set; }

        public int 交割月份 { get; set; }

        public int Date { get; set; }

        /// <summary>
        ///     日k，分钟k
        /// </summary>
        public int 周期 { get; set; }

        public double 前结算价 { get; set; }

        public double 前收盘价 { get; set; }

        public double 开盘价 { get; set; }

        public double 最高价 { get; set; }

        public double 最低价 { get; set; }

        public double 收盘价 { get; set; }

        public double 结算价 { get; set; }

        public int 成交量 { get; set; }

        public int 持仓量 { get; set; }

        /// <summary>
        /// 逗号分割均线数据
        /// </summary>
        public string 均线 { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}