using Microsoft.AspNetCore.Mvc;
using RoutingApp.Models;

namespace RoutingApp.Controllers
{
    public class ProductController : Controller
    {
        List<Product> products = new()
        {
            new Product { ProductID = 1, ProductName = "Laptop", CategoryID = 1, CategoryName = "Electronics", Description = "Laptop Description" },
            new Product { ProductID = 2, ProductName = "Mobile", CategoryID = 1, CategoryName = "Electronics", Description = "Mobile Description" },
            new Product { ProductID = 3, ProductName = "Shirt", CategoryID = 2, CategoryName = "Clothes", Description = "Shirt Description" },
            new Product { ProductID = 4, ProductName = "TShirt", CategoryID = 2, CategoryName = "Clothes", Description = "T-Shirt Description" },
            new Product { ProductID = 5, ProductName = "Trouser", CategoryID = 2, CategoryName = "Clothes", Description = "Trouser Description" }
        };

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Details(int id)
        //{
        //    Product product = products.FirstOrDefault(p => p.ProductID == id);
        //    if(product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);
        //}

        [Route("product-category-{categoryId}-{categoryname}-{productId}-{productname}")]
        [Route("Home/product-category-{categoryId}-{categoryname}-{productId}-{productname}")]
        public IActionResult Details(int productId)
        {
            var product = products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}