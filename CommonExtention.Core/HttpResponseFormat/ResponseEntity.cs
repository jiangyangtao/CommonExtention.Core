
namespace CommonExtention.Core.HttpResponseFormat
{
    /// <summary>
    /// Json 通用返回实体
    /// </summary>
    internal class ResponseEntity
    {
        /// <summary>
        /// 初始化 <see cref="ResponseEntity"/> 类的新实例
        /// </summary>
        public ResponseEntity() { }

        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { set; get; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { set; get; }

        /// <summary>
        /// 数据量
        /// </summary>
        public int Count { set; get; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { set; get; }
    }
}
