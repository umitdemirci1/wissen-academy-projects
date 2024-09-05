using Microsoft.AspNetCore.Mvc;

namespace LayoutSample.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TrumpSuikast()
        {
            return View();
        }

        public IActionResult BorsadaDusus()
        {
            return View();
        }
    }
}
