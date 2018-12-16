using CommonExtention.Core.Extensions;
using CommonExtention.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// 异步日志记录，不占用当前主线程。此类无法被继承
    /// </summary>
    public sealed class AsyncLogger
    {
        #region 记录异常
        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> 对象</param>
        /// <param name="request"><see cref="HttpRequest"/> 对象</param>
        public static void LogException(Exception exception, HttpRequest request)
        {
            if (exception == null) return;
            if (request == null) return;

            // 异步执行
            Task.Factory.StartNew(() =>
            {
                var _path = GetPath("error.txt");

                //允许多个进程同时写入
                using (var _fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                {
                    var _streamWrite = new StreamWriter(_fileStream, Encoding.Default);

                    try
                    {
                        _streamWrite.BaseStream.Seek(0, SeekOrigin.End);
                        _streamWrite.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        _streamWrite.WriteLine("\r\n");
                        _streamWrite.WriteLine("\r\n  异常信息：");
                        _streamWrite.WriteLine("\r\n\t请求地址：" + request.Url());
                        _streamWrite.WriteLine("\r\n\t错误信息：" + exception.ExceptionMessage());
                        _streamWrite.WriteLine("\r\n\t错 误 源：" + exception.Source);
                        _streamWrite.WriteLine("\r\n\t异常方法：" + exception.TargetSite);
                        _streamWrite.WriteLine("\r\n\t堆栈信息：" + exception.StackTrace);
                        _streamWrite.WriteLine("\r\n\t浏览器标识：" + request.UserAgent());
                        _streamWrite.WriteLine("\r\n");

                        //日志的分隔线
                        _streamWrite.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
                        _streamWrite.WriteLine("\r\n");
                        _streamWrite.WriteLine("\r\n");
                    }
                    finally
                    {
                        _streamWrite.Flush();
                        _streamWrite.Close();
                    }
                }
            });
        }
        #endregion

        #region 记录关键信息
        /// <summary>
        /// 记录关键信息
        /// </summary>
        /// <param name="information">关键信息</param>
        /// <param name="request"><see cref="HttpRequest"/> 对象</param>
        public static void LogInformation(string information, HttpRequest request)
        {
            if (information.IsNullOrEmpty()) return;
            if (request == null) return;

            // 异步执行
            Task.Factory.StartNew(() =>
            {
                var _path = GetPath("key.txt");

                //允许多个进程同时写入
                using (var _fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                {
                    var _streamWrite = new StreamWriter(_fileStream, Encoding.Default);
                    try
                    {
                        _streamWrite.BaseStream.Seek(0, SeekOrigin.End);
                        _streamWrite.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        _streamWrite.WriteLine("\r\n");
                        _streamWrite.WriteLine("\r\n");
                        _streamWrite.WriteLine("\r\n\t请求地址：" + request.Url());
                        _streamWrite.WriteLine("\r\n\t记录信息：" + information);
                        _streamWrite.WriteLine("\r\n");
                        _streamWrite.WriteLine("\r\n\t浏览器标识：" + request.UserAgent());

                        //日志的分隔线
                        _streamWrite.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
                        _streamWrite.WriteLine("\r\n");
                        _streamWrite.WriteLine("\r\n");
                        _streamWrite.WriteLine("\r\n");
                    }
                    finally
                    {
                        _streamWrite.Flush();
                        _streamWrite.Close();
                    }
                }
            });
        }
        #endregion

        #region 记录Mvc请求信息
        /// <summary>
        /// 记录Mvc请求信息
        /// </summary>
        /// <param name="model"><see cref="MvcRequestModel"/> 对象</param>
        /// <param name="request"><see cref="HttpRequest"/> 对象</param>
        public static void LogMvcRequest(MvcRequestModel model, HttpRequest request)
        {
            if (model == null) return;
            if (request == null) return;

            // 异步执行
            Task.Factory.StartNew(() =>
            {
                var _path = GetPath("request.txt");

                //允许多个进程同时写入
                using (var _fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                {
                    var _streamWrite = new StreamWriter(_fileStream, Encoding.Default);
                    try
                    {
                        _streamWrite.BaseStream.Seek(0, SeekOrigin.End);
                        _streamWrite.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        _streamWrite.WriteLine("\r\n");
                        _streamWrite.WriteLine("\r\n  请求信息：");
                        _streamWrite.WriteLine("\r\n\t浏览器标识：" + (model.UserAgent.IsNullOrEmpty() ? request.UserAgent() : model.UserAgent));
                        _streamWrite.WriteLine("\r\n\t请求地址：" + (model.Url.IsNullOrEmpty() ? request.Url() : model.Url));
                        _streamWrite.WriteLine("\r\n\t请求类型：" + model.RequestType);
                        _streamWrite.WriteLine("\r\n\t控制器名：" + model.ControllerName);
                        _streamWrite.WriteLine("\r\n\tAction名：" + model.ActionName);
                        if (model.IpAddress.NotNullAndEmpty()) _streamWrite.WriteLine("\r\n\tIp  地址：" + model.IpAddress);
                        if (model.RunTime.NotNullAndEmpty()) _streamWrite.WriteLine("\r\n\t消耗时间：" + model.RunTime + "s");
                        _streamWrite.WriteLine("\r\n\t参数信息：");
                        foreach (var item in model.Params)
                        {
                            _streamWrite.WriteLine("\r\n\t" + item.Key + "：" + item.Value);
                        }

                        //日志的分隔线
                        _streamWrite.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
                        _streamWrite.WriteLine("\r\n");
                        _streamWrite.WriteLine("\r\n");
                        _streamWrite.WriteLine("\r\n");
                    }
                    finally
                    {
                        _streamWrite.Flush();
                        _streamWrite.Close();
                    }
                }
            });
        }
        #endregion

        #region 获取当前日志路径
        /// <summary>
        /// 获取当前日志路径
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name = "hostingEnvironment" ><see cref="IHostingEnvironment"/> 接口</param>
        /// <returns>当前日志路径</returns>
        private static string GetPath(string fileName)
        {
            var strBuilder = new StringBuilder(Path.Combine(Directory.GetCurrentDirectory()));
            strBuilder.Append(@"\log\");
            strBuilder.Append(DateTime.Now.ToFormatDate());
            strBuilder.Append(" ");
            strBuilder.Append(fileName);

            var path = strBuilder.ToString();
            var _fileInfo = new FileInfo(path);
            var _dir = _fileInfo.Directory;
            if (!_dir.Exists) _dir.Create();    //如果文件夹不存在，则创建
            return path;
        }
        #endregion
    }
}
