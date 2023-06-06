using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ST10145185_DanielBooysen_PROG6211_POE
{
    internal class Recipe
    {
        public string RecipeName;
        public List<string> IName = new List<string>();
        public List<double> IQuantity = new List<double>();
        public List<string> IUMeasure = new List<string>();
        public List<int> ICalories = new List<int>();
        public int TotalCalories;
        public List<string> IFoodGroup = new List<string>();
        public List<string> StepDesc = new List<string>();

        public Recipe(string recipeName, List<string> iName, List<double> iQuantity, List<string> iUMeasure, List<int> iCalories, int totalCalories, List<string> iFoodGroup, List<string> stepDesc)
        {
            RecipeName = recipeName;
            IName = iName;
            IQuantity = iQuantity;
            IUMeasure = iUMeasure;
            ICalories = iCalories;
            TotalCalories = totalCalories;
            IFoodGroup = iFoodGroup;
            StepDesc = stepDesc;
        }
    }
}
