using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using 期货数据爬虫.Common;

namespace 期货数据爬虫.持仓.转换
{
    public class 大商所
    {
        /// <summary>
        ///     解析那天的数据
        /// </summary>
        /// <param name="date"></param>
        public Interest[] Parse(string date)
        {
            var ret = new List<Interest>();
            var saveFile = Path.Combine(Utils.GetDataFileBasePath, $"Interest/DaLian/{date.Substring(0, 4)}/{date}.zip");
            if (!File.Exists(saveFile))
                return ret.ToArray();


            // 这里要读zip文件

            var zip = new System.IO.Compression.ZipArchive(File.OpenRead(saveFile), System.IO.Compression.ZipArchiveMode.Read);

            foreach (var entity in zip.Entries)
            {
                Console.WriteLine(entity.FullName);
                var stream = entity.Open();

                using (var s = new StreamReader(stream))
                {
                    // var insterst = GetInterest(s.());
                    // ret.Add(insterst);
                }
            }
            Console.WriteLine(zip.Entries.Count);

            return ret.ToArray();
        }

        Interest GetInterest(string[] txt)
        {
            Interest ret = new Interest();




            return ret;
        }
    }
}
