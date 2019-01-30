using System;
using System.Data;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="DataTableCollection"/> 扩展
    /// </summary>
    public static class DataTableCollectionExtensions
    {
        #region 对 DataTableCollection 的每个元素执行指定操作
        /// <summary>
        /// 对 <see cref="DataTableCollection"/> 的每个元素执行指定操作
        /// </summary>
        /// <param name="dataTableCollection">要执行指定操作的 <see cref="DataTableCollection"/> 集合</param>
        /// <param name="action">要对 <see cref="DataTableCollection"/> 的每个元素执行的 <see cref="Action{DataTable}"/> 委托</param>
        public static void ForEach(this DataTableCollection dataTableCollection, Action<DataTable> action)
        {
            foreach (DataTable item in dataTableCollection)
            {
                action(item);
            }
        }
        #endregion

        #region 对 DataTableCollection 的每个元素执行指定操作
        /// <summary>
        /// 对 <see cref="DataTableCollection"/> 的每个元素执行指定操作
        /// </summary>
        /// <param name="dataTableCollection">要执行指定操作的 <see cref="DataTableCollection"/> 集合</param>
        /// <param name="action">要对 <see cref="DataTableCollection"/> 的每个元素执行的 <see cref="Action{DataTable}"/> 委托</param>
        public static void ForEach(this DataTableCollection dataTableCollection, Action<DataTable, int> action)
        {
            for (int i = 0; i < dataTableCollection.Count; i++)
            {
                action(dataTableCollection[i], i);
            }
        }
        #endregion
    }
}
