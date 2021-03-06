﻿namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="decimal"/> 扩展
    /// </summary>
    public static class DecimalExtensions
    {
        #region 将此实例的数值转换为其千分位的字符串表示形式
        /// <summary>
        /// 将此实例的数值转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="decimal"/> </param>
        /// <returns>此实例的值的千分位字符串表示形式</returns>
        public static string ToThousand(this decimal value) => string.Format("{0:N}", value);
        #endregion
    }
}
