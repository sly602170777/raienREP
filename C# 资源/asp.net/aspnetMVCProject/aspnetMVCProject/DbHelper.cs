using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace aspnetMVCProject
{
    public class DbHelper
    {
        private readonly string _connectionString;

        public DbHelper (string connectionString)
        {
            _connectionString = connectionString;
        }



        // 执行非查询操作（增、删、改）
        public int ExecuteNonQuery (string sql, params SqlParameter [] parameters)
        {
            using (SqlConnection conn = new SqlConnection (_connectionString))
            {
                conn.Open ();
                using (SqlCommand cmd = new SqlCommand (sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange (parameters);
                    }
                    return cmd.ExecuteNonQuery ();
                }
            }
        }

        // 执行查询操作，返回DataTable
        public DataTable ExecuteQuery (string sql, params SqlParameter [] parameters)
        {
            using (SqlConnection conn = new SqlConnection (_connectionString))
            {
                conn.Open ();
                using (SqlCommand cmd = new SqlCommand (sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange (parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter (cmd))
                    {
                        DataTable dt = new DataTable ();
                        adapter.Fill (dt);
                        return dt;
                    }
                }
            }
        }

        // 执行查询操作，返回第一行第一列的值
        public object ExecuteScalar (string sql, params SqlParameter [] parameters)
        {
            using (SqlConnection conn = new SqlConnection (_connectionString))
            {
                conn.Open ();
                using (SqlCommand cmd = new SqlCommand (sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange (parameters);
                    }
                    return cmd.ExecuteScalar ();
                }
            }
        }
    }
}