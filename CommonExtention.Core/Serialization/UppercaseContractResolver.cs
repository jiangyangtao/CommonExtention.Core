using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Serialization
{
    /// <summary>
    /// Json 全大写约定
    /// </summary>
    public class UppercaseContractResolver : DefaultContractResolver
    {
        #region constructor
        /// <summary>
        /// 初始化 Json 全大写约定的实例
        /// </summary>
        public UppercaseContractResolver()
        {

        }
        #endregion

        #region Resolves the name of the property
        /// <summary>
        /// Resolves the name of the property
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>Resolved name of the property</returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToUpper();
        }
        #endregion
    }
}
