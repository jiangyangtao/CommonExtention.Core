using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Attributes
{
    /// <summary>
    /// Excel 自动导出时，指定属性的列名
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ExcelColumnNameAttribute : Attribute
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="ExcelColumnNameAttribute"/> 类的新实例
        /// </summary>
        /// <param name="columnName">指定的列名</param>
        public ExcelColumnNameAttribute(string columnName) => columnName = ColumnName;
        #endregion

        #region 公开属性
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { set; get; }
        #endregion
    }
}
