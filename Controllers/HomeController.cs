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
        public IActionResult DBForm()
        {
            return View();
        }

        public IActionResult SiteFlow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetStarted()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetStarted(GeneratedDatabase generatedDatabase)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("CreateTable");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateTable()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult CreateTable(GeneratedDatabase generatedDatabase)
        //{
        //    return RedirectToAction("Finalize");
        //}

        [HttpGet]
        public IActionResult Finalize(GeneratedDatabase generatedDatabase)
        {
            return View(generatedDatabase);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}