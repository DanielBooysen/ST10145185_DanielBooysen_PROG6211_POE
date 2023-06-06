using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ST10145185_DanielBooysen_PROG6211_POE
{
    internal class MainProgram
    {
        static List<Recipe> Recipes = new List<Recipe>();
        static List<string> IFoodGroup = new List<string>();
        static List<double> TempQuantity = new List<double>();
        delegate int CheckTotalCalories(int num);
        public static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            int Option;

            //Print out the menu 
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Welcome to your recipe book!");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1 - Enter recipe");
            Console.WriteLine("2 - Display recipe");
            Console.WriteLine("3 - Scale recipe");
            Console.WriteLine("4 - Reset recipe");
            Console.WriteLine("5 - Delete recipe");
            Console.WriteLine("6 - Close recipe book");
            Console.WriteLine("Please enter an operation -->");
            Option = int.Parse(Console.ReadLine());
            Console.Clear();

            //Switch case statement to check user selection and run appropriate method
            switch (Option)
            {
                case 1:
                    EnterRecipe();
                    break;
                case 2:
                    DisplayRecipe();
                    break;
                case 3:
                    ScaleRecipe();
                    break;
                case 4:
                    ResetRecipe();
                    break;
                case 5:
                    DeleteRecipe();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    Menu();
                    break;
            }
        }

        private static void DeleteRecipe()
        {
            throw new NotImplementedException();
        }

        private static void ResetRecipe()
        {
            throw new NotImplementedException();
        }

        private static void ScaleRecipe()
        {
            int option;
            int scaleOption;

            Console.WriteLine("Enter an option to scale recipe -->");

            for (int i = 0; i < Recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Recipes[i].RecipeName}");
            }
            option = int.Parse(Console.ReadLine());
            option = option - 1;
            Console.Clear();

            Console.WriteLine("Enter a scale option -->");
            Console.WriteLine("1: 0.5");
            Console.WriteLine("2: 2");
            Console.WriteLine("3: 3");
            scaleOption = int.Parse(Console.ReadLine());

            for (int i = 0; i < Recipes[option].IQuantity.Count; i++)
            {
                TempQuantity.Add(Recipes[option].IQuantity[i]);

                switch (scaleOption)
                {
                    case 1:
                        Recipes[option].IQuantity[i] = Recipes[option].IQuantity[i] * 0.5;
                        break;
                    case 2:
                        Recipes[option].IQuantity[i] = Recipes[option].IQuantity[i] * 2;
                        break;
                    case 3:
                        Recipes[option].IQuantity[i] = Recipes[option].IQuantity[i] * 3;
                        break;
                }
            }

            Console.Clear();
            Menu();
        }

        public static void DisplayRecipe()
        {
            int option;

            Console.WriteLine("Enter a display option -->");

            for (int i = 0; i < Recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Recipes[i].RecipeName}");
            }
            option = int.Parse(Console.ReadLine());
            option = option - 1;
            Console.Clear();

            Console.WriteLine("***********************");
            Console.WriteLine(Recipes[option].RecipeName);
            Console.WriteLine("***********************");
            Console.WriteLine();
            Console.WriteLine("Ingredients: ");
            Console.WriteLine();

            for (int i = 0; i < Recipes[option].IName.Count; i++)
            {
                Console.WriteLine(Recipes[option].IName[i]);
                Console.WriteLine($"{Recipes[option].IQuantity[i]} {Recipes[option].IUMeasure[i]}");
                Console.WriteLine(Recipes[option].IFoodGroup[i]);
                Console.WriteLine($"{Recipes[option].ICalories[i]} Calories");
                Console.WriteLine();
            }

            Console.WriteLine("Steps: ");
            Console.WriteLine();

            for (int i = 0; i < Recipes[option].StepDesc.Count; i++)
            {
                Console.WriteLine($"Step {i + 1}");
                Console.WriteLine(Recipes[option].StepDesc[i]);
                Console.WriteLine();
            }
            Console.WriteLine($"Total calories: {Recipes[option].TotalCalories}");

            Console.ReadKey();
            Menu();
        }

        public static void EnterRecipe()
        {
            string RecipeName;
            List<string> IName = new List<string>();
            List<string> IUMeasure = new List<string>();
            List<double> IQuantity = new List<double>();
            List<int> ICalories = new List<int>();
            int TotalCalories = 0;
            List<string> StepDescr = new List<string>();

            int nrIngr;
            int nrSteps;
            int temp;
            string option;

            Console.WriteLine("Enter the recipe name -->");
            RecipeName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter the number of ingredients in the recipe -->");
            nrIngr = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Enter the number of steps in the recipe -->");
            nrSteps = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Clear();

            for (int i = 0; i < nrIngr; i++)
            {
                Console.WriteLine($"Ingredient number {i + 1}");
                Console.WriteLine("Enter the ingredient name -->");
                IName.Add(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Enter the unit of measurement -->");
                IUMeasure.Add(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Enter the quantity -->");
                IQuantity.Add(int.Parse(Console.ReadLine()));
                Console.WriteLine();

                Console.WriteLine("Enter the number of calories in this ingredient -->");
                temp = int.Parse(Console.ReadLine());
                ICalories.Add(temp);
                TotalCalories = TotalCalories + temp;
                Console.WriteLine();

                CheckTotalCalories CTC = new CheckTotalCalories(CheckCal);

                if (CTC(TotalCalories) == 1)
                {
                    Console.WriteLine("Warning!");
                    Console.WriteLine("The total calories exceed 300!");
                    Console.WriteLine("Do you wish to continue? Y = Yes N = No");
                    option = Console.ReadLine();

                    switch(option)
                    {
                        case "Y":
                            break;
                        case "N":
                            IName.Clear();
                            IQuantity.Clear();
                            IUMeasure.Clear();
                            ICalories.Clear();
                            TotalCalories = 0;
                            StepDescr.Clear();
                            IFoodGroup.Clear();
                            Menu();
                            break;
                    }
                }

                EnterFoodGroup();
                Console.WriteLine();
                Console.Clear();
            }

            for (int i = 0; i < nrSteps; i++)
            {
                Console.WriteLine($"Enter step number {i + 1}");
                StepDescr.Add(Console.ReadLine());
                Console.WriteLine();
                Console.Clear();
            }

            Recipe recipe = new Recipe(RecipeName, IName, IQuantity, IUMeasure, ICalories, TotalCalories, IFoodGroup, StepDescr);

            Recipes.Add(recipe);

            Menu();
        }

        public static int CheckCal(int num)
        {
            if (num > 300)
            {
                num = 1;
            }
            else
            {
                num = 0;
            }

            return num;
        }

        public static void EnterFoodGroup()
        {
            int option;

            Console.WriteLine("Choose a food group that the ingredient belongs too -->");
            Console.WriteLine("1: Fruit or vegetable");
            Console.WriteLine("2: Starch");
            Console.WriteLine("3: Dairy");
            Console.WriteLine("4: Protein");
            Console.WriteLine("5: Fat");
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    IFoodGroup.Add("Fruit or vegetable");
                    break;
                case 2:
                    IFoodGroup.Add("Starch");
                    break;
                case 3:
                    IFoodGroup.Add("Dairy");
                    break;
                case 4:
                    IFoodGroup.Add("Protein");
                    break;
                case 5:
                    IFoodGroup.Add("Fat");
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    EnterFoodGroup();
                    break;
            }
        }
    }
}
