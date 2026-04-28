using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg197
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {

            //{
            //    #region 无参数
            //    //    string sqlQuery = "insert into AAA(ID) values (1019)";
            //    //    int q = SqlHelper.ExcuteQuery(sqlQuery);
            ////    //    MessageBox.Show(q.ToString());
            ////    #endregion
            ////}

            //{
            //    #region 带参数
            //    string sqlParmaQuery = @"select * from AAA where ID =@param1 or name=@param2";
            //    SqlParameter[] cachedParms = new SqlParameter[]
            //    {
            //        new SqlParameter("@param1",4521),
            //        new SqlParameter("@param2","tt")
            //    };
            //    DataTable dt = SqlHelper.ExcuteParamQuery(sqlParmaQuery, cachedParms);
            //    StringBuilder sb = new StringBuilder();
            //    foreach (DataRow item in dt.Rows)
            //    {
            //        for (int i = 0; i < dt.Columns.Count; i++)
            //        {
            //            sb.AppendFormat("{0}--",item[i]);
            //        }
            //        sb.Append("\r\n");
            //    }

            //    MessageBox.Show(sb.ToString());
            //    #endregion
            //}


            //#region 不封装 直接传入参数
            //    string connStr = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;
            //    string sql = @"select * from AAA where ID =@param1 or name=@param2";
            //    SqlParameter[] parameters = new SqlParameter[]
            //    {
            //            new SqlParameter("@param1",4521),
            //            new SqlParameter("@param2","tt")
            //    };
            //SqlConnection connction = new SqlConnection(connStr);
            //try
            //{
            //    using (SqlCommand sqlCommand = new SqlCommand(sql, connction))
            //    {
            //        connction.Open();
            //        sqlCommand.CommandText = sql;
            //        sqlCommand.Parameters.AddRange(parameters);
            //        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            //        DataSet dataSet = new DataSet();
            //        adapter.Fill(dataSet);
            //        DataTable dataTable= dataSet.Tables[0];
            //        StringBuilder sb = new StringBuilder();
            //        foreach (DataRow item in dataTable.Rows)
            //        {
            //            for (int i = 0; i < dataTable.Columns.Count; i++)
            //            {
            //                sb.AppendFormat("{0}--", item[i]);
            //            }
            //            sb.Append("\r\n");
            //        }
            //        MessageBox.Show(sb.ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    connction.Close();
            //}



            //#endregion
            //{
            //    #region Datatable转list泛型 调用在D层中定义list来接收返回值
            //    // Student student = new Student();
            //    ModelConvertHelper modelConvertHelper = new ModelConvertHelper();
            //    List<Student> students= modelConvertHelper.GetStudents(new Student());
            //    foreach (var item in students)
            //    {
            //        MessageBox.Show(item.ID.ToString());
            //        MessageBox.Show(item.age.ToString());
            //        MessageBox.Show(item.createDate.ToString());
            //        MessageBox.Show(item.name.ToString());
            //        MessageBox.Show(item.flag.ToString());
            //    }
            //    #endregion
            //}


            //あるクラスの機能をすべてもらう
            var a2 = new Student(3);
            
           int u= a2.GetData();
            MessageBox.Show(u.ToString());

            var a3 = new Family(44);
           string p= a3.a;
            MessageBox.Show(p.ToString());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
