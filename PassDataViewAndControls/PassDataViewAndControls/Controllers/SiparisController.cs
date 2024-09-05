using Microsoft.AspNetCore.Mvc;

namespace PassDataViewAndControls.Controllers
{
    public class SiparisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UrunSat()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult UrunSat(string urunID, string UrunAdi, string UrunFiyati)
        //{
        //    TempData["UrunID"] = urunID;
        //    TempData["UrunAdi"] = UrunAdi;
        //    TempData["UrunFiyati"] = UrunFiyati;
        //    return RedirectToAction("SiparisInfo", "Stok");
        //}
        [HttpPost]
        public IActionResult UrunSat(IFormCollection form)
        {
            TempData["UrunID"] = int.Parse(form["UrunID"].ToString());
            TempData["UrunAdi"] = form["UrunAdi"].ToString();
            TempData["UrunFiyati"] = form["UrunFiyati"].ToString();
            return RedirectToAction("SiparisInfo", "Stok");
        }
    }
}
