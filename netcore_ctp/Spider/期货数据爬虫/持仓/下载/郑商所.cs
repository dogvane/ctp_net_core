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
    /// 郑州商品交易所
    /// </summary>
    public class 郑商所
    {
        /// <summary>
        ///     下载某天的数据
        /// </summary>
        public bool 下载(string date)
        {
            // var date = DateTime.Now.GetShortDate();
            var saveFile = Path.Combine(Utils.GetDataFileBasePath, $"Interest/ZhengZhou/{date.Substring(0, 4)}/{date}.txt");
            if (File.Exists(saveFile))
                return true;

            var fi = new FileInfo(saveFile);
            if (!fi.Directory.Exists)
                fi.Directory.Create();

            try
            {
                var url =
                    $"http://www.czce.com.cn/cn/DFSStaticFiles/Future/{date.Substring(0, 4)}/{date}/FutureDataHolding.txt";
                Console.WriteLine(url);
                var client = new WebClient();
                var bytes = client.DownloadData(url);
                var text = Encoding.Default.GetString(bytes);
                File.WriteAllText(saveFile, text);

                return true;
            }
            catch (Exception e)
            {
                Logs.Error("郑商所.下载持仓数据四边", e);
                return false;
            }
        }
    }
}
