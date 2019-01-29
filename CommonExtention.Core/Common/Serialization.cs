using CommonExtention.Core.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Xml.Linq;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// 提供 实体、<see cref="DataTable"/> 对象、<see cref="DataSet"/> 对象、<see cref="List{T}"/> 集合、<see cref="XmlNode"/>、<see cref="XNode"/>、<see cref="XDocument"/> 的序列化和反序列化
    /// </summary>
    public static class Serialization
    {
        #region Entity

        #region Serialize

        /// <summary>
        /// 将实体序列化成 Json 字符串
        /// </summary>
        /// <typeparam name="TEntity">要序列化的实体的类型</typeparam>
        /// <param name="entity">要序列化的实体</param>
        /// <returns>
        /// 如果 entity 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。
        /// </returns>
        public static string SerializeEntityToJson<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null) return string.Empty;
            return JsonConvert.SerializeObject(entity);
        }


        /// <summary>
        /// 将实体序列化成 Json 字符串
        /// </summary>
        /// <typeparam name="TEntity">要序列化的实体的类型</typeparam>
        /// <param name="entity">要序列化的实体</param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 entity 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。
        /// </returns>
        public static string SerializeEntityToJson<TEntity>(TEntity entity, params JsonConverter[] converters) where TEntity : class
        {
            if (entity == null) return string.Empty;
            return JsonConvert.SerializeObject(entity, converters);
        }


        /// <summary>
        /// 将实体序列化成 Json 字符串
        /// </summary>
        /// <typeparam name="TEntity">要序列化的实体的类型</typeparam>
        /// <param name="entity">要序列化的实体</param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>如果 entity 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeEntityToJson<TEntity>(TEntity entity, JsonSerializerSettings settings) where TEntity : class
        {
            if (entity == null) return string.Empty;
            return JsonConvert.SerializeObject(entity, settings);
        }


        /// <summary>
        /// 将实体序列化成 Json 字符串
        /// </summary>
        /// <typeparam name="TEntity">要序列化的实体的类型</typeparam>
        /// <param name="entity">要序列化的实体</param>
        /// <param name="formatting">序列化的格式</param>
        /// <returns>如果 entity 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeEntityToJson<TEntity>(TEntity entity, Newtonsoft.Json.Formatting formatting) where TEntity : class
        {
            if (entity == null) return string.Empty;
            return JsonConvert.SerializeObject(entity, formatting);
        }


        /// <summary>
        /// 将实体序列化成 Json 字符串
        /// </summary>
        /// <typeparam name="TEntity">要序列化的实体的类型</typeparam>
        /// <param name="entity">要序列化的实体</param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 entity 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeEntityToJson<TEntity>(TEntity entity, Newtonsoft.Json.Formatting formatting, params JsonConverter[] converters) where TEntity : class
        {
            if (entity == null) return string.Empty;
            return JsonConvert.SerializeObject(entity, formatting, converters);
        }


        /// <summary>
        /// 将实体序列化成 Json 字符串
        /// </summary>
        /// <typeparam name="TEntity">要序列化的实体的类型</typeparam>
        /// <param name="entity">要序列化的实体</param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>如果 entity 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeEntityToJson<TEntity>(TEntity entity, Newtonsoft.Json.Formatting formatting, JsonSerializerSettings settings) where TEntity : class
        {
            if (entity == null) return string.Empty;
            return JsonConvert.SerializeObject(entity, formatting, settings);
        }

        #endregion

        #region Deserialize
        /// <summary>
        /// 将字符串表示形式的 json 反序列化成指定类型的实体
        /// </summary>
        /// <typeparam name="TEntity">实体的类型</typeparam>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后指定类型的实体。
        /// </returns>
        public static TEntity DeserializeJsonToEntity<TEntity>(string json) where TEntity : class
        {
            if (json.IsNullOrEmpty()) return null;
            return JsonConvert.DeserializeObject<TEntity>(json);
        }

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成指定类型的实体
        /// </summary>
        /// <typeparam name="TEntity">实体的类型</typeparam>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <param name="settings">反序列化的设置</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后指定类型的实体。
        /// </returns>
        public static TEntity DeserializeJsonToEntity<TEntity>(string json, JsonSerializerSettings settings) where TEntity : class
        {
            if (json.IsNullOrEmpty()) return null;
            return JsonConvert.DeserializeObject<TEntity>(json, settings);
        }

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成指定类型的实体
        /// </summary>
        /// <typeparam name="TEntity">实体的类型</typeparam>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <param name="converters">反序列化时使用的转换器的集合</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后指定类型的实体。
        /// </returns>
        public static TEntity DeserializeJsonToEntity<TEntity>(string json, params JsonConverter[] converters) where TEntity : class
        {
            if (json.IsNullOrEmpty()) return null;
            return JsonConvert.DeserializeObject<TEntity>(json, converters);
        }
        #endregion

        #endregion

        #region DataTable

        #region Serialize

        /// <summary>
        /// 将 <see cref="DataTable"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="dataTable">要序列化的 <see cref="DataTable"/></param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串，包含 TableName。</returns>
        public static string SerializeDataTableToJson(DataTable dataTable) => dataTable.ToJsonString();


        /// <summary>
        /// 将 <see cref="DataTable"/> 对象序列化成 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要序列化的 <see cref="DataTable"/></param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串，不包含 TableName。</returns>
        public static string SerializeDataTableToJsonArray(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(dataTable);
        }

        /// <summary>
        /// 将 <see cref="DataTable"/> 对象序列化成 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要序列化的 <see cref="DataTable"/></param>
        /// <param name="formatting">序列化的格式</param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeDataTableToJsonArray(DataTable dataTable, Newtonsoft.Json.Formatting formatting)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(dataTable, formatting);
        }

        /// <summary>
        /// 将 <see cref="DataTable"/> 对象序列化成 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要序列化的 <see cref="DataTable"/></param>
        /// <param name="settings">settings</param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeDataTableToJsonArray(DataTable dataTable, JsonSerializerSettings settings)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(dataTable, settings);
        }

        /// <summary>
        /// 将 <see cref="DataTable"/> 对象序列化成 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要序列化的 <see cref="DataTable"/></param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeDataTableToJsonArray(DataTable dataTable, params JsonConverter[] converters)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(dataTable, converters);
        }

        /// <summary>
        /// 将 <see cref="DataTable"/> 对象序列化成 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要序列化的 <see cref="DataTable"/></param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="settings">settings</param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeDataTableToJsonArray(DataTable dataTable, Newtonsoft.Json.Formatting formatting, JsonSerializerSettings settings)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(dataTable, formatting, settings);
        }

        /// <summary>
        /// 将 <see cref="DataTable"/> 对象序列化成 Json 数组字符串
        /// </summary>
        /// <param name="dataTable">要序列化的 <see cref="DataTable"/></param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeDataTableToJsonArray(DataTable dataTable, Newtonsoft.Json.Formatting formatting, params JsonConverter[] converters)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(dataTable, formatting, converters);
        }

        #endregion

        #region Deserialize

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="DataTable"/> 对象
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="DataTable"/> 对象。
        /// </returns>
        public static DataTable DeserializeJsonToDataTable(string json)
        {
            if (json.IsNullOrEmpty()) return null;
            return JsonConvert.DeserializeObject<DataTable>(json);
        }

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="DataTable"/> 对象
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="DataTable"/> 对象。
        /// </returns>
        public static DataTable DeserializeJsonToDataTable(string json, JsonSerializerSettings settings)
        {
            if (json.IsNullOrEmpty()) return null;
            return JsonConvert.DeserializeObject<DataTable>(json, settings);
        }

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="DataTable"/> 对象
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="DataTable"/> 对象。
        /// </returns>
        public static DataTable DeserializeJsonToDataTable(string json, params JsonConverter[] converters)
        {
            if (json.IsNullOrEmpty()) return null;
            return JsonConvert.DeserializeObject<DataTable>(json, converters);
        }

        #endregion

        #endregion

        #region DataSet

        #region Serialize
        /// <summary>
        /// 将 <see cref="DataSet"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="dataSet">要序列化的 <see cref="DataSet"/></param>
        /// <returns>如果 dataSet 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeDataSetToJson(DataSet dataSet)
        {
            if (dataSet == null || dataSet.Tables.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(dataSet);
        }

        /// <summary>
        /// 将 <see cref="DataSet"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="dataSet">要序列化的 <see cref="DataSet"/></param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 dataSet 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeDataSetToJson(DataSet dataSet, params JsonConverter[] converters)
        {
            if (dataSet == null) return string.Empty;
            return JsonConvert.SerializeObject(dataSet, converters);
        }

        /// <summary>
        /// 将 <see cref="DataSet"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="dataSet">要序列化的 <see cref="DataSet"/></param>
        /// <param name="settings">settings</param>
        /// <returns>如果 dataSet 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeDataSetToJson(DataSet dataSet, JsonSerializerSettings settings)
        {
            if (dataSet == null) return string.Empty;
            return JsonConvert.SerializeObject(dataSet, settings);
        }

        /// <summary>
        /// 将 <see cref="DataSet"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="dataSet">要序列化的 <see cref="DataSet"/></param>
        /// <param name="formatting">序列化的格式</param>
        /// <returns>如果 dataSet 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeDataSetToJson(DataSet dataSet, Newtonsoft.Json.Formatting formatting)
        {
            if (dataSet == null) return string.Empty;
            return JsonConvert.SerializeObject(dataSet, formatting);
        }

        /// <summary>
        /// 将 <see cref="DataSet"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="dataSet">要序列化的 <see cref="DataSet"/></param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 dataSet 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeDataSetToJson(DataSet dataSet, Newtonsoft.Json.Formatting formatting, params JsonConverter[] converters)
        {
            if (dataSet == null) return string.Empty;
            return JsonConvert.SerializeObject(dataSet, formatting, converters);
        }

        /// <summary>
        /// 将 <see cref="DataSet"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="dataSet">要序列化的 <see cref="DataSet"/></param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="settings">settings</param>
        /// <returns>如果 dataSet 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeDataSetToJson(DataSet dataSet, Newtonsoft.Json.Formatting formatting, JsonSerializerSettings settings)
        {
            if (dataSet == null) return string.Empty;
            return JsonConvert.SerializeObject(dataSet, formatting, settings);
        }
        #endregion

        #region Deserialize
        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="DataSet"/> 对象
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="DataSet"/> 对象。
        /// </returns>
        public static DataSet DeserializeJsonToDataSet(string json)
        {
            if (json.IsNullOrEmpty()) return null;
            return JsonConvert.DeserializeObject<DataSet>(json);
        }

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="DataSet"/> 对象
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="DataSet"/> 对象。
        /// </returns>
        public static DataSet DeserializeJsonToDataSet(string json, JsonSerializerSettings settings)
        {
            if (json.IsNullOrEmpty()) return null;
            return JsonConvert.DeserializeObject<DataSet>(json, settings);
        }

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="DataSet"/> 对象
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="DataSet"/> 对象。
        /// </returns>
        public static DataSet DeserializeJsonToDataSet(string json, params JsonConverter[] converters)
        {
            if (json.IsNullOrEmpty()) return null;
            return JsonConvert.DeserializeObject<DataSet>(json, converters);
        }
        #endregion

        #endregion

        #region List

        #region Serialize

        /// <summary>
        /// 将 <see cref="List{T}"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <typeparam name="T">要序列化的集合的类型</typeparam>
        /// <param name="list">要序列化的 <see cref="List{T}"/></param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeListToJson<T>(List<T> list)
        {
            if (list == null || list.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 将 <see cref="List{T}"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <typeparam name="T">要序列化的集合的类型</typeparam>
        /// <param name="list">要序列化的 <see cref="List{T}"/></param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeListToJson<T>(List<T> list, params JsonConverter[] converters)
        {
            if (list == null) return string.Empty;
            return JsonConvert.SerializeObject(list, converters);
        }

        /// <summary>
        /// 将 <see cref="List{T}"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <typeparam name="T">要序列化的集合的类型</typeparam>
        /// <param name="list">要序列化的 <see cref="List{T}"/></param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeListToJson<T>(List<T> list, JsonSerializerSettings settings)
        {
            if (list == null) return string.Empty;
            return JsonConvert.SerializeObject(list, settings);
        }

        /// <summary>
        /// 将 <see cref="List{T}"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <typeparam name="T">要序列化的集合的类型</typeparam>
        /// <param name="list">要序列化的 <see cref="List{T}"/></param>
        /// <param name="formatting">序列化的格式</param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeListToJson<T>(List<T> list, Newtonsoft.Json.Formatting formatting)
        {
            if (list == null) return string.Empty;
            return JsonConvert.SerializeObject(list, formatting);
        }

        /// <summary>
        /// 将 <see cref="List{T}"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <typeparam name="T">要序列化的集合的类型</typeparam>
        /// <param name="list">要序列化的 <see cref="List{T}"/></param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeListToJson<T>(List<T> list, Newtonsoft.Json.Formatting formatting, params JsonConverter[] converters)
        {
            if (list == null) return string.Empty;
            return JsonConvert.SerializeObject(list, formatting, converters);
        }

        /// <summary>
        /// 将 <see cref="List{T}"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <typeparam name="T">要序列化的集合的类型</typeparam>
        /// <param name="list">要序列化的 <see cref="List{T}"/></param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>如果 dataTable 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeListToJson<T>(List<T> list, Newtonsoft.Json.Formatting formatting, JsonSerializerSettings settings)
        {
            if (list == null) return string.Empty;
            return JsonConvert.SerializeObject(list, formatting, settings);
        }

        #endregion

        #region Deserialize
        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="List{T}"/> 集合
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="List{T}"/> 集合。
        /// </returns>
        public static List<T> DeserializeJsonToList<T>(string json)
        {
            if (json.IsNullOrEmpty()) return null;
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="List{T}"/> 集合
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="List{T}"/> 集合。
        /// </returns>
        public static List<T> DeserializeJsonToList<T>(string json, JsonSerializerSettings settings)
        {
            if (json.IsNullOrEmpty()) return null;
            return JsonConvert.DeserializeObject<List<T>>(json, settings);
        }

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="List{T}"/> 集合
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="List{T}"/> 集合。
        /// </returns>
        public static List<T> DeserializeJsonToList<T>(string json, params JsonConverter[] converters)
        {
            if (json.IsNullOrEmpty()) return null;
            return JsonConvert.DeserializeObject<List<T>>(json, converters);
        }
        #endregion

        #endregion

        #region XML

        #region Serialize

        #region System.Xml
        /// <summary>
        /// 将 <see cref="XmlNode"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="node">要序列化的 XML 文档中的单个节点</param>
        /// <returns>如果 node 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeXmlToJson(XmlNode node)
        {
            if (node == null) return string.Empty;

            return JsonConvert.SerializeXmlNode(node);
        }

        /// <summary>
        /// 将 <see cref="XmlNode"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="node">要序列化的 XML 文档中的单个节点</param>
        /// <param name="formatting">序列化的格式</param>
        /// <returns>如果 node 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeXmlToJson(XmlNode node, Newtonsoft.Json.Formatting formatting)
        {
            if (node == null) return string.Empty;

            return JsonConvert.SerializeXmlNode(node, formatting);
        }

        /// <summary>
        /// 将 <see cref="XmlNode"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="node">要序列化的 XML 文档中的单个节点</param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="omitRootObject">是否省略根对象的写入</param>
        /// <returns>如果 node 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeXmlToJson(XmlNode node, Newtonsoft.Json.Formatting formatting, bool omitRootObject)
        {
            if (node == null) return string.Empty;

            return JsonConvert.SerializeXmlNode(node, formatting, omitRootObject);
        }
        #endregion

        #region System.Xml.Linq.XDocument
        /// <summary>
        /// 将 <see cref="XDocument"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="xDocument">要序列化的 <see cref="XDocument"/> </param>
        /// <returns>如果 xDocument 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeXmlToJson(XDocument xDocument)
        {
            if (xDocument == null) return string.Empty;

            return JsonConvert.SerializeXNode(xDocument);
        }

        /// <summary>
        /// 将 <see cref="XDocument"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="xDocument">要序列化的 <see cref="XDocument"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <returns>如果 xDocument 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeXmlToJson(XDocument xDocument, Newtonsoft.Json.Formatting formatting)
        {
            if (xDocument == null) return string.Empty;

            return JsonConvert.SerializeXNode(xDocument, formatting);
        }

        /// <summary>
        /// 将 <see cref="XDocument"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="xDocument">要序列化的 <see cref="XDocument"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="omitRootObject">是否省略根对象的写入</param>
        /// <returns>如果 xDocument 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeXmlToJson(XDocument xDocument, Newtonsoft.Json.Formatting formatting, bool omitRootObject)
        {
            if (xDocument == null) return string.Empty;

            return JsonConvert.SerializeXNode(xDocument, formatting, omitRootObject);
        }
        #endregion

        #region System.Xml.Linq.XNode
        /// <summary>
        /// 将 <see cref="XNode"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="node">要序列化的 <see cref="XNode"/> </param>
        /// <returns>如果 node 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeXmlToJson(XNode node)
        {
            if (node == null) return string.Empty;

            return JsonConvert.SerializeXNode(node);
        }

        /// <summary>
        /// 将 <see cref="XNode"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="node">要序列化的 <see cref="XNode"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <returns>如果 node 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeXmlToJson(XNode node, Newtonsoft.Json.Formatting formatting)
        {
            if (node == null) return string.Empty;

            return JsonConvert.SerializeXNode(node, formatting);
        }

        /// <summary>
        /// 将 <see cref="XNode"/> 对象序列化成 Json 字符串
        /// </summary>
        /// <param name="node">要序列化的 <see cref="XNode"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="omitRootObject">是否省略根对象的写入</param>
        /// <returns>如果 node 参数为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string SerializeXmlToJson(XNode node, Newtonsoft.Json.Formatting formatting, bool omitRootObject)
        {
            if (node == null) return string.Empty;

            return JsonConvert.SerializeXNode(node, formatting, omitRootObject);
        }

        #endregion

        #endregion

        #region Deserialize

        #region System.Xml

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="XmlDocument"/>
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="XmlDocument"/>。
        /// </returns>
        public static XmlDocument DeserializeJsonToXmlNode(string json)
        {
            if (json.IsNullOrEmpty()) return null;

            return JsonConvert.DeserializeXmlNode(json);
        }

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="XmlDocument"/>
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <param name="deserializeRootElementName">反序列化时要追加的根元素的名称</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="XmlDocument"/>。
        /// </returns>
        public static XmlDocument DeserializeJsonToXmlNode(string json, string deserializeRootElementName)
        {
            if (json.IsNullOrEmpty()) return null;

            return JsonConvert.DeserializeXmlNode(json, deserializeRootElementName);
        }

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="XmlDocument"/>
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <param name="deserializeRootElementName">反序列化时要追加的根元素的名称</param>
        /// <param name="writeArrayAttribute">一个标志，指示是否编写 Json.NET 数组属性。这个属性在将编写的XML转换回JSON时，有助于保存数组</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="XmlDocument"/>。
        /// </returns>
        public static XmlDocument DeserializeJsonToXmlNode(string json, string deserializeRootElementName, bool writeArrayAttribute)
        {
            if (json.IsNullOrEmpty()) return null;

            return JsonConvert.DeserializeXmlNode(json, deserializeRootElementName, writeArrayAttribute);
        }

        #endregion

        #region System.Xml.Linq

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="XDocument"/>
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="XDocument"/>。
        /// </returns>
        public static XDocument DeserializeXNode(string json)
        {
            if (json.IsNullOrEmpty()) return null;

            return JsonConvert.DeserializeXNode(json);
        }

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="XDocument"/>
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <param name="deserializeRootElementName">反序列化时要追加的根元素的名称</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="XDocument"/>。
        /// </returns>
        public static XDocument DeserializeXNode(string json, string deserializeRootElementName)
        {
            if (json.IsNullOrEmpty()) return null;

            return JsonConvert.DeserializeXNode(json, deserializeRootElementName);
        }

        /// <summary>
        /// 将字符串表示形式的 json 反序列化成 <see cref="XDocument"/>
        /// </summary>
        /// <param name="json">要反序列化的 json 字符串</param>
        /// <param name="deserializeRootElementName">反序列化时要追加的根元素的名称</param>
        /// <param name="writeArrayAttribute">一个标志，指示是否编写 Json.NET 数组属性。这个属性在将编写的XML转换回JSON时，有助于保存数组</param>
        /// <returns>
        /// 如果字符串为 null 或空字符串 ("")，则返回 null；
        /// 否则返回反序列化后的 <see cref="XDocument"/>。
        /// </returns>
        public static XDocument DeserializeXNode(string json, string deserializeRootElementName, bool writeArrayAttribute)
        {
            if (json.IsNullOrEmpty()) return null;

            return JsonConvert.DeserializeXNode(json, deserializeRootElementName, writeArrayAttribute);
        }

        #endregion

        #endregion

        #endregion
    }
}
