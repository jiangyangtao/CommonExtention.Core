using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="IFormCollection"/> 扩展
    /// </summary>
    public static class IFormCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="forms"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(this IFormCollection forms, string key)
        {
            if (forms == null || forms.Count <= 0) return string.Empty;
            if (forms.TryGetValue(key, out StringValues value)) return value;
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        public static string ToJson(this IFormCollection forms)
        {
            if (forms == null || forms.Count <= 0) return string.Empty;

            return JsonConvert.SerializeObject(forms);
        }
    }
}
