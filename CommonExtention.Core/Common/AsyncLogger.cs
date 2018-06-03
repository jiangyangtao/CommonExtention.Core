using CommonExtention.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// 异步日志记录，不占用当前主线程。此类无法被继承
    /// </summary>
    public sealed class AsyncLogger
    {
        //#region 静态方法
        ///// <summary>
        ///// 记录异常
        ///// </summary>
        ///// <param name="exception"><see cref="Exception"/> 对象</param>
        ///// <param name="context"><see cref="Microsoft.AspNetCore.Http.HttpContext"/> 对象</param>
        //public static void LogException(Exception exception, Microsoft.AspNetCore.Http.HttpContext context = null)
        //{
        //    //异步线程无法访问到主线程的HttpContext，所以要直接将主线程的HttpContext做为参数传给异步
        //    new AsyncLogException(BeginLogException).BeginInvoke(exception, context, null, null);
        //}

        ///// <summary>
        ///// 记录关键信息
        ///// </summary>
        ///// <param name="information">关键信息</param>
        ///// <param name="context"><see cref="Microsoft.AspNetCore.Http.HttpContext"/> 对象</param>
        //public static void LogInformation(string information, Microsoft.AspNetCore.Http.HttpContext context = null)
        //{
        //    //异步线程无法访问到主线程的HttpContext，所以要直接将主线程的HttpContext做为参数传给异步
        //    new AsyncLogInformation(BeginLogInformation).BeginInvoke(information, context, null, null);
        //}

        ///// <summary>
        ///// 记录Mvc请求信息
        ///// </summary>
        ///// <param name="model"><see cref="MvcRequestModel"/> 对象</param>
        ///// <param name="context"><see cref="Microsoft.AspNetCore.Http.HttpContext"/> 对象</param>
        //public static void LogMvcRequest(MvcRequestModel model, Microsoft.AspNetCore.Http.HttpContext context = null)
        //{
        //    //异步线程无法访问到主线程的HttpContext，所以要直接将主线程的HttpContext做为参数传给异步
        //    new AsyncLogMvcRequest(BeginLogMvcRequest).BeginInvoke(model, context, null, null);
        //}
        //#endregion

        //#region 异步方法
        ///// <summary>
        ///// 委托方式的异步写入异常
        ///// </summary>
        ///// <param name="exception"><see cref="Exception"/> 对象</param>
        ///// <param name="context"><see cref="Microsoft.AspNetCore.Http.HttpContext"/> 对象</param>
        //private delegate void AsyncLogException(Exception exception, Microsoft.AspNetCore.Http.HttpContext context);

        ///// <summary>
        ///// 委托方式的异步写入关键信息
        ///// </summary>
        ///// <param name="information">关键信息</param>
        ///// <param name="context"><see cref="Microsoft.AspNetCore.Http.HttpContext"/> 对象</param>
        //private delegate void AsyncLogInformation(string information, Microsoft.AspNetCore.Http.HttpContext context);

        ///// <summary>
        ///// 委托方式的异步写入Mvc请求信息
        ///// </summary>
        ///// <param name="model"><see cref="MvcRequestModel"/> 对象</param>
        ///// <param name="context"><see cref="Microsoft.AspNetCore.Http.HttpContext"/> 对象</param>
        //private delegate void AsyncLogMvcRequest(MvcRequestModel model, Microsoft.AspNetCore.Http.HttpContext context);
        //#endregion

        //#region 异步记录        
        ///// <summary>
        ///// 当前应用的相对路径
        ///// </summary>
        //private static readonly string _map = HttpRuntime.AppDomainAppPath + "log/" + DateTime.Now.ToString("yyyy-MM-dd") + " ";

        ///// <summary>
        ///// 异步写入异常
        ///// </summary>
        ///// <param name="exception"><see cref="Exception"/> 对象</param>
        ///// <param name="context"><see cref="Microsoft.AspNetCore.Http.HttpContext"/> 对象</param>
        //private static void BeginLogException(Exception exception, Microsoft.AspNetCore.Http.HttpContext context)
        //{
        //    if (exception != null)
        //    {
        //        var _path = _map + "error.txt";
        //        var _fileInfo = new FileInfo(_path);
        //        var _dir = _fileInfo.Directory;
        //        if (!_dir.Exists) _dir.Create();    //如果文件夹不存在，则创建

        //        //允许多个进程同时写入
        //        using (var _fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
        //        {
        //            var _streamWrite = new StreamWriter(_fileStream, Encoding.Default);

        //            try
        //            {
        //                _streamWrite.BaseStream.Seek(0, SeekOrigin.End);
        //                _streamWrite.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //                _streamWrite.WriteLine("\r\n");
        //                _streamWrite.WriteLine("\r\n  异常信息：");
        //                _streamWrite.WriteLine("\r\n\t请求地址：" + context.Request.Url.ToString());
        //                _streamWrite.WriteLine("\r\n\t错误信息：" + exception.ExceptionMessage());
        //                _streamWrite.WriteLine("\r\n\t错 误 源：" + exception.Source);
        //                _streamWrite.WriteLine("\r\n\t异常方法：" + exception.TargetSite);
        //                _streamWrite.WriteLine("\r\n\t堆栈信息：" + exception.StackTrace);
        //                _streamWrite.WriteLine("\r\n\t浏览器标识：" + context.Request.UserAgent);
        //                _streamWrite.WriteLine("\r\n");

        //                //日志的分隔线
        //                _streamWrite.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
        //                _streamWrite.WriteLine("\r\n");
        //                _streamWrite.WriteLine("\r\n");
        //            }
        //            finally
        //            {
        //                _streamWrite.Flush();
        //                _streamWrite.Close();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 异步写入关键信息
        ///// </summary>
        ///// <param name="information">关键信息</param>
        ///// <param name="context"><see cref="Microsoft.AspNetCore.Http.HttpContext"/> 对象</param>
        //private static void BeginLogInformation(string information, Microsoft.AspNetCore.Http.HttpContext context)
        //{
        //    var _path = _map + "key.txt";
        //    var _fileInfo = new FileInfo(_path);
        //    var _dir = _fileInfo.Directory;
        //    if (!_dir.Exists) _dir.Create();    //如果文件夹不存在，则创建

        //    //允许多个进程同时写入
        //    using (var _fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
        //    {
        //        var _streamWrite = new StreamWriter(_fileStream, Encoding.Default);
        //        try
        //        {
        //            _streamWrite.BaseStream.Seek(0, SeekOrigin.End);
        //            _streamWrite.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //            _streamWrite.WriteLine("\r\n");
        //            _streamWrite.WriteLine("\r\n");
        //            _streamWrite.WriteLine("\r\n\t请求地址：" + context.Request.Url.ToString());
        //            _streamWrite.WriteLine("\r\n\t记录信息：" + information);
        //            _streamWrite.WriteLine("\r\n");
        //            _streamWrite.WriteLine("\r\n\t浏览器标识：" + context.Request.UserAgent);

        //            //日志的分隔线
        //            _streamWrite.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
        //            _streamWrite.WriteLine("\r\n");
        //            _streamWrite.WriteLine("\r\n");
        //            _streamWrite.WriteLine("\r\n");
        //        }
        //        finally
        //        {
        //            _streamWrite.Flush();
        //            _streamWrite.Close();
        //        }
        //    }
        //}

        ///// <summary>
        ///// 异步写入请求信息
        ///// </summary>
        ///// <param name="model"><see cref="MvcRequestModel"/> 对象</param>
        ///// <param name="context"><see cref="Microsoft.AspNetCore.Http.HttpContext"/> 对象</param>
        //private static void BeginLogMvcRequest(MvcRequestModel model, Microsoft.AspNetCore.Http.HttpContext context)
        //{
        //    var _path = _map + "request.txt";
        //    var _fileInfo = new FileInfo(_path);
        //    var _dir = _fileInfo.Directory;
        //    if (!_dir.Exists) _dir.Create();    //如果文件夹不存在，则创建

        //    //允许多个进程同时写入
        //    using (var _fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
        //    {
        //        var _streamWrite = new StreamWriter(_fileStream, Encoding.Default);
        //        try
        //        {
        //            _streamWrite.BaseStream.Seek(0, SeekOrigin.End);
        //            _streamWrite.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //            _streamWrite.WriteLine("\r\n");
        //            _streamWrite.WriteLine("\r\n  请求信息：");
        //            _streamWrite.WriteLine("\r\n\t浏览器标识：" + (model.UserAgent.IsNullOrEmpty() ? context.Request.UserAgent : model.UserAgent));
        //            _streamWrite.WriteLine("\r\n\t请求地址：" + (model.Url.IsNullOrEmpty() ? context.Request.Url.ToString() : model.Url));
        //            _streamWrite.WriteLine("\r\n\t请求类型：" + model.RequestType);
        //            _streamWrite.WriteLine("\r\n\t控制器名：" + model.ControllerName);
        //            _streamWrite.WriteLine("\r\n\tAction名：" + model.ActionName);
        //            if (model.IpAddress.NotNullAndEmpty()) _streamWrite.WriteLine("\r\n\tIp  地址：" + model.IpAddress);
        //            if (model.RunTime.NotNullAndEmpty()) _streamWrite.WriteLine("\r\n\t消耗时间：" + model.RunTime + "s");
        //            _streamWrite.WriteLine("\r\n\t参数信息：");
        //            foreach (var item in model.Params)
        //            {
        //                _streamWrite.WriteLine("\r\n\t" + item.Key + "：" + item.Value);
        //            }

        //            //日志的分隔线
        //            _streamWrite.WriteLine("--------------------------------------------------------------------------------------------------------------\n");
        //            _streamWrite.WriteLine("\r\n");
        //            _streamWrite.WriteLine("\r\n");
        //            _streamWrite.WriteLine("\r\n");
        //        }
        //        finally
        //        {
        //            _streamWrite.Flush();
        //            _streamWrite.Close();
        //        }
        //    }
        //}
        //#endregion
    }
}
