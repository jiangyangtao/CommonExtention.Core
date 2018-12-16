using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="DatabaseFacade"/> 扩展
    /// </summary>
    public static class DatabaseExtensions
    {
        #region 参数化处理
        /// <summary>
        /// 参数化处理
        /// </summary>
        /// <param name="command"><see cref="DbCommand"/> 对象</param>
        /// <param name="parameters">参数集</param>
        private static void ParameterizedObject (ref DbCommand command, params object[] parameters)
        {
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if (!parameter.ParameterName.Contains("@"))
                        parameter.ParameterName = $"@{parameter.ParameterName}";
                    command.Parameters.Add(parameter);
                }
            }
        }
        #endregion

        #region 创建 DbCommand 对象
        /// <summary>
        /// 创建 <see cref="DbCommand"/> 对象
        /// </summary>
        /// <param name="facade"><see cref="DatabaseFacade"/> 对象</param>
        /// <param name="sql">要执行查询的 Sql 语句</param>
        /// <param name="dbConn"><see cref="DbConnection"/> 对象</param>
        /// <param name="parameters">参数集</param>
        /// <returns><see cref="DbCommand"/> 实例</returns>
        private static DbCommand CreateCommand(DatabaseFacade facade, string sql, out DbConnection dbConn, params object[] parameters)
        {
            var conn = facade.GetDbConnection();
            dbConn = conn;
            conn.Open();
            var cmd = conn.CreateCommand();
            if (facade.IsSqlServer())
            {
                cmd.CommandText = sql;
                ParameterizedObject(ref cmd, parameters);
            }
            return cmd;
        }
        #endregion

        #region Sql查询
        /// <summary>
        /// Sql查询
        /// </summary>
        /// <param name="facade">当前<see cref="DatabaseFacade"/> 对象</param>
        /// <param name="sql">要执行查询的 Sql 语句</param>
        /// <param name="parameters">参数集</param>
        /// <returns><see cref="DataTable"/> 对象</returns>
        public static DataTable SqlQuery(this DatabaseFacade facade, string sql, params object[] parameters)
        {
            var cmd = CreateCommand(facade, sql, out DbConnection conn, parameters);
            var reader = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            conn.Close();
            return dt;
        }
        #endregion

        #region Sql异步查询
        /// <summary>
        /// Sql异步查询
        /// </summary>
        /// <param name="facade">当前<see cref="DatabaseFacade"/> 对象</param>
        /// <param name="sql">要执行查询的 Sql 语句</param>
        /// <param name="parameters">参数集</param>
        /// <returns><see cref="DataTable"/> 对象</returns>
        public static async Task<DataTable> SqlQueryAsync(this DatabaseFacade facade, string sql, params object[] parameters)
        {
            var cmd = CreateCommand(facade, sql, out DbConnection conn, parameters);
            var reader = await cmd.ExecuteReaderAsync();
            var dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            conn.Close();
            return dt;
        }
        #endregion

        #region Sql查询
        /// <summary>
        /// Sql查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="facade">当前<see cref="DatabaseFacade"/> 对象</param>
        /// <param name="sql">要执行查询的 Sql 语句</param>
        /// <param name="parameters">参数集</param>
        /// <returns><see cref="IEnumerable{T}"/> 对象</returns>
        public static IEnumerable<T> SqlQuery<T>(this DatabaseFacade facade, string sql, params object[] parameters) where T : class, new()
        {
            DataTable dt = SqlQuery(facade, sql, parameters);
            return dt.ToEnumerable<T>();
        }
        #endregion

        #region Sql异步查询
        /// <summary>
        /// Sql异步查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="facade">当前<see cref="DatabaseFacade"/> 对象</param>
        /// <param name="sql">要执行查询的 Sql 语句</param>
        /// <param name="parameters">参数集</param>
        /// <returns><see cref="IEnumerable{T}"/> 对象</returns>
        public static async Task<IEnumerable<T>> SqlQueryAsync<T>(this DatabaseFacade facade, string sql, params object[] parameters) where T : class, new()
        {
            var dt = await SqlQueryAsync(facade, sql, parameters);
            return dt.ToEnumerable<T>();
        }
        #endregion
    }
}
