using CommonExtention.Core.Common;
using CommonExtention.Core.EncryptDecryption;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="string"/> 扩展
    /// </summary>
    public static class StringExtensions
    {
        #region 初始化一个字符串形式的 GUID 对象
        /// <summary>
        /// 初始化一个字符串形式的 <see cref="Guid"/> 对象
        /// </summary>
        /// <returns>返回 <see cref="Guid.NewGuid()"/> 的 <see cref="string"/> 表示形式</returns>
        public static string NewGuid() => Guid.NewGuid().ToString();
        #endregion

        #region 将字符串形式的Unix时间转换为DateTime对象
        /// <summary>
        /// 将字符串形式的Unix时间转为 <see cref="DateTime"/> 对象
        /// </summary>
        /// <param name="timeStamp">字符串形式的Unix时间</param>
        /// <returns>返回 <see cref="DateTime"/> 对象</returns>
        public static DateTime UnixToDateTime(this string timeStamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(timeStamp.ToInt64()).AddHours(8);
        }
        #endregion

        #region 指示指定的字符串是否为 null
        /// <summary>
        /// 指示指定的字符串是否为 null
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串为 null，则返回true；否则为 false。</returns>
        public static bool IsNull(this string value) => value == null;
        #endregion

        #region 指示指定的字符串是否为 System.String.Empty 字符串
        /// <summary>
        /// 指示指定的字符串是否为 <see cref="string.Empty"/> 字符串
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串为空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool IsEmpty(this string value) => value == string.Empty;
        #endregion

        #region 指示指定的字符串是 null 还是 System.String.Empty 字符串
        /// <summary>
        /// 指示指定的字符串是 null 还是 <see cref="string.Empty"/> 字符串
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串为 null 或空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
        #endregion

        #region 指示指定的字符串是否不为 null
        /// <summary>
        /// 指示指定的字符串是否不为 null
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串不为 null ，则为 true；否则为 false。</returns>
        public static bool NotNull(this string value) => value != null;
        #endregion

        #region 指示指定的字符串是否不为 System.String.Empty 字符串
        /// <summary>
        /// 指示指定的字符串是否不为 <see cref="string.Empty"/> 字符串
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串不为空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool NotEmpty(this string value) => value != string.Empty;
        #endregion

        #region 指示指定的字符串不为 null 和 System.String.Empty 字符串
        /// <summary>
        /// 指示指定的字符串不为 null 和不为 <see cref="string.Empty"/> 字符串
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串不为 null 和空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool NotNullAndEmpty(this string value) => !string.IsNullOrEmpty(value);
        #endregion

        #region 指示指定的字符串是否为电子邮箱
        /// <summary>
        /// 指示指定的字符串是否为电子邮箱
        /// </summary>
        /// <param name="value">要验证的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者空字符串("")，则返回 false;
        /// 如果 value 参数为正确的电子邮箱格式，则返回 true;
        /// 否则返回 false 。
        /// </returns>
        public static bool IsEmail(this string value)
        {
            if (value.IsNullOrEmpty()) return false;

            var emailStr = @"([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,5})+";
            var emailReg = new Regex(emailStr);
            return emailReg.IsMatch(value.Trim());
        }
        #endregion

        #region 指示指定的字符串是否为中华人民共和国第二代身份证号码
        /// <summary>
        /// 指示指定的字符串是否为中华人民共和国第二代身份证号码
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 false；
        /// 如果字符串不是是中华人民共和国第二代身份证号码，则返回 false；
        /// 否则返回 true。
        /// </returns>
        public static bool IsChinaIdentityNumber(this string value)
        {
            return IdentityCardNumber.IsChinaIdentityNumber(value);
        }
        #endregion

        #region 指示指定的字符串是否为等效的 Int16 类型
        /// <summary>
        /// 指示指定的字符串是否为等效的 <see cref="short"/> 类型
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串的值为等效的 <see cref="short"/> 类型，则返回true；否则返回false。</returns>
        public static bool IsInt16(this string value) => short.TryParse(value, out short i);
        #endregion

        #region 指示指定的字符串是否为等效的 Int32 类型
        /// <summary>
        /// 指示指定的字符串是否为等效的 <see cref="int"/> 类型
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串的值为等效的 <see cref="int"/> 类型，则返回true；否则返回false。</returns>
        public static bool IsInt(this string value) => int.TryParse(value, out int i);
        #endregion

        #region 指示指定的字符串是否为等效的 Int64 类型
        /// <summary>
        /// 指示指定的字符串是否为等效的 <see cref="long"/> 类型
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串的值为等效的 <see cref="long"/> 类型，则返回true；否则返回false。</returns>
        public static bool IsInt64(this string value) => long.TryParse(value, out long i);
        #endregion

        #region 指示指定的字符串是否为等效的 Decimal 类型
        /// <summary>
        /// 指示指定的字符串是否为等效的 <see cref="decimal"/> 类型
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串的值为等效的 <see cref="decimal"/> 类型，则返回true；否则返回false。</returns>
        public static bool IsDecimal(this string value) => decimal.TryParse(value, out decimal i);
        #endregion

        #region 指示指定的字符串是否为等效的 Single 类型
        /// <summary>
        /// 指示指定的字符串是否为等效的 <see cref="float"/> 类型
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串的值为等效的 <see cref="float"/> 类型，则返回true；否则返回false。</returns>
        public static bool IsSingle(this string value) => float.TryParse(value, out float i);
        #endregion

        #region 指示指定的字符串是否为等效的 Double 类型
        /// <summary>
        /// 指示指定的字符串是否为等效的 <see cref="double"/> 类型
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串的值为等效的 <see cref="double"/> 类型，则返回true；否则返回false。</returns>
        public static bool IsDouble(this string value) => double.TryParse(value, out double i);
        #endregion

        #region 指示指定的字符串是否为等效的 DadeTime 对象
        /// <summary>
        /// 指示指定的字符串是否为等效的 <see cref="DateTime"/> 对象
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串的值为等效的 <see cref="DateTime"/> 对象，则返回true；否则返回false。</returns>
        public static bool IsDateTime(this string value) => DateTime.TryParse(value, out DateTime d);
        #endregion

        #region 指示指定的字符串是否为等效的 Boolean 类型
        /// <summary>
        /// 指示指定的字符串是否为等效的 <see cref="bool"/> 类型
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串的值为等效的 <see cref="bool"/> 类型，则返回true；否则返回false。</returns>
        public static bool IsBoolean(this string value) => bool.TryParse(value, out bool i);
        #endregion

        #region 指示指定的字符串是否为等效的 Guid 类型
        /// <summary>
        /// 指示指定的字符串是否为等效的 <see cref="Guid"/> 类型
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>如果字符串的值为等效的 <see cref="Guid"/> 类型，则返回true；否则返回false。</returns>
        public static bool IsGuid(this string value) => Guid.TryParse(value, out Guid result);
        #endregion

        #region 指示指定的字符串是否为等效的 Guid 类型
        /// <summary>
        /// 指示指定的字符串是否为等效的 <see cref="Guid"/> 类型
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <param name="format">指示当解释 input 时要使用的确切格式：“N”、“D”、“B”、“P”或“X”</param>
        /// <returns>如果字符串的值为等效的 <see cref="Guid"/> 类型，则返回true；否则返回false。</returns>
        public static bool IsGuid(this string value, string format) => Guid.TryParseExact(value, format, out Guid result);
        #endregion

        #region 指示指定要加密的字符串进行 MD5 算法的16位小写加密
        /// <summary>
        /// 指示指定要加密的字符串进行 MD5 算法的16位小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回16位小写的 MD5 算法加密的密文。
        /// </returns>
        public static string ToMD5(this string value) => new MessageDigestAlgorithm().MD5(value);
        #endregion

        #region 指示指定要加密的字符串进行 MD5 算法的16位大写加密
        /// <summary>
        /// 指示指定要加密的字符串进行 MD5 算法的16位大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回16位大写的 MD5 算法加密的密文。
        /// </returns>
        public static string ToMD5Upper(this string value) => new MessageDigestAlgorithm().MD5Upper(value);
        #endregion

        #region 指示指定要加密的字符串进行 MD5 算法的32位小写加密
        /// <summary>
        /// 指示指定要加密的字符串进行 MD5 算法的32位小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回32位小写的 MD5 算法加密的密文。
        /// </returns>
        public static string ToMD5Lower32(this string value) => new MessageDigestAlgorithm().MD532(value);
        #endregion

        #region 指示指定要加密的字符串进行 MD5 算法的32位大写加密
        /// <summary>
        /// 指示指定要加密的字符串进行 MD5 算法的32位大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回32位大写的 MD5 算法加密的密文。
        /// </returns>
        public static string ToMD5Upper32(this string value) => new MessageDigestAlgorithm().MD532Upper(value);
        #endregion

        #region 指示指定要加密的字符串进行 MD5 混淆加密
        /// <summary>
        /// 指示指定要加密的字符串进行 MD5 混淆加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 MD5 算法加密的混淆密文。
        /// </returns>
        public static string ToMD5Confusion(this string value) => new MessageDigestAlgorithm().MD5Confusion(value);
        #endregion

        #region 指示指定要加密的字符串进行 SHA1 算法小写加密
        /// <summary>
        /// 指示指定要加密的字符串进行 SHA1 算法小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 SHA1 算法加密的小写的密文。
        /// </returns>
        public static string ToSHA1(this string value) => new MessageDigestAlgorithm().SHA1(value);
        #endregion

        #region 指示指定要加密的字符串进行 SHA1 算法大写加密
        /// <summary>
        /// 指示指定要加密的字符串进行 SHA1 算法大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 SHA1 算法加密的大写的密文。
        /// </returns>
        public static string ToSHA1Upper(this string value) => new MessageDigestAlgorithm().SHA1Upper(value);
        #endregion

        #region 指示指定要加密的字符串进行 SHA1 算法混淆加密
        /// <summary>
        /// 指示指定要加密的字符串进行 SHA1 算法混淆加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回SHA1的混淆加密密文。
        /// </returns>
        public static string ToSHA1Confusion(this string value) => new MessageDigestAlgorithm().SHA1Confusion(value);
        #endregion

        #region 指示指定要加密的字符串进行 SHA256 算法小写加密
        /// <summary>
        /// 指示指定要加密的字符串进行 SHA256 算法小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 SHA256 算法加密的小写的密文。
        /// </returns>
        public static string ToSHA256(this string value) => new MessageDigestAlgorithm().SHA256(value);
        #endregion

        #region 指示指定要加密的字符串进行 SHA256 算法大写加密
        /// <summary>
        /// 指示指定要加密的字符串进行 SHA256 算法大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 SHA256 算法加密的大写的密文。
        /// </returns>
        public static string ToSHA256Upper(this string value) => new MessageDigestAlgorithm().SHA256Upper(value);
        #endregion

        #region 指示指定要加密的字符串进行 SHA384 算法小写加密
        /// <summary>
        /// 指示指定要加密的字符串进行 SHA384 算法小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 SHA384 算法加密的小写的密文。
        /// </returns>
        public static string ToSHA384(this string value) => new MessageDigestAlgorithm().SHA384(value);
        #endregion

        #region 指示指定要加密的字符串进行 SHA384 算法大写加密
        /// <summary>
        /// 指示指定要加密的字符串进行 SHA384 算法大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 SHA384 算法加密的大写的密文。
        /// </returns>
        public static string ToSHA384Upper(this string value) => new MessageDigestAlgorithm().SHA384Upper(value);
        #endregion

        #region 指示指定要加密的字符串进行 SHA512 算法小写加密
        /// <summary>
        /// 指示指定要加密的字符串进行 SHA512 算法小写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 SHA512 算法加密的小写的密文。
        /// </returns>
        public static string ToSHA512(this string value) => new MessageDigestAlgorithm().SHA512(value);
        #endregion

        #region 指示指定要加密的字符串进行 SHA512 算法大写加密
        /// <summary>
        /// 指示指定要加密的字符串进行 SHA512 算法大写加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 SHA512 算法加密的大写的密文。
        /// </returns>
        public static string ToSHA512Upper(this string value) => new MessageDigestAlgorithm().SHA512Upper(value);
        #endregion

        #region 指示指定要加密的字符串进行 DES 算法加密
        /// <summary>
        /// 指示指定要加密的字符串进行 DES 算法加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <param name="key">密钥：长度最少8位，多于8位则截取。</param>
        /// <param name="iv">
        /// 向量：长度最少8位，如果不指定则使用 key 参数作为向量；
        /// 如果指定，多于8位则截取。</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回DES算法加密后的密文。
        /// </returns>
        /// <exception cref="ArgumentNullException"> key 参数为 null 或者 空字符串("")。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度少于8位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> iv 参数不为空且长度小于8位。 </exception>
        public static string ToDesEncrypt(this string value, string key, string iv = "") => new DataEncryptionStandard().Encrypt(value, key, iv);
        #endregion

        #region 指示指定要解密的字符串进行 DES 算法解密
        /// <summary>
        /// 指示指定要解密的字符串进行 DES 算法解密
        /// </summary>
        /// <param name="value">要解密的字符串</param>
        /// <param name="key">密钥：长度必须为8位，多于8位则截取。</param>
        /// <param name="iv">
        /// 向量：长度必须为8位，如果不指定则为使用 key 参数作为向量；
        /// 如果指定，多于8位则截取。</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回DES算法解密后的明文。
        /// </returns>
        /// <exception cref="ArgumentNullException"> key 参数为 null 或者 空字符串("")。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度少于8位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> iv 参数不为空且长度小于8位。 </exception>
        public static string ToDesDecrypt(this string value, string key, string iv = "") => new DataEncryptionStandard().Decrypt(value, key, iv);
        #endregion

        #region 指示指定要加密的字符串进行 3DES 算法加密
        /// <summary>
        /// 指示指定要加密的字符串进行 3DES 算法加密
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <param name="key">密钥：长度必须为24位，多于24位则截取。</param>
        /// <param name="iv">
        /// 向量：长度必须为8位，如果不指定则使用 key 参数的前8位作为向量；
        /// 如果指定，多于8位则截取。</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回3DES算法加密后的密文。
        /// </returns>
        /// <exception cref="ArgumentNullException"> key 参数为 null 或者 空字符串("")。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度少于24位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> iv 参数不为空且长度小于8位。 </exception>
        public static string To3DesEncrypt(this string value, string key, string iv = "") => new TripleDataEncryptionAlgorithm().Encrypt(value, key, iv);
        #endregion

        #region 指示指定要解密的字符串进行 3DES 算法解密
        /// <summary>
        /// 指示指定要解密的字符串进行 3DES 算法解密
        /// </summary>
        /// <param name="value">要解密的字符串</param>
        /// <param name="key">密钥：长度必须为24位，多于24位则截取。</param>
        /// <param name="iv">
        /// 向量：长度必须为8位，如果不指定则使用 key 参数的前8位作为向量；
        /// 如果指定，多于8位则截取。</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回3DES算法解密后的明文。
        /// </returns>
        /// <exception cref="ArgumentNullException"> key 参数为 null 或者 空字符串("")。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度少于24位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> iv 参数不为空且长度小于8位。 </exception>
        public static string To3DesDecrypt(this string value, string key, string iv = "") => new TripleDataEncryptionAlgorithm().Decrypt(value, key, iv);
        #endregion

        #region 指示指定要解密的字符串进行 AES 算法加密(CBC模式)
        /// <summary>
        /// 指示指定要解密的字符串进行 AES 算法加密(CBC模式)
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
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回AES算法加密后的密文。
        /// </returns>
        /// <exception cref="ArgumentNullException"> key 参数为 null 或者 空字符串("")。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度少于16位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度大于32位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度不是16位或者24位或者32位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> iv 参数不为空且长度小于16位。</exception>
        public static string ToAesEncrypt(this string value, string key, string iv = "") => new AdvancedEncryptionStandard().Encrypt(value, key, iv);
        #endregion

        #region 指示指定要解密的字符串进行 AES 算法解密(CBC模式)
        /// <summary>
        /// 指示指定要解密的字符串进行 AES 算法解密(CBC模式)
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
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回AES算法解密后的明文。
        /// </returns>
        /// <exception cref="ArgumentNullException"> key 参数为 null 或者 空字符串("")。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度少于16位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度大于32位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> key 参数长度不是16位或者24位或者32位。</exception>
        /// <exception cref="ArgumentOutOfRangeException"> iv 参数不为空且长度小于16位。</exception>
        public static string ToAesDecrypt(this string value, string key, string iv = "") => new AdvancedEncryptionStandard().Decrypt(value, key, iv);
        #endregion

        #region 将指定的字符串去除空格
        /// <summary>
        /// 将指定的字符串去除空格
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>去除空格后的字符串</returns>
        public static string ToNotSpaceString(this string value)
        {
            if (value == null) return string.Empty;
            return value.ToString().Trim();
        }
        #endregion

        #region 将字符串的表示形式转换不为 null 的 System.String 的值
        /// <summary>
        /// 将字符串的表示形式转换不为 null 的 <see cref="string"/> 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串不为 null，则返回当前字符串；
        /// 否则返回 <see cref="string.Empty"/>。
        /// </returns>
        public static string ToNotNullString(this string value)
        {
            if (value.IsNull()) return string.Empty;
            return value;
        }
        #endregion

        #region 将数字的字符串表示形式转换为其等效的 Int16 的值
        /// <summary>
        /// 将数字的字符串表示形式转换为其等效的 <see cref="short"/> 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回0；
        /// 如果字符串转换失败，则返回0；
        /// 如果字符串转换成功，则返回其等效的 <see cref="short"/> 值。
        /// </returns>
        public static short ToInt16(this string value)
        {
            if (value.IsNullOrEmpty()) return 0;

            var isParsed = short.TryParse(value, out short i);
            if (!isParsed) return 0;
            return i;
        }
        #endregion

        #region 将数字的字符串表示形式转换为其等效的 Int32 的值
        /// <summary>
        /// 将数字的字符串表示形式转换为其等效的 <see cref="int"/> 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns> 
        /// 如果字符串为 null 或空字符串 ("")，则返回0；
        /// 如果字符串转换失败，则返回0；
        /// 如果字符串转换成功，则返回等效的 <see cref="int"/> 的值。
        /// </returns>
        public static int ToInt(this string value)
        {
            if (value.IsNullOrEmpty()) return 0;

            var isParsed = int.TryParse(value, out int i);
            if (!isParsed) return 0;
            return i;
        }
        #endregion

        #region 将数字的字符串表示形式转换为其等效的 Int64 的值
        /// <summary>
        /// 将数字的字符串表示形式转换为其等效的 <see cref="long"/> 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回0；
        /// 如果字符串转换失败，则返回0；
        /// 如果字符串转换成功，则返回等效的 <see cref="long"/> 的值。
        /// </returns>
        public static long ToInt64(this string value)
        {
            if (value.IsNullOrEmpty()) return 0;

            var isParsed = long.TryParse(value, out long i);
            if (!isParsed) return 0;
            return i;
        }
        #endregion

        #region 将数字的字符串表示形式转换为其等效的 Single 的值
        /// <summary>
        /// 将数字的字符串表示形式转换为其等效的 <see cref="float"/> 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回0；
        /// 如果字符串转换失败，则返回0；
        /// 如果字符串转换成功，则返回等效的 <see cref="float"/> 的值。
        /// </returns>
        public static float ToSingle(this string value)
        {
            if (value.IsNullOrEmpty()) return 0;

            var isParsed = float.TryParse(value, out float i);
            if (!isParsed) return 0;
            return i;
        }
        #endregion

        #region 将数字的字符串表示形式转换为其等效的 Double 的值
        /// <summary>
        /// 将数字的字符串表示形式转换为其等效的 <see cref="double"/> 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回0；
        /// 如果字符串转换失败，则返回0；
        /// 如果字符串转换成功，则返回等效的 <see cref="double"/> 的值。
        /// </returns>
        public static double ToDouble(this string value)
        {
            if (value.IsNullOrEmpty()) return 0;

            var isParsed = double.TryParse(value, out double i);
            if (!isParsed) return 0;
            return i;
        }
        #endregion

        #region 将数字的字符串表示形式转换为其等效的 Decimal 的值
        /// <summary>
        /// 将数字的字符串表示形式转换为其等效的 <see cref="decimal"/> 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回0；
        /// 如果字符串转换失败，则返回0；
        /// 如果字符串转换成功，则返回等效的 <see cref="decimal"/> 的值。
        /// </returns>
        public static decimal ToDecimal(this string value)
        {
            if (value.IsNullOrEmpty()) return 0;

            var isParsed = decimal.TryParse(value, out decimal i);
            if (!isParsed) return 0;
            return i;
        }
        #endregion

        #region 将时间的字符串表示形式转换为其等效的 DateTime 对象
        /// <summary>
        /// 将时间的字符串表示形式转换为其等效的 <see cref="DateTime"/> 对象
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则抛出异常("该字符串未被识别为有效的DateTime。")；
        /// 如果字符串转换失败，则抛出异常("该字符串未被识别为有效的DateTime。")；
        /// 如果字符串转换成功，则返回等效的 <see cref="DateTime"/> 的对象。
        /// </returns>
        /// <exception cref="ArgumentNullException"> value 参数为 null 或空字符串 ("")</exception>
        /// <exception cref="InvalidCastException"> value 参数转换失败。</exception>
        public static DateTime ToDateTime(this string value)
        {
            if (value.IsNullOrEmpty()) throw new InvalidCastException("该字符串未被识别为有效的DateTime。");
            if (IsInt64(value)) return UnixToDateTime(value);

            var isParsed = DateTime.TryParse(value, out DateTime _d);
            if (!isParsed) throw new InvalidCastException("该字符串未被识别为有效的DateTime。");
            return _d;
        }
        #endregion

        #region 将布尔的字符串表示形式转换为其等效的 Boolean 的值
        /// <summary>
        /// 将布尔的字符串表示形式转换为其等效的 <see cref="bool"/> 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 false；
        /// 如果字符串转换失败，则返回 false；
        /// 如果字符串转换成功，则返回等效的 <see cref="bool"/> 的值。
        /// </returns>
        /// <exception cref="InvalidCastException"> value 参数转换失败。</exception>
        public static bool ToBoolean(this string value)
        {
            if (value.IsNullOrEmpty()) throw new InvalidCastException("该字符串未被识别为有效的布尔值。");

            var isParsed = bool.TryParse(value, out bool _b);
            if (!isParsed) throw new InvalidCastException("该字符串未被识别为有效的布尔值。");
            return _b;
        }
        #endregion

        #region 将 Guid 的字符串表示形式转换为其等效的 Guid 的值
        /// <summary>
        /// 将 <see cref="Guid"/> 的字符串表示形式转换为其等效的 <see cref="Guid"/> 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("") 或者转换失败，则返回 <see cref="Guid.Empty"/>；
        /// 否则返回等效的 <see cref="Guid"/> 的值。
        /// </returns>
        public static Guid ToGuid(this string value)
        {
            if (value.IsNullOrEmpty()) return Guid.Empty;

            var isParsed = Guid.TryParse(value, out Guid result);
            if (!isParsed) return Guid.Empty;
            return result;
        }
        #endregion

        #region 将 Guid 的字符串表示形式转换为其等效的 Guid 的值
        /// <summary>
        /// 将 <see cref="Guid"/> 的字符串表示形式转换为其等效的 <see cref="Guid"/> 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <param name="format">指示当解释 input 时要使用的确切格式：“N”、“D”、“B”、“P”或“X”</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("") 或者转换失败，则返回 <see cref="Guid.Empty"/>；
        /// 否则返回等效的 <see cref="Guid"/> 的值。
        /// </returns>
        public static Guid ToGuid(this string value, string format)
        {
            if (value.IsNullOrEmpty()) return Guid.Empty;

            var isParsed = Guid.TryParseExact(value, format, out Guid result);
            if (!isParsed) return Guid.Empty;
            return result;
        }
        #endregion

        #region 将数字的字符串表示形式转换为其等效的 short? 的值
        /// <summary>
        /// 将数字的字符串表示形式转换为其等效的 <see cref="short"/>? 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回其等效的 <see cref="short"/> 值。
        /// </returns>
        public static short? ToNullableInt16(this string value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = short.TryParse(value, out short i);
            if (!isParsed) return null;
            return i;
        }
        #endregion

        #region 将数字的字符串表示形式转换为其等效的 int? 的值
        /// <summary>
        /// 将数字的字符串表示形式转换为其等效的 <see cref="int"/>? 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns> 
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="int"/> 的值。
        /// </returns>
        public static int? ToNullableInt(this string value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = int.TryParse(value, out int i);
            if (!isParsed) return null;
            return i;
        }
        #endregion

        #region 将数字的字符串表示形式转换为其等效的 long? 的值
        /// <summary>
        /// 将数字的字符串表示形式转换为其等效的 <see cref="long"/>? 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="long"/> 的值。
        /// </returns>
        public static long? ToNullableInt64(this string value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = long.TryParse(value, out long i);
            if (!isParsed) return null;
            return i;
        }
        #endregion

        #region 将数字的字符串表示形式转换为其等效的 float? 的值
        /// <summary>
        /// 将数字的字符串表示形式转换为其等效的 <see cref="float"/>? 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="float"/> 的值。
        /// </returns>
        public static float? ToNullableSingle(this string value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = float.TryParse(value, out float i);
            if (!isParsed) return null;
            return i;
        }
        #endregion

        #region 将数字的字符串表示形式转换为其等效的 double? 的值
        /// <summary>
        /// 将数字的字符串表示形式转换为其等效的 <see cref="double"/>? 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="double"/> 的值。
        /// </returns>
        public static double? ToNullableDouble(this string value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = double.TryParse(value, out double i);
            if (!isParsed) return null;
            return i;
        }
        #endregion

        #region 将数字的字符串表示形式转换为其等效的 decimal? 的值
        /// <summary>
        /// 将数字的字符串表示形式转换为其等效的 <see cref="decimal"/>? 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="decimal"/> 的值。
        /// </returns>
        public static decimal? ToNullableDecimal(this string value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = decimal.TryParse(value, out decimal i);
            if (!isParsed) return null;
            return i;
        }
        #endregion

        #region 将时间的字符串表示形式转换为其等效的 DateTime? 对象
        /// <summary>
        /// 将时间的字符串表示形式转换为其等效的 <see cref="DateTime"/>? 对象
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="DateTime"/> 的对象。
        /// </returns>
        public static DateTime? ToNullableDateTime(this string value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = DateTime.TryParse(value, out DateTime _d);
            if (!isParsed) return null;
            return _d;
        }
        #endregion

        #region 将布尔的字符串表示形式转换为其等效的 bool? 的值
        /// <summary>
        /// 将布尔的字符串表示形式转换为其等效的 <see cref="bool"/>? 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 如果转换失败，则返回 null；
        /// 如果转换成功，则返回等效的 <see cref="bool"/> 的值。
        /// </returns>
        public static bool? ToNullableBoolean(this string value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = bool.TryParse(value, out bool _b);
            if (!isParsed) return null;
            return _b;
        }
        #endregion

        #region 将 Guid 的字符串表示形式转换为其等效的 Guid? 的值
        /// <summary>
        /// 将 <see cref="Guid"/> 的字符串表示形式转换为其等效的 <see cref="Guid"/>? 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("") 或者转换失败，则返回 null；
        /// 否则返回等效的 <see cref="Guid"/> 的值。
        /// </returns>
        public static Guid? ToNullableGuid(this string value)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = Guid.TryParse(value, out Guid result);
            if (!isParsed) return null;
            return result;
        }
        #endregion

        #region 将 Guid 的字符串表示形式转换为其等效的 Guid? 的值
        /// <summary>
        /// 将 <see cref="Guid"/> 的字符串表示形式转换为其等效的 <see cref="Guid"/>? 的值
        /// </summary>
        /// <param name="value">指定的字符串</param>
        /// <param name="format">指示当解释 input 时要使用的确切格式：“N”、“D”、“B”、“P”或“X”</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("") 或者转换失败，则返回 null；
        /// 否则返回等效的 <see cref="Guid"/> 的值。
        /// </returns>
        public static Guid? ToNullableGuid(this string value, string format)
        {
            if (value.IsNullOrEmpty()) return null;

            var isParsed = Guid.TryParseExact(value, format, out Guid result);
            if (!isParsed) return null;
            return result;
        }
        #endregion

        #region 将 Json 的字符串表示形式转换为 Newtonsoft.Json.Linq.JObject 对象
        /// <summary>
        /// 将 Json 的字符串表示形式转换为 <see cref="JObject"/> 对象
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回 <see cref="JObject"/> 对象。
        /// </returns>
        public static JObject ToJson(this string value)
        {
            if (value.IsNullOrEmpty()) return null;
            return JObject.Parse(value);
        }
        #endregion

        #region 将 Json 数组的字符串表示形式转换为 Newtonsoft.Json.Linq.JArray 对象
        /// <summary>
        /// 将 Json 数组的字符串表示形式转换为 <see cref="JArray"/> 对象
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回 <see cref="JArray"/> 对象。
        /// </returns>
        public static JArray ToJsonArray(this string value)
        {
            if (value.IsNullOrEmpty()) return null;
            return JArray.Parse(value);
        }
        #endregion

        #region 将 Base64 字符串表示形式转换为等效的字符串
        /// <summary>
        /// 将 Base64 字符串表示形式转换为等效的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FromBase64ToString(this string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;

            var result = Convert.FromBase64String(value);
            return Encoding.Default.GetString(result);
        }
        #endregion

        #region 将当前字符串转换为 Base64 字符串表示形式
        /// <summary>
        /// 将当前字符串转换为 Base64 字符串表示形式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBase64String(this string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;

            var result = Encoding.Default.GetBytes(value);
            return Convert.ToBase64String(result);
        }
        #endregion

        #region 计算指定字符串的16位 MD5 的哈希/散列值
        /// <summary>
        /// 计算指定字符串的16位 MD5 的哈希/散列值
        /// </summary>
        /// <param name="value">要计算的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回计算所得的16位MD5哈希/散列值。
        /// </returns>
        public static string To16MD5Hash(this string value) => new MessageDigestAlgorithm().Get16MD5Hash(value);
        #endregion

        #region 计算指定字符串的32位 MD5 的哈希/散列值
        /// <summary>
        /// 计算指定字符串的32位 MD5 的哈希/散列值
        /// </summary>
        /// <param name="value">要计算的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回计算所得的32位MD5哈希/散列值。
        /// </returns>
        public static string To32MD5Hash(this string value) => new MessageDigestAlgorithm().Get32MD5Hash(value);
        #endregion

        #region 计算指定字符串的 SHA1 算法的哈希/散列值
        /// <summary>
        /// 计算指定字符串的 SHA1 算法的哈希/散列值
        /// </summary>
        /// <param name="value">要计算的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者为空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回计算所得的SHA1算法哈希/散列值。
        /// </returns>
        public static string ToSHA1Hash(this string value) => new MessageDigestAlgorithm().GetSHA1Hash(value);
        #endregion

        #region 获取指定的字符串中包含的后缀名
        /// <summary>
        /// 获取指定的字符串中包含的后缀名
        /// </summary>
        /// <param name="value">要获取后缀名的字符串</param>
        /// <param name="containDot">是否包含"."，true 则包含；false 则不包含，默认为包含</param>
        /// <returns>
        /// 返回字符串包含"."，且 containDot 参数为 true 则返回最后一个"."后的字符串，包含"."；
        /// 返回字符串包含"."，且 containDot 参数为 false 则返回最后一个"."后的字符串，不包含"."；
        /// 如果字符串为 null 或空字符串 ("")，则返回 <see cref="string.Empty"/>
        /// </returns>
        public static string ExtendName(this string value, bool containDot = true)
        {
            if (value.IsNullOrEmpty()) return string.Empty;

            var _lastName = string.Empty;
            if (containDot) _lastName = value.Substring(value.LastIndexOf("."));
            else _lastName = value.Substring(value.LastIndexOf(".") + 1);

            if (_lastName.NotNullAndEmpty()) return _lastName;
            return string.Empty;
        }
        #endregion

        #region 获取当前电子邮箱的字符串表示形式的前缀
        /// <summary>
        /// 获取当前电子邮箱的字符串表示形式的前缀
        /// </summary>
        /// <param name="value">要获取电子邮箱前缀的字符串</param>
        /// <returns>
        /// 如果当前字符串为 null 或者空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 如果当前字符串不是正确的电子邮箱，则返回 <see cref="string.Empty"/>；
        /// 否则返回字符串中 @ 符号前的字符。
        /// </returns>
        public static string EmailPrefix(this string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            if (!value.IsEmail()) return string.Empty;
            return value.Substring(0, value.IndexOf("@"));
        }
        #endregion

        #region 获取 Json 的字符串表示形式中的值
        /// <summary>
        /// 获取 Json 的字符串表示形式中的值
        /// </summary>
        /// <param name="value">Json 的字符串表示形式</param>
        /// <param name="key">要获取值的 Key</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 Key 对应的 Value。
        /// </returns>
        public static string GetJsonValue(this string value, string key)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            var json = value.ToJson();
            var result = json.GetKeyValue(key);
            if (result.Value != null) return result.Value.ToString();
            return string.Empty;
        }
        #endregion

        #region 获取 Json 的字符串表示形式中的值
        /// <summary>
        /// 获取 Json 的字符串表示形式中的值
        /// </summary>
        /// <typeparam name="T">要获取值的类型</typeparam>
        /// <param name="value">Json 的字符串表示形式</param>
        /// <param name="key">要获取值的 Key</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 <see cref="string.Empty"/>；
        /// 否则返回 Key 对应的 Value
        /// </returns>
        public static T GetJsonValue<T>(this string value, string key)
        {
            if (value.IsNullOrEmpty()) return default(T);
            var json = value.ToJson();
            var result = json.GetValue(key);
            if (result.HasValues) return result.Value<T>();
            return default(T);
        }
        #endregion

        #region 获取指定的中华人民共和国第二代身份证号码字符串的出生日期
        /// <summary>
        /// 获取指定的中华人民共和国第二代身份证号码字符串的出生日期
        /// </summary>
        /// <param name="value">中华人民共和国第二代身份证号码字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者空字符串("")，则返回 null；
        /// 如果字符串检验结果不为中华人民共和国第二代身份证号码，则返回 null；
        /// 否则返回从6到14位的出生日期；
        /// </returns>
        public static DateTime? GetDateOfBirthOfChinaIDNumber(this string value)
        {
            if (value.IsNullOrEmpty()) return null;
            if (!value.IsChinaIdentityNumber()) return null;
            return DateTime.Parse($"{value.Substring(6, 4)}-{value.Substring(10, 2)}-{value.Substring(12, 2)}");
        }
        #endregion

        #region 获取指定的中华人民共和国第二代身份证号码字符串的当前年龄
        /// <summary>
        /// 获取指定的中华人民共和国第二代身份证号码字符串的当前年龄
        /// </summary>
        /// <param name="value">中华人民共和国第二代身份证号码字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者空字符串("")，则返回 null；
        /// 如果字符串检验结果不为中华人民共和国第二代身份证号码，则返回 null；
        /// 否则返回从出生日期到今天的年龄；
        /// </returns>
        public static int? GetAgeOfChinaIDNumber(this string value)
        {
            if (value.IsNullOrEmpty()) return null;
            var _date = value.GetDateOfBirthOfChinaIDNumber();
            if (!_date.HasValue) return null;
            var diff = DateTime.Now.Subtract(_date.Value);
            return diff.Days / 365;
        }
        #endregion

        #region 获取指定的中华人民共和国第二代身份证号码字符串的性别的文字
        /// <summary>
        /// 获取指定的中华人民共和国第二代身份证号码字符串的性别的文字
        /// </summary>
        /// <param name="value">中华人民共和国第二代身份证号码字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者空字符串("")，则返回 <see cref="string.Empty"/>；
        /// 如果字符串检验结果不为中华人民共和国第二代身份证号码，则返回 <see cref="string.Empty"/>；
        /// 否则返回性别文字，"男" / "女"；
        /// </returns>
        public static string GetGenderTextOfChinaIDNumber(this string value)
        {
            if (value.IsNullOrEmpty()) return string.Empty;
            if (!value.IsChinaIdentityNumber()) return string.Empty;
            return int.Parse(value.Substring(16, 1)) % 2 == 0 ? "女" : "男";
        }
        #endregion

        #region 获取指定的中华人民共和国第二代身份证号码字符串的性别的数字
        /// <summary>
        /// 获取指定的中华人民共和国第二代身份证号码字符串的性别的数字
        /// </summary>
        /// <param name="value">中华人民共和国第二代身份证号码字符串</param>
        /// <returns>
        /// 如果字符串为 null 或者空字符串("")，则返回 null；
        /// 如果字符串检验结果不为中华人民共和国第二代身份证号码，则返回 null；
        /// 否则返回性别的数字：1 - 男，2 - 女；
        /// </returns>
        public static int? GetGenderCodeOfChinaIDNumber(this string value)
        {
            if (value.IsNullOrEmpty()) return null;
            if (!value.IsChinaIdentityNumber()) return null;
            return int.Parse(value.Substring(16, 1)) % 2 == 0 ? 2 : 1;
        }
        #endregion
    }
}
