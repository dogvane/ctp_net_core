using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace Common.Entitys
{
    /// <summary>
    ///     持仓数据
    /// </summary>
    public class 持仓数据
    {
        [PrimaryKey] public string Id { get; set; }

        public string 品种 { get; set; }

        public string Code { get; set; }

        public int 交割月份 { get; set; }

        public int Date { get; set; }

        public int 持仓量 { get; set; }

        public List<机构商持仓项> 成交量 { get; set; }

        public List<机构商持仓项> 多单 { get; set; }

        public List<机构商持仓项> 空单 { get; set; }
    }


    public class 机构商持仓项
    {
        public string 机构名称 { get; set; }

        public string 机构Id { get; set; }

        public int 数量 { get; set; }

        public int 变化 { get; set; }

        public int 排名 { get; set; }
    }
}