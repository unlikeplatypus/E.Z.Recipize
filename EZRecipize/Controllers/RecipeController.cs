using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EZRecipize.Models;

namespace EZRecipize.Controllers
{
    public class RecipeController : Controller
    {

        public static List<Recipe> recipes = new List<Recipe>()
        {
            new Recipe("Baked Chicken","a simple baked chicken recipy", new List<RecipeStep>
            {
                new RecipeStep("preheat oven to 400 degrees",null, new List<string>{"convention oven"}, null),
                new RecipeStep("Wash you hands with hot water and soap",null, null, null),
                new RecipeStep("add the seasonings to your cutting board and then take your chicken breasts and slice them down the long way and then take to two halfs and do it again",new List<Ingredient>
                {
                    new Ingredient("paprika", 3, "tablespoon","amount will vary based on how much spice you want"),
                    new Ingredient("Garlic Salt", 1, "tablespoon","none"),
                    new Ingredient("Skinless boneless chicken breast", 2, "tablespoon","none")

                }
                , new List<string>{"cutting board", "Sharp Knife(preferably straigt edge)" }, null),
                new RecipeStep("fill one of the bowls with flower, paperika, garlic powder, and pepper. fill another with 2 eggs wisked lightly and the final bowl with your panko",new List<Ingredient>
                {
                    new Ingredient("flower",1,"cup", "may need a little more"),
                    new Ingredient("paperika",1,"tablespoon", "none"),
                    new Ingredient("galric powder",1,"tablespoon", "none"),
                    new Ingredient("eggs",2,"", "none"),
                    new Ingredient("Panko",2,"cups", "none")
                }, new List<string>{ "three bowls", "wisk/fork"},null),
                new RecipeStep("toss the chicken in the flower, then the egg, then the panko and place to the side",null, null, new List<string>{"tongs"}),
                new RecipeStep("warm up some oil on the stove you can test the heat by taking a little of the egg/breading and seeing if it sizzles when you put it in. " +
                    "you will place the breaded chicken in the oil using the tongs or fork for a few seconds on each side just to brown it and add a crispness",new List<Ingredient>
                    {
                        new Ingredient("oil", 3, "tablespoons", "just enough to come up to about 1/3 to 1/2 of the chicken you are putting in it")
                    }, new List<string>{ "small sauce pan", "tongs or fork"},null),
                new RecipeStep("if you have tin foil lay that out on the baking sheet to make clean up easier. put pam or another non stick spray on the baking sheet and arrange the chicken on the sheet to be evenly spread out. " +
                    "place in the oven and let cook for 18 min",null,
                    new List<string>{"pam/non-stick spray", "baking sheet" }, new List<string>{"tin foil" }, true, 18),
                new RecipeStep("while the chicken is cooking clean up the mess by throwing away excess breading and washing the bowls, cutting board and utensils",null, null, null),
                new RecipeStep("once the chicken is done take it out and cut the thickes piece in half to ensure that it is fully cooked and there is no pink in the center. if there is put it back in for a few more minutes and check again",null, null, null),

            }),
            new Recipe("Baked Chicken 2","a simple baked chicken recipy", new List<RecipeStep>
            {
                new RecipeStep("preheat oven to 400 degrees",null, new List<string>{"convention oven"}, null),
                new RecipeStep("Wash you hands with hot water and soap",null, null, null),
                new RecipeStep("add the seasonings to your cutting board and then take your chicken breasts and slice them down the long way and then take to two halfs and do it again",new List<Ingredient>
                {
                    new Ingredient("paprika", 3, "tablespoon","amount will vary based on how much spice you want"),
                    new Ingredient("Garlic Salt", 1, "tablespoon","none"),
                    new Ingredient("Skinless boneless chicken breast", 2, "tablespoon","none")

                }
                , new List<string>{"cutting board", "Sharp Knife(preferably straigt edge)" }, null),
                new RecipeStep("fill one of the bowls with flower, paperika, garlic powder, and pepper. fill another with 2 eggs wisked lightly and the final bowl with your panko",new List<Ingredient>
                {
                    new Ingredient("flower",1,"cup", "may need a little more"),
                    new Ingredient("paperika",1,"tablespoon", "none"),
                    new Ingredient("galric powder",1,"tablespoon", "none"),
                    new Ingredient("eggs",2,"", "none"),
                    new Ingredient("Panko",2,"cups", "none")
                }, new List<string>{ "three bowls", "wisk/fork"},null),
                new RecipeStep("toss the chicken in the flower, then the egg, then the panko and place to the side",null, null, new List<string>{"tongs"}),
                new RecipeStep("warm up some oil on the stove you can test the heat by taking a little of the egg/breading and seeing if it sizzles when you put it in. " +
                    "you will place the breaded chicken in the oil using the tongs or fork for a few seconds on each side just to brown it and add a crispness",new List<Ingredient>
                    {
                        new Ingredient("oil", 3, "tablespoons", "just enough to come up to about 1/3 to 1/2 of the chicken you are putting in it")
                    }, new List<string>{ "small sauce pan", "tongs or fork"},null),
                new RecipeStep("if you have tin foil lay that out on the baking sheet to make clean up easier. put pam or another non stick spray on the baking sheet and arrange the chicken on the sheet to be evenly spread out. " +
                    "place in the oven and let cook for 18 min",null,
                    new List<string>{"pam/non-stick spray", "baking sheet" }, new List<string>{"tin foil" }, true, 18),
                new RecipeStep("while the chicken is cooking clean up the mess by throwing away excess breading and washing the bowls, cutting board and utensils",null, null, null),
                new RecipeStep("once the chicken is done take it out and cut the thickes piece in half to ensure that it is fully cooked and there is no pink in the center. if there is put it back in for a few more minutes and check again",null, null, null),

            })
        };
        private static Recipe recipe;
        private static RecipeStep recipeStep;

        public IActionResult Recipes()
        {
            return View(recipes);
        }

        //public IActionResult RecipeDetails(Recipe r)
        //{
        //    return View(r);
        //}

        public IActionResult RecipeDetails(int recipeId)
        {
            Recipe r = recipes.Where(r => r.Id == recipeId).FirstOrDefault();
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
                recipes.Add(recipeTemp);
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