using Dapper;
using System;
using System.Data.Common;
using System.Collections.Generic;
using NLog;

namespace MVC5Template.Dapper
{
    public class DapperManager
    {
        private static Logger logger = LogManager.GetLogger("Dapper");

        public DapperManager() { }

        public static dynamic Query(string connectionName, string select, object param = null)
        {
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                cn.Open();
                var result = cn.Query(select, param);
                return result;
            }
        }

        public static IEnumerable<T> Query<T>(string connectionName, string select, object param = null)
        {
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                cn.Open();
                var result = cn.Query<T>(select, param);
                return result;
            }
        }

        public static int Execute(string connectionName, string update, object param = null)
        {
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
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        logger.Error(string.Format("Message = {0} |Source = {1} | StackTrace = {2}", ex.Message, ex.Source, ex.StackTrace));
                    }
                }
                return result;
            }
        }
    }
}