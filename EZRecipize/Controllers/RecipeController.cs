using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EZRecipize.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Recipes()
        {
            return View();
        }
        public IActionResult RecipeDetails()
        {
            return View();
        }
        public IActionResult RecipeCooking()
        {
            return View();
        }
    }
}