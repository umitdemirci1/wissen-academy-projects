using Microsoft.AspNetCore.Mvc;
using PartialViewSample.Models;
using System.Diagnostics;

namespace PartialViewSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        List<Product> products = new List<Product>
        {
            new Product { ProductID = 1, ProductName = "Laptop", CategoryName = "Electronics", Price = 50000, Description = "Dell Laptop" },
            new Product { ProductID = 2, ProductName = "Mobile", CategoryName = "Electronics", Price = 20000, Description = "Samsung Mobile" },
            new Product { ProductID = 3, ProductName = "Shirt", CategoryName = "Clothing", Price = 1000, Description = "Peter England Shirt" },
            new Product { ProductID = 4, ProductName = "T-Shirt", CategoryName = "Clothing", Price = 500, Description = "Polo T-Shirt" },
            new Product { ProductID = 5, ProductName = "Shoes", CategoryName = "Footwear", Price = 3000, Description = "Nike Shoes" }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var productList = products.OrderBy(p => p.Price).ThenByDescending(p => p.CategoryName).ToList();
            return View(productList);
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
