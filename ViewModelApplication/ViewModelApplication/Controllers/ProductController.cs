using Microsoft.AspNetCore.Mvc;
using ViewModelApplication.Models;
using ViewModelApplication.Models.ViewModel;

namespace ViewModelApplication.Controllers
{
    public class ProductController : Controller
    {
        List<Category> categories = new List<Category>()
        {
            new Category{ CategoryID=1, CategoryName= "Beverages", Description="Alcoholic and non-alcoholic beverages"},
            new Category{ CategoryID=2, CategoryName= "Bakery", Description="Breads, cakes, pastries, and other bakery products"},
            new Category{ CategoryID=3, CategoryName= "Fruits", Description="Fresh and dried fruits"},
            new Category{ CategoryID=4, CategoryName= "Vegetables", Description="Fresh vegetables and herbs"},
            new Category{ CategoryID=5, CategoryName= "Dairy", Description="Milk, cheese, and other dairy products"}
        };
        List<Supplier> suppliers = new List<Supplier>()
        {
           new Supplier{ SupplierID=1, CompanyName="Acme Corp", ContactName="John Doe", ContactTitle="Sales Manager", Address="123 Elm St", City="Metropolis", Region="North", PostalCode="12345", Country="USA",   Phone="555-1234", Fax="555-5678", HomePage="www.acmecorp.com"},
           new Supplier{ SupplierID=2, CompanyName="Global Export", ContactName="Jane Smith", ContactTitle="Owner", Address="456 Oak St", City="Gotham", Region="South", PostalCode="67890", Country="USA", Phone="555-6789",     Fax="555-4321", HomePage="www.globalexport.com"},
           new Supplier{ SupplierID=3, CompanyName="Fresh Produce Ltd", ContactName="Ahmed Khan", ContactTitle="Marketing Director", Address="789 Pine St", City="Star City", Region="East", PostalCode="54321",    Country="UK",     Phone="123-4567", Fax="123-7654", HomePage="www.freshproduce.co.uk"},
           new Supplier{ SupplierID=4, CompanyName="Gourmet Delights", ContactName="Elena Rodriguez", ContactTitle="CEO", Address="321 Birch St", City="Central City", Region="West", PostalCode="98765", Country="Spain",        Phone="987-6543", Fax="987-6543", HomePage="www.gourmetdelights.es"},
           new Supplier{ SupplierID=5, CompanyName="Quick Electronics", ContactName="Satoshi Nakamoto", ContactTitle="Founder", Address="654 Cedar St", City="Emerald City", Region="Central", PostalCode="24680",      Country="Japan", Phone="654-3210", Fax="654-3210", HomePage="www.quickelectronics.jp"}
        };
        public IActionResult Index(ProductAddVM productAddVM)
        {
            return View(productAddVM);
        }

        public IActionResult Create()
        {
            ProductAddVM productAddVM = new ProductAddVM();
            productAddVM.Product = new Product();
            productAddVM.Categories = categories;
            productAddVM.Suppliers = suppliers;
            return View(productAddVM);
        }

        [HttpPost]
        public IActionResult Create(ProductAddVM productAddVM)
        {
            Category category = categories.FirstOrDefault(x => x.CategoryID == productAddVM.Product.CategoryID);
            Supplier supplier = suppliers.FirstOrDefault(x => x.SupplierID == productAddVM.Product.SupplierID);
            productAddVM.Product.Category = category;
            productAddVM.Product.Supplier = supplier;
            return View("Index", productAddVM);
        }
    }
}

