using Newtonsoft.Json;
using System;
using System.Collections.Specialized;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="NameValueCollection"/> 扩展
    /// </summary>
    public static class NameValueCollectionExtensions
    {
        #region 对当前集合的每个元素执行指定操作
        /// <summary>
        /// 对当前集合的每个元素执行指定操作
        /// </summary>
        /// <param name="collection">当前的集合</param>
        /// <param name="action">要对 <see cref="NameValueCollection"/> 的每个元素执行的 <see cref="Action{T}"/> 委托</param>
        public static void ForEach(this NameValueCollection collection, Action<string, string> action)
        {
            if (collection == null || collection.Count <= 0) return;

            var keys = collection.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                action(key, collection[i]);
            }
        }
        #endregion

        #region 对当前集合的每个元素执行指定操作
        /// <summary>
        /// 对当前集合的每个元素执行指定操作
        /// </summary>
        /// <param name="collection">当前的集合</param>
        /// <param name="action">要对 <see cref="NameValueCollection"/> 的每个元素执行的 <see cref="Action{T}"/> 委托</param>
        public static void ForEach(this NameValueCollection collection, Action<string, string, int> action)
        {
            if (collection == null || collection.Count <= 0) return;

            var keys = collection.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                action(key, collection[i], i);
            }
        }
        #endregion

        #region 将当前集合序列化成 Json 的字符串表示形式
        /// <summary>
        /// 将当前集合序列化成 Json 的字符串表示形式
        /// </summary>
        /// <param name="collection">当前的集合</param>
        /// <returns>
        /// 如果 collection 参数为 null 或者 collection 的 Count 属性为0，则返回 <see cref="string.Empty"/>;
        /// 否则返回 Newtonsoft 序列化后的 json 字符串。
        /// </returns>
        public static string ToJson(this NameValueCollection collection)
        {
            if (collection == null || collection.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(collection);
        }
        #endregion
    }
}
