using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ST10145185_DanielBooysen_PROG6211_POE;

namespace ST10145185_DanielBooysen_PROG6211_POE_WPF
{
    /// <summary>
    /// Interaction logic for EnterIngrDetails.xaml
    /// </summary>

    public partial class EnterIngrDetails : Window
    {
        string IngrName;
        string IngrUMeasure;
        int IngrQuantity;
        int IngrCalories;
        string IngrFoodGroup;

        List<Ingredients> IngredientsList = new List<Ingredients>();
        List<Recipe> Recipes = new List<Recipe>();

        string recipeName;
        int NrIngr;
        int NrSteps;

        int num = 0;

        public EnterIngrDetails(string RecipeName, int nrIngr, int nrSteps, List<Recipe> recipes)
        {
            InitializeComponent();
            recipeName = RecipeName;
            NrIngr = nrIngr;
            NrSteps = nrSteps;
            Recipes.AddRange(recipes);
        }

        public EnterIngrDetails(string RecipeName, int nrIngr, int nrSteps, List<Ingredients> ingredients, int number, List<Recipe> recipes)
        {
            InitializeComponent();
            recipeName = RecipeName;
            NrIngr = nrIngr;
            NrSteps = nrSteps;
            IngredientsList.AddRange(ingredients);
            num = number;
            Recipes.AddRange(recipes);
        }

        private void IngrNameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            IngrName = IngrNameInput.Text;
        }

        private void IngrUMeasureInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            IngrUMeasure = IngrUMeasureInput.Text;
        }

        private void IngrQuantityInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            IngrQuantity = Convert.ToInt32(IngrQuantityInput.Text);
        }

        private void IngrCaloriesInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            IngrCalories = Convert.ToInt32(IngrCaloriesInput.Text);
        }

        private void IngrFoodGroupInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            IngrFoodGroup = IngrFoodGroupInput.Text;
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            
            Ingredients ingredients = new Ingredients(IngrName, IngrUMeasure, IngrQuantity, IngrCalories, IngrFoodGroup);
            IngredientsList.Add(ingredients);

            if (num < NrIngr - 1)
            {
                num++;
                EnterIngrDetails enterIngrDetails = new EnterIngrDetails(recipeName, NrIngr, NrSteps, IngredientsList, num, Recipes);
                enterIngrDetails.Show();
                Close();
            }
            else
            {
                EnterStepDetails enterStepDetails = new EnterStepDetails(NrSteps, recipeName, IngredientsList, Recipes);
                enterStepDetails.Show();
                Close();
            }
        }
    }
}
