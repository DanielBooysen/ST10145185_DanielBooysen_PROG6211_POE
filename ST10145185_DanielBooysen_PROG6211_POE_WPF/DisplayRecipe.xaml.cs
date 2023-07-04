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
    /// Interaction logic for DisplayRecipe.xaml
    /// </summary>
    public partial class DisplayRecipe : Window
    {
        string searchOption;
        List<Recipe> Recipes = new List<Recipe>();
        List<string> recipeNames = new List<string>();
        public DisplayRecipe(List<Recipe> recipes)
        {
            InitializeComponent();
            Recipes.AddRange(recipes);

            foreach(var recipeName in Recipes)
            {
                recipeNames.Add(recipeName.RecipeName);
            }

            for(int i = 0; i < recipeNames.Count; i++)
            {
                RecipeNamesDisplay _newRecipeName = new RecipeNamesDisplay()
                {
                    RecipeNames = recipeNames[i]
                };

                ViewRecipeNames.Items.Add(_newRecipeName);
            }
        }

        private void RecipeNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchOption = RecipeNameSearch.Text;
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < Recipes.Count; i++)
            {
                if (Recipes[i].RecipeName == searchOption)
                {
                    DisplayRecipeDatails displayRecipeDatails = new DisplayRecipeDatails(Recipes[i], Recipes);
                    displayRecipeDatails.Show();
                    Close();
                }
            }
        }
    }

    public class RecipeNamesDisplay
    {
        public string RecipeNames { get; set; }
    }
}
