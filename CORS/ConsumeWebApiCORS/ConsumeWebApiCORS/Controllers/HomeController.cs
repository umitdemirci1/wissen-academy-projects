using ConsumeWebApiCORS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ConsumeWebApiCORS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        private string baseUrl = "https://localhost:7080/api/";
        private string getStudentsMethod = "Student/GetAllStudents";
        public async Task<IActionResult> Privacy()
        {

            HttpClient client = new HttpClient();
            string url = string.Concat(baseUrl, getStudentsMethod);
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            List<Student> studentList = JsonConvert.DeserializeObject<List<Student>>(json);
            return View(studentList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
