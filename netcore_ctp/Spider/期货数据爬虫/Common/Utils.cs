using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace 期货数据爬虫.Common
{
    public class Utils
    {
        public static string GetDataFileBasePath
        {
            get
            {
                var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "../../../../Data");
                if (!dir.Exists)
                    dir.Create();

                return dir.FullName;
            }
        }
    }
}
