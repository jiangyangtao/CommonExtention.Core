using CommonExtention.Core.Extensions;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// 提供读取 Excel 功能。此类不可被继承
    /// </summary>
    public sealed class ReadExcel
    {
        #region 构造函数
        /// <summary>
        /// 初始化 ReadExcel 的新实例
        /// </summary>
        public ReadExcel()
        {

        }
        #endregion

        #region 将 Excel 文件读取到 DataTable
        /// <summary>
        /// 将 Excel 文件读取到 <see cref="DataTable"/>
        /// </summary>
        /// <param name="filePath">文件完整路径名</param>
        /// <param name="sheetName">指定读取 Excel 工作薄 sheet 的名称</param>
        /// <param name="firstRowIsColumnName">首行是否为 <see cref="DataColumn.ColumnName"/></param>
        /// <returns><see cref="DataTable"/>数据表</returns>
        public DataTable ReadExcelToDataTable(string filePath, string sheetName = null, bool firstRowIsColumnName = true)
        {
            if (filePath.IsNullOrEmpty()) return null;
            if (!File.Exists(filePath)) return null;

            //根据指定路径读取文件
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            if (fileStream == null || fileStream.Length <= 0) return null;

            //定义要返回的datatable对象
            DataTable data = new DataTable();

            //excel工作表
            ISheet sheet = null;

            //数据开始行(排除标题行)
            int startRow = 0;
            try
            {
                //根据文件流创建excel数据结构
                IWorkbook workbook = WorkbookFactory.Create(fileStream);

                if (sheetName.IsNullOrEmpty()) sheet = workbook.GetSheetAt(0);
                else
                {
                    sheet = workbook.GetSheet(sheetName);

                    //如果没有找到指定的sheetName对应的sheet，则获取第一个sheet
                    if (sheet == null) sheet = workbook.GetSheetAt(0);
                }

                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);

                    //一行最后一个cell的编号 即总的列数
                    int cellCount = firstRow.LastCellNum;

                    //如果第一行是标题列名
                    if (firstRowIsColumnName)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; // 没有数据的行默认是 null，如果为 null 则不添加

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            // 没有数据的单元格默认是 null
                            if (row.GetCell(j) != null) dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                fileStream.Flush();
                fileStream.Close();
            }
        }
        #endregion

        #region 将 IFormFile 对象读取到 DataTable
        /// <summary>
        /// 将 <see cref="IFormFile"/> 对象读取到 <see cref="DataTable"/>
        /// </summary>
        /// <param name="formFile"><see cref="IFormFile"/>对象</param>
        /// <param name="sheetName">指定读取 Excel 工作薄 sheet 的名称</param>
        /// <param name="firstRowIsColumnName">首行是否为 <see cref="DataColumn.ColumnName"/></param>
        /// <returns></returns>
        public DataTable ReadFormFileToDataTable(IFormFile formFile, string sheetName = null, bool firstRowIsColumnName = true)
        {
            var stream = formFile.OpenReadStream();
            var dt = ReadStreamToDataTable(stream, sheetName, firstRowIsColumnName);
            return dt;
        }
        #endregion

        #region 将 Stream 对象读取到 DataTable
        /// <summary>
        /// 将 <see cref="Stream"/> 对象读取到 <see cref="DataTable"/>
        /// </summary>
        /// <param name="stream">当前 <see cref="Stream"/> 对象</param>
        /// <param name="sheetName">指定读取 Excel 工作薄 sheet 的名称</param>
        /// <param name="firstRowIsColumnName">首行是否为 <see cref="DataColumn.ColumnName"/></param>
        /// <returns><see cref="DataTable"/>数据表</returns>
        public DataTable ReadStreamToDataTable(Stream stream, string sheetName = null, bool firstRowIsColumnName = true)
        {
            if (stream == null || stream.Length <= 0) return null;

            //定义要返回的datatable对象
            var data = new DataTable();

            //excel工作表
            ISheet sheet = null;

            //数据开始行(排除标题行)
            int startRow = 0;
            try
            {
                //根据文件流创建excel数据结构,NPOI的工厂类WorkbookFactory会自动识别excel版本，创建出不同的excel数据结构
                IWorkbook workbook = WorkbookFactory.Create(stream);

                //如果有指定工作表名称
                if (!string.IsNullOrEmpty(sheetName))
                {
                    sheet = workbook.GetSheet(sheetName);
                    //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    if (sheet == null)
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    //如果没有指定的sheetName，则尝试获取第一个sheet
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);

                    //一行最后一个cell的编号 即总的列数
                    int cellCount = firstRow.LastCellNum;

                    //如果第一行是标题列名
                    if (firstRowIsColumnName)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null || row.FirstCellNum < 0) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            //同理，没有数据的单元格都默认是null
                            ICell cell = row.GetCell(j);
                            if (cell != null)
                            {
                                if (cell.CellType == CellType.Numeric)
                                {
                                    //判断是否日期类型
                                    if (DateUtil.IsCellDateFormatted(cell))
                                    {
                                        dataRow[j] = row.GetCell(j).DateCellValue;
                                    }
                                    else
                                    {
                                        dataRow[j] = row.GetCell(j).ToString().Trim();
                                    }
                                }
                                else
                                {
                                    dataRow[j] = row.GetCell(j).ToString().Trim();
                                }
                            }
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                stream.Close(); // 关闭流
            }
        }
        #endregion
    }
}