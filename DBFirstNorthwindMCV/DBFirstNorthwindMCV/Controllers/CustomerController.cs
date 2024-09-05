using DBFirstNorthwindMCV.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBFirstNorthwindMCV.Controllers
{
    public class CustomerController : Controller
    {
        NorthwindDbContext _context;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(NorthwindDbContext context, ILogger<CustomerController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList<Customer>();
            return View(customers);
        }

        public IActionResult Details(string id)
        {
            var customer = _context.Customers.Find(id);
            return View(customer);
        }

        public IActionResult Delete(string id)
        {
            var customer = _context.Customers.Find(id);
            return View(customer);
        }
    }
}
