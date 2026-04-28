using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg197
{
    public class SqlHelper
    {

        //把连接字符串写在App.config文件中
        private static string connStr = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;
        #region 更新数据
        public static int ExcuteQuery(string sql,params SqlHelper[] sqlHelpers) 
        {
                SqlConnection connction = new SqlConnection(connStr);
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connction))
                    {  
                        connction.Open();
                        sqlCommand.CommandText = sql;
                        sqlCommand.Parameters.AddRange(sqlHelpers);
                        return sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally 
                {
                    connction.Close();
                }
        }
        #endregion

        #region 参数查询 返回多行多列
        public static DataTable ExcuteParamQuery(string sql, SqlParameter[] sqlparams)
        {
            SqlConnection connction = new SqlConnection(connStr);
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, connction))
                {
                    connction.Open();
                    sqlCommand.CommandText = sql;
                    sqlCommand.Parameters.AddRange(sqlparams);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connction.Close();
            }
        }
        #endregion　//3.返回多行多列
    }
}
