using Microsoft.AspNetCore.Mvc;
using ViewModelApplication.Models;

namespace ViewModelApplication.Controllers
{
    public class StudentController : Controller
    {
        List<Gender> genders = new List<Gender>()
        {
            new Gender { GenderID=1, GenderName= "Erkek" },
            new Gender { GenderID=2, GenderName= "Kadın" }
        };

        List<Country> countrys = new List<Country>()
        {
            new Country { CountryID=1, CountryName= "Türkiye" },
            new Country { CountryID=2, CountryName= "Amerika" },
            new Country { CountryID=3, CountryName= "Almanya" }
        };

        public IActionResult Index()
        {
            ViewData["Gender"] = genders;
            ViewData["Country"] = countrys;
            Student student = new Student();
            return View(student);
        }
    }
}
