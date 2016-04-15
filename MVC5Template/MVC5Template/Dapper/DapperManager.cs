using Dapper;
using NLog;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using System;

namespace MVC5Template.Dapper
{
    /// <summary>
    /// Micro-ORM Dapperの機能を提供します。
    /// </summary>
    public class DapperManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DapperManager() { }

        /// <summary>
        /// Select用の実行機能を提供します。
        /// </summary>
        ///          <code>
        ///                 IEnumerable<User> result = DapperManager.Query<User>("MVC5TemplateServer",
        ///            "SELECT UserID, FamilyName, FirstName FROM [dbo].[User] WHERE UserID = @UserID AND Password = @Password",
        ///            new { UserID = model.UserID, Password = model.Password });
        /// </code>
        /// <param name="connectionName">コネクションストリング</param>
        /// <param name="query">クエリ</param>
        /// <param name="param">パラメータ</param>
        /// <returns>実行結果</returns>
        public static dynamic Query(string connectionName, string query, object param = null)
        {
            OutputLog(connectionName, query, param);
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                cn.Open();
                var result = cn.Query(query, param);
                return result;
            }
        }

        /// <summary>
        /// Select用の実行機能を提供します。
        /// </summary>
        /// <typeparam name="T">結果保存用の型</typeparam>
        /// <param name="connectionName">コネクションストリング</param>
        /// <param name="query">クエリ</param>
        /// <param name="param">パラメータ</param>
        /// <returns>実行結果</returns>
        public static IEnumerable<T> Query<T>(string connectionName, string query, object param = null)
        {
            OutputLog(connectionName, query, param);
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                cn.Open();
                var result = cn.Query<T>(query, param);
                return result;
            }
        }

        public static int Execute(string connectionName, string update, object param = null)
        {
            OutputLog(connectionName, update, param);
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                int result = 0;
                cn.Open();
                using (var tr = cn.BeginTransaction())
                {
                    try
                    {
                        result = cn.Execute(update, param, tr);
                        tr.Commit();
                    }
                    catch(Exception e)
                    {
                        logger.Debug(e.Message);
                        tr.Rollback();
                    }
                }
                return result;
            }
        }

        public static void OutputLog(string connectionName, string sql, object param)
        {
            StringBuilder logText = new StringBuilder();
            logText.Append(string.Format("connectionName = {0}, sql = {1}, param = {2}", connectionName, sql, param));
            logger.Debug(logText.ToString());
        }
    }
}