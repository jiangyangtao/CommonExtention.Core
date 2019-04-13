using Microsoft.AspNetCore.Http;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="IHeaderDictionary"/> 扩展
    /// </summary>
    public static class IHeaderDictionaryExtensions
    {
        #region 获取当前请求的 UserAgent
        /// <summary>
        /// 获取当前请求的 UserAgent
        /// </summary>
        /// <param name="headerDictionary">HttpRequest</param>
        /// <returns>
        /// 如果当前 HttpRequest 对象为 null，则返回 <see cref="string.Empty"/>;
        /// 当前请求的 UserAgent
        /// </returns>
        public static string UserAgent(this IHeaderDictionary headerDictionary)
        {
            if (headerDictionary == null) return string.Empty;
            if (!headerDictionary.ContainsKey("User-Agent")) return string.Empty;
            return headerDictionary["User-Agent"];
        }
        #endregion

        #region 获取当前请求的 Content-Type
        /// <summary>
        /// 获取当前请求的 Content-Type
        /// </summary>
        /// <param name="headerDictionary">HttpRequest</param>
        /// <returns>
        /// 如果当前 HttpRequest 对象为 null，则返回 <see cref="string.Empty"/>;
        /// 当前请求的 Content-Type 
        /// </returns>
        public static string ContentType(this IHeaderDictionary headerDictionary)
        {
            if (headerDictionary == null) return string.Empty;
            if (!headerDictionary.ContainsKey("ContentType")) return string.Empty;
            return headerDictionary["ContentType"];
        }
        #endregion
    }
}
