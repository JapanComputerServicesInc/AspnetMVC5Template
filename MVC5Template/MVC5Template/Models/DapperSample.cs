using Dapper;
using System;
using System.Data.Common;
using System.Text;

namespace MVC5Template.Models
{
    public class DapperSample<T>
    {
        private string connectionName = null;
        public DapperSample(string connectionName)
        {
            this.connectionName = connectionName;
        }

        public dynamic Select(string select, object param)
        {
            using (var cn = new DbConnectionFactory(connectionName).Create())
            {
                cn.Open();
                var result = cn.Query<T>(select, param);
                return result;
            }
        }

        public int Update(string update, object param)
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

        public int Insert(string insert, object param)
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

        public int Delete(string delete, object param)
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