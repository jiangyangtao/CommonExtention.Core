using CommonExtention.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// 基础控制器，提供通用返回格式。此类不可被实例化
    /// </summary>
    public abstract class BasicsController : Controller
    {
        #region init
        /// <summary>
        /// Basics Controller Constructor
        /// </summary>
        public BasicsController() { }
        #endregion

        #region Json通用返回格式
        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <returns>
        /// Json格式 : {code:0,data:"",count:0,message:Success}
        /// </returns>
        protected virtual IActionResult ResponseSuccess()
        {
            var json = new Dictionary<string, object>()
            {
                {"code",0},
                {"data",null},
                {"count",0},
                {"message","Success" }
            };
            return Json(json);
        }


        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <param name="data">要返回的数据</param>
        /// <param name="count">返回的数据行数(默认为1，数据为null则为0)</param>
        /// <returns>
        /// Json格式 : {code:0,data:data,count:1,message:Success}
        /// </returns>
        protected virtual IActionResult ResponseSuccess<T>(T data, int count = 1)
        {
            if (data == null) count = 0;
            var json = new Dictionary<string, object>()
            {
                {"code",0},
                {"data",data},
                {"count",count},
                {"message","Success"}
            };
            return Json(json);
        }

        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <param name="list"><see cref="List{T}"/></param>
        /// <param name="count">数据量(默认为 <see cref="List{T}.Count"/>)</param>
        /// <returns>
        /// Json格式 : {code:0,data:List,count:List.Count(),message:Success}
        /// </returns>
        protected virtual IActionResult ResponseSuccess<T>(List<T> list, int count = 0)
        {
            if (count == 0) count = list.Count();
            var json = new Dictionary<string, object>()
            {
                {"code",0},
                {"data",list},
                {"count",count},
                {"message","Success"}
            };
            return Json(json);
        }

        /// <summary>
        /// Json通用返回格式：返回成功
        /// </summary>
        /// <param name="dt"><see cref="DataTable"/></param>
        /// <param name="count">数据量(默认为 <see cref="DataTable.Rows"/> 的Count)</param>
        /// <returns>
        /// Json格式 : {code:0,data:DataTable,count:DataTable.Rows.Count,message:Success}
        /// </returns>
        protected virtual IActionResult ResponseSuccess(DataTable dt, int count = 0)
        {
            if (count == 0) count = dt.Rows.Count;
            var jsonBuilder = new StringBuilder("{\"code\":0,\"count\":" + count + ",\"message\":\"Success\",\"data\":");
            jsonBuilder.Append(dt.ToJsonArray());
            jsonBuilder.Append("}");
            return Content(jsonBuilder.ToString(), "application/json");
        }

        /// <summary>
        /// Json通用返回格式：返回失败
        /// </summary>
        /// <param name="code">错误代码</param>
        /// <param name="message">错误信息(默认为"Unknown error")</param>
        /// <returns>
        /// Json格式 : {code:-1,data:"",count:-1,message:Unknown error}
        /// </returns>
        protected virtual IActionResult ResponseFail(int code = -1, string message = "Unknown error")
        {
            var json = new Dictionary<string, object>()
            {
                {"code",code},
                {"data",""},
                {"count",-1},
                {"message",message}
            };
            return Json(json);
        }
        #endregion

        #region Json通用网格返回格式
        /// <summary>
        /// Json通用网格返回格式：返回成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="count">数据量(默认为1，数据为null则为0)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:data,total:1,message:Success}
        /// </returns>
        protected virtual IActionResult ResponseGridResult<T>(T data, int count = 1)
        {
            if (data != null) count = 1;
            var result = new Dictionary<string, object>()
            {
                {"code",0 },
                {"total",count },
                {"rows",data },
                {"message","Success" },
            };
            return Json(result);
        }

        /// <summary>
        /// Json通用网格返回格式：返回成功
        /// </summary>
        /// <param name="list"><see cref="List{T}"/></param>
        /// <param name="count">数据量(默认为 <see cref="List{T}.Count"/>)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:List,total:List.Count(),message:Success}
        /// </returns>
        protected virtual IActionResult ResponseGridResult<T>(List<T> list, int count = 0)
        {
            if (count == 0) count = list.Count();
            var result = new Dictionary<string, object>()
            {
                {"code",0 },
                {"total",count },
                {"rows",list },
                {"message","Success" },
            };
            return Json(result);
        }

        /// <summary>
        /// Json通用网格返回格式：返回成功
        /// </summary>
        /// <param name="dt"><see cref="DataTable"/></param>
        /// <param name="count">数据量(默认为 <see cref="DataTable.Rows"/> 的Count)</param>
        /// <returns>
        /// Json格式 : {code:0,rows:DataTable,total:DataTable.Rows.Count,message:Success}
        /// </returns>
        protected virtual IActionResult ResponseGridResult(DataTable dt, int count = 0)
        {
            if (count == 0) count = dt.Rows.Count;
            var jsonBuilder = new StringBuilder("{\"code\":0,\"total\":" + count + ",\"message\":\"Success\",\"rows\":");
            jsonBuilder.Append(dt.ToJsonArray());
            jsonBuilder.Append("}");
            return Content(jsonBuilder.ToString(), "application/json");
        }


        /// <summary>
        /// Json通用网格返回格式：返回失败
        /// </summary>
        /// <param name="code">失败代码</param>
        /// <param name="message">失败信息</param>
        /// <returns>
        /// Json格式 : {code:-1,rows:[],total:0,message:Unknown error}
        /// </returns>
        protected virtual IActionResult ResponseGridResult(int code = -1, string message = "Unknown error")
        {
            var result = new Dictionary<string, object>()
            {
                {"code",code },
                {"total",0 },
                {"rows",new string[0] },
                {"message",message },
            };
            return Json(result);
        }
        #endregion
    }
}
