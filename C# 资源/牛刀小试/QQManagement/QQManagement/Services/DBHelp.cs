using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQManagement.Services
{
    public class DBHelp
    {
        private const string ConnectionString = "Persist Security Info=False;User ID=sa;Password=123456; Initial Catalog=QQDb;Server=RAIEN";

        /// <summary>
        /// 获取连接对象
        /// </summary>
        private static SqlConnection Con {
            get {
                var con = new SqlConnection(ConnectionString);
                //不进行try Catch 在view层中报错时往上抛
                con.Open();
                return con;
            }
        }
        /// <summary>
        /// 获取指令对象
        /// </summary>
        private static SqlCommand Cmd => Con.CreateCommand();
        //此方法等同于上边一行代码
        //private static SqlCommand Cmd
        //{
        //    get {
        //        //此方法等同于下边简写方法
        //        //var cmd = new SqlCommand() { Connection = Con };
        //        //return cmd;

        //        return Con.CreateCommand();
        //    }
        //}
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool Update(string sql) 
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object SelectForScalar(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteScalar();
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        /// <summary>
        /// 返回一个DataReader
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader SelectForReader(string sql) 
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {

                cmd.Connection.Close();

                return null;
            }
        }
    
    }
}
