using Dapper;
using System;
using System.Data.Common;
using System.Text;
using System.Collections.Generic;

namespace MVC5Template.Models
{
    public class DapperManager
    {
        public DapperManager() { }

        public static dynamic Select(string connectionName, string select, object param)
        {
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                cn.Open();
                var result = cn.Query(select, param);
                return result;
            }
        }

        public static IEnumerable<T> Select<T>(string connectionName, string select, object param)
        {
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                cn.Open();
                var result = cn.Query<T>(select, param);
                return result;
            }
        }

        public static int Update(string connectionName, string update, object param)
        {
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                int result = 0;
                cn.Open();
                using (var tr = cn.BeginTransaction())
                {
                    try
                    {
                        result = cn.Execute(update, param);
                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                    }
                }
                cn.Close();
                return result;
            }
        }

        public static int Insert(string connectionName, string insert, object param)
        {
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                int result = 0;
                cn.Open();
                using (var tr = cn.BeginTransaction())
                {
                    try
                    {
                        result = cn.Execute(insert, param);
                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                    }
                }
                cn.Close();
                return result;
            }
        }

        public static int Delete(string connectionName, string delete, object param)
        {
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                int result = 0;
                cn.Open();
                using (var tr = cn.BeginTransaction())
                {
                    try
                    {
                        result = cn.Execute(delete, param);
                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                    }
                }
                cn.Close();
                return result;
            }
        }
    }
}