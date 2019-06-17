using Common.Log;
using System;
using System.IO;
using System.Net;
using System.Text;
using 期货数据爬虫.Common;

namespace 期货数据爬虫.K线.下载
{
    /// <summary>
    ///     上海日K的数据下载
    /// </summary>
    public class 上期所
    {
        /// <summary>
        ///     下载某天的数据
        /// </summary>
        public bool 下载(string date)
        {
            // var date = DateTime.Now.GetShortDate();
            var saveFile = Path.Combine(Utils.GetDataFileBasePath, $"KLine/Shanghai/{date.Substring(0, 4)}/{date}.txt");
            if (File.Exists(saveFile))
                return true;

            var fi = new FileInfo(saveFile);
            if (!fi.Directory.Exists)
                fi.Directory.Create();

            var url = string.Format($"http://www.shfe.com.cn/data/dailydata/kx/kx{date}.dat");

            try
            {
                var client = new WebClient();
                var bytes = client.DownloadData(url);
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