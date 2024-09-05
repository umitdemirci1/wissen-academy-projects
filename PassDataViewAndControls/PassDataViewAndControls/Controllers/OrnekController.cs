using Microsoft.AspNetCore.Mvc;

namespace PassDataViewAndControls.Controllers
{
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag
            ViewBag.GetDate = DateTime.Now.ToLongDateString();
            ViewBag.Names = new string[] { "Ahmet", "Mehmet", "Ayşe", "Fatma" };

            //ViewData
            ViewData["Hour"] = DateTime.Now.ToLongTimeString();

            //TempData
            TempData["Day"] = DateTime.Now.Day;

            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }
    }
}
