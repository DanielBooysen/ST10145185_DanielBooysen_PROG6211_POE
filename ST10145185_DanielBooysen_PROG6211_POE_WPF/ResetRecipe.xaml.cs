﻿using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ResetRecipe.xaml
    /// </summary>
    public partial class ResetRecipe : Window
    {
        List<Recipe> Recipes = new List<Recipe>();
        List<Scaling> Scalings = new List<Scaling>();
        List<string> recipeNames = new List<string>();

        string searchOption;
        public ResetRecipe(List<Recipe> recipes, List<Scaling> scalings)
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
                ScalingRecipeNames _newRecipeName = new ScalingRecipeNames()
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
                    for (int j = 0; j < Scalings.Count; j++)
                    {
                        if (Scalings[j].Index == i)
                        {
                            foreach (var ingr in Recipes[i].Ingredients)
                            {
                                ingr.ingrQuantity = ingr.ingrQuantity * Math.Pow(Scalings[j].ScaleValue, -1);
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Recipe reset successfully!");
            MainWindow mainWindow = new MainWindow(Recipes, Scalings);
            mainWindow.Show();
            Close();
        }
    }

    public class ScalingRecipeNames
    {
        public string? RecipeNames { get; set; }
    }
}
