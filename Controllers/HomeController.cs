using DummyDataMaker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DummyDataMaker.Controllers
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

        [HttpGet]
        public IActionResult GetStarted()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetStarted(GeneratedDatabase? generatedDatabase)
        {
            if (ModelState.IsValid)
            {
                return View("GoodJob");
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult GoodJob()
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