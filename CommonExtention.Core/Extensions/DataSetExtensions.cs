using CommonExtention.Core.Common;
using Newtonsoft.Json;
using System.Data;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="DataSet"/> 扩展
    /// </summary>
    public static class DataSetExtensions
    {
        #region 将当前 DataSet 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataSet"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataSet">要转换的 <see cref="DataSet"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <returns>如果 <see cref="DataSet"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJson(this DataSet dataSet, Formatting formatting) => Serialization.SerializeDataSetToJson(dataSet, formatting);
        #endregion

        #region 将当前 DataSet 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataSet"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataSet">要转换的 <see cref="DataSet"/> </param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>如果 <see cref="DataSet"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJson(this DataSet dataSet, JsonSerializerSettings settings) => Serialization.SerializeDataSetToJson(dataSet, settings);
        #endregion

        #region 将当前 DataSet 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataSet"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataSet">要转换的 <see cref="DataSet"/> </param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 <see cref="DataSet"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJson(this DataSet dataSet, params JsonConverter[] converters) => Serialization.SerializeDataSetToJson(dataSet, converters);
        #endregion

        #region 将当前 DataSet 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataSet"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataSet">要转换的 <see cref="DataSet"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="settings">序列化的设置</param>
        /// <returns>如果 <see cref="DataSet"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJson(this DataSet dataSet, Formatting formatting, JsonSerializerSettings settings) => Serialization.SerializeDataSetToJson(dataSet, settings);
        #endregion

        #region 将当前 DataSet 对象转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="DataSet"/> 对象转换为 Json 数组字符串
        /// </summary>
        /// <param name="dataSet">要转换的 <see cref="DataSet"/> </param>
        /// <param name="formatting">序列化的格式</param>
        /// <param name="converters">序列化时使用的转换器的集合</param>
        /// <returns>如果 <see cref="DataSet"/> 为 null，则返回 <see cref="string.Empty"/>；否则返回序列化后的 json 字符串。</returns>
        public static string ToJson(this DataSet dataSet, Formatting formatting, params JsonConverter[] converters) => Serialization.SerializeDataSetToJson(dataSet, formatting, converters);
        #endregion
    }
}
