using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EZRecipize.Models;

namespace EZRecipize.Controllers
{
    public class HomeController : Controller
    {
        private RecipeDBContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_db.Recipes);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
