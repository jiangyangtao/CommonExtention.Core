using System;
using System.Data;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="DataRowCollection"/> 扩展
    /// </summary>
    public static class DataRowCollectionExtensions
    {
        #region 对 DataRowCollection 的每个元素执行指定操作
        /// <summary>
        /// 对 <see cref="DataRowCollection"/> 的每个元素执行指定操作
        /// </summary>
        /// <param name="dataRowCollection">要执行指定操作的 <see cref="DataRowCollection"/> 集合</param>
        /// <param name="action">要对 <see cref="DataRowCollection"/> 的每个元素执行的 <see cref="Action{DataRow}"/> 委托</param>
        public static void ForEach(this DataRowCollection dataRowCollection, Action<DataRow> action)
        {
            foreach (DataRow item in dataRowCollection)
            {
                action(item);
            }
        }
        #endregion

        #region 对 DataRowCollection 的每个元素执行指定操作
        /// <summary>
        /// 对 <see cref="DataRowCollection"/> 的每个元素执行指定操作
        /// </summary>
        /// <param name="dataRowCollection">要执行指定操作的 <see cref="DataRowCollection"/> 集合</param>
        /// <param name="action">要对 <see cref="DataRowCollection"/> 的每个元素执行的 <see cref="Action{DataRow}"/> 委托</param>
        public static void ForEach(this DataRowCollection dataRowCollection, Action<DataRow, int> action)
        {
            for (int i = 0; i < dataRowCollection.Count; i++)
            {
                action(dataRowCollection[i], i);
            }
        }
        #endregion
    }
}
