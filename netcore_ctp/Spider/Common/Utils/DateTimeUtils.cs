using System;

namespace Common.Utils
{
    public static class DateTimeUtils
    {
        public static string GetShortDate(this DateTime datetime)
        {
            return datetime.ToString("yyyyMMdd");
        }
    }
}