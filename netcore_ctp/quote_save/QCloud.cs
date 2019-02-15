using Common;
using COSXML;
using COSXML.Auth;
using COSXML.Model.Bucket;
using COSXML.Model.Object;
using COSXML.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace quote_save
{
    public class QCloud
    {
        public QCloud()
        {
            LoadConfigs();

            var config = new CosXmlConfig.Builder()
                .SetConnectionTimeoutMs(60000)  //设置连接超时时间，单位 毫秒 ，默认 45000ms
                .SetReadWriteTimeoutMs(40000)  //设置读写超时时间，单位 毫秒 ，默认 45000ms
                .IsHttps(true)  //设置默认 https 请求
                .SetAppid(appid)  //设置腾讯云账户的账户标识 APPID
                .SetRegion(region)  //设置一个默认的存储桶地域
                .SetDebugLog(true)  //显示日志
                .Build();  //创建 CosXmlConfig 对象

            cosCredentialProvider = new DefaultQCloudCredentialProvider(secretId, secretKey, durationSecond);

            cosSserver = new CosXmlServer(config, cosCredentialProvider);
        }

        void LoadConfigs()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("appsettings.debug.json", true, true);

            var configBuilder = builder.Build();
            var section = configBuilder.GetSection("qcloud");
            if (section == null)
            {
                Logger.Error("not find config file.");
                return;
            }

            appid = section["appid"];
            bucketName = section["bucketName"];
            region = section["region"];
            secretId = section["secretId"];
            secretKey = section["secretKey"];
        }

        CosXmlServer cosSserver;

        //初始化 QCloudCredentialProvider ，SDK中提供了3种方式：永久密钥 、 临时密钥  、 自定义 
        QCloudCredentialProvider cosCredentialProvider = null;

        //方式1， 永久密钥
        string bucketName = ""; // 可以算根目录，建议：qihuo
        string appid = "";//设置腾讯云账户的账户标识 APPID
        string region = ""; //设置一个默认的存储桶地域（ap-shanghai）
        string secretId = ""; //"云 API 密钥 SecretId";
        string secretKey = ""; //"云 API 密钥 SecretKey";
        long durationSecond = 600;  //secretKey 有效时长,单位为 秒

        public void UploadFile(string fileName, string localFileName)
        {
            try
            {
                string bucket = bucketName + "-" + appid; //存储桶，格式：BucketName-APPID
                PutObjectRequest request = new PutObjectRequest(bucket, fileName, localFileName);
                //设置签名有效时长
                request.SetSign(TimeUtils.GetCurrentTime(TimeUnit.SECONDS), 600);

                //执行请求
                PutObjectResult result = cosSserver.PutObject(request);
                //请求成功
                // Console.WriteLine(result.GetResultInfo());
            }
            catch (COSXML.CosException.CosClientException clientEx)
            {
                //请求失败
                Console.WriteLine("CosClientException: " + clientEx.Message);
            }
            catch (COSXML.CosException.CosServerException serverEx)
            {
                //请求失败
                Console.WriteLine("CosServerException: " + serverEx.GetInfo());
            }
        }

        public void CreateBucke(string name)
        {
            try
            {
                // string bucket = "examplebucket-1250000000"; //存储桶名称 格式：BucketName-APPID
                PutBucketRequest request = new PutBucketRequest(name);
                //设置签名有效时长
                request.SetSign(TimeUtils.GetCurrentTime(TimeUnit.SECONDS), 600);
                //执行请求
                PutBucketResult result = cosSserver.PutBucket(request);
                //请求成功
                Console.WriteLine(result.GetResultInfo());
            }
            catch (COSXML.CosException.CosClientException clientEx)
            {
                //请求失败
                Console.WriteLine("CosClientException: " + clientEx.Message);
            }
            catch (COSXML.CosException.CosServerException serverEx)
            {
                //请求失败
                Console.WriteLine("CosServerException: " + serverEx.GetInfo());
            }
        }
    }
         
}
