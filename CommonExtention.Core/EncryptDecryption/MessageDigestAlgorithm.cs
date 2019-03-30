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
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="MessageDigestAlgorithm"/> 类的新实例
        /// </summary>
        public MessageDigestAlgorithm() { }
        #endregion

        #region 将要加密的字符串进行 MD5 算法的16位小写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref="System.Security.Cryptography.MD5"/> 算法的16位小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回16位小写的 <see cref="System.Security.Cryptography.MD5"/> 算法加密的密文。
        /// </returns>
        public string MD5(string value) => MD5Upper(value).ToLower();
        #endregion

        #region 将要加密的字符串进行 MD5 算法的16位大写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref="System.Security.Cryptography.MD5"/> 算法的16位大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回16位大写的 <see cref="System.Security.Cryptography.MD5"/> 算法加密的密文。
        /// </returns>
        public string MD5Upper(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var md5 = new MD5CryptoServiceProvider();
            var result = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(value)), 4, 8);
            result = result.Replace("-", "");
            return result;
        }
        #endregion

        #region 将要加密的字符串进行 MD5 算法的32位小写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref="System.Security.Cryptography.MD5"/> 算法的32位小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回32位小写的 <see cref="System.Security.Cryptography.MD5"/> 算法加密的密文。
        /// </returns>
        public string MD532(string value) => MD532Upper(value).ToLower();
        #endregion

        #region 将要加密的字符串进行 MD5 算法的32位大写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref="System.Security.Cryptography.MD5"/> 算法的32位大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回32位大写的 <see cref="System.Security.Cryptography.MD5"/> 算法加密的密文。
        /// </returns>
        public string MD532Upper(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var _data = System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value));
            var _strBuilder = new StringBuilder();
            for (int i = 0; i < _data.Length; i++)
            {
                _strBuilder.Append(_data[i].ToString("X2"));
            }
            return _strBuilder.ToString();
        }
        #endregion

        #region 将要加密的字符串进行 MD5 算法的混淆加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref="System.Security.Cryptography.MD5"/> 算法的混淆加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 <see cref="System.Security.Cryptography.MD5"/> 算法加密的混淆密文。
        /// </returns>
        public string MD5Confusion(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var s1 = MD532Upper(value);
            var s2 = MD532Upper(s1.Substring(0, 23));
            var s3 = MD532Upper(s2.Substring(6, 18));
            var _strBuilder = new StringBuilder(s3.Substring(4, 9)).
                Append(s2.Substring(0, 10)).
                Append(s3.Substring(23, 8)).
                Append(s1.Substring(15, 10));
            return _strBuilder.ToString();
        }
        #endregion

        #region 将要加密的字符串进行 SHA1 算法的小写加密
        /// <summary>
        /// 将要加密的字符串进行 SHA1 算法的小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 SHA1 算法小写的密文。
        /// </returns>
        public string SHA1(string value) => SHA1Upper(value).ToLower();
        #endregion

        #region 将要加密的字符串进行 SHA1 算法的大写加密
        /// <summary>
        /// 将要加密的字符串进行 SHA1 算法的大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 SHA1 算法大写的密文。
        /// </returns>
        public string SHA1Upper(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var data = new SHA1CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(value));
            var strBuilder = new StringBuilder();
            data.ForEach(item => { strBuilder.Append(item.ToString("X2")); });
            return strBuilder.ToString();
        }
        #endregion

        #region 将要加密的字符串进行 SHA1 算法的混淆加密
        /// <summary>
        /// 将要加密的字符串进行 SHA1 算法的混淆加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 SHA1 的混淆加密密文。
        /// </returns>
        public string SHA1Confusion(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var s1 = SHA1Upper(value);
            var s2 = SHA1Upper(s1.Substring(7, 31));
            var s3 = SHA1Upper(s2.Substring(0, 26));
            var s4 = SHA1Upper($"{s3.Substring(15, 24)}{s2.Substring(14, 22)}{s1.Substring(3, 19)}");
            var _strBuilder = new StringBuilder(s4.Substring(2, 17))
                .Append(s3.Substring(5, 28))
                .Append(s2.Substring(18, 15))
                .Append(s1.Substring(9, 20));
            return _strBuilder.ToString();
        }
        #endregion

        #region 将要加密的字符串进行 SHA256 算法的小写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref=" System.Security.Cryptography.SHA256"/> 算法小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 <see cref=" System.Security.Cryptography.SHA256"/> 算法加密的小写密文。
        /// </returns>
        public string SHA256(string value) => SHAArithmetic(value, 256).ToLower();
        #endregion

        #region 将要加密的字符串进行 SHA256 算法的大写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref=" System.Security.Cryptography.SHA256"/> 算法大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 <see cref=" System.Security.Cryptography.SHA256"/> 算法加密的大写密文。
        /// </returns>
        public string SHA256Upper(string value) => SHAArithmetic(value, 256);
        #endregion

        #region 将要加密的字符串进行 SHA384 算法的小写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref=" System.Security.Cryptography.SHA384"/> 算法小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 <see cref=" System.Security.Cryptography.SHA384"/> 算法加密的小写密文。
        /// </returns>
        public string SHA384(string value) => SHAArithmetic(value, 384).ToLower();
        #endregion

        #region 将要加密的字符串进行 SHA384 算法的大写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref=" System.Security.Cryptography.SHA384"/> 算法大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 <see cref=" System.Security.Cryptography.SHA384"/> 算法加密的大写密文。
        /// </returns>
        public string SHA384Upper(string value) => SHAArithmetic(value, 384);
        #endregion

        #region 将要加密的字符串进行 SHA512 算法的小写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref=" System.Security.Cryptography.SHA512"/> 算法小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 <see cref=" System.Security.Cryptography.SHA512"/> 算法加密的小写密文。
        /// </returns>
        public string SHA512(string value) => SHAArithmetic(value, 512).ToLower();
        #endregion

        #region 将要加密的字符串进行 SHA512 算法的大写加密
        /// <summary>
        /// 将要加密的字符串进行 <see cref=" System.Security.Cryptography.SHA512"/> 算法大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 <see cref=" System.Security.Cryptography.SHA512"/> 算法加密的大写密文。
        /// </returns>
        public string SHA512Upper(string value) => SHAArithmetic(value, 512);

        /// <summary>
        /// 将要加密的字符串进行 SHA 算法大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <param name="bit">位数</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 SHA 算法大写的密文。
        /// </returns>
        private string SHAArithmetic(string value, int bit)
        {
            if (value.IsNullOrEmpty()) return string.Empty;

            HashAlgorithm sha = new SHA256Managed();
            if (bit == 384) sha = new SHA384Managed();
            if (bit == 512) sha = new SHA512Managed();

            var result = sha.ComputeHash(Encoding.Default.GetBytes(value));
            sha.Clear();
            return Convert.ToBase64String(result);
        }
        #endregion

        #region 计算指定字符串的16位 MD5 的哈希/散列值
        /// <summary>
        /// 计算指定字符串的16位 <see cref="System.Security.Cryptography.MD5"/> 的哈希/散列值
        /// </summary>
        /// <param name="value">要计算的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回计算所得的16位 <see cref="System.Security.Cryptography.MD5"/> 哈希/散列值。
        /// </returns>
        public string Get16MD5Hash(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(value)), 4, 8); ;
        }
        #endregion

        #region 计算指定字符串的32位 MD5 的哈希/散列值
        /// <summary>
        /// 计算指定字符串的32位 <see cref="System.Security.Cryptography.MD5"/> 的哈希/散列值
        /// </summary>
        /// <param name="value">要计算的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回计算所得的32位 <see cref="System.Security.Cryptography.MD5"/> 哈希/散列值。
        /// </returns>
        public string Get32MD5Hash(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var data = System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value));
            return BitConverter.ToString(data);
        }
        #endregion

        #region 计算指定字符串的 SHA1 的哈希/散列值
        /// <summary>
        /// 计算指定字符串的 SHA1 的哈希/散列值
        /// </summary>
        /// <param name="value">要计算的字符串</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回计算所得的 SHA1 哈希/散列值。
        /// </returns>
        public string GetSHA1Hash(string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var data = new SHA1CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(value));
            return BitConverter.ToString(data);
        }
        #endregion
    }
}
