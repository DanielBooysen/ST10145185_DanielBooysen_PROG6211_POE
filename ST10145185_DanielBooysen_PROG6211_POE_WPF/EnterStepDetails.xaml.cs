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
    /// Interaction logic for EnterStepDetails.xaml
    /// </summary>
    public partial class EnterStepDetails : Window
    {
        List<Steps> StepsList = new List<Steps>();

        string Descr;
        int NrSteps;
        string RecipeName;
        int num = 0;

        List<Ingredients> IngredientsList = new List<Ingredients>();
        List<Recipe> Recipes = new List<Recipe>();
        public EnterStepDetails(int nrSteps, string recipeName, List<Ingredients> ingredients, List<Recipe> recipes)
        {
            InitializeComponent();
            NrSteps = nrSteps;
            RecipeName = recipeName;
            IngredientsList.AddRange(ingredients);
            Recipes.AddRange(recipes);
        }

        public EnterStepDetails(int nrSteps, string recipeName, List<Ingredients> ingredients, List<Steps> steps, int number, List<Recipe> recipes)
        {
            InitializeComponent();
            NrSteps = nrSteps;
            RecipeName = recipeName;
            IngredientsList.AddRange(ingredients);
            StepsList.AddRange(steps);
            num = number;
            Recipes.AddRange(recipes);
        }

        private void StepDescrInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Descr = StepDescrInput.Text;
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            Steps steps = new Steps(Descr);
            StepsList.Add(steps);

            if(num < NrSteps - 1)
            {
                num++;
                EnterStepDetails enterStepDetails = new EnterStepDetails(NrSteps, RecipeName, IngredientsList, StepsList, num, Recipes);
                enterStepDetails.Show();
                Close();
            }
            else
            {
                MainWindow mainWindow = new MainWindow(RecipeName, IngredientsList, StepsList, Recipes);
                mainWindow.Show();
                Close();
            }
        }
    }
}
