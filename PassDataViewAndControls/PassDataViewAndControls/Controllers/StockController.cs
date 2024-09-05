using Microsoft.AspNetCore.Mvc;

namespace PassDataViewAndControls.Controllers
{
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SiparisInfo()
        {
            int UrunID = int.Parse(TempData["UrunID"].ToString());
            string UrunAdi = TempData["UrunAdi"].ToString();
            string UrunFiyati = TempData["UrunFiyati"].ToString();

            return View();
        }
    }
}
