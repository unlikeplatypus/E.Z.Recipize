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
        public string TempRequiredCookware { get; set; }
        public List<string> SuggestedCookware { get; set; }
        public string TempSuggestedCookware { get; set; }
        [Required(ErrorMessage = "you must determin weather or not there is a timer for this step")]
        public bool IsTimer { get; set; } = false;
        public float Timer { get; set; } = 0;

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

        public void SeperateListStrings()
        {

            SuggestedCookware = new List<string>();
            RequiredCookware = new List<string>();

            if(SuggestedCookware != null)
            {
                //string temp = SuggestedCookware.LastOrDefault();
                if(TempSuggestedCookware != null)
                {
                    foreach (string s in TempSuggestedCookware.Split(",").ToList())
                    {
                        SuggestedCookware.Add(s);
                    }
                }
            }
            if(RequiredCookware != null)
            {
                //string temp = RequiredCookware.LastOrDefault();
                if (TempRequiredCookware != null)
                {
                    foreach (string s in TempRequiredCookware.Split(",").ToList())
                    {
                        RequiredCookware.Add(s);
                    }
                }
            }

        }

    }
}
