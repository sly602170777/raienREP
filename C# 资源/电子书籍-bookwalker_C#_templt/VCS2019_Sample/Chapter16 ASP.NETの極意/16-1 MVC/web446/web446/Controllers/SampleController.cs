using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web446.Controllers
{
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            var data = HttpContext.Session.GetString("現在時刻");
            ViewBag.NowTime = data;
            return View();
        }
    }
}