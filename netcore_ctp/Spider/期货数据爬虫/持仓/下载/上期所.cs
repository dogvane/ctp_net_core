using Common.Log;
using System;
using System.IO;
using System.Net;
using System.Text;
using NLog;
using 期货数据爬虫.Common;

namespace 期货数据爬虫.持仓.下载
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
            try
            {
                // var date = DateTime.Now.GetShortDate();
                var saveFile = Path.Combine(Utils.GetDataFileBasePath, $"Interest/Shanghai/{date.Substring(0, 4)}/{date}.txt");
                if (File.Exists(saveFile))
                    return true;

                var fi = new FileInfo(saveFile);
                if (!fi.Directory.Exists)
                    fi.Directory.Create();

                var url = string.Format($"http://www.shfe.com.cn/data/dailydata/kx/pm{date}.dat");

                var client = new WebClient();
                var bytes = client.DownloadData(url);
                var text = Encoding.Default.GetString(bytes);
                File.WriteAllText(saveFile, text);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}