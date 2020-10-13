using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aspnetoctest.Models;
using Microsoft.Extensions.Configuration;

namespace aspnetoctest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.ASPNETCORE_ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            ViewBag.S2 = Environment.GetEnvironmentVariable("S2");
            ViewBag.ENVTEST = Environment.GetEnvironmentVariable("ENVTEST");
            ViewBag.SECRET1 = _configuration.GetValue<string>("secret1");
            ViewBag.SECRET2 = _configuration.GetValue<string>("secret2");
            ViewBag.ERLKEY1 = _configuration.GetValue<string>("erlkey1");

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
