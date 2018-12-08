using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="DataTable"/> 扩展
    /// </summary>
    public static class DataTableExtensions
    {
        #region 将当前DataTable对象转换为Json字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 字符串
        /// </summary>
        /// <param name="dt">要转换的 <see cref="DataTable"/> </param>
        /// <returns>返回Json字符串，包含 TableName</returns>
        public static string ToJsonString(this DataTable dt)
        {
            var _jsonBuilder = new StringBuilder();
            _jsonBuilder.Append("{\"" + dt.TableName + "\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    _jsonBuilder.Append("\"");
                    _jsonBuilder.Append(dt.Columns[j].ColumnName);
                    _jsonBuilder.Append("\":");
                    _jsonBuilder.Append(GetValueByType(dt.Rows[i][j]));
                    if (j != dt.Columns.Count - 1) _jsonBuilder.Append(",");
                }
                _jsonBuilder.Append("},");
            }
            if (_jsonBuilder.ToString().Substring(_jsonBuilder.Length - 1, 1) == ",") _jsonBuilder.Remove(_jsonBuilder.Length - 1, 1);
            _jsonBuilder.Append("]}");
            return _jsonBuilder.ToString();
        }
        #endregion

        #region 将当前DataTable对象转换为Json数组字符串
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dt">要转换的 <see cref="DataTable"/> </param>
        /// <returns>返回Json数组字符串，不包含 TableName</returns>
        public static string ToJsonArrayString(this DataTable dt)
        {
            var _jsonBuilder = new StringBuilder();
            _jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    _jsonBuilder.Append("\"");
                    _jsonBuilder.Append(dt.Columns[j].ColumnName);
                    _jsonBuilder.Append("\":");
                    _jsonBuilder.Append(GetValueByType(dt.Rows[i][j]));
                    if (j != dt.Columns.Count - 1) _jsonBuilder.Append(",");
                }
                _jsonBuilder.Append("}");
                if (i != dt.Rows.Count - 1) _jsonBuilder.Append(",");
            }
            _jsonBuilder.Append("]");
            var _json = _jsonBuilder.ToString();
            if (_json.Substring(_json.Length - 1, 1) == ",") _json = _json.Substring(0, _json.Length - 1);
            return _json;
        }

        /// <summary>
        /// 根据类型返回相应的对象
        /// </summary>
        /// <param name="value">object</param>
        /// <returns>object</returns>
        private static object GetValueByType(object value)
        {
            if (value == null) return string.Empty;
            var _type = value.GetType().Name;
            switch (_type)
            {
                case "String": return "\"" + value.ToString().TrimStart().TrimEnd() + "\"";
                case "DateTime": return "\"" + Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss") + "\"";
                case "Int16": return Convert.ToInt16(value);
                case "Int32": return Convert.ToInt32(value);
                case "Int64": return Convert.ToInt64(value);
                case "Decimal": return Convert.ToDecimal(value);
                case "Single": return Convert.ToSingle(value);
                case "Double": return Convert.ToDouble(value);
                case "Boolean": return "\"" + value.ToString() + "\"";
            }
            return value.ToString();
        }
        #endregion

        #region 将当前DataTable对象转换为 Newtonsoft.Json.Linq.JObject 对象
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 <see cref="JObject"/> 对象
        /// </summary>
        /// <param name="dt">要转换的 <see cref="DataTable"/> </param>
        /// <returns>返回 <see cref="JObject"/> 对象，包含 TableName</returns>
        public static JObject ToJObject(this DataTable dt)
        {
            return JObject.Parse(dt.ToJsonString());
        }
        #endregion

        #region 将当前DataTable对象转换为 Newtonsoft.Json.Linq.JArray 对象
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 <see cref="JArray"/> 对象
        /// </summary>
        /// <param name="dt">要转换的 <see cref="DataTable"/> </param>
        /// <returns>返回 <see cref="JArray"/> 对象，不包含 TableName</returns>
        public static JArray ToJArray(this DataTable dt)
        {
            return JArray.Parse(dt.ToJsonArrayString());
        }
        #endregion

        #region 将当前DataTable对象转换为 List 对象
        /// <summary>
        /// 将当前 <see cref="DataTable"/> 对象转换为 <see cref="List{T}"/> 对象
        /// </summary>
        /// <typeparam name="T">要转换的元素的类型</typeparam>
        /// <param name="dt">要转换的 <see cref="DataTable"/> </param>
        /// <returns>转换过后的 <see cref="List{T}"/> 对象</returns>
        public static List<T> ToList<T>(this DataTable dt) where T : class, new()
        {
            List<T> list = new List<T>();
            if (dt == null || dt.Rows.Count <= 0) return list;

            var type = typeof(T);
            var properties = type.GetProperties();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T model = new T();
                foreach (var item in properties)
                {
                    string itemStr = item.Name;
                    var itemType = item.PropertyType;
                    object value = GetDataRowValue(itemStr, itemType, dt.Rows[i]);
                    item.SetValue(model, value, null);
                }
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        ///  根据Type在DataRow中获取对应的column值
        /// </summary>
        /// <param name="columnName">列名称</param>
        /// <param name="columnType">列的类型</param>
        /// <param name="dr">DataRow 集合</param>
        /// <returns>列值</returns>
        private static object GetDataRowValue(string columnName, Type columnType, DataRow dr)
        {
            if (dr.Table.Columns.Contains(columnName))
            {
                if (typeof(string) == columnType) return dr[columnName].ToString();
                if (typeof(short) == columnType) return dr[columnName].ToString().ToInt16();
                if (typeof(short?) == columnType) return dr[columnName].ToString().ToNullableInt16();
                if (typeof(int) == columnType) return dr[columnName].ToString().ToInt();
                if (typeof(int?) == columnType) return dr[columnName].ToString().ToNullableInt();
                if (typeof(long) == columnType) return dr[columnName].ToString().ToInt64();
                if (typeof(long?) == columnType) return dr[columnName].ToString().ToNullableInt64();
                if (typeof(float) == columnType) return dr[columnName].ToString().ToSingle();
                if (typeof(float?) == columnType) return dr[columnName].ToString().ToNullableSingle();
                if (typeof(double) == columnType) return dr[columnName].ToString().ToDouble();
                if (typeof(double?) == columnType) return dr[columnName].ToString().ToNullableDouble();
                if (typeof(decimal) == columnType) return dr[columnName].ToString().ToDecimal();
                if (typeof(decimal?) == columnType) return dr[columnName].ToString().ToNullableDecimal();
                if (typeof(DateTime) == columnType) return dr[columnName].IsNullOrEmpty() ? DateTime.Parse("1900/01/01") : DateTime.Parse(dr[columnName].ToString());
                if (typeof(DateTime?) == columnType) return dr[columnName].ToString().ToNullableDateTime();
                if (typeof(bool) == columnType) return dr[columnName].ToString().ToBoolean();
                if (typeof(bool?) == columnType) return dr[columnName].ToString().ToNullableBoolean();
                if (dr[columnName] != null) return dr[columnName].ToString();
            }
            return string.Empty;
        }
        #endregion

        #region 将当前DataTable对象转换为 ArrayList 对象
        /// <summary>
        /// 将当前DataTable对象转换为 ArrayList 对象
        /// </summary>
        /// <param name="dt">要转换的DataTable</param>
        /// <returns>返回 Dictionary 键值对的 ArrayList 对象</returns>
        public static ArrayList ToArrayList(this DataTable dt)
        {
            var arrayList = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                var dictionary = new Dictionary<string, object>();
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToString());
                }
                arrayList.Add(dictionary);
            }
            return arrayList;
        }
        #endregion

        #region 清除当前 DataTable 对象的空行
        /// <summary>
        /// 清除当前DataTable对象的空行
        /// </summary>
        /// <param name="dt">要清除空行的 DataTable </param>
        /// <returns>返回清除空行后的 DataTable 。</returns>
        public static DataTable ClearEmptyRow(this DataTable dt)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                var emptyColumnCount = 0;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    var item = dt.Rows[i][j].ToString();
                    if (!string.IsNullOrEmpty(item)) break;
                    else emptyColumnCount++;
                }

                if (emptyColumnCount == dt.Columns.Count) dt.Rows.RemoveAt(i);
            }
            return dt;
        }
        #endregion
    }
}
