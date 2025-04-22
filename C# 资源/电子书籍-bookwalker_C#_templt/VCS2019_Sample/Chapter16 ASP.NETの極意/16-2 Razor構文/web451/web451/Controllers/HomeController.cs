using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web451.Models;

namespace web451.Controllers
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
            var lst = new List<MyModel>();
            lst.Add(new MyModel() { ID = 100, Title = "逆引き大全C#2019", Price = 2000 });
            lst.Add(new MyModel() { ID = 101, Title = "逆引き大全VB2019", Price = 2000 });
            lst.Add(new MyModel() { ID = 102, Title = "逆引き大全F#2019", Price = 2000 });
            return View(lst);
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
