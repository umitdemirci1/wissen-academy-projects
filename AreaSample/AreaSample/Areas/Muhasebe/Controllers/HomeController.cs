using Microsoft.AspNetCore.Mvc;

namespace AreaSample.Areas.Muhasebe.Controllers
{
    [Area("Muhasebe")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
