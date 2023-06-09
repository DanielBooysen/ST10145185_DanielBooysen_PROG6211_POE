﻿using System;
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
    /// Interaction logic for DeleteRecipe.xaml
    /// </summary>
    public partial class DeleteRecipe : Window
    {
        List<Recipe> Recipes = new List<Recipe>();
        List<Scaling> Scalings = new List<Scaling>();

        string searchOption;
        public DeleteRecipe(List<Recipe> recipes, List<Scaling> scalings)
        {
            InitializeComponent();
            Recipes.AddRange(recipes);
            Scalings.AddRange(scalings);
        }

        private void RecipeNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchOption = RecipeNameSearch.Text;
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Recipes.Count; i++)
            {
                if (Recipes[i].RecipeName.Equals(searchOption))
                {
                    Recipes.RemoveAt(i);
                }
            }

            MainWindow mainWindow = new MainWindow(Recipes, Scalings);
            mainWindow.Show();
            Close();
        }
    }

    public class DeleteRecipeNames
    {
        public string RecipeNames { get; set; }
    }
}
