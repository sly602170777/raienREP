using aspnetMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace aspnetMVCProject.Controllers
{
    public class ProductController : Controller
    {
        MyLogger logger = new MyLogger ();
        string connectionString = ConfigurationManager.ConnectionStrings ["DefaultConnection"].ConnectionString;
        
        public JsonResult GetProducts ()
        {
            
            DbHelper dbHelper = new DbHelper (connectionString);
            string sql = "select [ABC], [id] from AAA";
            DataTable dt = dbHelper.ExecuteQuery (sql);

            List<user> users = new List<user>{ };
            
            foreach (DataRow row in dt.Rows)
            {
                logger.Page_Load (new user (row ["ABC"].ToString (), row ["id"].ToString ()), EventArgs.Empty);
                users.Add(new user (row ["ABC"].ToString (), row ["id"].ToString ()));
            }
            return Json (users, JsonRequestBehavior.AllowGet);

        }
        public ActionResult EditProdect ()
        {
            ViewBag.Message = "Your application description page.";

            return View ();
        }

    }

};

        
       