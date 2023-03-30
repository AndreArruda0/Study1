using ConnectAPI.Data;
using ConnectAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ConnectAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using(var httpClient = new HttpClient())
            {
                var menus = await httpClient.GetAsync("https://localhost:7179/Menus");
                var retorno = await menus.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<Menu>>(retorno);
                ViewBag.Menus = json;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}