using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="object"/> 扩展
    /// </summary>
    public static class ObjectExtensions
    {
        #region 指示指定的 object 是否为等效的 String 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="string"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="string"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsString(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "String";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Int16 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="short"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="short"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsInt16(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Int16";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Int32 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="int"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="int"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsInt(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Int32";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Int64 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="long"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="long"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsInt64(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Int64";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Decimal 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="decimal"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="decimal"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsDecimal(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Decimal";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Single 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="float"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="float"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsSingle(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Single";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Double 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="double"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="double"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsDouble(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Double";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 DadeTime 对象
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="DateTime"/> 对象
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 值为等效的 <see cref="DateTime"/> 对象，则返回true；否则返回false。
        /// </returns>
        public static bool IsDateTime(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "DateTime";
        }
        #endregion

        #region 指示指定的 object 是否为等效的 Boolean 类型
        /// <summary>
        /// 指示指定的 <see cref="object"/> 是否为等效的 <see cref="bool"/> 类型
        /// </summary>
        /// <param name="value">要检测的 <see cref="object"/> </param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果 value 为等效的 <see cref="bool"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsBoolean(this object value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Boolean";
        }
        #endregion

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
