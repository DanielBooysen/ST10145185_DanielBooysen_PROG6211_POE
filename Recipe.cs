using ST10145185_DanielBooysen_PROG6211_POE_WPF;
using System.Collections.Generic;
using ST10145185_DanielBooysen_PROG6211_POE;

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
