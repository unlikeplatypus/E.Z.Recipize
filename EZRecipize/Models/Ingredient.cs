using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EZRecipize.Models
{
    public class Ingredient
    {
        public Ingredient(string name, float amount, string unit, string specialInstructions)
        {
            Name = name;
            Amount = amount;
            Unit = unit;
            SpecialInstructions = specialInstructions;
        }

        public Ingredient() { }

        //private long key;
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "you need to put what the ingredient is called")]
        public string Name { get; set; }
        [Required(ErrorMessage = "you need to put what amount of the ingredient is needed")]
        public float Amount { get; set; }
        [Required(ErrorMessage ="you need to put what unit of measurement is being used")]
        public string Unit { get; set; }
        [UIHint("if there is a size of vegtable or another factor into how much is used")]
        public string SpecialInstructions { get; set; }

        public int RecipeStepid { get; set; }

    }
}
