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
        public static string ActionName(this RouteData routeData)
        {
            if (routeData == null || routeData.Values == null || routeData.Values["Action"] == null) return string.Empty;
            return routeData.Values["Action"].ToString();
        }

        public static string ControllerName(this RouteData routeData)
        {
            if (routeData == null || routeData.Values == null || routeData.Values["Controller"] == null) return string.Empty;
            return routeData.Values["Action"].ToString();
        }
    }
}
