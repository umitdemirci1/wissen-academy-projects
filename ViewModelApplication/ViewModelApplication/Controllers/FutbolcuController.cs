using Microsoft.AspNetCore.Mvc;
using ViewModelApplication.Models;
using ViewModelApplication.Models.ViewModel;

namespace ViewModelApplication.Controllers
{
    public class FutbolcuController : Controller
    {
        List<Takim> teams = new List<Takim>()
        {
            new Takim{ TakimID=1, TakimAdi= "Galatasaray"},
            new Takim{ TakimID=2, TakimAdi= "Fenerbahçe"},
            new Takim{ TakimID=3, TakimAdi= "Beşiktaş"},
            new Takim{ TakimID=4, TakimAdi= "Trabzonspor"},
            new Takim{ TakimID=5, TakimAdi= "Başakşehir"},
            new Takim{ TakimID=6, TakimAdi= "Sivasspor"},
        };

        List<Mevki> positions = new List<Mevki>()
        {
            new Mevki{ MevkiID=1, MevkiAdi= "Kaleci"},
            new Mevki{ MevkiID=2, MevkiAdi= "Defans"},
            new Mevki{ MevkiID=3, MevkiAdi= "Orta Saha"},
            new Mevki{ MevkiID=4, MevkiAdi= "Forvet"},
            new Mevki{ MevkiID=5, MevkiAdi= "Santrafor"},
        };
        public IActionResult Index(FutbolcuAddVM futbolcuAddVM)
        {
            //Futbolcu futbolcu = futbolcuVM.Futbolcu;
            return View(futbolcuAddVM);
        }

        public IActionResult Create()
        {
            FutbolcuAddVM futbolcuAddVM = new FutbolcuAddVM();
            futbolcuAddVM.Futbolcu = new Futbolcu();
            futbolcuAddVM.Takimlar = teams;
            futbolcuAddVM.Mevkiler = positions;
            return View(futbolcuAddVM);
        }

        [HttpPost]
        public IActionResult Create(FutbolcuAddVM futbolcuAddVM)
        {
            Mevki mevki = positions.FirstOrDefault(x => x.MevkiID == futbolcuAddVM.Futbolcu.MevkiID);
            Takim takim = teams.FirstOrDefault(x => x.TakimID == futbolcuAddVM.Futbolcu.TakimID);
            futbolcuAddVM.Futbolcu.Mevki = mevki;
            futbolcuAddVM.Futbolcu.Takim = takim;
            return View("Index", futbolcuAddVM);
        }
    }
}
