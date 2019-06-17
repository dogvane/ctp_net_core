using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entitys
{
    /// <summary>
    /// 代码
    /// </summary>
    public class 期货代码
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 代码类型
        /// 0 表示大类
        /// 1 表示具体到每个月的代码
        /// </summary>
        public int 类型 { get; set; }

        /// <summary>
        /// 代码，完整代日期
        /// </summary>
        public string 代码 { get; set; }

        /// <summary>
        /// 短代码
        /// </summary>
        public string 短代码 { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string 名字 { get; set; }

        /// <summary>
        /// 交割月份
        /// </summary>
        public int 交割月份 { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public int 年份 { get; set; }
    }
}
