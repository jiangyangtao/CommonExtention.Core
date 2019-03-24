using CommonExtention.Core.Extensions;
using CommonExtention.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// 异步日志记录，不占用当前主线程。此类不可被继承
    /// </summary>
    public sealed class AsyncLogger
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="AsyncLogger"/> 类的新实例
        /// </summary>
        public AsyncLogger() { }
        #endregion

        #region 记录异常
        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> 对象</param>
        /// <param name="request"><see cref="HttpRequest"/> 对象</param>
        public static void LogException(Exception exception, HttpRequest request)
            => new AsyncLogException(BeginLogException).BeginInvoke(exception, request, null, null);
        #endregion

        #region 记录关键信息
        /// <summary>
        /// 记录关键信息
        /// </summary>
        /// <param name="information">关键信息</param>
        /// <param name="request"><see cref="HttpRequest"/> 对象</param>
        public static void LogInformation(string information, HttpRequest request) =>
             new AsyncLogInformation(BeginLogInformation).BeginInvoke(information, request, null, null);
        #endregion

        #region 记录Mvc请求信息
        /// <summary>
        /// 记录Mvc请求信息
        /// </summary>
        /// <param name="model"><see cref="MvcRequest"/> 对象</param>
        /// <param name="request"><see cref="HttpRequest"/> 对象</param>
        public static void LogMvcRequest(MvcRequest model, HttpRequest request)
            => new AsyncLogMvcRequest(BeginLogMvcRequest).BeginInvoke(model, request, null, null);
        #endregion

        #region 异步方法
        /// <summary>
        /// 委托方式的异步写入异常
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> 对象</param>
        /// <param name="request"><see cref="HttpRequest"/> 对象</param>
        private delegate void AsyncLogException(Exception exception, HttpRequest request);

        /// <summary>
        /// 委托方式的异步写入关键信息
        /// </summary>
        /// <param name="information">关键信息</param>
        /// <param name="request"><see cref="HttpRequest"/> 对象</param>
        private delegate void AsyncLogInformation(string information, HttpRequest request);

        /// <summary>
        /// 委托方式的异步写入Mvc请求信息
        /// </summary>
        /// <param name="model"><see cref="MvcRequest"/> 对象</param>
        /// <param name="request"><see cref="HttpRequest"/> 对象</param>
        private delegate void AsyncLogMvcRequest(MvcRequest model, HttpRequest request);
        #endregion

        #region 异步记录    
        /// <summary>
        /// 异步写入异常
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> 对象</param>
        /// <param name="request"><see cref="HttpRequest"/> 对象</param>
        private static void BeginLogException(Exception exception, HttpRequest request)
        {
            if (exception == null || request == null) return;

            var _path = GetLogPath("error.txt");

            //允许多个线程同时写入
            using (var fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                var streamWrite = new StreamWriter(fileStream, Encoding.Default);

                try
                {
                    streamWrite.BaseStream.Seek(0, SeekOrigin.End);
                    streamWrite.WriteLine(DateTime.Now.ToFormatDateTime());
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n  异常信息：");
                    streamWrite.WriteLine($"\r\n\t请求地址：{request.Url()}");
                    streamWrite.WriteLine($"\r\n\t请求参数：{request.GetParamsString()}");
                    streamWrite.WriteLine($"\r\n\t错误代码：{exception.HResult}");
                    streamWrite.WriteLine($"\r\n\t错误信息：{exception.ExceptionMessage()}");
                    streamWrite.WriteLine($"\r\n\t错 误 源：{exception.Source}");
                    streamWrite.WriteLine($"\r\n\t异常方法：{exception.TargetSite}");
                    streamWrite.WriteLine($"\r\n\t堆栈信息：{exception.StackTrace}");
                    streamWrite.WriteLine($"\r\n\t线程  ID：{Thread.CurrentThread.ManagedThreadId}");
                    streamWrite.WriteLine($"\r\n\t浏览器标识：{request.UserAgent()}");
                    streamWrite.WriteLine("\r\n");

                    //日志分隔线
                    streamWrite.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n");
                }
                finally
                {
                    streamWrite.Flush();
                    streamWrite.Close();
                }
            }
        }

        /// <summary>
        /// 异步写入关键信息
        /// </summary>
        /// <param name="information">关键信息</param>
        /// <param name="request"><see cref="HttpRequest"/> 对象</param>
        private static void BeginLogInformation(string information, HttpRequest request)
        {
            if (information.IsNullOrEmpty() || request == null) return;

            var _path = GetLogPath("key.txt");

            //允许多个线程同时写入
            using (var fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                var streamWrite = new StreamWriter(fileStream, Encoding.Default);
                try
                {
                    streamWrite.BaseStream.Seek(0, SeekOrigin.End);
                    streamWrite.WriteLine(DateTime.Now.ToFormatDateTime());
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine($"\r\n\t请求地址：{request.Url()}");
                    streamWrite.WriteLine($"\r\n\t记录信息：{information}");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine($"\r\n\t浏览器标识：{request.UserAgent()}");

                    //日志分隔线
                    streamWrite.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n");
                }
                finally
                {
                    streamWrite.Flush();
                    streamWrite.Close();
                }
            }
        }

        /// <summary>
        /// 异步写入请求信息
        /// </summary>
        /// <param name="model"><see cref="MvcRequest"/> 对象</param>
        /// <param name="request"><see cref="HttpRequest"/> 对象</param>
        private static void BeginLogMvcRequest(MvcRequest model, HttpRequest request)
        {
            if (model == null || request == null) return;

            var _path = GetLogPath("request.txt");

            //允许多个线程同时写入
            using (var fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                var streamWrite = new StreamWriter(fileStream, Encoding.Default);
                try
                {
                    streamWrite.BaseStream.Seek(0, SeekOrigin.End);
                    streamWrite.WriteLine(DateTime.Now.ToFormatDateTime());
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n  请求信息：");
                    streamWrite.WriteLine($"\r\n\t浏览器标识：{model.UserAgent}");
                    streamWrite.WriteLine($"\r\n\t请求地址：{model.Url}");
                    streamWrite.WriteLine($"\r\n\t请求参数：{model.Params}");
                    streamWrite.WriteLine($"\r\n\t请求类型：{model.RequestType}");
                    streamWrite.WriteLine($"\r\n\t控制器名：{model.ControllerName}");
                    streamWrite.WriteLine($"\r\n\tAction名：{model.ActionName}");
                    streamWrite.WriteLine($"\r\n\tIp  地址：{model.IpAddress}");
                    streamWrite.WriteLine($"\r\n\t线程  ID：{model.ThreadId}");
                    streamWrite.WriteLine($"\r\n\t消耗时间：{model.ConsumingTime} s");

                    //日志分隔线
                    streamWrite.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n");
                    streamWrite.WriteLine("\r\n");
                }
                finally
                {
                    streamWrite.Flush();
                    streamWrite.Close();
                }
            }
        }
        #endregion

        #region 获取日志路径
        /// <summary>
        /// 获取日志路径
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>当前日志路径</returns>
        private static string GetLogPath(string fileName)
        {
            var strBuilder = new StringBuilder(Path.Combine(Directory.GetCurrentDirectory())).
                    Append(@"\log\").
                    Append(DateTime.Now.ToFormatDate()).
                    Append(" ").
                    Append(fileName);

            var path = strBuilder.ToString();
            var fileInfo = new FileInfo(path);
            var dir = fileInfo.Directory;
            if (!dir.Exists) dir.Create();    //如果文件夹不存在，则创建
            return path;
        }
        #endregion
    }
}
