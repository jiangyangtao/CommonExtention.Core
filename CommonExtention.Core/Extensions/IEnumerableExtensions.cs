using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="IEnumerable"/> 扩展
    /// </summary>
    public static class IEnumerableExtensions
    {
        #region 对当前 IEnumerable 的每个元素执行指定操作
        /// <summary>
        /// 对当前 <see cref="IEnumerable{T}"/> 的每个元素执行指定操作
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> 元素的类型</typeparam>
        /// <param name="ts">源 <see cref="IEnumerable{T}"/> 公开枚举器</param>
        /// <param name="action">要对 <see cref="IEnumerable{T}"/> 的每个元素执行的 <see cref="Action{T}"/> 委托</param>
        public static void ForEach<T>(this IEnumerable<T> ts, Action<T> action)
        {
            foreach (var item in ts)
            {
                action(item);
            }
        }
        #endregion

        #region 对当前 IEnumerable 的每个元素执行指定操作
        /// <summary>
        /// 对当前 <see cref="IEnumerable{T}"/> 的每个元素执行指定操作
        /// </summary>
        /// <typeparam name="T"><see cref="IEnumerable{T}"/> 元素的类型</typeparam>
        /// <param name="ts">源 <see cref="IEnumerable{T}"/> 公开枚举器</param>
        /// <param name="action">要对 <see cref="IEnumerable{T}"/> 的每个元素执行的 <see cref="Action{T}"/> 委托</param>
        public static void ForEach<T>(this IEnumerable<T> ts, Action<T, int> action)
        {
            var index = 0;
            foreach (var item in ts)
            {
                action(item, index);
                index++;
            }
        }
        #endregion

        #region 指示 CustomAttributeData 公开枚举器中是否存在指定的 Attribute
        /// <summary>
        /// 指示 <see cref="CustomAttributeData"/> 公开枚举器中是否存在指定的 <see cref="Attribute"/>
        /// </summary>
        /// <param name="customs"> <see cref="CustomAttributeData"/> 公开枚举器</param>
        /// <param name="type">要验证的 <see cref="Attribute"/> 的 Type</param>
        /// <returns>
        /// 如果集合中存在指定的 <see cref="Attribute"/> 或者 Filter，则为 true;
        /// 如果不存在，则为 false;
        /// </returns>
        public static bool HasAttribute(this IEnumerable<CustomAttributeData> customs, Type type) => customs.Any(a => a.AttributeType == type);
        #endregion
    }
}
