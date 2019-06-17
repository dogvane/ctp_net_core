using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Common.Log;
using 期货数据爬虫.Common;

namespace 期货数据爬虫.持仓.下载
{
    /// <summary>
    /// 大商所
    /// </summary>
    public class 大商所
    {
        /// <summary>
        ///     下载某天的数据
        /// </summary>
        public bool 下载(string date)
        {
            // var date = DateTime.Now.GetShortDate();
            var saveFile = Path.Combine(Utils.GetDataFileBasePath, $"Interest/DaLian/{date.Substring(0, 4)}/{date}.zip");
            if (File.Exists(saveFile))
                return true;

            var fi = new FileInfo(saveFile);
            if (!fi.Directory.Exists)
                fi.Directory.Create();
            // /publicweb/quotesdata/exportDayQuotesChData.html
            var url = string.Format($"http://www.dce.com.cn//publicweb/quotesdata/exportMemberDealPosiQuotesBatchData.html");

            try
            {
                var client = new WebClient();
                StringBuilder sb = new StringBuilder();

                sb.Append("&batchExportFlag=batch");
                sb.AppendFormat($"&year={date.Substring(0, 4)}");
                sb.AppendFormat($"&month={date.Substring(4, 2)}");
                sb.AppendFormat($"&day={date.Substring(6, 2)}");

                var bytes = client.UploadData(url, Encoding.Default.GetBytes(sb.ToString()));

                File.WriteAllBytes(saveFile, bytes);
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
