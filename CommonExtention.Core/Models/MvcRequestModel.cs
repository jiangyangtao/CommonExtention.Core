using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Models
{
    /// <summary>
    /// Mvc请求信息。此类不可被继承
    /// </summary>
    public sealed class MvcRequestModel
    {
        /// <summary>
        /// 请求的控制器名
        /// </summary>
        public string ControllerName { set; get; }

        /// <summary>
        /// 请求的Action名
        /// </summary>
        public string ActionName { set; get; }

        /// <summary>
        /// 请求的方式(get/post/delete/put/patch)
        /// </summary>
        public string RequestType { set; get; }

        /// <summary>
        /// 请求的参数
        /// </summary>
        public IDictionary<string, object> Params { set; get; }

        /// <summary>
        /// 请求链接
        /// </summary>
        public string Url { set; get; }

        /// <summary>
        /// 浏览器标识
        /// </summary>
        public string UserAgent { set; get; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { set; get; }

        /// <summary>
        /// 运行时间
        /// </summary>
        public string RunTime { set; get; }
    }
}
