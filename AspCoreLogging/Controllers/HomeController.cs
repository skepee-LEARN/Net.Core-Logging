using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCoreLogging.Models;
using Microsoft.Extensions.Logging;

namespace AspCoreLogging.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult GetById(string id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Gettimg Item {ID}",id);

            var item = "test"; // todo

            if (item == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetById({ID}) NOT FOUND", id);

                return NotFound();
            }
            return new ObjectResult(item);
        }


        public IActionResult Index()
        {
            _logger.LogInformation (LoggingEvents.GetItem, "Gettimg Item {ID}", "11111");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Gettimg Item {ID}", "22222");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class LoggingEvents
    {
        public const int GenerateItems = 1000;
        public const int ListItems = 1001;
        public const int GetItem = 1002;
        public const int InsertItem = 1003;
        public const int UpdateItem = 1004;
        public const int DeleteItem = 1005;
        public const int GetItemNotFound = 4000;
        public const int UpdateItemNotFound = 4001;
    }
}
