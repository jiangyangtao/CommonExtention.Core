using CommonExtention.Core.Common;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="List{T}"/> 扩展
    /// </summary>
    public static class ListExtensions
    {
        #region 将当前 List 集合转换为 DataTable
        /// <summary>
        /// 将当前 <see cref="List{T}"/> 转换为 <see cref="DataTable"/>
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="list">当前<see cref="List{T}"/></param>
        /// <param name="addEmptyRow">如果 list 参数的 item 为 null，是否将其添加为空行，默认为 false，不添加。</param>
        /// <returns>转化后的 <see cref="DataTable"/></returns>
        public static DataTable ToDataTable<T>(this List<T> list, bool addEmptyRow = false)
        {
            if (list == null || !list.Any()) return null;

            var type = typeof(T);
            var typeName = type.Name;
            var dataTable = new DataTable(typeName);

            if (typeName == "String" ||
                typeName == "Int16" ||
                typeName == "Int32" ||
                typeName == "Int64" ||
                typeName == "Decimal" ||
                typeName == "Single" ||
                typeName == "Double" ||
                typeName == "DateTime" ||
                typeName == "Boolean" ||
                typeName == "Guid")
            {
                dataTable.Columns.Add(typeName, type);
                for (int i = 0; i < list.Count; i++)
                {
                    var dataRow = dataTable.NewRow();
                    var item = list[i];
                    if (item == null)
                    {
                        if (addEmptyRow) dataTable.Rows.Add(dataRow);
                        continue;
                    }

                    dataRow[typeName] = item;
                    dataTable.Rows.Add(dataRow);
                }
                return dataTable;
            }

            var keys = type.GetProperties();
            foreach (var item in keys)
            {
                dataTable.Columns.Add(item.Name, item.PropertyType);
            }

            foreach (var entity in list)
            {
                var dataRow = dataTable.NewRow();
                if (entity == null)
                {
                    if (addEmptyRow) dataTable.Rows.Add(dataRow);
                    continue;
                }

                var properties = entity.GetType().GetProperties();
                foreach (var item in properties)
                {
                    dataRow[item.Name] = item.GetValue(entity);
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
        #endregion

        #region 将当前 List 集合转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="List{T}"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="list">要转换的 <see cref="List{T}"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <returns>如果 <see cref="List{T}"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJson<T>(this List<T> list, Formatting formatting) => new Serialization().SerializeListToJson(list, formatting);
        #endregion

        #region 将当前 List 集合转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="List{T}"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="list">要转换的 <see cref="List{T}"/> </param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>如果 <see cref="List{T}"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJson<T>(this List<T> list, JsonSerializerSettings settings) => new Serialization().SerializeListToJson(list, settings);
        #endregion

        #region 将当前 List 集合转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="List{T}"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="list">要转换的 <see cref="List{T}"/> </param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 <see cref="List{T}"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJson<T>(this List<T> list, params JsonConverter[] converters) => new Serialization().SerializeListToJson(list, converters);
        #endregion

        #region 将当前 List 集合转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="List{T}"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="list">要转换的 <see cref="List{T}"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>如果 <see cref="List{T}"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJson<T>(this List<T> list, Formatting formatting, JsonSerializerSettings settings) => new Serialization().SerializeListToJson(list, settings);
        #endregion

        #region 将当前 List 集合转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="List{T}"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="list">要转换的 <see cref="List{T}"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 <see cref="List{T}"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJson<T>(this List<T> list, Formatting formatting, params JsonConverter[] converters) => new Serialization().SerializeListToJson(list, formatting, converters);
        #endregion

        #region 对当前 List 集合的每个元素执行指定操作
        /// <summary>
        /// 对当前 <see cref="List{T}"/> 的每个元素执行指定操作
        /// </summary>
        /// <typeparam name="T">源 <see cref="List{T}"/> 集合元素的类型</typeparam>
        /// <param name="list">源 <see cref="List{T}"/> 集合</param>
        /// <param name="action">要对 <see cref="List{T}"/> 的每个元素执行的 <see cref="Action"/> 委托</param>
        public static void ForEach<T>(this List<T> list, Action<T, int> action)
        {
            for (int i = 0; i < list.Count; i++)
            {
                action(list[i], i);
            }
        }
        #endregion

        #region 将当前 List 集合写入 MemoryStream
        /// <summary>
        /// 将当前 <see cref="List{T}"/> 写入 <see cref="MemoryStream"/>
        /// </summary>
        /// <typeparam name="T">要写入 <see cref="MemoryStream"/> 的集合元素的类型</typeparam>
        /// <param name="list">要写入的 <see cref="List{T}"/> 集合</param>
        /// <param name="sheetsName">Excel 的工作簿名称</param>
        /// <returns>Excel 形式的 <see cref="MemoryStream"/> 对象</returns>
        public static MemoryStream WriteToMemoryStream<T>(this List<T> list, string sheetsName = "sheet1") => new Excel().WriteToMemoryStream(list, sheetsName);
        #endregion

        #region 将当前 List 集合写入 MemoryStream
        /// <summary>
        /// 将当前 <see cref="List{T}"/> 写入 <see cref="MemoryStream"/>
        /// </summary>
        /// <typeparam name="T">要写入 <see cref="MemoryStream"/> 的集合元素的类型</typeparam>
        /// <param name="list">要写入的 <see cref="List{T}"/> 集合</param>
        /// <param name="action">用于执行写入 Excel 单元格的函数</param>
        /// <param name="sheetsName">Excel 的工作簿名称</param>
        /// <returns>Excel 形式的 <see cref="MemoryStream"/> 对象</returns>
        public static MemoryStream WriteToMemoryStream<T>(this List<T> list, Action<ExcelWorksheet, PropertyInfo[]> action,
            string sheetsName = "sheet1") => new Excel().WriteToMemoryStream(list, action, sheetsName);
        #endregion

        #region 将当前 List 集合用异步方式写入 MemoryStream
        /// <summary>
        /// 将当前 <see cref="List{T}"/> 集合用异步方式写入 <see cref="MemoryStream"/>
        /// </summary>
        /// <typeparam name="T">要写入 <see cref="MemoryStream"/> 的集合元素的类型</typeparam>
        /// <param name="list">要写入的 <see cref="List{T}"/> 集合</param>
        /// <param name="sheetsName">Excel 的工作簿名称</param>
        /// <returns>Excel 形式的 <see cref="MemoryStream"/> 对象</returns>
        public static async Task<MemoryStream> WriteToMemoryStreamAsync<T>(this List<T> list, string sheetsName = "sheet1") =>
            await new Excel().WriteToMemoryStreamAsync(list, sheetsName);
        #endregion

        #region 将当前 List 集合用异步方式写入 MemoryStream
        /// <summary>
        /// 将当前 <see cref="List{T}"/> 集合用异步方式写入 <see cref="MemoryStream"/>
        /// </summary>
        /// <typeparam name="T">要写入 <see cref="MemoryStream"/> 的集合元素的类型</typeparam>
        /// <param name="list">要写入的 <see cref="List{T}"/> 集合</param>
        /// <param name="action">用于执行写入 Excel 单元格的函数</param>
        /// <param name="sheetsName">Excel 的工作簿名称</param>
        /// <returns>Excel 形式的 <see cref="MemoryStream"/> 对象</returns>
        public static async Task<MemoryStream> WriteToMemoryStreamAsync<T>(this List<T> list, Action<ExcelWorksheet, PropertyInfo[]> action,
            string sheetsName = "sheet1") => await new Excel().WriteToMemoryStreamAsync(list, action, sheetsName);
        #endregion

        #region 清除当前 List<T> 中的空元素
        /// <summary>
        /// 清除当前 <see cref="List{T}"/> 中的空元素
        /// </summary>
        /// <typeparam name="T">要清除空元素的 <see cref="List{T}"/> 集合元素的类型</typeparam>
        /// <param name="list">要清除空元素的 <see cref="List{T}"/> 集合</param>
        /// <returns>返回已经清除了空元素的 <see cref="List{T}"/> 集合</returns>
        public static List<T> ClearNullItem<T>(this List<T> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                var item = list[i];
                if (item == null || item.ToNotSpaceString().IsNullOrEmpty()) list.RemoveAt(i);
            }
            return list;
        }
        #endregion
    }
}