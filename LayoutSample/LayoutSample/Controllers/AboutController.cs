using Microsoft.AspNetCore.Mvc;

namespace LayoutSample.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult YonetimKurulu()
        {
            return View();
        }

        public IActionResult Tarihce()
        {
            return View();
        }


    }
}
