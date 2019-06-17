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
    }
}
