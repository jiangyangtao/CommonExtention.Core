using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// Json 全小写约定
    /// </summary>
    public class LowercaseContractResolver : DefaultContractResolver
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="LowercaseContractResolver"/> 类的的实例
        /// </summary>
        public LowercaseContractResolver() { }
        #endregion

        #region 解析属性名称
        /// <summary>
        /// 解析属性名称
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <returns>属性的解析名称</returns>
        protected override string ResolvePropertyName(string propertyName) => propertyName.ToLower();
        #endregion
    }
}
