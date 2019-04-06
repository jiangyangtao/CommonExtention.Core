using System;
using System.Text;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// 提供密码生成。此类不可被继承
    /// </summary>
    public sealed class PasswordGenerator
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="PasswordGenerator"/> 类的新实例
        /// </summary>
        public PasswordGenerator() { }
        #endregion

        #region 私有属性
        /// <summary>
        /// 数字、大小写字母
        /// </summary>
        private const string _Key = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// 符号
        /// </summary>
        private const string _Symbol = "~!@#$%^&*()_+`-=";

        /// <summary>
        /// @ 符号
        /// </summary>
        private const char _AtSymbol = '@';
        #endregion

        #region 生成一个新的密码
        /// <summary>
        /// 生成一个新的密码
        /// </summary>
        /// <param name="length">密码长度</param>
        /// <param name="containsAtSymbol">是否包含 @ 符号</param>
        /// <param name="containsSymbol">是否包含符号</param>
        /// <returns>返回一个包含数字和大小写字母的密码</returns>
        public string NewPassword(int length = 8, bool containsAtSymbol = false, bool containsSymbol = false)
        {
            var key = _Key;
            if (containsSymbol) key = $"{key}{_Symbol}";

            var random = new Random();
            var passwordStringBuild = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                passwordStringBuild.Append(key[random.Next(0, key.Length)]);
            }

            var password = passwordStringBuild.ToString();
            if (containsAtSymbol && !password.Contains(_AtSymbol))
            {
                password = JoinAtSymbol(password.ToString());
            }
            return password;
        }
        #endregion

        #region 加入 @ 符号
        /// <summary>
        /// 加入 @ 符号
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns>返回一个加入@符号的密码</returns>
        private string JoinAtSymbol(string password)
        {
            var index = new Random().Next(0, password.Length);
            return password.Replace(password[index], _AtSymbol);
        }
        #endregion
    }
}
