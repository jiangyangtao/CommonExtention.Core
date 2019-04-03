using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Attributes
{
    /// <summary>
    /// Excel 自动导出时，指定排除的属性不生成列名
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ExcelExcludeColumnAttribute : Attribute
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="ExcelExcludeColumnAttribute"/> 类的新实例
        /// </summary>
        public ExcelExcludeColumnAttribute() { }
        #endregion
    }
}
