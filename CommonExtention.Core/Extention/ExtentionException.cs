using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Extention
{
    /// <summary>
    /// <see cref="Exception"/> 扩展
    /// </summary>
    public static class ExtentionException
    {
        #region 返回当前Exception中InnerException的Message
        /// <summary>
        /// 返回当前 <see cref="Exception.InnerException" /> 中的Message
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>返回 <see cref="Exception.InnerException" /> 中的 Message(6层)</returns>
        public static string ExceptionMessage(this Exception exception)
        {
            if (exception == null) return string.Empty;
            if (exception.InnerException != null)
            {
                if (exception.InnerException.InnerException != null)
                {
                    if (exception.InnerException.InnerException.InnerException != null)
                    {
                        if (exception.InnerException.InnerException.InnerException.InnerException != null)
                        {
                            if (exception.InnerException.InnerException.InnerException.InnerException.InnerException != null)
                            {
                                if (exception.InnerException.InnerException.InnerException.InnerException.InnerException.InnerException != null)
                                {
                                    return exception.InnerException.InnerException.InnerException.InnerException.InnerException.InnerException.Message;
                                }
                                return exception.InnerException.InnerException.InnerException.InnerException.InnerException.Message;
                            }
                            return exception.InnerException.InnerException.InnerException.InnerException.Message;
                        }
                        return exception.InnerException.InnerException.InnerException.Message;
                    }
                    return exception.InnerException.InnerException.Message;
                }
                return exception.InnerException.Message;
            }
            return exception.Message;
        }
        #endregion
    }
}
