using System;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="Exception"/> 扩展
    /// </summary>
    public static class ExtentionExtensions
    {
        #region 返回 Exception 对象中的 InnerException
        /// <summary>
        /// 返回 <see cref="Exception" /> 中的 <see cref="Exception.InnerException" />
        /// </summary>
        /// <param name="exception"><see cref="Exception" />对象</param>
        /// <returns>返回 <see cref="Exception" /> 中的 <see cref="Exception.InnerException" /></returns>
        public static Exception GetInnerException(this Exception exception)
        {
            if (exception == null) return null;
            if (exception.InnerException != null) return GetInnerException(exception.InnerException);
            return exception;
        }
        #endregion

        #region 返回 Exception 对象中 InnerException 的 Message
        /// <summary>
        /// 返回当前 <see cref="Exception.InnerException" /> 中的Message
        /// </summary>
        /// <param name="exception"><see cref="Exception" />对象</param>
        /// <returns>返回 <see cref="Exception.InnerException" /> 中的 Message</returns>
        public static string ExceptionMessage(this Exception exception)
        {
            if (exception == null) return string.Empty;
            if (exception.InnerException != null) return ExceptionMessage(exception.InnerException);
            return exception.Message;
        }
        #endregion
    }
}
