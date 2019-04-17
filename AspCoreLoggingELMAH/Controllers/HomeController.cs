﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCoreLoggingELMAH.Models;
using Microsoft.Extensions.Logging;
using ElmahCore;

namespace AspCoreLoggingELMAH.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Test()
        {
            HttpContext.RiseError(new InvalidOperationException("Test"));
            return View("Index");
        }



        public IActionResult Index()
        {

            _logger.LogInformation("In Index");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("In Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
