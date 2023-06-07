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

        //List variables used to store values until they are stored in the main list
        static List<string> IFoodGroup = new List<string>();
        static List<double> TempQuantity = new List<double>();

        //Declaring delegate
        delegate int CheckTotalCalories(int num);

        //Messages to print out in where needed
        static string Ast = "******************************";
        static string invInput = "Error: invalid input";
        static string prompt = "Please enter an operation -->";
        public static void Main(string[] args)
        {
            Menu();
        }

        //Menu method to display the menu to the user 
        public static void Menu()
        {
            //Variables used to store what is printed to the menu
            string WelcomeMsg = "Welcome to your recipe book!";
            string option1 = "1 - Enter recipe";
            string option2 = "2 - Display recipe";
            string option3 = "3 - Scale recipe";
            string option4 = "4 - Reset recipe";
            string option5 = "5 - Delete recipe";
            string option6 = "6 - Close recipe book";
            
            Console.ForegroundColor = ConsoleColor.Blue;

            //Print out the menu, center alligned
            Console.WriteLine();
            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + Ast.Length / 2) + "}", Ast));
            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + WelcomeMsg.Length / 2) + "}", WelcomeMsg));
            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + Ast.Length / 2) + "}", Ast));
            Console.ResetColor();
            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + option1.Length / 2) + "}", option1));
            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + option2.Length / 2) + "}", option2));
            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + option3.Length / 2) + "}", option3));
            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + option4.Length / 2) + "}", option4));
            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + option5.Length / 2) + "}", option5));
            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + option6.Length / 2) + "}", option6));
            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + prompt.Length / 2) + "}", prompt));

            //Try catch to ensure the user does not input an invalid value
            try
            {
                int Option = Convert.ToInt32(Console.ReadLine());

                //Switch to check user input and run appropriate method
                switch (Option)
                {
                    case 1:
                        Console.Clear();
                        EnterRecipe();
                        break;
                    case 2:
                        Console.Clear();
                        DisplayRecipe();
                        break;
                    case 3:
                        Console.Clear();
                        ScaleRecipe();
                        break;
                    case 4:
                        Console.Clear();
                        ResetRecipe();
                        break;
                    case 5:
                        Console.Clear();
                        DeleteRecipe();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + invInput.Length / 2) + "}", invInput));
                        Menu();
                        break;
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + invInput.Length / 2) + "}", invInput));
                Menu();

            }

            Console.Clear();
        }
        //Method to delete a recipe
        private static void DeleteRecipe()
        {
            int option;

            //Loops through all the recipe names and displays them to the user for them to choose from
            for (int i = 0; i < Recipes.Count; i++)
            {
                Console.WriteLine(String.Format("{i + 1, " + (Console.WindowWidth / 2 + Recipes[i].RecipeName.Length / 2) + ", 0", Recipes[i].RecipeName));
            }

            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + prompt.Length / 2) + "}", prompt));

            //Try catch to ensure the user does not input an invalid value
            try
            {
                //Removes the recipe specified by the user
                option = int.Parse(Console.ReadLine());
                option = option - 1;
                Console.Clear();

                Recipes.RemoveAt(option);

                Console.Clear();
                Menu();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + invInput.Length / 2) + "}", invInput));
                DeleteRecipe();
            }            
        }
        //Method to reset a recipe that has been scaled
        private static void ResetRecipe()
        {
            int option;
            string ResetMsg = "Recipe reset succesfully!";

            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + prompt.Length / 2) + "}", prompt));

            //Loops through all the recipe names and displays them to the user for them to choose from
            for (int i = 0; i < Recipes.Count; i++)
            {
                Console.WriteLine(String.Format("{i + 1, " + (Console.WindowWidth / 2 + Recipes[i].RecipeName.Length / 2) + ", 0", Recipes[i].RecipeName));
            }

            //Try catch to ensure the user does not input an invalid value
            try
            {
                option = int.Parse(Console.ReadLine());
                option = option - 1;
                Console.Clear();

                //Loop to assign the quantity value to a temporary variable so it can be restored
                for (int i = 0; i < Recipes[option].IQuantity.Count; i++)
                {
                    Recipes[option].IQuantity[i] = TempQuantity[i];
                }

                Console.WriteLine(String.Format("{i + 1, " + (Console.WindowWidth / 2 + ResetMsg.Length / 2) + ", 0", ResetMsg));
                Console.ReadKey();

                Console.Clear();
                Menu();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + invInput.Length / 2) + "}", invInput));
                ResetRecipe();
            }
        }
        //Method to scale the recipe
        private static void ScaleRecipe()
        {
            int option;
            int scaleOption;

            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + prompt.Length / 2) + "}", prompt));

            //Loop to diplay the recipe names for the user to choose from
            for (int i = 0; i < Recipes.Count; i++)
            {
                Console.WriteLine(String.Format("{i + 1, " + (Console.WindowWidth / 2 + Recipes[i].RecipeName.Length / 2) + ", 0", Recipes[i].RecipeName));
            }

            //Try catch to ensure the user does not input an invalid value
            try
            {
                option = int.Parse(Console.ReadLine());
                option = option - 1;
                Console.Clear();

                Console.WriteLine("Enter a scale option -->");
                Console.WriteLine("1: 0.5");
                Console.WriteLine("2: 2");
                Console.WriteLine("3: 3");
                scaleOption = int.Parse(Console.ReadLine());

                //Loop to scale each ingredient to the relevant amount
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
                        default:
                            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + invInput.Length / 2) + "}", invInput));
                            ScaleRecipe();
                            break;
                    }
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + invInput.Length / 2) + "}", invInput));
                ScaleRecipe();
            }
        }
        //Method to display recipe
        public static void DisplayRecipe()
        {
            int option;
            int Position = 0;
            string IngrMsg = "Ingredients: ";
            string StepsMsg = "Steps: ";

            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + prompt.Length / 2) + "}", prompt));

            //Loop to print out recipe name for the user to choose from
            foreach(var recipe in  Recipes) 
            {
                    Console.WriteLine($"{Position + 1} {recipe.RecipeName}");
                    Position++;
            }

            //Try catch to ensure the user does not input an invalid value
            try
            {
                option = int.Parse(Console.ReadLine());
                option = option - 1;
                Console.Clear();

                Console.WriteLine(Ast);
                Console.WriteLine(Recipes[option].RecipeName);
                Console.WriteLine(Ast);
                Console.WriteLine();
                Console.WriteLine(IngrMsg);
                Console.WriteLine();

                //Loop to print out relevant recipe
                for (int i = 0; i < Recipes[option].IName.Count; i++)
                {
                    Console.WriteLine(Recipes[option].IName[i]);
                    Console.WriteLine(Recipes[option].IQuantity[i]);
                    Console.WriteLine(Recipes[option].IFoodGroup[i]);
                    Console.WriteLine($"Calories: {Recipes[option].ICalories[i]}");
                    Console.WriteLine();
                }

                Console.WriteLine(StepsMsg);
                Console.WriteLine();

                //Loop to rpint out the steps in the relevant recipe
                for (int i = 0; i < Recipes[option].StepDesc.Count; i++)
                {
                    Console.WriteLine(Recipes[option].StepDesc[i]);
                    Console.WriteLine();
                }
                Console.WriteLine($"Total calories: {Recipes[option].TotalCalories}");
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + invInput.Length / 2) + "}", invInput));
                DisplayRecipe();
            }

            Console.ReadKey();
            Console.Clear();
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

            //Try catch to ensure the user does not input an invalid value
            try
            {
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

                //Loop to take uesr input for each ingredient
                for (int i = 0; i < nrIngr; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Ingredient number {i + 1}");
                    Console.ResetColor();
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

                    //Create delegate
                    CheckTotalCalories CTC = new CheckTotalCalories(CheckCal);

                    //Runs delegate if the condition is met
                    if (CTC(TotalCalories) == -1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Warning!");
                        Console.WriteLine("The total calories exceed 300!");
                        Console.ResetColor();
                        Console.WriteLine("Do you wish to continue? Y = Yes N = No");
                        option = Console.ReadLine();

                        switch (option)
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

                //Loop to ask the user for the steps in the recipe
                for (int i = 0; i < nrSteps; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Enter step number {i + 1}");
                    Console.ResetColor();
                    StepDescr.Add(Console.ReadLine());
                    Console.WriteLine();
                    Console.Clear();
                }

                Recipe recipe = new Recipe(RecipeName, IName, IQuantity, IUMeasure, ICalories, TotalCalories, IFoodGroup, StepDescr);

                Recipes.Add(recipe);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + invInput.Length / 2) + "}", invInput));
                IName.Clear();
                IQuantity.Clear();
                IUMeasure.Clear();
                ICalories.Clear();
                TotalCalories = 0;
                StepDescr.Clear();
                IFoodGroup.Clear();
                EnterRecipe();
            }

            Menu();
        }

        //Delegate method to check if the calories exceed 300
        public static int CheckCal(int num)
        {
            if (num > 300)
            {
                num = -1;
            }
            else
            {
                num = -2;
            }

            return num;
        }
        //Method to determine the food group that the ingredient belongs too
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
                    Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + invInput.Length / 2) + "}", invInput));
                    EnterFoodGroup();
                    break;
            }
        }
    }
}
