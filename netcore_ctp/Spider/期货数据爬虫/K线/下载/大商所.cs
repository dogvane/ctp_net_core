using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Common.Log;
using 期货数据爬虫.Common;

namespace 期货数据爬虫.K线.下载
{
    /// <summary>
    /// 郑州商品交易所
    /// </summary>
    public class 大商所
    {
        /// <summary>
        ///     下载某天的数据
        /// </summary>
        public bool 下载(string date)
        {
            // var date = DateTime.Now.GetShortDate();
            var saveFile = Path.Combine(Utils.GetDataFileBasePath, $"KLine/DaLian/{date.Substring(0, 4)}/{date}.txt");
            if (File.Exists(saveFile))
                return true;

            var fi = new FileInfo(saveFile);
            if (!fi.Directory.Exists)
                fi.Directory.Create();
            // http://www.dce.com.cn/dalianshangpin/xqsj/tjsj26/rtj/rxq/index.html
            var url = string.Format($"http://www.dce.com.cn//publicweb/quotesdata/exportDayQuotesChData.html");

            try
            {
                var client = new WebClient();
                StringBuilder sb = new StringBuilder();

                sb.Append("dayQuotes.variety=all");
                sb.Append("&dayQuotes.trade_type=0");
                sb.Append("&exportFlag=txt");
                sb.AppendFormat($"&year={date.Substring(0, 4)}");
                sb.AppendFormat($"&month={date.Substring(4, 2)}");
                sb.AppendFormat($"&day={date.Substring(6, 2)}");

                var bytes = client.UploadData(url, Encoding.Default.GetBytes(sb.ToString()));

                var text = Encoding.Default.GetString(bytes);
                File.WriteAllText(saveFile, text);
                return true;
            }
            catch (Exception e)
            {
                if (!e.Message.Contains("404"))
                {
                    Logs.Error(e.ToString());
                }

                return false;
            }
        }
    }
}
