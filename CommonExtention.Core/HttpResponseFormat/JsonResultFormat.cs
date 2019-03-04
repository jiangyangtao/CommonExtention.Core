using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CommonExtention.Core.HttpResponseFormat
{
    /// <summary>
    /// Json 结果返回格式。此类不可被继承
    /// </summary>
    public sealed class JsonResultFormat
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="JsonResultFormat"/> 类的新实例
        /// </summary>
        public JsonResultFormat() { }
        #endregion

        #region Json 通用返回格式
        /// <summary>
        /// Json 通用返回格式：返回成功
        /// </summary>
        /// <returns>
        /// Json格式 : {code:0,data:"",count:0,message:Success}
        /// </returns>
        public static JsonResult ResponseSuccess() => new JsonResponseFormat().ResponseSuccess();

        /// <summary>
        /// Json 通用返回格式：返回成功
        /// </summary>
        /// <param name="data">要返回的数据</param>
        /// <param name="count">返回的数据行数(默认为1，数据为null则为0)</param>
        /// <returns>
        /// Json格式 : {code:0,data:data,count:1,message:Success}
        /// </returns>
        public static JsonResult ResponseSuccess<T>(T data, int count = 0) => new JsonResponseFormat().ResponseSuccess(data, count);

        /// <summary>
        /// Json 通用返回格式：返回成功
        /// </summary>
        /// <param name="list"><see cref="List{T}"/></param>
        /// <param name="count">数据量(默认为 <see cref="List{T}.Count"/>)</param>
        /// <returns>
        /// Json格式 : {code:0,data:List,count:List.Count(),message:Success}
        /// </returns>
        public static JsonResult ResponseSuccess<T>(List<T> list, int count = 0) => new JsonResponseFormat().ResponseSuccess(list, count);

        /// <summary>
        /// Json 通用返回格式：返回成功
        /// </summary>
        /// <param name="dataTable"><see cref="DataTable"/></param>
        /// <param name="count">数据量(默认为 <see cref="DataTable.Rows"/> 的Count)</param>
        /// <returns>
        /// Json格式 : {code:0,data:DataTable,count:DataTable.Rows.Count,message:Success}
        /// </returns>
        public static JsonResult ResponseSuccess(DataTable dataTable, int count = 0) => new JsonResponseFormat().ResponseSuccess(dataTable, count);

        /// <summary>
        /// Json 通用返回格式：返回失败
        /// </summary>
        /// <param name="code">错误代码</param>
        /// <param name="message">错误信息(默认为"Unknown error")</param>
        /// <returns>
        /// Json格式 : {code:-1,data:"",count:-1,message:Unknown error}
        /// </returns>
        public static JsonResult ResponseFail(int code = -1, string message = "Unknown error") => new JsonResponseFormat().ResponseFail(code, message);
        #endregion

        #region Json 通用网格返回格式
        /// <summary>
        /// Json 通用网格返回格式：返回成功
        /// </summary>
        /// <returns>
        /// Json格式 : {code:0,rows:data,total:1,message:Success}
        /// </returns>
        public static JsonResult ResponseGridResult() => new JsonResponseFormat().ResponseGridResult();

        /// <summary>
        /// Json 通用网格返回格式：返回成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="count">数据量(默认为1，数据为null则为0)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:data,total:1,message:Success}
        /// </returns>
        public static JsonResult ResponseGridResult<T>(T data, int count = 0) => new JsonResponseFormat().ResponseGridResult(data, count);

        /// <summary>
        /// Json 通用网格返回格式：返回成功
        /// </summary>
        /// <param name="list"><see cref="List{T}"/></param>
        /// <param name="count">数据量(默认为 <see cref="List{T}.Count"/>)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:List,total:List.Count(),message:Success}
        /// </returns>
        public static JsonResult ResponseGridResult<T>(List<T> list, int count = 0) => new JsonResponseFormat().ResponseGridResult(list, count);

        /// <summary>
        /// Json 通用网格返回格式：返回成功
        /// </summary>
        /// <param name="dataTable"><see cref="DataTable"/></param>
        /// <param name="count">数据量(默认为 <see cref="DataTable.Rows"/> 的Count)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:DataTable,total:DataTable.Rows.Count,message:Success}
        /// </returns>
        public static JsonResult ResponseGridResult(DataTable dataTable, int count = 0) => new JsonResponseFormat().ResponseGridResult(dataTable, count);

        /// <summary>
        /// Json 通用网格返回格式：返回失败
        /// </summary>
        /// <param name="code">失败代码</param>
        /// <param name="message">失败信息</param>
        /// <returns>
        /// Json格式 : {code:-1,rows:[],total:0,message:Unknown error}
        /// </returns>
        public static JsonResult ResponseGridResult(int code = -1, string message = "Unknown error") => new JsonResponseFormat().ResponseGridResult(code, message);
        #endregion
    }
}
