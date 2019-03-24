using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="RouteData"/> 扩展
    /// </summary>
    public static class RouteDataExtensions
    {
        #region 获取当前 RouteData 的 ActionName
        /// <summary>
        /// 获取当前 <see cref="RouteData"/> 的 ActionName
        /// </summary>
        /// <param name="routeData">要获取 ActionName 的 <see cref="RouteData"/></param>
        /// <returns>
        /// 如果当前 <see cref="RouteData"/> 为 null 或者 <see cref="RouteData.Values"/> 为 null，
        /// 或者 <see cref="RouteData.Values"/> 中不包含 Action，则返回 <see cref="string.Empty"/>。
        /// 否则返回当前 <see cref="RouteData"/> 的 Action。
        /// </returns>
        public static string ActionName(this RouteData routeData)
        {
            if (routeData == null || routeData.Values == null || routeData.Values["action"] == null) return string.Empty;
            return routeData.Values["action"].ToString();
        }
        #endregion

        #region 获取当前 RouteData 的 ControllerName
        /// <summary>
        /// 获取当前 <see cref="RouteData"/> 的 ControllerName
        /// </summary>
        /// <param name="routeData">要获取 ControllerName 的 <see cref="RouteData"/></param>
        /// <returns>
        /// 如果当前 <see cref="RouteData"/> 为 null 或者 <see cref="RouteData.Values"/> 为 null，
        /// 或者 <see cref="RouteData.Values"/> 中不包含 Controller，则返回 <see cref="string.Empty"/>。
        /// 否则返回当前 <see cref="RouteData"/> 的 Controller。
        /// </returns>
        public static string ControllerName(this RouteData routeData)
        {
            if (routeData == null || routeData.Values == null || routeData.Values["controller"] == null) return string.Empty;
            return routeData.Values["controller"].ToString();
        }
        #endregion
    }
}
