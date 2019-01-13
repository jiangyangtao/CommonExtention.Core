using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="DatabaseFacade"/> 扩展
    /// </summary>
    public static class DatabaseFacadeExtensions
    {
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
            var dbCommand = conn.CreateCommand();
            if (facade.IsSqlServer())
            {
                dbCommand.CommandText = sql;
                if (parameters != null)
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        if (!parameter.ParameterName.Contains("@"))
                            parameter.ParameterName = $"@{parameter.ParameterName}";
                        dbCommand.Parameters.Add(parameter);
                    }
                }
            }
            return dbCommand;
        }
        #endregion

        #region 创建一个原始 Sql 查询，将该查询的结果返回给 DataTable
        /// <summary>
        /// 创建一个原始 Sql 查询，将该查询的结果返回给 <see cref="DataTable"/>
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

        #region 创建一个原始 Sql 查询，将该查询的结果返回给 DataTable
        /// <summary>
        /// 创建一个原始 Sql 查询，将该查询的结果返回给 <see cref="DataTable"/>
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

        #region 创建一个原始 Sql 查询，将该查询的结果返回给 IEnumerable<T>
        /// <summary>
        /// 创建一个原始 Sql 查询，将该查询的结果返回给 <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">T</typeparam>
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

        #region 创建一个原始 Sql 查询，将该查询的结果返回给 IEnumerable<T>
        /// <summary>
        /// 创建一个原始 Sql 查询，将该查询的结果返回给 <see cref="IEnumerable{T}"/>
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

        #region 创建一个原始 Sql 查询，将该查询的结果返回给 DataSet
        /// <summary>
        /// 创建一个原始 Sql 查询，将该查询的结果返回给 <see cref="DataSet"/>
        /// </summary>
        /// <param name="facade">当前 <see cref="DatabaseFacade"/> 对象</param>
        /// <param name="sql">要执行查询的 Sql 语句</param>
        /// <param name="parameters">参数集</param>
        /// <returns><see cref="DataSet"/></returns>
        public static DataSet SqlQueryToDataSet(this DatabaseFacade facade, string sql, params object[] parameters)
        {
            using (var conn = (SqlConnection)facade.GetDbConnection())
            {
                conn.Open();
                using (var sqlCommand = conn.CreateCommand())
                {
                    sqlCommand.CommandText = sql;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            if (!parameter.ParameterName.Contains("@"))
                                parameter.ParameterName = $"@{parameter.ParameterName}";
                            sqlCommand.Parameters.Add(parameter);
                        }
                    }
                    var adapter = new SqlDataAdapter(sqlCommand);
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }
        #endregion
    }
}
