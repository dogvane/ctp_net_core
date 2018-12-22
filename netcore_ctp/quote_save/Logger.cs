using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    /// <summary>
    /// 默认的日志记录器
    /// 项目使用NLog记录日志
    /// 但不直接使用NLog的接口
    /// 而是自定义的一条日志接口和实现
    /// 这样可以方便切换日志组件
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// 默认构造方法
        /// </summary>
        static Logger()
        {
            var nLogfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nlog.config");
            if (File.Exists(nLogfile))
            {
                // 按照文件进行初始化
                LogManager.LoadConfiguration(nLogfile);
                s_logger = LogManager.GetCurrentClassLogger();
            }
            else
            {
                var config = new LoggingConfiguration();

                var console = new ConsoleTarget();
                console.Layout = @"${date:format=HH\:mm\:ss} ${logger} [${level}] ${message}";
                config.AddTarget("console", console);

                var file = new FileTarget();
                config.AddTarget("file", file);

                file.Layout = @"${date:format=yyyy-MM-dd HH\:mm\:ss.fff} ${logger} [${level}] ${message} ${onexception:inner=${newline}[Exception]${exception:format=ToString}}";
                file.FileName = "${basedir}/logs/log${date:format=yyyyMMdd}.txt";
                file.ArchiveDateFormat = "yyyyMMdd";
                file.ArchiveEvery = FileArchivePeriod.Day;
                file.BufferSize = 1024 * 1024;
                file.CreateDirs = true;

                var rule1 = new LoggingRule("*", LogLevel.Info, console);
                config.LoggingRules.Add(rule1);

                var rule2 = new LoggingRule("*", LogLevel.Info, file);
                config.LoggingRules.Add(rule2);

                LogManager.Configuration = config;

                s_logger = LogManager.GetLogger("");
            }
        }

        static ILogger s_logger;

        /// <summary>
        /// 输出Debug信息
        /// </summary>
        /// <param name="message">日志消息</param>
        public static void Debug(string message)
        {
            s_logger.Debug(message);
        }

        /// <summary>
        /// 输出Debug信息
        /// </summary>
        /// <param name="format">日志格式 {0} {1} 的替换方式</param>
        /// <param name="param">替换参数</param>
        public static void Debug(string format, params object[] param)
        {
            s_logger.Debug(format, param);
        }

        /// <summary>
        /// 输出Info信息
        /// </summary>
        /// <param name="message">日志消息</param>
        public static void Info(string message)
        {
            s_logger.Info(message);
        }

        /// <summary>
        /// 输出Info信息
        /// </summary>
        /// <param name="format">日志格式 {0} {1} 的替换方式</param>
        /// <param name="param">替换参数</param>
        public static void Info(string format, params object[] param)
        {
            s_logger.Info(format, param);
        }

        /// <summary>
        /// 输出Warn信息
        /// </summary>
        /// <param name="message">日志消息</param>
        public static void Warn(string message)
        {
            s_logger.Warn(message);
        }

        /// <summary>
        /// 输出Warn信息
        /// </summary>
        /// <param name="format">日志格式 {0} {1} 的替换方式</param>
        /// <param name="param">替换参数</param>
        public static void Warn(string format, params object[] param)
        {
            s_logger.Warn(format, param);
        }

        /// <summary>
        /// 输出Error信息
        /// </summary>
        /// <param name="message">日志消息</param>
        public static void Error(string message)
        {
            s_logger.Error(message);
        }

        /// <summary>
        /// 输出Error信息
        /// </summary>
        /// <param name="format">日志格式 {0} {1} 的替换方式</param>
        /// <param name="param">替换参数</param>
        public static void Error(string format, string param)
        {
            s_logger.Error(format, param);
        }

        /// <summary>
        /// 输出Error信息
        /// </summary>
        /// <param name="format">日志格式 {0} {1} 的替换方式</param>
        /// <param name="param">替换参数</param>
        public static void Error(string format, int param)
        {
            s_logger.Error(format, param);
        }

        /// <summary>
        /// 输出Error信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="message">日志消息</param>
        public static void Error(Exception ex, string message)
        {
            s_logger.Error(ex, message);
        }

        /// <summary>
        /// 输出Error信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="message">日志消息</param>
        public static void Error(string message, Exception ex)
        {
            s_logger.Error(ex, message);
        }

        /// <summary>
        /// 输出Error信息
        /// </summary>
        /// <param name="format">日志格式 {0} {1} 的替换方式</param>
        /// <param name="param">替换参数</param>
        public static void Error(Exception ex, string format, params object[] param)
        {
            s_logger.Error(ex, format, param);
        }

        /// <summary>
        /// 输出Error信息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="param1">替换参数</param>
        /// <param name="param2">替换参数</param>
        public static void Error(string message, string param1, string param2)
        {
            s_logger.Error(message, new object[] { param1, param2 });
        }

        /// <summary>
        /// 输出Error信息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="param1">替换参数</param>
        /// <param name="param2">替换参数</param>
        /// <param name="param3">替换参数</param>
        public static void Error(string message, string param1, string param2, string param3)
        {
            s_logger.Error(message, new object[] { param1, param2, param3 });
        }

        /// <summary>
        /// 输出Error信息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="param1">替换参数</param>
        /// <param name="ex">异常</param>
        public static void Error(Exception ex, string message, string param1)
        {
            s_logger.Error(ex, message, param1);
        }

        /// <summary>
        /// 输出Error信息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="ex">异常</param>
        /// <param name="param1">替换参数</param>
        /// <param name="param2">替换参数</param>
        public static void Error(Exception ex, string message, string param1, string param2)
        {
            s_logger.Error(ex, message, param1, param2);
        }

        /// <summary>
        /// 输出Error信息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="ex">异常</param>
        /// <param name="param1">替换参数</param>
        /// <param name="param2">替换参数</param>
        /// <param name="param3">替换参数</param>
        public static void Error(Exception ex, string message, string param1, string param2, string param3)
        {
            s_logger.Error(ex, message, param1, param2, param3);
        }

    }
}
