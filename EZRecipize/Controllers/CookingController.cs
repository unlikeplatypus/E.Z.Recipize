using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EZRecipize.Models;

namespace EZRecipize.Controllers
{
    public class CookingController : Controller
    {
        //private RecipeDBContext _db;
        private static Recipe recipe;
        private static DisplayInfo Info = new DisplayInfo();
        private static int stepNum = 0;

        public IActionResult Index(int rId)
        {
            recipe =  Repo.recipes.Where(r => r.Id == rId).FirstOrDefault();
            return View(recipe);
        }

        public IActionResult Tutorial()
        {
            if(stepNum < recipe.Steps.Count())
            {
                Info.step = recipe.Steps.ElementAt(stepNum);
                if(Info.step.IsTimer)
                {
                    Info.timers.TryAdd(Info.step.TimerName, Info.step.Timer);
                }
                stepNum++;

                return View(Info);
            }
            else
            {
                stepNum = 0;
                Info = new DisplayInfo();
                return View("Finshed", recipe.Id);
            }

        }


        //protected void Display()
        //{
        //    TimeSpan ts;

        //    HidH.Value = Convert.ToString(ts.Hours);

        //    HidM.Value = Convert.ToString(ts.Minutes);

        //    HidS.Value = Convert.ToString(ts.Seconds);

        //}
            
    }
}