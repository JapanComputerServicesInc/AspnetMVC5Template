using Dapper;
using NLog;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;

namespace MVC5Template.Dapper
{
    public class DapperManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DapperManager() { }

        public static dynamic Query(string connectionName, string select, object param = null)
        {
            OutputLog(connectionName, select, param);
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                cn.Open();
                var result = cn.Query(select, param);
                return result;
            }
        }

        public static IEnumerable<T> Query<T>(string connectionName, string select, object param = null)
        {
            OutputLog(connectionName, select, param);
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                cn.Open();
                var result = cn.Query<T>(select, param);
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
                    catch
                    {
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