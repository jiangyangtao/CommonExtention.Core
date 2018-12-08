using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="short"/> 扩展
    /// </summary>
    public static class ShortExtensions
    {
        #region 将此实例的数值转换为其千分位的字符串表示形式
        /// <summary>
        /// 将此实例的数值转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的short</param>
        /// <returns>此实例的值的千分位字符串表示形式</returns>
        public static string ToThousand(this short value) => string.Format("{0:N}", value);
        #endregion
    }
}
