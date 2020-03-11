using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZRecipize.Models
{
    public class RecipeStep
    {

        public int id { get; set; }

        [Required(ErrorMessage ="you need to put the instructions in for this step")]
        public string Instructions { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        [NotMapped]
        public List<string> RequiredCookware { get; set; }

        public string TempRequiredCookware { get; set; }
        [NotMapped]
        public List<string> SuggestedCookware { get; set; }

        public string TempSuggestedCookware { get; set; }

        [Required(ErrorMessage = "you must determin weather or not there is a timer for this step")]
        public bool IsTimer { get; set; } = false;

        public int Timer { get; set; } = 0;
        public string TimerName { get; set; } = "";
        public int RecipeId { get; }

        public RecipeStep(string instructions, List<Ingredient> ingredients, List<string> requiredCookware, List<string> suggestedCookware, bool isTimer = false, string tName = "", int timer = 0)
        {
            Instructions = instructions;
            Ingredients = ingredients;
            RequiredCookware = requiredCookware;
            SuggestedCookware = suggestedCookware;
            IsTimer = isTimer;
            Timer = timer;
            TimerName = tName;
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
