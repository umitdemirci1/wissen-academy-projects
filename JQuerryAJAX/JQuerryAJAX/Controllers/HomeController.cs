using JQuerryAJAX.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JQuerryAJAX.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public CalculateNumbers Calculate(int number1, int number2)
        {
            CalculateNumbers calculate = new CalculateNumbers();
            calculate.Add = number1 + number2;
            calculate.Subtract = number1 - number2;
            calculate.Multiplier = number1 * number2;
            calculate.Divide = number1 / number2;
            return calculate;
        }

        public IActionResult Personel()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Personel(Personel personel)
        {
            return Json(personel);
        }

        [HttpPost]
        public IActionResult PersonelDetail(Personel personel)
        {
            return View(personel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
