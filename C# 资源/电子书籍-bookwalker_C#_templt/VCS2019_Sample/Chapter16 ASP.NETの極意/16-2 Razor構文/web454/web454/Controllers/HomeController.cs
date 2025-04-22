using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web454.Models;

namespace web454.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Index2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Post(MyModel model)
        {
            ViewBag.Message = "";
            if (string.IsNullOrEmpty(model.Name) ||
                string.IsNullOrEmpty(model.Telephone))
            {
                ViewBag.Message = "名前と電話番号を入力してください";
                return View("Index", model);
            }
            else
            {
                // 結果ページを表示
                return View("Result", model);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
