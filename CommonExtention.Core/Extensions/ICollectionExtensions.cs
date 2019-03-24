using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="ICollection"/> 扩展
    /// </summary>
    public static class ICollectionExtensions
    {
        #region 对 ICollection 的每个元素执行指定操作
        /// <summary>
        /// 对 <see cref="ICollection{T}"/> 的每个元素执行指定操作
        /// </summary>
        /// <typeparam name="T">要执行指定操作的 <see cref="ICollection{T}"/> 元素的类型</typeparam>
        /// <param name="ts">要执行指定操作的 <see cref="ICollection{T}"/> 集合</param>
        /// <param name="action">要对 <see cref="ICollection{T}"/> 的每个元素执行的 <see cref="Action{T}"/> 委托</param>
        public static void ForEach<T>(this ICollection<T> ts, Action<T> action)
        {
            foreach (var item in ts)
            {
                action(item);
            }
        }
        #endregion

        #region 对 ICollection 的每个元素执行指定操作
        /// <summary>
        /// 对 <see cref="ICollection{T}"/> 的每个元素执行指定操作
        /// </summary>
        /// <typeparam name="T">要执行指定操作的 <see cref="ICollection{T}"/> 元素的类型</typeparam>
        /// <param name="ts">要执行指定操作的 <see cref="ICollection{T}"/> 集合</param>
        /// <param name="action">要对 <see cref="ICollection{T}"/> 的每个元素执行的 <see cref="Action{T}"/> 委托</param>
        public static void ForEach<T>(this ICollection<T> ts, Action<T, int> action)
        {
            var index = 0;
            foreach (var item in ts)
            {
                action(item, index);
                index++;
            }
        }
        #endregion
    }
}
