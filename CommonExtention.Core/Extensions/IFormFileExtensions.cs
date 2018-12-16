using CommonExtention.Core.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="IFormFile"/> 扩展
    /// </summary>
    public static class IFormFileExtensions
    {
        #region 将当前 IFormFile 对象读取到 DataTable
        /// <summary>
        /// 将当前 <see cref="IFormFile"/> 对象读取到 <see cref="DataTable"/>
        /// </summary>
        /// <param name="formFile"><see cref="IFormFile"/>对象</param>
        /// <param name="sheetName">指定工作薄 sheet 的名称</param>
        /// <param name="firstRowIsColumnName">首行是否为 <see cref="DataColumn.ColumnName"/></param>
        /// <returns></returns>
        public static DataTable ReadToDataTable(this IFormFile formFile, string sheetName = null, bool firstRowIsColumnName = true)
        {
            return ReadExcel.ReadFormFileToDataTable(formFile, sheetName, firstRowIsColumnName);
        }
        #endregion
    }
}
