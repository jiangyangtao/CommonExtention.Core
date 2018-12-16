using System;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// 泛型扩展
    /// </summary>
    public static class GenericsExtensions
    {
        #region 指示指定的泛型元素是否为等效的 String 类型
        /// <summary>
        /// 指示指定的泛型元素是否为等效的 <see cref="string"/> 类型
        /// </summary>
        /// <typeparam name="TValue">要检测的泛型元素</typeparam>
        /// <param name="value">要检测的泛型元素值</param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果泛型元素的值为等效的 <see cref="string"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsString<TValue>(this TValue value)
        {
            if (value == null) return false;
            return value.GetType().Name == "String";
        }
        #endregion

        #region 指示指定的泛型元素是否为等效的 Int16 类型
        /// <summary>
        /// 指示指定的泛型元素是否为等效的 <see cref="short"/> 类型
        /// </summary>
        /// <typeparam name="TValue">要检测的泛型元素</typeparam>
        /// <param name="value">要检测的泛型元素值</param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果泛型元素的值为等效的 <see cref="short"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsInt16<TValue>(this TValue value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Int16";
        }
        #endregion

        #region 指示指定的泛型元素是否为等效的 Int32 类型
        /// <summary>
        /// 指示指定的泛型元素是否为等效的 <see cref="int"/> 类型
        /// </summary>
        /// <typeparam name="TValue">要检测的泛型元素</typeparam>
        /// <param name="value">要检测的泛型元素值</param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果泛型元素的值为等效的 <see cref="int"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsInt<TValue>(this TValue value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Int32";
        }
        #endregion

        #region 指示指定的泛型元素是否为等效的 Int64 类型
        /// <summary>
        /// 指示指定的泛型元素是否为等效的 <see cref="long"/> 类型
        /// </summary>
        /// <typeparam name="TValue">要检测的泛型元素</typeparam>
        /// <param name="value">要检测的泛型元素值</param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果泛型元素的值为等效的 <see cref="long"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsInt64<TValue>(this TValue value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Int64";
        }
        #endregion

        #region 指示指定的泛型元素是否为等效的 Decimal 类型
        /// <summary>
        /// 指示指定的泛型元素是否为等效的 <see cref="decimal"/> 类型
        /// </summary>
        /// <typeparam name="TValue">要检测的泛型元素</typeparam>
        /// <param name="value">要检测的泛型元素值</param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果泛型元素的值为等效的 <see cref="decimal"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsDecimal<TValue>(this TValue value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Decimal";
        }
        #endregion

        #region 指示指定的泛型元素是否为等效的 Single 类型
        /// <summary>
        /// 指示指定的泛型元素是否为等效的 <see cref="float"/> 类型
        /// </summary>
        /// <typeparam name="TValue">要检测的泛型元素</typeparam>
        /// <param name="value">要检测的泛型元素值</param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果泛型元素的值为等效的 <see cref="float"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsSingle<TValue>(this TValue value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Single";
        }
        #endregion

        #region 指示指定的泛型元素是否为等效的 Double 类型
        /// <summary>
        /// 指示指定的泛型元素是否为等效的 <see cref="double"/> 类型
        /// </summary>
        /// <typeparam name="TValue">要检测的泛型元素</typeparam>
        /// <param name="value">要检测的泛型元素值</param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果泛型元素的值为等效的 <see cref="double"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsDouble<TValue>(this TValue value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Double";
        }
        #endregion

        #region 指示指定的泛型元素是否为等效的 DadeTime 对象
        /// <summary>
        /// 指示指定的泛型元素是否为等效的 <see cref="DateTime"/> 对象
        /// </summary>
        /// <typeparam name="TValue">要检测的泛型元素</typeparam>
        /// <param name="value">要检测的泛型元素值</param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果泛型元素的值为等效的 <see cref="DateTime"/> 对象，则返回true；否则返回false。
        /// </returns>
        public static bool IsDateTime<TValue>(this TValue value)
        {
            if (value == null) return false;
            return value.GetType().Name == "DateTime";
        }
        #endregion

        #region 指示指定的泛型元素是否为等效的 Boolean 类型
        /// <summary>
        /// 指示指定的泛型元素是否为等效的 <see cref="bool"/> 类型
        /// </summary>
        /// <typeparam name="TValue">要检测的泛型元素</typeparam>
        /// <param name="value">要检测的泛型元素值</param>
        /// <returns>
        /// 如果 value 值为 null，则返回 false；
        /// 如果泛型元素的值为等效的 <see cref="bool"/> 类型，则返回true；否则返回false。
        /// </returns>
        public static bool IsBoolean<TValue>(this TValue value)
        {
            if (value == null) return false;
            return value.GetType().Name == "Boolean";
        }
        #endregion
    }
}
