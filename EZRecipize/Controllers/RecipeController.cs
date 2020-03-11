﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EZRecipize.Models;

namespace EZRecipize.Controllers
{
    public class RecipeController : Controller
    {
        //private RecipeDBContext _db;
        private static Recipe recipe;
        private static RecipeStep recipeStep;

        public IActionResult Recipes()
        {
            return View(Repo.recipes);
        }

        //public IActionResult RecipeDetails(Recipe r)
        //{
        //    return View(r);
        //}

        public IActionResult RecipeDetails(int recipeId)
        {
            Recipe r = Repo.recipes.Where(r => r.Id == recipeId).FirstOrDefault();
            return View(r);
        }

        public IActionResult RecipeCooking()
        {
            return View();
        }

        public IActionResult Create(bool active)
        {
            if(!active)
            {
                recipe = new Recipe();
            }

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Create(Recipe recipeTemp, bool addingStep)
        {
            if (ModelState.IsValid && !addingStep && recipe.Steps.Count != 0)
            {
                if(recipe.Steps != null && recipe.Steps.Count > 0)
                {
                    recipe.Steps.Last().SeperateListStrings();
                }
                recipeTemp.Steps = recipe.Steps;
                Repo.recipes.Add(recipeTemp);
                return View("RecipeDetails", recipeTemp);
            }
            else if(addingStep)
            {
                return RedirectToAction("CreateStep", recipeTemp);
            }
            else
            {
                return View(recipe);
            }
        }

        public IActionResult CreateStep(Recipe r, bool active = false)
        {

            if (!active)
            {
                recipeStep = new RecipeStep();
            }
            
            recipe.RecipeName = r.RecipeName;
            recipe.RecipeDescription = r.RecipeDescription;
            if(recipeStep.RequiredCookware == null)
            {
                recipeStep.RequiredCookware = new List<string>();
            }
            if(recipeStep.SuggestedCookware == null)
            {
                recipeStep.SuggestedCookware = new List<string>();
            }
            return View(recipeStep);
        }

        [HttpPost]
        public IActionResult CreateStep(RecipeStep s, bool addingIngredient)
        {
            if (ModelState.IsValid && !addingIngredient)
            {
                recipeStep.SeperateListStrings();
                recipeStep.Instructions = s.Instructions;
                recipeStep.IsTimer = s.IsTimer;
                recipeStep.Timer = s.Timer;
                recipeStep.TimerName = s.TimerName;
                if (s.RequiredCookware != null && s.RequiredCookware.Count > 0 && s.RequiredCookware.ElementAt(0) != null && recipeStep.RequiredCookware != null && s.RequiredCookware.Count != recipeStep.RequiredCookware.Count)
                {
                    for (int i = 0; i < s.RequiredCookware.Count; i++)
                    {

                        recipeStep.RequiredCookware.Add(s.RequiredCookware.ElementAt(i));
                    }
                }
                if (s.SuggestedCookware != null && s.SuggestedCookware.Count > 0 && s.SuggestedCookware.ElementAt(0) != null && recipeStep.SuggestedCookware != null && s.SuggestedCookware.Count != recipeStep.SuggestedCookware.Count)
                {
                    for (int i = 0; i < s.SuggestedCookware.Count; i++)
                    {
                        recipeStep.SuggestedCookware.Add(s.SuggestedCookware.ElementAt(i));
                    }
                }

                recipe.Steps.Add(recipeStep);
                return View("Create", recipe);
            }
            else if(addingIngredient)
            {
                recipeStep.Instructions = s.Instructions;
                recipeStep.IsTimer = s.IsTimer;
                recipeStep.Timer = s.Timer;
                recipeStep.TimerName = s.TimerName;
                recipeStep.TempRequiredCookware = s.TempRequiredCookware;
                if (s.RequiredCookware != null && s.RequiredCookware.Count > 0 && s.RequiredCookware.ElementAt(0) != null && recipeStep.RequiredCookware != null && s.RequiredCookware.Count != recipeStep.RequiredCookware.Count)
                {
                    for (int i = 0; i < s.RequiredCookware.Count; i++)
                    {
                        
                        recipeStep.RequiredCookware.Add(s.RequiredCookware.ElementAt(i));
                    }
                }
                recipeStep.TempSuggestedCookware = s.TempSuggestedCookware;
                if (s.SuggestedCookware != null && s.SuggestedCookware.Count > 0 && s.SuggestedCookware.ElementAt(0) != null && recipeStep.SuggestedCookware != null && s.SuggestedCookware.Count != recipeStep.SuggestedCookware.Count)
                {
                    for (int i = 0; i < s.SuggestedCookware.Count; i++)
                    {
                        recipeStep.SuggestedCookware.Add(s.SuggestedCookware.ElementAt(i));
                    }
                }
                //recipeStep = s;

                return RedirectToAction("CreateIngredient", recipeStep);
            }
            else
            {
                return View();
            }
        }

        public IActionResult CreateIngredient(RecipeStep s)
        {
            //recipeStep = new RecipeStep();

            if (recipeStep.Ingredients == null)
            {
                recipeStep.Ingredients = new List<Ingredient>();
            }

            recipeStep.Ingredients.Add(new Ingredient());

            return View();
        }

        [HttpPost]
        public IActionResult CreateIngredient(Ingredient i)
        {
            if (ModelState.IsValid)
            {

                recipeStep.Ingredients.Last().Name = i.Name;
                recipeStep.Ingredients.Last().Amount = i.Amount;
                recipeStep.Ingredients.Last().Unit = i.Unit;
                recipeStep.Ingredients.Last().SpecialInstructions = i.SpecialInstructions;

                return View("CreateStep", recipeStep);
            }
            else
            {
                return View();
            }
        }

    }
}