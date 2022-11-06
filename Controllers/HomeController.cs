using DummyDataMaker.Models;
using DummyDataMaker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DummyDataMaker.Controllers
{

    public class HomeController : Controller
    {
        private IGenerateRepository _generateRepository;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IGenerateRepository generateRepository )
        {
            _logger = logger;
            _generateRepository = generateRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetStarted()
        {
            List<string> dataTypes = Enum.GetNames(typeof(AllDataTypes)).Cast<string>().ToList();
            ViewBag.DataTypeOptions = dataTypes;
            return View();
        }

        [HttpPost]
        public IActionResult GetStarted(string dbName)
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