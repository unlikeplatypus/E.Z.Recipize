using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EZRecipize.Models
{
    public class RecipeStep
    {
        public RecipeStep(string instructions, List<Ingredient> ingredients, List<string> requiredCookware, List<string> suggestedCookware, bool isTimer = false, float timer = 0)
        {
            Instructions = instructions;
            Ingredients = ingredients;
            RequiredCookware = requiredCookware;
            SuggestedCookware = suggestedCookware;
            IsTimer = isTimer;
            Timer = timer;
        }

        public RecipeStep() { }

        [Required(ErrorMessage ="you need to put the instructions in for this step")]
        public string Instructions { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> RequiredCookware { get; set; }
        public List<string> SuggestedCookware { get; set; }
        [Required(ErrorMessage = "you must determin weather or not there is a timer for this step")]
        public bool IsTimer { get; set; } = false;
        public float Timer { get; set; } = 0;
    }
}
