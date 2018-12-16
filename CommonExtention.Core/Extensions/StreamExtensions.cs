using CommonExtention.Core.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="Stream"/> 扩展
    /// </summary>
    public static class StreamExtensions
    {
        #region 将当前 Stream 对象读取到 DataTable
        /// <summary>
        /// 将当前 <see cref="Stream"/> 对象读取到 <see cref="DataTable"/>
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="sheetName">指定工作薄 sheet 的名称</param>
        /// <param name="firstRowIsColumnName">首行是否为 <see cref="DataColumn.ColumnName"/></param>
        /// <returns></returns>
        public static DataTable ReadToDataTable(this Stream stream, string sheetName = null, bool firstRowIsColumnName = true)
        {
            return ReadExcel.ReadStreamToDataTable(stream, sheetName, firstRowIsColumnName);
        }
        #endregion
    }
}
