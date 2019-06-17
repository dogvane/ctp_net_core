using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace 期货数据爬虫.持仓
{
    /// <summary>
    ///     持仓数据
    /// </summary>
    public class Interest
    {
        [PrimaryKey] public string Id { get; set; }

        public string 品种 { get; set; }

        public string Code { get; set; }

        public int 交割月份 { get; set; }

        public int Date { get; set; }

        public int 持仓量 { get; set; }

        public List<InterestItem> 成交量 { get; set; }

        public List<InterestItem> 多单 { get; set; }

        public List<InterestItem> 空单 { get; set; }
    }


    public class InterestItem
    {
        public string 机构名称 { get; set; }

        public string 机构Id { get; set; }

        public int 数量 { get; set; }

        public int 变化 { get; set; }

        public int 排名 { get; set; }
    }
}