using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using aspnetMVCProject.Models;

namespace aspnetMVCProject.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;

        public ActionResult Index()
        {
            MyLogger logger = new MyLogger();

            logger.Page_Load(null, EventArgs.Empty);

            DbHelper dbHelper = new DbHelper(connectionString);
            //dbHelper.ExecuteQuery ('select [ABC], [id] from AAA',);
            string sql = "select [ABC], [id] from AAA";
            DataTable dt = dbHelper.ExecuteQuery(sql);
            List<user> users = new List<user>();
            user user1 = new user();
            foreach (DataRow row in dt.Rows)
            {
                if (row["ABC"].ToString().Replace(" ", "") == "sly")
                {
                    //  user1 = new user (row ["ABC"].ToString (), row ["id"].ToString (),);
                }
                //users.Add (new user (row ["ABC"].ToString (), row ["id"].ToString ()));

                //log.Info ();
            }
            ViewData.Model = user1;

            //指定画面展示
            return View("Index2");
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetUserInfo()
        {
            DbHelper dbHelper = new DbHelper(connectionString);
            //dbHelper.ExecuteQuery ('select [ABC], [id] from AAA',);
            string sql = "select [ABC], [id] from AAA where ABC ='sly'";
            DataTable dt = dbHelper.ExecuteQuery(sql);
            List<user> users = new List<user>();
            user user1 = new user();
            foreach (DataRow row in dt.Rows)
            {
                if (row["ABC"].ToString().Replace(" ", "") == "sly")
                {
                    //user1 = new user(row["ABC"].ToString(), row["id"].ToString());
                }
            }
            //ASP.NET MVC默认出于安全考虑，禁止通过GET请求返回JSON数据（防止JSON劫持攻击）。
            //如果确定需要允许GET请求返回JSON数据，需显式设置 JsonRequestBehavior.AllowGet。
            //安全性优先：尽量使用POST请求，并结合防伪令牌验证。
            return Json(user1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
