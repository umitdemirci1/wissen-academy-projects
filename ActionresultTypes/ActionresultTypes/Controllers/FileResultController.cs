using Microsoft.AspNetCore.Mvc;

namespace ActionresultTypes.Controllers
{
    public class FileResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public FileResult FileContent()
        {
            //return File("~/files/BAU_İSTKA_ÖĞRENCİ_TAAHHÜTNAMESİ.pdf", "application/pdf");
            //return File("~/files/çalışma progrmı.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheet.sheet");
            return File("~/files/çalışma programı.xls", "application/vnd.ms-excel");
        }
    }
}
