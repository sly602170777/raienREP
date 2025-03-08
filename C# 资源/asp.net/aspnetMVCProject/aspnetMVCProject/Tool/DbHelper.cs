using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace aspnetMVCProject
{
    public class DbHelper
    {
        private readonly string _connectionString;

        public DbHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 执行非查询操作（增、删、改）
        public int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // 执行查询操作，返回DataTable
        public DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // 执行查询操作，返回第一行第一列的值
        public object ExecuteScalar(string tableName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from " + tableName + " where ";
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.CommandText +=
                            parameters[i].ParameterName.Replace("@", "")
                            + " = "
                            + parameters[i].Value;
                        if (i != parameters.Length - 1)
                        {
                            cmd.CommandText += " and ";
                        }
                    }
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        // 执行添加操作
        public int ExecuteAdd(string tableName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into " + tableName + " values(";
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.CommandText += parameters[i].ParameterName;
                        if (i != parameters.Length - 1)
                        {
                            cmd.CommandText += ",";
                        }
                    }
                    cmd.CommandText += ")";
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //执行修改操作
        public int ExecuteUpdate(string tableName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "update " + tableName + " set ";
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.CommandText += parameters[i].ParameterName;
                        if (i != parameters.Length - 1)
                        {
                            cmd.CommandText += ",";
                        }
                    }
                    cmd.CommandText += " where ";
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.CommandText += parameters[i].ParameterName;
                        if (i != parameters.Length - 1)
                        {
                            cmd.CommandText += " and ";
                        }
                    }
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //执行删除操作
        public int ExecuteDelete(string tableName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from " + tableName + " where ";
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        cmd.CommandText +=
                            parameters[i].ParameterName.Replace("@", "")
                            + " = "
                            + parameters[i].Value;
                        if (i != parameters.Length - 1)
                        {
                            cmd.CommandText += " and ";
                        }
                    }
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
