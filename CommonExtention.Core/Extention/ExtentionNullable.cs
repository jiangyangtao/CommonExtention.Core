using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extention
{
    /// <summary>
    /// <see cref="Nullable"/> 扩展
    /// </summary>
    public static class ExtentionNullable
    {
        #region 将当前 short? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="Nullable{Int16}"/> 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{Int16}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 属性为 true，则返回 <see cref="Nullable{Int16}"/> 的 Value；
        /// 如果 value 参数的 HasValue 为 false，则返回 0。
        /// </returns>
        public static short ToInt16(this short? value)
        {
            if (!value.HasValue) return 0;
            return value.Value;
        }
        #endregion

        #region 将当前 int? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="Nullable{Int32}"/> 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{Int32}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的HasValue 为 true，则返回 <see cref="Nullable{Int32}"/> 的 Value；
        /// 如果 value 参数的HasValue 为 false，则返回 0。
        /// </returns>
        public static int ToInt(this int? value)
        {
            if (!value.HasValue) return 0;
            return value.Value;
        }
        #endregion

        #region 将当前 long? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="Nullable{Int64}"/> 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{Int64}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 为 true，则返回 <see cref="Nullable{Int64}"/> 的 Value；
        /// 如果 value 参数的 HasValue 为 false，则返回 0。
        /// </returns>
        public static long ToInt64(this long? value)
        {
            if (!value.HasValue) return 0;
            return value.Value;
        }
        #endregion

        #region 将当前 float? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="Nullable{Single}"/> 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{Single}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 为 true，则返回 <see cref="Nullable{Single}"/> 的 Value；
        /// 如果 value 参数的 HasValue 为 false，则返回 0。
        /// </returns>
        public static float ToSingle(this float? value)
        {
            if (!value.HasValue) return 0;
            return value.Value;
        }
        #endregion

        #region 将当前 double? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="Nullable{Double}"/> 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{Single}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 为 true，则返回 <see cref="Nullable{Single}"/> 的 Value；
        /// 如果 value 参数的 HasValue 为 false，则返回 0。
        /// </returns>
        public static double ToDouble(this double? value)
        {
            if (!value.HasValue) return 0;
            return value.Value;
        }
        #endregion

        #region 将当前 decimal? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="Nullable{Decimal}"/> 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{Decimal}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 为 true，则返回 <see cref="Nullable{Decimal}"/> 的 Value；
        /// 如果 value 参数的 HasValue 为 false，则返回 0。
        /// </returns>
        public static decimal ToDecimal(this decimal? value)
        {
            if (!value.HasValue) return 0;
            return value.Value;
        }
        #endregion

        #region 将当前 short? 对象转换为其千分位的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="Nullable{Int16}"/> 对象转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{Int16}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 为 false，则返回 <see cref="string.Empty"/>；
        /// 否则返回此实例的值的千分位字符串表示形式。
        /// </returns>
        public static string ToThousand(this short? value)
        {
            if (!value.HasValue) return string.Empty;
            return string.Format("{0:N}", value.Value);
        }
        #endregion

        #region 将当前 int? 对象转换为其千分位的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="Nullable{Int32}"/> 对象转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{Int32}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 为 false，则返回 <see cref="string.Empty"/>；
        /// 否则返回此实例的值的千分位字符串表示形式。
        /// </returns>
        public static string ToThousand(this int? value)
        {
            if (!value.HasValue) return string.Empty;
            return string.Format("{0:N}", value.Value);
        }
        #endregion

        #region 将当前 long? 对象转换为其千分位的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="Nullable{Int64}"/> 对象转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{Int64}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 为 false，则返回 <see cref="string.Empty"/>；
        /// 否则返回此实例的值的千分位字符串表示形式。
        /// </returns>
        public static string ToThousand(this long? value)
        {
            if (!value.HasValue) return string.Empty;
            return string.Format("{0:N}", value.Value);
        }
        #endregion

        #region 将当前 float? 对象转换为其千分位的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="Nullable{Single}"/> 对象转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{Single}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 为 false，则返回 <see cref="string.Empty"/>；
        /// 否则返回此实例的值的千分位字符串表示形式。
        /// </returns>
        public static string ToThousand(this float? value)
        {
            if (!value.HasValue) return string.Empty;
            return string.Format("{0:N}", value.Value);
        }
        #endregion

        #region 将当前 double? 对象转换为其千分位的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="Nullable{Double}"/> 对象转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{Double}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 为 false，则返回 <see cref="string.Empty"/>；
        /// 否则返回此实例的值的千分位字符串表示形式。
        /// </returns>
        public static string ToThousand(this double? value)
        {
            if (!value.HasValue) return string.Empty;
            return string.Format("{0:N}", value.Value);
        }
        #endregion

        #region 将当前 decimal? 对象转换为其千分位的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="Nullable{Decimal}"/> 对象转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{Decimal}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 为 false，则返回 <see cref="string.Empty"/>；
        /// 否则返回此实例的值的千分位字符串表示形式。
        /// </returns>
        public static string ToThousand(this decimal? value)
        {
            if (!value.HasValue) return string.Empty;
            return string.Format("{0:N}", value.Value);
        }
        #endregion

        #region 将当前 DateTime? 对象转换为格式化后的日期字符串
        /// <summary>
        /// 将当前 <see cref="Nullable{DateTime}"/> 对象转换为格式化后的日期字符串
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{DateTime}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 属性为 true，则返回格式为 yyyy-MM-dd 的字符串；
        /// 否则返回 <see cref="string.Empty"/>;
        /// </returns>
        public static string ToFormatDate(this DateTime? value)
        {
            if (!value.HasValue) return string.Empty;
            return value.Value.ToFormatDate();
        }
        #endregion

        #region 将当前 DateTime? 对象转换为格式化后的日期时间字符串
        /// <summary>
        /// 将当前 <see cref="Nullable{DateTime}"/> 对象转换为格式化后的日期时间字符串
        /// </summary>
        /// <param name="value">要转换的 <see cref="Nullable{DateTime}"/> 对象</param>
        /// <returns>
        /// 如果 value 参数的 HasValue 属性为 true，则返回格式为 yyyy-MM-dd HH:mm:ss 字符串；
        /// 否则返回 <see cref="string.Empty"/> ;
        /// </returns>
        public static string ToFormatDateTime(this DateTime? value)
        {
            if (!value.HasValue) return string.Empty;
            return value.Value.ToFormatDateTime();
        }
        #endregion
    }
}
