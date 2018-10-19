using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extention
{
    /// <summary>
    /// <see cref="object"/> 扩展
    /// </summary>
    public static class ExtentionObject
    {
        #region 指示指定的 object 对象是否不为 null
        /// <summary>
        /// 指示指定的 <see cref="object"/> 对象是否不为 null
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>如果 object 不为 null ，则为 true；否则为 false。</returns>
        public static bool NotNull(this object value)
        {
            return value != null;
        }
        #endregion

        #region 指示指定的 object 对象不是 null 和 System.String.Empty 字符串
        /// <summary>
        /// 指示指定的 <see cref="object"/> 对象不为 null 和 <see cref="string.Empty"/> 字符串
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>如果 object 不为 null 和空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool NotNullAndEmpty(this object value)
        {
            return value != null && value.ToString() != string.Empty;
        }
        #endregion

        #region 指示指定的 object 对象是否为 null
        /// <summary>
        /// 指示指定的 <see cref="object"/> 对象是否为 null
        /// </summary>
        /// <param name="value">指定的 <see cref="object"/> 对象</param>
        /// <returns>如果 object 为 null，则返回true；否则为 false。</returns>
        public static bool IsNull(this object value)
        {
            return value == null;
        }
        #endregion

        #region 指示指定的 object 对象是 null 还是 System.String.Empty 字符串
        /// <summary>
        /// 指示指定的 object 对象是 null 还是 <see cref="string.Empty"/> 字符串
        /// </summary>
        /// <param name="value">要检测的Object对象</param>
        /// <returns>如果 object 为 null 或空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool IsNullOrEmpty(this object value)
        {
            return value == null || value.ToNotSpaceString() == string.Empty;
        }
        #endregion

        #region 将指定的 object 对象转换不为 null 的 System.String 表示形式
        /// <summary>
        /// 将指定的 <see cref="object"/> 对象转换不为 null 的 <see cref="string"/> 表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 object 不为 null，则返回 object 的 <see cref="string"/> 表示形式；
        /// 否则返回 <see cref="string.Empty"/>。
        /// </returns>
        public static string ToNotNullString(this object value)
        {
            if (value.IsNull()) return string.Empty;
            return value.ToString();
        }
        #endregion

        #region 将指定的 object 对象转换为去除空格后的 System.String 表示形式
        /// <summary>
        /// 将指定的 <see cref="object"/> 对象转换为去除空格后的 <see cref="string"/> 表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="object"/> 对象</param>
        /// <returns>
        /// 如果 object 不为 null，则返回 object 去除空格后的 <see cref="string"/> 表示形式；
        /// 否则返回 <see cref="string.Empty"/>。
        /// </returns>
        public static string ToNotSpaceString(this object value)
        {
            if (value == null) return string.Empty;
            return value.ToString().Trim();
        }
        #endregion
    }
}
