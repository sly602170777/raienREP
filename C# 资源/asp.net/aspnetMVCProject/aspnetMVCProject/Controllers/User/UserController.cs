using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using aspnetMVCProject.logs;
using aspnetMVCProject.Models;

namespace aspnetMVCProject.Controllers.User
{
    public class UserController : Controller
    {
        string connectionString = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;

        #region 用户一览表
        public ActionResult ShowUserList()
        {
            testTool testTool = new testTool();
            testTool.TestGenFileName();
            //testTool.TestGenFileName4();

            DbHelper dbHelper = new DbHelper(connectionString);
            string sql = "SELECT  [Id],[Name],[Age]FROM [JBCC].[dbo].[User]";
            DataTable dt = dbHelper.ExecuteQuery(sql);
            List<user> users = new List<user>();
            foreach (DataRow row in dt.Rows)
            {
                //user user = new user(
                //    row["Name"].ToString(),
                //    int.Parse(row["Id"].ToString()),
                //    int.Parse(row["Age"].ToString())
                //);

                users.Add(
                    new user(
                        row["Name"].ToString(),
                        int.Parse(row["Id"].ToString()),
                        int.Parse(row["Age"].ToString())
                    )
                );
            }
            ViewData.Model = users;
            return View();
        }
        #endregion

        public ActionResult Add()
        {
            return View();
        }

        #region 用户注册事件
        // GET: User
        public ActionResult AddUser()
        {
            DbHelper dbHelper = new DbHelper(connectionString);

            //获取用户输入的信息
            int userId = int.Parse(Request.Form["userId"]);
            string userName = Request.Form["userName"];
            int age = int.Parse(Request.Form["age"]);
            //将用户输入的信息插入数据库
            //string sql = "select into User value(@id,@name,@age)";
            SqlParameter param1 = new SqlParameter("@Param1", userId);
            SqlParameter param2 = new SqlParameter("@Param2", userName);
            SqlParameter param3 = new SqlParameter("@Param3", age);
            //将用户输入的信息插入数据库
            dbHelper.ExecuteAdd("[dbo].[User]", param1, param2, param3);
            //返回提示内容
            //return Content("send OK");
            return RedirectToAction("ShowUserList");
        }
        #endregion

        #region 用户详细页面
        [HttpGet]
        public ActionResult ShowUserDetail(int Id)
        {
            DbHelper dbHelper = new DbHelper(connectionString);
            string sql = "select Name ,Id,Age from [dbo].[User] where Id=@Id";
            DataTable dt = dbHelper.ExecuteQuery(sql, new SqlParameter("@Id", Id));

            //int result = dbHelper.ExecuteDelete("[dbo].[User]", param1);
            //user users = new user("王さん", 777, 19);
            user users = new user(
                dt.Rows[0]["Name"].ToString(),
                int.Parse(dt.Rows[0]["Id"].ToString()),
                int.Parse(dt.Rows[0]["Age"].ToString())
            );
            ViewData.Model = users;

            return View();
        }
        #endregion

        #region 削除用户処理
        [HttpPost]
        public ActionResult DeleteUser(int Id)
        {
            //Id = int.Parse(Request.Form["userId"]);
            DbHelper dbHelper = new DbHelper(connectionString);
            SqlParameter param1 = new SqlParameter("@Id", Id);

            int result = dbHelper.ExecuteDelete("[dbo].[User]", param1);
            if (result > 0)
            {
                return RedirectToAction("ShowUserList");
            }
            return Content("無効");
        }
        #endregion

        #region 修改用户信息

        public ActionResult EditUser(int Id, int Age, string Name)
        {
            DbHelper dbHelper = new DbHelper(connectionString);
            string sql = "update [dbo].[User] set Name=@Name ,Id =@Id ,Age = @Age where Id = @Id";
            SqlParameter param1 = new SqlParameter("@Id", Id);
            SqlParameter param2 = new SqlParameter("@Age", Age);
            SqlParameter param3 = new SqlParameter("@Name", Name);

            dbHelper.ExecuteNonQuery(sql, param1, param2, param3);

            return RedirectToAction("ShowUserList");
        }
        #endregion
    }
}
