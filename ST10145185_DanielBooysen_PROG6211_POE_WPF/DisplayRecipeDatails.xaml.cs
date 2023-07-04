using ST10145185_DanielBooysen_PROG6211_POE;
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

namespace ST10145185_DanielBooysen_PROG6211_POE_WPF
{
    /// <summary>
    /// Interaction logic for DisplayRecipeDatails.xaml
    /// </summary>
    public partial class DisplayRecipeDatails : Window
    {
        static Recipe? DisplayRecipe;
        List<Recipe> Recipes = new List<Recipe>();

        int StepNr = 0;
        public DisplayRecipeDatails(Recipe recipe, List<Recipe> RecipeList)
        {
            InitializeComponent();
            DisplayRecipe = new Recipe(recipe.RecipeName, recipe.StepDesc, recipe.Ingredients);
            RecipeNameSet.Text = DisplayRecipe.RecipeName;

            Recipes.AddRange(RecipeList);

            List<Ingredients> Ingr = new List<Ingredients>();
            foreach(var ingr in DisplayRecipe.Ingredients)
            {
                Ingr.Add(ingr);
            }

            List<Steps> steps = new List<Steps>();
            foreach(var st in DisplayRecipe.StepDesc)
            {
                steps.Add(st);
            }

            for(int i = 0; i < Ingr.Count; i++)
            {
                IngredientsDisplay _newIngr = new IngredientsDisplay()
                {
                    Name = Ingr[i].ingrName,
                    UMeasure = Ingr[i].ingrUMeasure,
                    Quantity = Ingr[i].ingrQuantity,
                    Calories = Ingr[i].ingrCalories,
                    FoodGroup = Ingr[i].ingrFoodGroup
                };

                IngredientsView.Items.Add(_newIngr);
            }

            for(int i = 0; i < steps.Count; i++)
            {
                StepsDisplay _newStep = new StepsDisplay()
                {
                    StepDescr = $"{StepNr}: {steps[i].Description}"
                };

                StepNr++;
                StepsView.Items.Add(_newStep);
            }
        }

        private void ReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(Recipes);
            mainWindow.Show();
            Close();
        }
    }

    class IngredientsDisplay
    {
        public string? Name { get; set; }
        public string? UMeasure { get; set; }
        public double Quantity { get; set; }
        public int Calories { get; set; }
        public string? FoodGroup { get; set; }
    }

    class StepsDisplay
    {
        public string? StepDescr { get; set; }
    }
}
