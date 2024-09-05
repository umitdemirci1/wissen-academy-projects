using Microsoft.AspNetCore.Mvc;

namespace AreaSample.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
