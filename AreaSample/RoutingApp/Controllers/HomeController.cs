using Microsoft.AspNetCore.Mvc;
using RoutingApp.Models;
using System.Diagnostics;

namespace RoutingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        List<Product> products = new()
        {
            new Product { ProductID = 1, ProductName = "Laptop", CategoryID = 1, CategoryName = "Electronics", Description = "Laptop Description" },
            new Product { ProductID = 2, ProductName = "Mobile", CategoryID = 1, CategoryName = "Electronics", Description = "Mobile Description" },
            new Product { ProductID = 3, ProductName = "Shirt", CategoryID = 2, CategoryName = "Clothes", Description = "Shirt Description" },
            new Product { ProductID = 4, ProductName = "TShirt", CategoryID = 2, CategoryName = "Clothes", Description = "T-Shirt Description" },
            new Product { ProductID = 5, ProductName = "Trouser", CategoryID = 2, CategoryName = "Clothes", Description = "Trouser Description" }
        };

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            return View(products);
        }

        [Route("Privacy")]
        [Route("Home/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //saat 10:40
    }
}
