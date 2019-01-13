using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="List{T}"/> 扩展
    /// </summary>
    public static class ListExtensions
    {
        #region 将当前 List<T> 转化为 DataTable
        /// <summary>
        /// 将当前 <see cref="List{T}"/> 转化为 <see cref="DataTable"/>
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="list">当前<see cref="List{T}"/></param>
        /// <param name="addEmptyRow">如果 T 为 null，是否将其添加为空行，默认为 false，不添加。</param>
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
                typeName == "Boolean")
            {
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

        #region 清除当前 List<T> 中的空对象
        /// <summary>
        /// 清除当前 <see cref="List{T}"/> 中的空对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> ClearNull<T>(this List<T> list)
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
