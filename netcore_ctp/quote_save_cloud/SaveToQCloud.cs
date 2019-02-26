using Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace quote_save_cloud
{
    /// <summary>
    /// 将数据保存到腾讯云
    /// </summary>
    public class SaveToQCloud
    {
        QCloud qcloud = new QCloud();

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="localFileName">本地文件名</param>
        public void UploadFile(string fileName, string localFileName)
        {
            Logger.Info("upload csv file=" + fileName);
            qcloud.UploadFile(fileName, localFileName);
        }

        /// <summary>
        /// 上传数据
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="basePathName">路径</param>
        public void Upload(string date, string basePathName)
        {
            Logger.Info("upload csv file to cos: date={0}", date);

            var basePath = new DirectoryInfo(basePathName);
            var fileName = date + ".csv";
            foreach(var productPath in basePath.GetDirectories())
            {
                var productCode = productPath.Name;
                Console.WriteLine(productCode);
                foreach(var codePath in productPath.GetDirectories())
                {
                    var code = codePath.Name;
                    var csvFileName = Path.Combine(codePath.FullName, fileName);
                    if (File.Exists(csvFileName))
                    {
                        UploadFile(string.Format("tick/{0}/{1}/{2}", productCode, code, fileName), csvFileName);
                    }
                }
            }
        }
    }

    public class QCloudTest
    {
        public void TestUpload()
        {
            new SaveToQCloud().Upload("20181218", @"C:\Users\Dogvane\Desktop\Code\myctp\hf_ctp_py_proxy\netcore_ctp\quote_save\bin\Debug\netcoreapp2.1\data");
            return;
            var cloud = new QCloud();
            //cloud.CreateBucke("qihuo");
            //return;

            var fileName = @"C:\Users\Dogvane\Desktop\Code\myctp\hf_ctp_py_proxy\netcore_ctp\quote_save\bin\Debug\netcoreapp2.1\data\au\au1903\20190201.csv";
            cloud.UploadFile("123.csv", fileName);
        }
    }
         
}
