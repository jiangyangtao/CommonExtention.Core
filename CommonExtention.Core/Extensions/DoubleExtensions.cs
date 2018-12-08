using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="double"/> 扩展
    /// </summary>
    public static class DoubleExtensions
    {
        #region 返回 length 对应的 Size
        /// <summary>
        /// 返回 ContentLength 对应的 Size
        /// </summary>
        /// <param name="length"> ContentLength 长度</param>
        /// <returns>B/KB/MB/GB/TB/PB</returns>
        public static string FileSize(this double length)
        {
            var units = new string[] { "B", "KB", "MB", "GB", "TB", "PB" };
            var mod = 1024.0;
            var i = 0;
            while (length >= mod)
            {
                length /= mod;
                i++;
            }
            return Math.Round(length) + units[i];
        }
        #endregion

        #region 将此实例的数值转换为其千分位的字符串表示形式
        /// <summary>
        /// 将此实例的数值转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="double"/> </param>
        /// <returns>此实例的值的千分位字符串表示形式</returns>
        public static string ToThousand(this double value) => string.Format("{0:N}", value);
        #endregion
    }
}
