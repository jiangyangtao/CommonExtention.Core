using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace CommonExtention.Core.HttpResponseFormat
{
    /// <summary>
    /// Json 格式化基类。此类不可被实例化
    /// </summary>
    public abstract class JsonFormatBase
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="JsonFormatBase"/> 类的新实例
        /// </summary>
        public JsonFormatBase() { }
        #endregion

        #region 初始化 JsonResult 返回类型
        /// <summary>
        /// 初始化 <see cref="JsonResult"/> 返回类型
        /// </summary>
        /// <typeparam name="T">要实例化的类型</typeparam>
        /// <param name="response">要实例化的实体</param>
        /// <returns>实例化后的 <see cref="JsonResult"/></returns>
        protected JsonResult Json<T>(T response) where T : class
        {
            return new JsonResult(response)
            {
                StatusCode = 200,
                ContentType = "application/json",
            };
        }
        #endregion

        #region Json 通用返回格式
        /// <summary>
        /// Json 通用返回格式：返回成功
        /// </summary>
        /// <returns>
        /// Json格式 : {code:0,data:"",count:0,message:Success}
        /// </returns>
        public virtual JsonResult ResponseSuccess() => Json(new ResponseEntity()
        {
            Code = 0,
            Data = null,
            Count = 0,
            Message = "Success",
        });

        /// <summary>
        /// Json 通用返回格式：返回成功
        /// </summary>
        /// <param name="data">要返回的数据</param>
        /// <param name="count">返回的数据行数(默认为1，数据为null则为0)</param>
        /// <returns>
        /// Json格式 : {code:0,data:data,count:1,message:Success}
        /// </returns>
        public virtual JsonResult ResponseSuccess<T>(T data, int count = 0) => Json(new ResponseEntity()
        {
            Code = 0,
            Data = data,
            Count = data == null ? 0 : count,
            Message = "Success",
        });

        /// <summary>
        /// Json 通用返回格式：返回成功
        /// </summary>
        /// <param name="list"><see cref="List{T}"/></param>
        /// <param name="count">数据量(默认为 <see cref="List{T}.Count"/>)</param>
        /// <returns>
        /// Json格式 : {code:0,data:List,count:List.Count(),message:Success}
        /// </returns>
        public virtual JsonResult ResponseSuccess<T>(List<T> list, int count = 0) => Json(new ResponseEntity()
        {
            Code = 0,
            Data = list,
            Count = count == 0 ? list.Count : count,
            Message = "Success",
        });

        /// <summary>
        /// Json 通用返回格式：返回成功
        /// </summary>
        /// <param name="dataTable"><see cref="DataTable"/></param>
        /// <param name="count">数据量(默认为 <see cref="DataTable.Rows"/> 的Count)</param>
        /// <returns>
        /// Json格式 : {code:0,data:DataTable,count:DataTable.Rows.Count,message:Success}
        /// </returns>
        public virtual JsonResult ResponseSuccess(DataTable dataTable, int count = 0) => Json(new ResponseEntity()
        {
            Code = 0,
            Data = dataTable,
            Count = count == 0 ? dataTable.Rows.Count : count,
            Message = "Success",
        });

        /// <summary>
        /// Json 通用返回格式：返回失败
        /// </summary>
        /// <param name="code">错误代码</param>
        /// <param name="message">错误信息(默认为"Unknown error")</param>
        /// <returns>
        /// Json格式 : {code:-1,data:"",count:-1,message:Unknown error}
        /// </returns>
        public virtual JsonResult ResponseFail(int code = -1, string message = "Unknown error") => Json(new ResponseEntity()
        {
            Code = code,
            Data = null,
            Count = 0,
            Message = message,
        });
        #endregion

        #region Json 通用网格返回格式
        /// <summary>
        /// Json 通用网格返回格式：返回成功
        /// </summary>
        /// <returns>
        /// Json格式 : {code:0,rows:data,total:1,message:Success}
        /// </returns>
        public virtual JsonResult ResponseGridResult() => Json(new ResponseGridEntity()
        {
            Code = 0,
            Rows = null,
            Total = 0,
            Message = "Success",
        });

        /// <summary>
        /// Json 通用网格返回格式：返回成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="count">数据量(默认为1，数据为null则为0)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:data,total:1,message:Success}
        /// </returns>
        public virtual JsonResult ResponseGridResult<T>(T data, int count = 0) => Json(new ResponseGridEntity()
        {
            Code = 0,
            Rows = data,
            Total = data == null ? 0 : count,
            Message = "Success",
        });

        /// <summary>
        /// Json 通用网格返回格式：返回成功
        /// </summary>
        /// <param name="list"><see cref="List{T}"/></param>
        /// <param name="count">数据量(默认为 <see cref="List{T}.Count"/>)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:List,total:List.Count(),message:Success}
        /// </returns>
        public virtual JsonResult ResponseGridResult<T>(List<T> list, int count = 0) => Json(new ResponseGridEntity()
        {
            Code = 0,
            Rows = list,
            Total = count == 0 ? list.Count : count,
            Message = "Success",
        });

        /// <summary>
        /// Json 通用网格返回格式：返回成功
        /// </summary>
        /// <param name="dataTable"><see cref="DataTable"/></param>
        /// <param name="count">数据量(默认为 <see cref="DataTable.Rows"/> 的Count)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:DataTable,total:DataTable.Rows.Count,message:Success}
        /// </returns>
        public virtual JsonResult ResponseGridResult(DataTable dataTable, int count = 0) => Json(new ResponseGridEntity()
        {
            Code = 0,
            Rows = dataTable,
            Total = count == 0 ? dataTable.Rows.Count : count,
            Message = "Success",
        });

        /// <summary>
        /// Json 通用网格返回格式：返回失败
        /// </summary>
        /// <param name="code">失败代码</param>
        /// <param name="message">失败信息</param>
        /// <returns>
        /// Json格式 : {code:-1,rows:[],total:0,message:Unknown error}
        /// </returns>
        public virtual JsonResult ResponseGridResult(int code = -1, string message = "Unknown error") => Json(new ResponseGridEntity()
        {
            Code = code,
            Rows = null,
            Total = 0,
            Message = message,
        });
        #endregion
    }
}
