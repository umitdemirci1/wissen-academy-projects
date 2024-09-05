using ConsumeJSONWebToken.Model;
using ConsumeJSONWebToken.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ConsumeJSONWebToken.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private string baseUrl = "https://localhost:7041/api/";
        private string method = "Login/LoginUser";
        public async Task<IActionResult> Index()
        {
            AuthUser user = new AuthUser()
            {
                UserName = "admin",
                Password = "123456"
            };

            var serializeUser = System.Text.Json.JsonSerializer.Serialize(user);

            StringContent stringContent = new StringContent(serializeUser, Encoding.UTF8, "application/json");

           
            HttpClient client = new HttpClient();
            string url = string.Concat(baseUrl,method);
            var result = await client.PostAsync(url, stringContent);
            var json = await result.Content.ReadAsStringAsync();
            Token token = JsonConvert.DeserializeObject<Token>(json);

            HttpContext.Session.SetString("token", token.token);
            return View(token);
        }

        public async Task<IActionResult> Privacy()
        { 
            string token = HttpContext.Session.GetString("token");
            baseUrl = "https://localhost:7041/";
            method = "WeatherForecast";


            HttpClient client = new HttpClient();
            string url = string.Concat(baseUrl, method);
            //client.BaseAddress = new Uri(url);
            
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");


            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            IEnumerable<WeatherForecast> data = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(json);
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
