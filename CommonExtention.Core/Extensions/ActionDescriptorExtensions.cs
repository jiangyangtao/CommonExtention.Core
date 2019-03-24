using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="ActionDescriptor"/> 扩展
    /// </summary>
    public static class ActionDescriptorExtensions
    {
        #region 获取当前 ActionDescriptor 的 ControllerName
        /// <summary>
        /// 获取当前 <see cref="ActionDescriptor"/> 的 ControllerName
        /// </summary>
        /// <param name="actionDescriptor">要获取 ControllerName 的 <see cref="ActionDescriptor"/></param>
        /// <returns>
        /// 如果当前 <see cref="ActionDescriptor"/> 为 null，则返回 <see cref="string.Empty"/>。
        /// 否则返回与 <see cref="ActionDescriptor"/> 对应的 <see cref="ControllerActionDescriptor.ControllerName"/>。
        /// </returns>
        public static string ControllerName(this ActionDescriptor actionDescriptor)
        {
            if (actionDescriptor == null) return string.Empty;
            if (!(actionDescriptor is ControllerActionDescriptor controller))
            {
                controller = (ControllerActionDescriptor)actionDescriptor;
                if (controller == null) return string.Empty;
            }
            return controller.ControllerName;
        }
        #endregion
    }
}
