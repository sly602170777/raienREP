using aspnetMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace aspnetMVCProject.Controllers.User
{
    public class UserController: Controller
    {
        MyLogger logger = new MyLogger ();
        string connectionString = ConfigurationManager.ConnectionStrings ["DefaultConnection"].ConnectionString;

        // 获取所有用户
        [HttpGet]
        public JsonResult GetUsers ()
        {
            DbHelper dbHelper = new DbHelper (connectionString);
            string sql = "select  [Id]  ,[Name] from [dbo].[User]";
            DataTable dt = dbHelper.ExecuteQuery (sql);
            List<user> users = new List<user> { };
            // TODO:
            foreach (DataRow row in dt.Rows)
            {
                logger.Page_Load (new user (row ["Id"].ToString (), row ["Name"].ToString ()), EventArgs.Empty);
                users.Add (new user (row ["Id"].ToString (), row ["Name"].ToString ()));
            }
            //ViewData.Model = users;
            //return View ("UserIndex");
            var result = Json (new { users, success = true }, JsonRequestBehavior.AllowGet);
            return result;// 返回JSON数据
        }


        public ActionResult UserView ()
        {
            return View ();
        }
    }
}