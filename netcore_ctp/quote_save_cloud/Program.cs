using System;
using System.Diagnostics;
using System.IO;
using Common;

namespace quote_save_cloud
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "./";
            if (args.Length > 0)
            {
                path = args[0];
            }

            if (!Directory.Exists(path))
            {
                Logger.Error("数据目录不存在 path=" + path);
            }

            Stopwatch watch = Stopwatch.StartNew();

            var date = DateTime.Now.ToString("yyyyMMdd");
            new SaveToQCloud().Upload(date, new DirectoryInfo(path).FullName);

            Logger.Info($"保存完成 耗时 {watch.ElapsedMilliseconds} ms");
        }
    }
}
