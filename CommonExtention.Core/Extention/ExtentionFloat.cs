using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extention
{
    /// <summary>
    /// <see cref="float"/> 扩展
    /// </summary>
    public static class ExtentionFloat
    {
        #region 将此实例的数值转换为其千分位的字符串表示形式
        /// <summary>
        /// 将此实例的数值转换为其千分位的字符串表示形式
        /// </summary>
        /// <param name="value">要转换的 <see cref="float"/> </param>
        /// <returns>此实例的值的千分位字符串表示形式</returns>
        public static string ToThousand(this float value) => string.Format("{0:N}", value);
        #endregion
    }
}
