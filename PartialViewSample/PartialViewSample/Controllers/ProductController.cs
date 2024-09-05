using Microsoft.AspNetCore.Mvc;
using PartialViewSample.Models;

namespace PartialViewSample.Controllers
{
    public class ProductController : Controller
    {
        List<Product> products = new List<Product>
        {
            new Product { ProductID = 1, ProductName = "Laptop", CategoryName = "Electronics", Price = 50000, Description = "Dell Laptop" },
            new Product { ProductID = 2, ProductName = "Mobile", CategoryName = "Electronics", Price = 20000, Description = "Samsung Mobile" },
            new Product { ProductID = 3, ProductName = "Shirt", CategoryName = "Clothing", Price = 1000, Description = "Peter England Shirt" },
            new Product { ProductID = 4, ProductName = "T-Shirt", CategoryName = "Clothing", Price = 500, Description = "Polo T-Shirt" },
            new Product { ProductID = 5, ProductName = "Shoes", CategoryName = "Footwear", Price = 3000, Description = "Nike Shoes" }
        };

        public IActionResult Index()
        {
            var productList = products.OrderBy(p => p.Price).ThenByDescending(p => p.CategoryName).ToList();
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductID == id);
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            Product product = products.FirstOrDefault(x => x.ProductID == id);
            return PartialView("ProductDetail", product);
        }
    }
}
