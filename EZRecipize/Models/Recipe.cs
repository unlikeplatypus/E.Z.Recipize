using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZRecipize.Models
{
    public class Recipe
    {
        public static int Count = 0;

        public Recipe(string recipeName, string recipeDescription, List<RecipeStep> steps)
        {
            RecipeName = recipeName;
            RecipeDescription = recipeDescription;
            Steps = steps;
            //Id = Count++;
        }
        public Recipe() 
        {
            RecipeName = "";
            RecipeDescription = "";
            Steps = new List<RecipeStep>();
            //Id = Count++;
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "the recipe needs to have a name")]
        public string RecipeName { get; set; }

        [Required(ErrorMessage = "the recipe needs to have a short description of what it is")]
        public string RecipeDescription { get; set; }
        
        public List<RecipeStep> Steps { get; set; }

    }
}
