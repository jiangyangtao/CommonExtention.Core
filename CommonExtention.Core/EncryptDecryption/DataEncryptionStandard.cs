using CommonExtention.Core.Extensions;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CommonExtention.Core.EncryptDecryption
{
    /// <summary>
    /// 数据加密算法(DES)。此类无法被继承
    /// </summary>
    public sealed class DataEncryptionStandard
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="DataEncryptionStandard"/> 类的新实例
        /// </summary>
        public DataEncryptionStandard() { }
        #endregion

        #region 将要加密的字符串进行DES加密
        /// <summary>
        /// 将要加密的字符串进行DES加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <param name="key">密钥：长度最少8位，多于8位则截取。</param>
        /// <param name="iv">
        /// 向量：长度最少8位，如果不指定则使用 key 参数作为向量；
        /// 如果指定，多于8位则截取。</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回DES算法加密后的密文。
        /// </returns>
        /// <exception cref="ArgumentNullException"> key 参数为 null 或者 空字符串("")。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度少于8位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> iv 参数不为空且长度小于8位。 </exception>
        public string Encrypt(string value, string key, string iv = "")
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            if (key == null) throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            if (key.Length < 8) throw new ArgumentOutOfRangeException("指定的密钥长度不能少于8位。");
            if (iv.NotNullAndEmpty())
            {
                if (iv.Length < 8) throw new ArgumentOutOfRangeException("指定的向量长度不能少于8位。");
            }

            var _keyByte = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            var _ivByte = iv.NotNullAndEmpty() ? Encoding.UTF8.GetBytes(iv.Substring(0, 8)) : _keyByte;
            var _valueByteArray = Encoding.UTF8.GetBytes(value);
            using (var des = new DESCryptoServiceProvider())
            {
                using (var _memoryStream = new MemoryStream())
                {
                    using (var _cryptoStream = new CryptoStream(_memoryStream, des.CreateEncryptor(_keyByte, _ivByte), CryptoStreamMode.Write))
                    {
                        _cryptoStream.Write(_valueByteArray, 0, _valueByteArray.Length);
                        _cryptoStream.FlushFinalBlock();
                        _cryptoStream.Close();
                        _memoryStream.Close();
                        return Convert.ToBase64String(_memoryStream.ToArray());
                    }
                }
            }
        }
        #endregion

        #region 将要解密的字符串进行DES解密
        /// <summary>
        /// 将要解密的字符串进行DES解密
        /// </summary>
        /// <param name="value">要解密的字符串</param>
        /// <param name="key">密钥：长度必须为8位，多于8位则截取。</param>
        /// <param name="iv">
        /// 向量：长度必须为8位，如果不指定则为使用 key 参数作为向量；
        /// 如果指定，多于8位则截取。</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回DES算法解密后的明文。
        /// </returns>
        /// <exception cref="ArgumentNullException"> key 参数为 null 或者 空字符串("")。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度少于8位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> iv 参数不为空且长度小于8位。 </exception>
        public string Decrypt(string value, string key, string iv = "")
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            if (key == null) throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            if (key.Length < 8) throw new ArgumentOutOfRangeException("指定的密钥长度不能少于8位。");
            if (iv.NotNullAndEmpty())
            {
                if (iv.Length < 8) throw new ArgumentOutOfRangeException("指定的向量长度不能少于8位。");
            }

            var _keyByte = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            var _ivByte = iv.NotNullAndEmpty() ? Encoding.UTF8.GetBytes(iv.Substring(0, 8)) : _keyByte;
            var _valueByteArray = Convert.FromBase64String(value);
            using (var des = new DESCryptoServiceProvider())
            {
                using (var _memoryStream = new MemoryStream())
                {
                    using (var _cryptoStream = new CryptoStream(_memoryStream, des.CreateDecryptor(_keyByte, _ivByte), CryptoStreamMode.Write))
                    {
                        _cryptoStream.Write(_valueByteArray, 0, _valueByteArray.Length);
                        _cryptoStream.FlushFinalBlock();
                        _cryptoStream.Close();
                        _memoryStream.Close();
                        return Encoding.UTF8.GetString(_memoryStream.ToArray());
                    }
                }
            }
        }
        #endregion
    }
}
