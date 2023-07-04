using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10145185_DanielBooysen_PROG6211_POE_WPF
{
    public class Ingredients
    {
        string ingrName;
        string ingrUMeasure;
        int ingrQuantity;
        int ingrCalories;
        string ingrFoodGroup;

        public Ingredients(string IngrName, string IngrUMeasure, int IngrQuantity, int IngrCalories, string IngrFoodGroup)
        {
            ingrName = IngrName;
            ingrUMeasure = IngrUMeasure;
            ingrQuantity = IngrQuantity;
            ingrCalories = IngrCalories;
            ingrFoodGroup = IngrFoodGroup;
        }
    }
}
