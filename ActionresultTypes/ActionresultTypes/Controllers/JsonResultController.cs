using ActionresultTypes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionresultTypes.Controllers
{
    public class JsonResultController : Controller
    {
        List<Employee> employees = new()
        {
            new Employee{
                EmployeeID = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john@mail.com",
                Address = new Address
                {
                    AddressID = 1,
                    Country = "USA",
                    City = "New York",
                    AddressDetail = "123 Wall Street"
                } 
            },
            new Employee{
                EmployeeID = 1,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane@mail.com",
                Address = new Address
                {
                    AddressID = 1,
                    Country = "USA",
                    City = "New York",
                    AddressDetail = "125 Wall Street"
                } 
            }
        };
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetJsonEmployee()
        {
            return Json(employees);
        }
    }
}
