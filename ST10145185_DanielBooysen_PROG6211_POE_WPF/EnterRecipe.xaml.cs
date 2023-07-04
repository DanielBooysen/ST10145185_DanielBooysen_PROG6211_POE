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
    /// Interaction logic for EnterRecipe.xaml
    /// </summary>
    public partial class EnterRecipe : Window
    {
        String RecipeName;
        List<Ingredients> Ingredients = new List<Ingredients>();
        int nrIngr;
        int nrSteps;

        List<Recipe> Recipes = new List<Recipe>();
        public EnterRecipe(List<Recipe> recipes)
        {
            InitializeComponent();
            Recipes.AddRange(recipes);
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            EnterIngrDetails enterIngrDetails = new EnterIngrDetails(RecipeName, nrIngr, nrSteps, Recipes);
            enterIngrDetails.Show();
            Close();
        }

        private void RecipeNameInput(object sender, TextChangedEventArgs e)
        {
            RecipeName = InputRecipeName.Text;
        }

        private void NumberIngrInput(object sender, TextChangedEventArgs e)
        {
            nrIngr = Convert.ToInt32(InputNumberIngr.Text);
        }

        private void NumberStepsInput(object sender, TextChangedEventArgs e)
        {
            nrSteps = Convert.ToInt32(InputNumberSteps.Text);
        }
    }
}
