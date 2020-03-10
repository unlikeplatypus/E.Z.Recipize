using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZRecipize.Models
{
    public class DisplayInfo
    {

        public RecipeStep step = new RecipeStep();
        public Dictionary<string, int> timers = new Dictionary<string, int>();

    }
}
