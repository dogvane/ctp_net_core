using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace 期货数据爬虫.Common
{
    public static class Extends
    {


        public static double GetDouble(this JToken obj)
        {
            var str = obj.ToString();
            if (string.IsNullOrEmpty(str))
                return 0;

            return double.Parse(str);
        }

        public static double GetDouble(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            str = str.Replace(",", "");

            return double.Parse(str);
        }

        public static int GetInteger(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            str = str.Replace(",", "");

            return (int)double.Parse(str);
        }

        /// <summary>
        /// 将常见的字符串,格式化为csv可识别的样式
        /// 先把 , 删除,把\t替换为, 多个\t只视为一个
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FixLineToCsv(this string str)
        {
            StringBuilder sb = new StringBuilder(str);

            sb.Replace(",", "");

            int length = sb.Length;
            while (true)
            {
                sb.Replace("\t\t", "\t");
                if (sb.Length == length)
                    break;

                length = sb.Length;
            }

            sb.Replace("\t", ",");

            return sb.ToString();
        }
    }
}
