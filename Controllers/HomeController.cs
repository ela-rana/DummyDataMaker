using DummyDataMaker.Models;
using DummyDataMaker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DummyDataMaker.Controllers
{

    public class HomeController : Controller
    {
        private IGenerateRepository _generateRepository;
        private GeneratedDatabase generatedDatabase;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IGenerateRepository generateRepository)
        {
            _logger = logger;
            _generateRepository = generateRepository;
            generatedDatabase = new GeneratedDatabase();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenerateDB()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateDB(string dbName)
        {

            if (ModelState.IsValid)
            {
                generatedDatabase.Name = dbName;
                generatedDatabase.Id = _generateRepository.MaxDatabaseID()+1;
                if (User.Identity.IsAuthenticated) 
                {
                    generatedDatabase.User = User.Identity.Name;
                }
                else
                {
                    generatedDatabase.User = "Guest User";
                }
                _generateRepository.AddDatabase(generatedDatabase);
                return RedirectToAction("GenerateTB", new {DBID=generatedDatabase.Id, DBName=generatedDatabase.Name});
            }
            else
            {
                return View("CustomError");
            }
        }

        [HttpGet]
        public IActionResult GenerateTB(int DBId, string DBName)
        {
            List<string> dataTypes = Enum.GetNames(typeof(AllDataTypes)).Cast<string>().ToList();
            ViewBag.DataTypeOptions = dataTypes;
            ViewBag.DBId = DBId;
            ViewBag.DBName = DBName;
            return View();
        }

        [HttpPost]
        public IActionResult GenerateTB()
        {
            if (ModelState.IsValid)
            {
                return View("Index");
            }
            return View("CustomError");
        }



        public IActionResult CustomError()
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