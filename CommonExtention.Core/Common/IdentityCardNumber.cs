using CommonExtention.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// 提供身份证号码的验证和其它信息。此类不可被继承
    /// </summary>
    public class IdentityCardNumber
    {
        #region Constructor
        /// <summary>
        /// 初始化 身份证号码 的实例
        /// </summary>
        /// <param name="value">身份证号码的字符串</param>
        public IdentityCardNumber(string value)
        {
            IsIdentityNumber = Verification(value);
            if (IsIdentityNumber)
            {
                BirthDate = DateTime.Parse(value.Substring(6, 4) + "-" + value.Substring(10, 2) + "-" + value.Substring(12, 2));
                Age = CalculateAge(BirthDate.Value);
                GenderCode = int.Parse(value.Substring(16, 1)) % 2 == 0 ? 0 : 1;
                GenderText = GenderCode == 0 ? "女" : "男";
            }
        }
        #endregion

        #region Public Property
        /// <summary>
        /// 是否为中华人民共和国第二代身份证号码。如果身份证验证通过，则返回 true; 否则返回 false。
        /// </summary>
        public bool IsIdentityNumber { get; private set; } = false;

        /// <summary>
        /// 出生日期。如果身份证验证通过，则返回 身份证号码上的出生日期; 否则返回 null。
        /// </summary>
        public DateTime? BirthDate { get; private set; } = null;

        /// <summary>
        /// 年龄。如果身份证验证通过，则返回 身份证号码公民的当前周岁; 否则返回 -1。
        /// </summary>
        public int Age { get; private set; } = -1;

        /// <summary>
        /// 性别。如果身份证验证通过，则返回 男 / 女; 否则返回 <see cref="string.Empty"/>。
        /// </summary>
        public string GenderText { get; private set; } = string.Empty;

        /// <summary>
        /// 性别代码。如果身份证验证通过，则返回 0：女 / 1：男; 否则返回 -1。
        /// </summary>
        public int GenderCode { get; private set; } = -1;
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
        public static bool IsChinaIdentityNumber(string value)
        {
            return Verification(value);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// 验证指定的字符串是否为中华人民共和国第二代身份证号码
        /// </summary>
        /// <param name="value">要检测的字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 false；
        /// 如果字符串不是是中华人民共和国第二代身份证号码，则返回 false；
        /// 否则返回 true。
        /// </returns>
        private static bool Verification(string value)
        {
            if (value.IsNullOrEmpty()) return false;
            var objReg = new Regex(@"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
            string birthday = string.Empty;
            if (!objReg.IsMatch(value))
            {
                return false;
            }

            if (value.Length == 15)
            {
                //取生日  
                birthday = "19" + value.Substring(7, 6);
                return IsDate(birthday);
            }
            else if (value.Length == 18)
            {
                //取生日  
                birthday = value.Substring(6, 8);
                if (IsDate(birthday))
                {
                    // 校验表  
                    int[] check = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
                    char[] checkSum = { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };
                    // 校验源  
                    string checkSource = value.Substring(0, 17);
                    // 校验源转换成数字  
                    var source = new List<int>();
                    for (int i = 0; i < checkSource.Length; i++)
                    {
                        source.Add(Convert.ToInt32(checkSource.Substring(i, 1)));
                    }
                    // 校验源的校验和  
                    string checkLast = value.Substring(17);
                    int sum = 0;
                    // 对应项求积，再把所有积求和  
                    for (int i = 0; i < source.Count; i++)
                    {
                        sum += source[i] * check[i];
                    }
                    // 取余  
                    int remainder = sum % 11;
                    if (string.Equals(checkLast, checkSum[remainder].ToString()))
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// 是否是日期
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static bool IsDate(string text)
        {
            var objReg = new Regex(@"((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._]?)(10|12|0?[13578])([-\/\._]?)(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._]?)(11|0?[469])([-\/\._]?)(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._]?)(0?2)([-\/\._]?)(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([3579][26]00)([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([1][89][0][48])([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([2-9][0-9][0][48])([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([1][89][2468][048])([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([2-9][0-9][2468][048])([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([1][89][13579][26])([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([2-9][0-9][13579][26])([-\/\._]?)(0?2)([-\/\._]?)(29)$))");
            return objReg.IsMatch(text);
        }

        /// <summary>
        /// 根据出生日期计算年龄
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int CalculateAge(DateTime dateTime)
        {
            var diff = DateTime.Now.Subtract(BirthDate.Value);
            return diff.Days / 365;
        }
        #endregion
    }
}
