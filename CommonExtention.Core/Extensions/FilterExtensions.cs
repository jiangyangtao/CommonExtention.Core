using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// Filter 扩展
    /// </summary>
    public static class FilterExtensions
    {
        #region 指示 FilterDescriptor 集合中是否存在指定的 Attribute 或者 Filter
        /// <summary>
        /// 指示 <see cref="FilterDescriptor"/> 集合中是否存在指定的 <see cref="Attribute"/> 或者 Filter
        /// </summary>
        /// <param name="filterDescriptors"><see cref="FilterDescriptor"/> 集合</param>
        /// <param name="type">要验证的 <see cref="Attribute"/> 或者 Filter 的 Type</param>
        /// <returns>
        /// 如果集合为 null ，则为 false;
        /// 如果 type 参数为 null，则为 false;
        /// 如果集合中存在指定的 <see cref="Attribute"/> 或者 Filter，则为 true;
        /// 如果不存在，则为 false;
        /// </returns>
        public static bool HasFilterOrAttribute(this IList<FilterDescriptor> filterDescriptors, Type type)
        {
            if (filterDescriptors == null) return false;
            if (type == null) return false;
            return filterDescriptors.Any(a => a.Filter.GetType() == type);
        }
        #endregion

        #region 指示 IFilterMetadata 集合中是否存在指定的 Filter
        /// <summary>
        /// 指示 <see cref="IFilterMetadata"/> 集合中是否存在指定的 Filter
        /// </summary>
        /// <param name="filterMetadatas"><see cref="IFilterMetadata"/> 集合/param>
        /// <param name="type">指定的 Filter 的 Type</param>
        /// <returns>
        /// 如果集合为 null ，则为 false;
        /// 如果 type 参数为 null，则为 false;
        /// 如果集合中存在指定的 Filter，则为 true;
        /// 如果不存在，则为 false;
        /// </returns>
        public static bool HasFilter(this IList<IFilterMetadata> filterMetadatas, Type type)
        {
            if (filterMetadatas == null) return false;
            if (type == null) return false;

            return filterMetadatas.Any(a => a.GetType() == type);
        }
        #endregion
    }
}
