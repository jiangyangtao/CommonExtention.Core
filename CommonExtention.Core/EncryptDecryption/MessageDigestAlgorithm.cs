using CommonExtention.Core.Extensions;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CommonExtention.Core.EncryptDecryption
{
    /// <summary>
    /// 消息摘要算法加密。此类无法被继承
    /// </summary>
    public sealed class MessageDigestAlgorithm
    {
        #region 将要加密的字符串进行加密(默认为16位小写)
        /// <summary>
        /// 将要加密的字符串进行 <see cref="MD5"/> 加密(默认为16位小写)
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回16位小写的 <see cref="MD5"/> 密文。
        /// </returns>
        public static string MD5String(string value) => MD5Lower16(value);
        #endregion

        #region 将要加密的字符串进行MD5的16位大写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref="MD5"/> 的16位大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回16位大写的 <see cref="MD5"/> 密文。
        /// </returns>
        public static string MD5Upper16(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var result = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(value)), 4, 8);
            result = result.Replace("-", "");
            return result;
        }
        #endregion

        #region 将要加密的字符串进行MD5的16位小写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref="MD5"/> 的16位小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回16位小写的 <see cref="MD5"/> 密文。
        /// </returns>
        public static string MD5Lower16(string value) => MD5Upper16(value).ToLower();
        #endregion

        #region 将要加密的字符串进行MD5的32位大写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref="MD5"/> 的32位大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回32位大写的 <see cref="MD5"/> 密文。
        /// </returns>
        public static string MD5Upper32(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var _data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value));
            var _strBuilder = new StringBuilder();
            for (int i = 0; i < _data.Length; i++)
            {
                _strBuilder.Append(_data[i].ToString("X2"));
            }
            return _strBuilder.ToString();
        }
        #endregion

        #region 将要加密的字符串进行MD5的32位小写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref="MD5"/> 的32位小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回32位小写的 <see cref="MD5"/> 密文。
        /// </returns>
        public static string MD5Lower32(string value) => MD5Upper32(value).ToLower();
        #endregion

        #region 将要加密的字符串进行MD5混淆加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref="MD5"/> 混淆加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 <see cref="MD5"/> 的混淆加密密文。
        /// </returns>
        public static string MD5Confusion(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var s1 = MD5Lower32(value);
            var s2 = MD5Lower32(s1.Substring(0, 23));
            var s3 = MD5Lower32(s2.Substring(6, 18));
            var _strBuilder = new StringBuilder(s3.Substring(4, 9));
            _strBuilder.Append(s2.Substring(0, 10));
            _strBuilder.Append(s3.Substring(23, 8));
            _strBuilder.Append(s1.Substring(15, 10));
            return _strBuilder.ToString();
        }
        #endregion

        #region 将要加密的字符串进行SHA1算法加密(小写)
        /// <summary>
        /// 将要加密的字符串进行SHA1算法加密(小写)
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回SHA1算法小写的密文。
        /// </returns>
        public static string SHA1(string value) => SHA1Upper(value).ToLower();
        #endregion

        #region 将要加密的字符串进行SHA1算法大写加密
        /// <summary>
        /// 将要加密的字符串进行SHA1算法大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回SHA1算法大写的密文。
        /// </returns>
        public static string SHA1Upper(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var _data = new SHA1CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(value));
            var strBuilder = new StringBuilder();
            for (int i = 0; i < _data.Length; i++)
            {
                strBuilder.Append(_data[i].ToString("X"));
            }
            return strBuilder.ToString();
        }
        #endregion

        #region 将要加密的字符串进行SHA1算法小写加密
        /// <summary>
        /// 将要加密的字符串进行SHA1算法小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回SHA1算法小写的密文。
        /// </returns>
        public static string SHA1Lower(string value) => SHA1Upper(value).ToLower();
        #endregion

        #region 将要加密的字符串进行SHA1算法的混淆加密
        /// <summary>
        /// 将要加密的字符串进行SHA1算法的混淆加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回SHA1的混淆加密密文。
        /// </returns>
        public static string SHA1Confusion(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var s1 = SHA1Lower(value);
            var s2 = SHA1Lower(s1.Substring(7, 31));
            var s3 = SHA1Lower(s2.Substring(0, 26));
            var s4 = SHA1Lower(s3.Substring(15, 24) + s2.Substring(14, 22) + s1.Substring(3, 19));
            var _strBuilder = new StringBuilder(s4.Substring(2, 17));
            _strBuilder.Append(s3.Substring(5, 28));
            _strBuilder.Append(s2.Substring(18, 15));
            _strBuilder.Append(s1.Substring(9, 20));
            return _strBuilder.ToString();
        }
        #endregion

        #region 计算指定字符串的16位MD5的哈希/散列值
        /// <summary>
        /// 计算指定字符串的16位 <see cref="MD5"/> 的哈希/散列值
        /// </summary>
        /// <param name="value">要计算的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回计算所得的16位 <see cref="MD5"/> 哈希/散列值。
        /// </returns>
        public static string Get16MD5Hash(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var result = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(value)), 4, 8);
            return result;
        }
        #endregion

        #region 计算指定字符串的32位MD5的哈希/散列值
        /// <summary>
        /// 计算指定字符串的32位 <see cref="MD5"/> 的哈希/散列值
        /// </summary>
        /// <param name="value">要计算的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回计算所得的32位 <see cref="MD5"/> 哈希/散列值。
        /// </returns>
        public static string Get32MD5Hash(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var _data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value));
            string result = BitConverter.ToString(_data);
            return result.ToString();
        }
        #endregion

        #region 计算指定字符串的SHA1的哈希/散列值
        /// <summary>
        /// 计算指定字符串的SHA1的哈希/散列值
        /// </summary>
        /// <param name="value">要计算的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回计算所得的SHA1哈希/散列值。
        /// </returns>
        public static string GetSHA1Hash(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var _data = new SHA1CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(value));
            string result = BitConverter.ToString(_data);
            return result.ToString();
        }
        #endregion
    }
}
