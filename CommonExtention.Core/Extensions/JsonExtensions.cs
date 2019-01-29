using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// Json 扩展
    /// </summary>
    public static class JsonExtensions
    {
        #region 返回 Key 对应的字符串表示形式的值
        /// <summary>
        /// 返回 Key 对应的字符串表示形式的值
        /// </summary>
        /// <param name="jObject">要获取值的 <see cref="JObject"/>对象</param>
        /// <param name="key">指定的 Key </param>
        /// <returns>
        /// 如果 jObject 为 null，则返回 <see cref="string.Empty"/>；
        /// 如果 key 不存在于 jObject 中，则返回 <see cref="string.Empty"/>；
        /// 否则返回 Key 参数对应的字符串表示形式的值。
        /// </returns>
        public static string GetValue(this JObject jObject, string key)
        {
            if (jObject == null) return string.Empty;
            foreach (var item in jObject)
            {
                if (item.Key.ToLower() == key.ToLower()) return item.Value.ToString();
            }
            return string.Empty;
        }
        #endregion

        #region 返回 Key 对应的指定类型的值
        /// <summary>
        /// 返回 Key 对应的指定类型的值
        /// </summary>
        /// <typeparam name="TOutput">返回值的类型</typeparam>
        /// <param name="jObject">要获取值的 <see cref="JObject"/>对象</param>
        /// <param name="key">指定的 Key </param>
        /// <returns>
        /// 如果 jObject 为 null，则返回 <see cref="string.Empty"/>；
        /// 如果 key 不存在于 jObject 中，则返回 <see cref="string.Empty"/>；
        /// 否则返回 Key 参数对应的指定类型的值。
        /// </returns>
        public static TOutput GetValue<TOutput>(this JObject jObject, string key)
        {
            var defaultResult = default(TOutput);
            if (jObject == null) return defaultResult;

            var value = jObject[key];
            if (!value.HasValues) return defaultResult;

            return jObject[key].Value<TOutput>();
        }
        #endregion

        #region 返回 Key 对应的键值对
        /// <summary>
        /// 返回 Key 对应的键值对
        /// </summary>
        /// <param name="jObject">要获取键值对的 <see cref="JObject"/>对象</param>
        /// <param name="key">指定的 Key </param>
        /// <returns>
        /// 如果 jObject 为 null，则返回 null 值的键值对；
        /// 如果 key 不存在于 jObject 中，则返回 null 值的键值对；
        /// 否则返回 Key 参数对应的键值对。
        /// </returns>
        public static KeyValuePair<string, JToken> GetKeyValue(this JObject jObject, string key)
        {
            var pair = new KeyValuePair<string, JToken>(key, null);
            if (jObject == null) return pair;
            foreach (var item in jObject)
            {
                if (item.Key.ToLower() == key.ToLower()) return item;
            }
            return pair;
        }
        #endregion
    }
}
