using Newtonsoft.Json.Serialization;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// Json 全大写约定
    /// </summary>
    public class UppercaseContractResolver : DefaultContractResolver
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="UppercaseContractResolver"/> 类的新实例
        /// </summary>
        public UppercaseContractResolver() { }
        #endregion

        #region 解析属性名称
        /// <summary>
        /// 解析属性名称
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <returns>属性的解析名称</returns>
        protected override string ResolvePropertyName(string propertyName) => propertyName.ToUpper();
        #endregion
    }
}
