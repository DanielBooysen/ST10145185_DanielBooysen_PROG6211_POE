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
    /// Interaction logic for ScaleOption.xaml
    /// </summary>
    public partial class ScaleOption : Window
    {
        List<Recipe> Recipes = new List<Recipe>();
        List<Scaling> Scalings = new List<Scaling>();

        int IndexToScale;
        double scaleOption;
        public ScaleOption(List<Recipe> recipes, List<Scaling> scalings, int i)
        {
            InitializeComponent();
            Recipes.AddRange(recipes);
            Scalings.AddRange(scalings);
            IndexToScale = i;
        }

        private void HalfScaling_Checked(object sender, RoutedEventArgs e)
        {
            scaleOption = 0.5;
        }

        private void DoubleScaling_Checked(object sender, RoutedEventArgs e)
        {
            scaleOption = 2;
        }

        private void TripleScaling_Checked(object sender, RoutedEventArgs e)
        {
            scaleOption = 3;
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            Scaling scaling = new Scaling(IndexToScale, scaleOption);
            Scalings.Add(scaling);
            Recipe scaleRecipe = new Recipe(Recipes[IndexToScale].RecipeName, Recipes[IndexToScale].StepDesc, Recipes[IndexToScale].Ingredients);

            foreach(var ingr in scaleRecipe.Ingredients)
            {
                ingr.ingrQuantity = ingr.ingrQuantity * scaleOption;
            }

            MessageBox.Show("Recipe scaled succesfully!");

            MainWindow mainWindow = new MainWindow(Recipes, Scalings);
            mainWindow.Show();
            Close();
        }
    }
}
