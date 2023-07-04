using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ST10145185_DanielBooysen_PROG6211_POE;

namespace ST10145185_DanielBooysen_PROG6211_POE_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Recipe> Recipes = new List<Recipe>();
        List<Scaling> Scalings = new List<Scaling>(); 
        public MainWindow(string Recipename, List<Ingredients> Ingr, List<Steps> steps, List<Recipe> recipes)
        {
            InitializeComponent();
            Recipes.AddRange(recipes);

            if(Recipename is null)
            {

            }
            else
            {
                Recipe _recipe = new Recipe(Recipename, steps, Ingr);
                Recipes.Add(_recipe);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            Recipes.AddRange(recipes);
        }

        public MainWindow(List<Recipe> recipes, List<Scaling> scalings)
        {
            InitializeComponent();
            Recipes.AddRange(recipes);
            Scalings.AddRange(scalings);
        }

        private void enterRecipe(object sender, RoutedEventArgs e)
        {
            EnterRecipe enterRecipe = new EnterRecipe(Recipes);
            enterRecipe.Show();
            Close();
        }

        private void displayRecipe(object sender, RoutedEventArgs e)
        {
            DisplayRecipe displayRecipe = new DisplayRecipe(Recipes);
            displayRecipe.Show();
            Close();
        }

        private void scaleRecipe(object sender, RoutedEventArgs e)
        {
            ScaleRecipe scaleRecipe = new ScaleRecipe(Recipes);
            scaleRecipe.Show();
            Close();
        }

        private void resetRecipe(object sender, RoutedEventArgs e)
        {
            ResetRecipe resetRecipe = new ResetRecipe(Recipes, Scalings);
            resetRecipe.Show();
            Close();
        }

        private void deleteRecipe(object sender, RoutedEventArgs e)
        {
            DeleteRecipe deleteRecipe = new DeleteRecipe(Recipes, Scalings);
            deleteRecipe.Show();
            Close();
        }

        private void closeRecipeBook(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void createMenu(object sender, RoutedEventArgs e)
        {
            CreateMenu createMenu = new CreateMenu(Recipes, Scalings);
            createMenu.Show();
            Close();
        }
    }
}
