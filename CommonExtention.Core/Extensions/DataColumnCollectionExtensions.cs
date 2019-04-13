using System;
using System.Data;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="DataColumnCollection"/> 扩展
    /// </summary>
    public static class DataColumnCollectionExtensions
    {
        #region 对 DataColumnCollection 的每个元素执行指定操作
        /// <summary>
        /// 对 <see cref="DataColumnCollection"/> 的每个元素执行指定操作
        /// </summary>
        /// <param name="dataColumnCollection">要执行指定操作的 <see cref="DataColumnCollection"/> 集合</param>
        /// <param name="action">要对 <see cref="DataColumnCollection"/> 的每个元素执行的 <see cref="Action{DataColumn}"/> 委托</param>
        public static void ForEach(this DataColumnCollection dataColumnCollection, Action<DataColumn> action)
        {
            foreach (DataColumn item in dataColumnCollection)
            {
                action(item);
            }
        }
        #endregion

        #region 对 DataColumnCollection 的每个元素执行指定操作
        /// <summary>
        /// 对 <see cref="DataColumnCollection"/> 的每个元素执行指定操作
        /// </summary>
        /// <param name="dataColumnCollection">要执行指定操作的 <see cref="DataColumnCollection"/> 集合</param>
        /// <param name="action">要对 <see cref="DataColumnCollection"/> 的每个元素执行的 <see cref="Action{DataColumn}"/> 委托</param>
        public static void ForEach(this DataColumnCollection dataColumnCollection, Action<DataColumn, int> action)
        {
            for (int i = 0; i < dataColumnCollection.Count; i++)
            {
                action(dataColumnCollection[i], i);
            }
        }
        #endregion
    }
}
