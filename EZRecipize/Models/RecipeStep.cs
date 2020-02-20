using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EZRecipize.Models
{
    public class RecipeStep
    {
        [Required(ErrorMessage ="you need to put the instructions in for this step")]
        public string Instructions { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> RequiredCookware { get; set; }
        public List<string> SuggestedCookware { get; set; }
        public bool IsTimer { get; set; } = false;
        public float Timer { get; set; } = 0;
    }
}
