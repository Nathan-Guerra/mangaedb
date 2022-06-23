using Mangaedb.Model;
using Mangaedb.Models;
using Mangaedb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace Mangaedb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        MangaedbContext _db = new MangaedbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int days = 15)
        {
            var topMangas = MangaService.GetTopMangas(DateTime.Now.AddDays(days * -1).Date, 5);

            ViewBag.Days = days;
            ViewBag.TopMangas = topMangas;

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