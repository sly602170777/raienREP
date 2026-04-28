using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using aspnetMVCProject.Models;

namespace aspnetMVCProject.Controllers
{
    public class JsonResultDemoController : Controller
    {
        #region ActionControllers

        public JsonResult WelcomeNote()
        {
            bool isAdmin = false;
            string output = isAdmin ? "Welcome" : "Hello World";

            return Json(output, JsonRequestBehavior.AllowGet);
        }

        private List<user> GetUsers()
        {
            var usersList = new List<user>
            {
                new user { Id = "11", Name = "Tapas1" },
                new user { Id = "12", Name = "Robin2" },
                new user { Id = "13", Name = "Robin3" },
            };

            return usersList;
        }

        public JsonResult GetUsersData()
        {
            var users = GetUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        private List<user> GetUsersHugeData()
        {
            var usersList = new List<user>();
            user user;
            for (int i = 1; i < 51000; i++)
            {
                user = new user { Id = i + "", Name = "user-" + i };
                usersList.Add(user);
            }

            return usersList;
        }

        public JsonResult GetUsersHugeList()
        {
            var users = GetUsersHugeData();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SampleView()
        {
            return View();
        }

        protected override JsonResult Json(
            object data,
            string contentType,
            Encoding contentEncoding,
            JsonRequestBehavior behavior
        )
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue,
            };
        }
        #endregion
    }
}
