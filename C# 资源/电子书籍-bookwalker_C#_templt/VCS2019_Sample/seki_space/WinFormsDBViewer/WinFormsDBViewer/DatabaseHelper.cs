using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsDBViewer
{
    public static class DatabaseHelper
    {
        // <summary>
        // 获取数据库连接字符串的共同方法 (这里为了演示方便直接写在代码中，实际项目中应该从配置文件读取)
        // </summary>
        private static string GetConnectionString()
        {
            // !!! 重要提示 !!!
            // 实际项目中，请不要将连接字符串硬编码在代码中，这是不安全的做法。
            // 应该将连接字符串存储在配置文件 (如 App.config 或 Settings) 中，并从配置文件中读取。
            // 示例连接字符串，请根据您的实际SQL Server配置进行修改
            return "Data Source=RAIEN;Initial Catalog=JBCC;Integrated Security=True;";
            // 替换 "YourServerName" 为您的SQL Server服务器名称或IP地址
            // 替换 "YourDatabaseName" 为您要连接的数据库名称
            // 如果您使用SQL Server用户名和密码进行连接，请将 "Integrated Security=True;" 替换为以下格式：
            // "Data Source=YourServerName;Initial Catalog=YourDatabaseName;User ID=YourUserName;Password=YourPassword;";
        }

        // <summary>
        // 执行SQL查询并返回DataTable的共同方法
        // </summary>
        // <param name="sqlQuery">要执行的SQL查询语句</param>
        // <returns>包含查询结果的DataTable，如果发生错误则返回null</returns>
        public static DataTable GetDataTable(string sqlQuery)
        {
            DataTable dataTable = new DataTable(); // 创建一个新的DataTable用于存储数据
            SqlConnection sqlConnection = null; // SqlConnection对象，用于数据库连接，初始化为null

            try
            {
                // 1. 获取数据库连接字符串
                string connectionString = GetConnectionString();

                // 2. 创建SqlConnection对象并打开连接
                sqlConnection = new SqlConnection(connectionString); // 创建SqlConnection实例
                sqlConnection.Open(); // 打开数据库连接

                // 3. 创建SqlCommand对象并执行查询
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection); // 创建SqlCommand实例，关联查询语句和连接对象
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // 创建SqlDataAdapter，用于填充DataTable

                // 4. 使用SqlDataAdapter填充DataTable
                sqlDataAdapter.Fill(dataTable); // 执行SQL查询并将结果填充到dataTable中

                // 5. 查询成功，返回DataTable
                return dataTable; // 返回填充了数据的dataTable
            }
            catch (Exception ex)
            {
                // 6. 发生异常，进行错误处理
                MessageBox.Show(
                    $"数据库操作发生错误：{ex.Message}",
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                ); // 弹出错误提示框
                return null; // 发生错误时返回null
            }
            finally
            {
                // 7. 确保在finally块中关闭数据库连接，无论是否发生异常都执行
                if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close(); // 关闭数据库连接
                }
            }
        }

        /// <summary>
        /// 执行SQL查询并返回DataTable的共同方法
        /// </summary>
        /// <param name="sqlQuery">要执行的SQL查询语句</param>
        /// <returns>包含查询结果的DataTable</returns>
        public static DataTable GetDataTable2(string sqlQuery)
        {
            if (string.IsNullOrWhiteSpace(sqlQuery))
                throw new ArgumentException(
                    "SQL查询语句不能为空或仅包含空白字符。",
                    nameof(sqlQuery)
                );

            DataTable dataTable = new DataTable();

            try
            {
                // 使用 `using` 确保资源释放
                using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (SqlException ex)
            {
                // 捕获SQL异常并重新抛出，供调用方处理
                throw new InvalidOperationException("执行SQL查询时发生错误。", ex);
            }

            return dataTable;
        }
    }
}
