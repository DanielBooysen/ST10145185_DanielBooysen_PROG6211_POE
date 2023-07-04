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
    /// Interaction logic for DisplayMenu.xaml
    /// </summary>
    public partial class DisplayMenu : Window
    {
        List<Recipe> Recipes = new List<Recipe>();
        List<Scaling> Scalings = new List<Scaling>();
        List<Recipe> Menu = new List<Recipe>();
        public DisplayMenu(List<Recipe> recipes, List<Scaling> scalings, List<Recipe> menu)
        {
            InitializeComponent();
            Recipes.AddRange(recipes);
            Scalings.AddRange(scalings);
            Menu.AddRange(menu);

            for (int i = 0; i < Menu.Count; i++)
            {
                RecipeNamesDisplay _newRecipeName = new RecipeNamesDisplay()
                {
                    RecipeNames = Menu[i].RecipeName,
                    NrIngr = Recipes[i].Ingredients.Count,
                    NrSteps = Recipes[i].StepDesc.Count
                };

                ViewRecipeNames.Items.Add(_newRecipeName);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(Recipes, Scalings);
            mainWindow.Show();
            Close();
        }
    }

    public class DisplayMenuContents
    {
        public string RecipeNames { get; set; }
        public int NrIngr { get; set; }
        public int NrSteps { get; set; }
    }
}
