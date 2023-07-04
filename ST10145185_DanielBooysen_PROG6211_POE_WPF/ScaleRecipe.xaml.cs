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
    /// Interaction logic for ScaleRecipe.xaml
    /// </summary>
    public partial class ScaleRecipe : Window
    {
        List<Recipe> Recipes = new List<Recipe>();
        List<string> recipeNames = new List<string>();
        List<Scaling> scalings = new List<Scaling>();

        string searchOption;
        public ScaleRecipe(List<Recipe> recipes)
        {
            InitializeComponent();
            Recipes.AddRange(recipes);

            foreach(var recipeName in Recipes)
            {
                recipeNames.Add(recipeName.RecipeName);
            }

            for(int i = 0; i < recipeNames.Count; i++)
            {
                RecipeNamesDisplayScale _newRecipeName = new RecipeNamesDisplayScale()
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
            for (int i = 0; i < Recipes.Count; i++)
            {
                if (Recipes[i].RecipeName == searchOption)
                {
                    ScaleOption scaleOption = new ScaleOption(Recipes, scalings, i);
                    scaleOption.Show();
                    Close();
                }
            }
        }
    }

    public class RecipeNamesDisplayScale
    {
        public string RecipeNames { get; set; }
    }
}
