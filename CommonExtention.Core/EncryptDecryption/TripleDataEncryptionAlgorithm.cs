using CommonExtention.Core.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CommonExtention.Core.EncryptDecryption
{
    /// <summary>
    /// 三重数据加密算法(3DES)。此类无法被继承
    /// </summary>
    public sealed class TripleDataEncryptionAlgorithm
    {
        #region 将要加密的字符串进行3DES加密
        /// <summary>
        /// 将要加密的字符串进行3DES加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <param name="key">密钥：长度必须为24位，多于24位则截取。</param>
        /// <param name="iv">
        /// 向量：长度必须为8位，如果不指定则使用 key 参数的前8位作为向量；
        /// 如果指定，多于8位则截取。</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回3DES算法加密后的密文。
        /// </returns>
        /// <exception cref="Exception"> key 参数为 null 或者 空字符串("")。</exception>
        /// <exception cref="Exception"> key 参数长度少于24位。</exception>
        /// <exception cref="Exception"> iv 参数不为空且长度小于8位。 </exception>
        public static string Encrypt(string value, string key, string iv = "")
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            if (key == null) throw new Exception("未将对象引用设置到对象的实例。");
            if (key.Length < 24) throw new Exception("指定的密钥长度不能少于24位。");
            if (iv.NotNullAndEmpty())
            {
                if (iv.Length < 8) throw new Exception("指定的向量长度不能少于8位。");
            }

            var _keyByte = Encoding.UTF8.GetBytes(key.Substring(0, 24));
            var _ivByte = Encoding.UTF8.GetBytes(iv.NotNullAndEmpty() ? iv.Substring(0, 8) : key.Substring(0, 8));
            var _valueByteArray = Encoding.UTF8.GetBytes(value);
            using (var _tdes = new TripleDESCryptoServiceProvider())
            {
                using (var _memoryStream = new MemoryStream())
                {
                    using (var _cryptoStream = new CryptoStream(_memoryStream, _tdes.CreateEncryptor(_keyByte, _ivByte), CryptoStreamMode.Write))
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

        #region 将要解密的字符串进行3DES解密
        /// <summary>
        /// 将要解密的字符串进行3DES解密
        /// </summary>
        /// <param name="value">要解密的字符串</param>
        /// <param name="key">密钥：长度必须为24位，多于24位则截取。</param>
        /// <param name="iv">
        /// 向量：长度必须为8位，如果不指定则使用 key 参数的前8位作为向量；
        /// 如果指定，多于8位则截取。</param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回3DES算法解密后的明文。
        /// </returns>
        /// <exception cref="Exception"> key 参数为 null 或者 空字符串("")。</exception>
        /// <exception cref="Exception"> key 参数长度少于24位。</exception>
        /// <exception cref="Exception"> iv 参数不为空且长度小于8位。 </exception>
        public static string Decrypt(string value, string key, string iv = "")
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            if (key == null) throw new Exception("未将对象引用设置到对象的实例。");
            if (key.Length < 24) throw new Exception("指定的密钥长度不能少于24位。");
            if (iv.NotNullAndEmpty())
            {
                if (iv.Length < 8) throw new Exception("指定的向量长度不能少于8位。");
            }

            var _keyByte = Encoding.UTF8.GetBytes(key.Substring(0, 24));
            var _ivByte = Encoding.UTF8.GetBytes(iv.NotNullAndEmpty() ? iv.Substring(0, 8) : key.Substring(0, 8));
            var _valueByteArray = Convert.FromBase64String(value);
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                using (var _memoryStream = new MemoryStream())
                {
                    using (var _cryptoStream = new CryptoStream(_memoryStream, tdes.CreateDecryptor(_keyByte, _ivByte), CryptoStreamMode.Write))
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
