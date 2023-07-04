using ST10145185_DanielBooysen_PROG6211_POE_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10145185_DanielBooysen_PROG6211_POE
{
    public class Recipe
    {
        public string RecipeName;
        public List<Steps> StepDesc = new List<Steps>();
        public List<Ingredients> Ingredients = new List<Ingredients>();

        public Recipe(string recipeName, List<Steps> stepDesc, List<Ingredients> Ingr)
        {
            RecipeName = recipeName;
            StepDesc.AddRange(stepDesc);
            Ingredients.AddRange(Ingr);
        }
    }
}
