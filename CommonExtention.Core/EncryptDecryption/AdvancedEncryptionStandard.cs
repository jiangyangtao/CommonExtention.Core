using CommonExtention.Core.Extensions;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CommonExtention.Core.EncryptDecryption
{
    /// <summary>
    /// 高级加密标准(AES)。此类无法被继承
    /// </summary>
    public sealed class AdvancedEncryptionStandard
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="AdvancedEncryptionStandard"/> 类的新实例
        /// </summary>
        public AdvancedEncryptionStandard() { }
        #endregion

        #region 将要加密的字符串进行AES加密(CBC模式)
        /// <summary>
        /// 将要加密的字符串进行AES加密(CBC模式)
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <param name="key">
        /// 密钥：长度为16位(128位加密)或者24位(192位加密)和32位(256位加密)。
        /// </param>
        /// <param name="iv">
        /// 向量：长度必须为16位，如果不指定则使用 key 参数的前16位作为向量；
        /// 如果指定，多于16位则截取。
        /// </param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回AES算法加密后的密文。
        /// </returns>
        /// <exception cref="ArgumentNullException"> key 参数为 null 或者 空字符串("")。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度少于16位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度大于32位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度不是16位或者24位或者32位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> iv 参数不为空且长度小于16位。</exception>
        public string Encrypt(string value, string key, string iv = "")
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            if (key == null) throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            if (key.Length < 16) throw new ArgumentOutOfRangeException("指定的密钥长度不能少于16位。");
            if (key.Length > 32) throw new ArgumentOutOfRangeException("指定的密钥长度不能多于32位。");
            if (key.Length != 16 && key.Length != 24 && key.Length != 32) throw new ArgumentOutOfRangeException("指定的密钥长度不明确。");
            if (iv.NotNullAndEmpty())
            {
                if (iv.Length < 16) throw new ArgumentOutOfRangeException("指定的向量长度不能少于16位。");
            }

            var _keyByte = Encoding.UTF8.GetBytes(key);
            var _valueByte = Encoding.UTF8.GetBytes(value);
            using (var aes = new RijndaelManaged())
            {
                aes.IV = iv.NotNullAndEmpty() ? Encoding.UTF8.GetBytes(iv) : Encoding.UTF8.GetBytes(key.Substring(0, 16));
                aes.Key = _keyByte;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                var cryptoTransform = aes.CreateEncryptor();
                var resultArray = cryptoTransform.TransformFinalBlock(_valueByte, 0, _valueByte.Length);
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
        }
        #endregion

        #region 将要解密的字符串进行AES解密(CBC模式)
        /// <summary>
        /// 将要解密的字符串进行AES解密(CBC模式)
        /// </summary>
        /// <param name="value">要解密的字符串</param>
        /// <param name="key">
        /// 密钥：长度为16位(128位加密)或者24位(192位加密)和32位(256位加密)。
        /// </param>
        /// <param name="iv">
        /// 向量：长度必须为16位，如果不指定则使用 key 参数的前16位作为向量；
        /// 如果指定，多于16位则截取。
        /// </param>
        /// <returns>
        /// 如果 value 参数为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回AES算法解密后的明文。
        /// </returns>
        /// <exception cref="ArgumentNullException"> key 参数为 null 或者 空字符串("")。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度少于16位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度大于32位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度不是16位或者24位或者32位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> iv 参数不为空且长度小于16位。</exception>
        public string Decrypt(string value, string key, string iv = "")
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            if (key == null) throw new ArgumentNullException("未将对象引用设置到对象的实例。");
            if (key.Length < 16) throw new ArgumentOutOfRangeException("指定的密钥长度不能少于16位。");
            if (key.Length > 32) throw new ArgumentOutOfRangeException("指定的密钥长度不能多于32位。");
            if (key.Length != 16 && key.Length != 24 && key.Length != 32) throw new ArgumentOutOfRangeException("指定的密钥长度不明确。");
            if (iv.NotNullAndEmpty())
            {
                if (iv.Length < 16) throw new ArgumentOutOfRangeException("指定的向量长度不能少于16位。");
            }

            var _keyByte = Encoding.UTF8.GetBytes(key);
            var _valueByte = Convert.FromBase64String(value);
            using (var aes = new RijndaelManaged())
            {
                aes.IV = iv.NotNullAndEmpty() ? Encoding.UTF8.GetBytes(iv) : Encoding.UTF8.GetBytes(key.Substring(0, 16));
                aes.Key = _keyByte;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                var cryptoTransform = aes.CreateDecryptor();
                var resultArray = cryptoTransform.TransformFinalBlock(_valueByte, 0, _valueByte.Length);
                return Encoding.UTF8.GetString(resultArray);
            }
        }
        #endregion
    }
}
