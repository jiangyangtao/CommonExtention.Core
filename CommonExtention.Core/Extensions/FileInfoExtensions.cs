using System.IO;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="FileInfo"/> 扩展
    /// </summary> 
    public static class FileInfoExtensions
    {
        #region 将当前 FileInfo 对象转换成 MemoryStream 对象
        /// <summary>
        /// 将当前 <see cref="FileInfo"/> 对象转换成 <see cref="MemoryStream"/> 对象
        /// </summary>
        /// <param name="fileInfo">要转换的 <see cref="FileInfo"/> 对象</param>
        /// <param name="deleteFile">是否删除文件</param>
        /// <returns>转换后的 <see cref="MemoryStream"/> 对象</returns>
        public static MemoryStream ToMemoryStream(this FileInfo fileInfo, bool deleteFile = true)
        {
            var memoryStream = new MemoryStream();
            var fileStream = fileInfo.OpenRead();
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);
            memoryStream.Write(bytes, 0, (int)fileStream.Length);
            fileStream.Close();
            if (deleteFile) fileInfo.Delete();
            return memoryStream;
        }
        #endregion

        #region 返回当前 FileInfo 对象的无符号字节数组
        /// <summary>
        /// 返回当前 <see cref="FileInfo"/> 对象的无符号字节数组
        /// </summary>
        /// <param name="fileInfo">要获取无符号字节数组的 <see cref="FileInfo"/> 对象</param>
        /// <param name="deleteFile">是否删除文件</param>
        /// <returns>当前 <see cref="FileInfo"/> 对象的无符号字节数组</returns>
        public static byte[] GetBuffer(this FileInfo fileInfo, bool deleteFile = true)
        {
            var buffer = new byte[1024 * 10];
            var memoryStream = fileInfo.ToMemoryStream(deleteFile);
            buffer = memoryStream.GetBuffer();
            memoryStream.Close();
            return buffer;
        }
        #endregion
    }
}
