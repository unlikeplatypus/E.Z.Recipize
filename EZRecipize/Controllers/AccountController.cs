using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EZRecipize.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Account()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}