using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace 期货数据爬虫.交易日历
{
    public class 下载并转换
    {
        // http://www.shfe.com.cn/js/calendar-data.js?190617221150

        /// <summary>
        /// 这里只是上海交易所的日期
        /// 理论上郑州和大连的的应该不一样
        /// 但,实际上,我们用不了这么多年的数据
        /// 因为,太前面的数据参考的意义已经不大了
        /// </summary>
        /// <returns></returns>
        public string[] GetTradeDay()
        {
            var client = new WebClient();
            var url = "http://www.shfe.com.cn/js/calendar-data.js";
            var bytes = client.DownloadData(url);

            var txt = Encoding.Default.GetString(bytes);

            var json = txt.Substring(27, txt.Length - 27 - 4);

            var obj = Newtonsoft.Json.Linq.JObject.Parse(json);

            List<string> ret = new List<string>(32 * 1024);
            foreach (var s in obj.PropertyValues())
            {
                ret.AddRange(s.ToString().Split(","));
            }

            return ret.ToArray();
        }
    }
}
