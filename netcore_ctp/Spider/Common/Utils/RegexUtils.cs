using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Utils
{
    /// <summary>
    /// 正则表达式的辅助类
    /// </summary>
    public static class RegexUtils
    {

        public static string Regex(this string str, string regex)
        {
            var reg = new Regex(regex);
            return reg.Match(str).Value;
        }

        public static bool In(this string str, params string[] containsStr)
        {
            foreach (var s in containsStr)
            {
                if (str.Contains(s))
                    return true;
            }

            return false;
        }
    }
}
