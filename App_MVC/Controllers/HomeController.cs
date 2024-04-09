using App_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult indexU(){
            return View();
        }

        public IActionResult Index()
        {
			var sessionData = HttpContext.Session.GetString("user");
			if (sessionData == null)
			{
				ViewData["mes"] = "Bạn chưa đăng nhập hoặc phiên đăng nhập đã hết hạn";
			}
			else
			{
				ViewData["mes"] = $"Chào mừng {sessionData} đến với unfinished square integer";
			}
			return View();
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