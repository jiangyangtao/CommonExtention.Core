using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="IFormCollection"/> 扩展
    /// </summary>
    public static class IFormCollectionExtensions
    {
        #region 获取当前 IFormCollection 集合的指定值
        /// <summary>
        /// 获取当前 <see cref="IFormCollection"/> 集合的指定值
        /// </summary>
        /// <param name="forms">要获取值的 <see cref="IFormCollection"/></param>
        /// <param name="key">指定的 key </param>
        /// <returns>
        /// 如果 forms 参数为 null，或者其 Count 属性小于或者等于0，则返回 null；
        /// 如果当前 <see cref="IFormCollection"/> 集合中不存在 key 参数的值，则返回 <see cref="string.Empty"/>；
        /// 否则返回与 key 参数对应的 Value。
        /// </returns>
        public static string GetValue(this IFormCollection forms, string key)
        {
            if (forms == null || forms.Count <= 0) return string.Empty;
            if (forms.TryGetValue(key, out StringValues value)) return value;
            return string.Empty;
        }
        #endregion

        #region 将当前 FormCollection 集合转换为 Json 数组字符串
        /// <summary>
        /// 将当前 <see cref="IFormCollection"/> 集合转换为 Json 数组字符串
        /// </summary>
        /// <param name="forms">要转换的 <see cref="IFormCollection"/> 集合</param>
        /// <returns>转换后 Json 数组字符串</returns>
        public static string ToJson(this IFormCollection forms)
        {
            if (forms == null || forms.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(forms);
        }
        #endregion
    }
}
