using System;

namespace CommonExtention.Core.Extention
{
    /// <summary>
    /// <see cref="Array"/> 扩展
    /// </summary>
    public static class ExtentionArray
    {
        #region 将 int[] 数组的转换为 string[] 数组
        /// <summary>
        /// 将 int[] 数组的转换为 string[] 数组
        /// </summary>
        /// <param name="intArr">int[]数组</param>
        /// <returns>string[]数组</returns>
        public static string[] ToStringArray(this int[] intArr)
        {
            return Array.ConvertAll(intArr, a => a.ToString());
        }
        #endregion

        #region 将 string[] 数组转 int[] 数组
        /// <summary>
        /// 将 string[] 数组转 int[] 数组
        /// </summary>
        /// <param name="strArr">string[]数组</param>
        /// <returns>int[]数组</returns>
        public static int[] ToIntArray(this string[] strArr)
        {
            return Array.ConvertAll(strArr, a => a.ToInt());
        }
        #endregion

        #region 将 string[] 数组转 decimal[] 数组
        /// <summary>
        /// 将 string[] 数组转 decimal[] 数组
        /// </summary>
        /// <param name="strArr">string[]数组</param>
        /// <returns>decimal[]数组</returns>
        public static decimal[] ToDecimalArray(this string[] strArr)
        {
            return Array.ConvertAll(strArr, a => a.ToDecimal());
        }
        #endregion        

        #region 将 decimal[] 数组转换为 string[] 数组
        /// <summary>
        /// 将 decimal[] 数组转换为 string[] 数组
        /// </summary>
        /// <param name="decimalArr">decimal[]数组</param>
        /// <returns>string[]数组</returns>
        public static string[] ToStringArray(this decimal[] decimalArr)
        {
            return Array.ConvertAll(decimalArr, a => a.ToString());
        }
        #endregion

        #region 将 System.String 的表示形式转换为 string[]数组(默认为英文逗号分隔)
        /// <summary>
        /// 将 <see cref="string"/> 的表示形式转换为 string[]数组(默认为英文逗号分割)
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <param name="symbol">分隔符，默认为英文逗号</param>
        /// <returns>
        /// 如果字符串为 null 或者空字符串 ("")，则返回 string[] 的空数组；
        /// 否则返回转换后的string[]的数组。
        /// </returns>
        public static string[] ToSplitArray(this string value, char symbol = ',')
        {
            if (value.IsNullOrEmpty()) return new string[0];
            return value.Split(symbol);
        }
        #endregion

        #region 将 string[] 序列中的元素转化为的 System.String 的表示形式(默认英文逗号分隔)
        /// <summary>
        /// 将 string[] 序列的所有元素转化为 <see cref="string"/> 的表示形式(默认英文逗号分隔)
        /// </summary>
        /// <param name="strArr">string[]数组</param>
        /// <param name="symbol">分隔符号</param>
        /// <returns>
        /// 如果字符串为 null 或者空字符串 ("")，则返回 string[] 的空数组；
        /// 否则返回转换后的英文逗号分隔的字符串。
        /// </returns>
        public static string ToStringValue(this string[] strArr, string symbol = ",")
        {
            var str = string.Empty;
            if (strArr.Length == 0 || strArr == null) return str;
            for (int i = 0; i < strArr.Length; i++)
            {
                str += strArr[i];
                if (i != strArr.Length - 1) str += symbol;
            }
            return str;
        }
        #endregion
    }
}
