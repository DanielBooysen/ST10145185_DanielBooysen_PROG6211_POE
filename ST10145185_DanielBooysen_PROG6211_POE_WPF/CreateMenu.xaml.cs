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
    /// Interaction logic for CreateMenu.xaml
    /// </summary>
    public partial class CreateMenu : Window
    {
        List<Recipe> Recipes = new List<Recipe>();
        List<string> FoodGroups = new List<string>();
        List<string> recipeNames = new List<string>();
        List<Recipe> Menu = new List<Recipe>();
        List<Scaling> Scalings = new List<Scaling>();

        string searchOption;
        public CreateMenu(List<Recipe> recipes, List<Scaling> scalings)
        {
            InitializeComponent();
            Recipes.AddRange(recipes);
            Scalings.AddRange(scalings);

            foreach (var recipeName in Recipes)
            {
                recipeNames.Add(recipeName.RecipeName);
            }

            for (int i = 0; i < recipeNames.Count; i++)
            {
                RecipeNamesDisplay _newRecipeName = new RecipeNamesDisplay()
                {
                    RecipeNames = recipeNames[i],
                    NrIngr = Recipes[i].Ingredients.Count,
                    NrSteps = Recipes[i].StepDesc.Count
                };

                ViewRecipeNames.Items.Add(_newRecipeName);
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Recipes.Count; i++)
            {
                if (Recipes[i].RecipeName == searchOption)
                {
                    Menu.Add(Recipes[i]);
                }
            }
        }

        private void RecipeNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchOption = RecipeNameSearch.Text;
        }

        private void viewMenu(object sender, RoutedEventArgs e)
        {
            DisplayMenu displayMenu = new DisplayMenu(Recipes, Scalings, Menu);
            displayMenu.Show();
            Close();
        }
    }

    public class RecipeNamesDisplayForMenu
    {
        public string? RecipeNames { get; set; }
        public int NrIngr { get; set; }
        public int NrSteps { get; set; }
    }
}
