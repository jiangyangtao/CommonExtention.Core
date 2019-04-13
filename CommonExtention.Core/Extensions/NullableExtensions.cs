using System;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="Nullable"/> 扩展
    /// </summary>
    public static class NullableExtensions
    {
        #region 将当前 short? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="short"/>? 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="short"/>? </param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 属性为 true，则返回 <see cref="short"/>? 的 Value；
        /// 如果当前实例的 HasValue 为 false，则返回 0。
        /// </returns>
        public static short ToInt16(this short? value, short defaultValue = 0)
        {
            if (!value.HasValue) return defaultValue;
            return value.Value;
        }
        #endregion

        #region 将当前 int? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="int"/>? 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="int"/>? </param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的HasValue 为 true，则返回 <see cref="int"/>? 的 Value；
        /// 如果当前实例的HasValue 为 false，则返回 0。
        /// </returns>
        public static int ToInt(this int? value, int defaultValue = 0)
        {
            if (!value.HasValue) return 0;
            return value.Value;
        }
        #endregion

        #region 将当前 long? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="long"/>? 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="long"/>? </param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 为 true，则返回 <see cref="long"/>? 的 Value；
        /// 如果当前实例的 HasValue 为 false，则返回 0。
        /// </returns>
        public static long ToInt64(this long? value, long defaultValue = 0)
        {
            if (!value.HasValue) return 0;
            return value.Value;
        }
        #endregion

        #region 将当前 float? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="float"/>? 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="float"/>? </param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 为 true，则返回 <see cref="float"/>? 的 Value；
        /// 如果当前实例的 HasValue 为 false，则返回 0。
        /// </returns>
        public static float ToSingle(this float? value, float defaultValue = 0)
        {
            if (!value.HasValue) return 0;
            return value.Value;
        }
        #endregion

        #region 将当前 double? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="double"/>? 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="double"/>? </param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 为 true，则返回 <see cref="double"/>? 的 Value；
        /// 如果当前实例的 HasValue 为 false，则返回 0。
        /// </returns>
        public static double ToDouble(this double? value, double defaultValue = 0)
        {
            if (!value.HasValue) return 0;
            return value.Value;
        }
        #endregion

        #region 将当前 decimal? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="decimal"/>? 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="decimal"/>? </param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 为 true，则返回 <see cref="decimal"/>? 的 Value；
        /// 如果当前实例的 HasValue 为 false，则返回 0。
        /// </returns>
        public static decimal ToDecimal(this decimal? value, decimal defaultValue = 0)
        {
            if (!value.HasValue) return 0;
            return value.Value;
        }
        #endregion

        #region 将当前 DateTime? 对象转换为其等效的安全值
        /// <summary>
        /// 将当前 <see cref="DateTime"/>? 对象转换为其等效的安全值
        /// </summary>
        /// <param name="value">要转换的 <see cref="DateTime"/>? </param>
        /// <returns>
        /// 如果当前实例的 HasValue 为 true，则返回 <see cref="DateTime"/>? 的 Value；
        /// 如果当前实例的 HasValue 为 false，则返回 <see cref="DateTime.MinValue"/>。
        /// </returns>
        public static DateTime ToDateTime(this DateTime? value)
        {
            if (!value.HasValue) return DateTime.MinValue;
            return value.Value;
        }
        #endregion

        #region 将当前 short? 对象转换为其千分位的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="short"/>? 对象转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="short"/>? </param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 为 false，则返回 <see cref="string.Empty"/>；
        /// 否则返回此实例的值的千分位字符串表示形式。
        /// </returns>
        public static string ToThousand(this short? value, string defaultValue = "")
        {
            if (!value.HasValue) return defaultValue;
            return string.Format("{0:N}", value.Value);
        }
        #endregion

        #region 将当前 int? 对象转换为其千分位的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="int"/>? 对象转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="int"/>? </param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 为 false，则返回 <see cref="string.Empty"/>；
        /// 否则返回此实例的值的千分位字符串表示形式。
        /// </returns>
        public static string ToThousand(this int? value, string defaultValue = "")
        {
            if (!value.HasValue) return defaultValue;
            return string.Format("{0:N}", value.Value);
        }
        #endregion

        #region 将当前 long? 对象转换为其千分位的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="long"/>? 对象转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="long"/>? </param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 为 false，则返回 <see cref="string.Empty"/>；
        /// 否则返回此实例的值的千分位字符串表示形式。
        /// </returns>
        public static string ToThousand(this long? value, string defaultValue = "")
        {
            if (!value.HasValue) return defaultValue;
            return string.Format("{0:N}", value.Value);
        }
        #endregion

        #region 将当前 float? 对象转换为其千分位的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="float"/>? 转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="float"/>? </param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 为 false，则返回 <see cref="string.Empty"/>；
        /// 否则返回此实例的值的千分位字符串表示形式。
        /// </returns>
        public static string ToThousand(this float? value, string defaultValue = "")
        {
            if (!value.HasValue) return defaultValue;
            return string.Format("{0:N}", value.Value);
        }
        #endregion

        #region 将当前 double? 对象转换为其千分位的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="double"/>? 转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="double"/>? </param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 为 false，则返回 <see cref="string.Empty"/>；
        /// 否则返回此实例的值的千分位字符串表示形式。
        /// </returns>
        public static string ToThousand(this double? value, string defaultValue = "")
        {
            if (!value.HasValue) return defaultValue;
            return string.Format("{0:N}", value.Value);
        }
        #endregion

        #region 将当前 decimal? 对象转换为其千分位的字符串表示形式
        /// <summary>
        /// 将当前 <see cref="decimal"/>? 转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="decimal"/>? </param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 为 false，则返回 <see cref="string.Empty"/>；
        /// 否则返回此实例的值的千分位字符串表示形式。
        /// </returns>
        public static string ToThousand(this decimal? value, string defaultValue = "")
        {
            if (!value.HasValue) return defaultValue;
            return string.Format("{0:N}", value.Value);
        }
        #endregion

        #region 将当前 DateTime? 对象转换为格式化后的日期字符串
        /// <summary>
        /// 将当前 <see cref="DateTime"/>? 转换为格式化后的日期字符串
        /// </summary>
        /// <param name="value">要转换的 <see cref="DateTime"/>? 对象</param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 属性为 true，则返回格式为 yyyy-MM-dd 的字符串；
        /// 否则返回 <see cref="string.Empty"/>;
        /// </returns>
        public static string ToFormatDate(this DateTime? value, string defaultValue = "")
        {
            if (!value.HasValue) return defaultValue;
            return value.Value.ToFormatDate();
        }
        #endregion

        #region 将当前 DateTime? 对象转换为格式化后的日期时间字符串
        /// <summary>
        /// 将当前 <see cref="DateTime"/>? 对象转换为格式化后的日期时间字符串
        /// </summary>
        /// <param name="value">要转换的 <see cref="DateTime"/>? 对象</param>
        /// <param name="defaultValue">默认值：如果当前实例的 HasValue 为 false 时，要返回的默认值</param>
        /// <returns>
        /// 如果当前实例的 HasValue 属性为 true，则返回格式为 yyyy-MM-dd HH:mm:ss 字符串；
        /// 否则返回 <see cref="string.Empty"/> ;
        /// </returns>
        public static string ToFormatDateTime(this DateTime? value, string defaultValue = "")
        {
            if (!value.HasValue) return defaultValue;
            return value.Value.ToFormatDateTime();
        }
        #endregion
    }
}
