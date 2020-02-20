using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EZRecipize.Models
{
    public class Recipe
    {
        [Required(ErrorMessage = "the recipe needs to have a name")]
        public string RecipeName { get; set; }
        [Required(ErrorMessage = "the recipe needs to have a short description of what it is")]
        public string RecipeDescription { get; set; }
        
        public List<RecipeStep> Steps { get; set; }

    }
}
