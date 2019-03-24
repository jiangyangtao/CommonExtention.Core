using System.Collections.Generic;

namespace CommonExtention.Core.Models
{
    /// <summary>
    /// Mvc请求信息。此类不可被继承
    /// </summary>
    public sealed class MvcRequest
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
        public string Params { set; get; }

        /// <summary>
        /// 请求链接
        /// </summary>
        public string Url { set; get; }

        /// <summary>
        /// 浏览器标识
        /// </summary>
        public string UserAgent { set; get; }

        /// <summary>
        /// 线程ID
        /// </summary>
        public int ThreadId { set; get; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { set; get; }

        /// <summary>
        /// 消耗的时间(单位：秒)
        /// </summary>
        public string ConsumingTime { set; get; }
    }
}
