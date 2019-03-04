
namespace CommonExtention.Core.HttpResponseFormat
{
    /// <summary>
    /// Json 通用网格返回实体
    /// </summary>
    internal class ResponseGridEntity
    {
        /// <summary>
        /// 初始化 <see cref="ResponseGridEntity"/> 类的新实例
        /// </summary>
        public ResponseGridEntity() { }

        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { set; get; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Rows { set; get; }

        /// <summary>
        /// 数据量
        /// </summary>
        public int Total { set; get; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { set; get; }
    }
}
