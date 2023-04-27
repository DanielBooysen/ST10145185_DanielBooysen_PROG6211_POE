using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ST10145185_DanielBooysen_PROG6221_POE
{

    internal class Program
    {
        private static int nrIngr;
        private static string[] IName;
        private static int[] IQuantity;
        private static string[] IUMeasure;
        private static int nrSteps;
        private static string[] SDescr;
        private static int[] TempQuantity;
        private static string RecipeName;
        private static Boolean RecipeSaved = false;

        public static void Main(string[] args)
        {
            Menu();
        }

        //Menu method for the user to input an oppperation for the system to perform
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

        //Method for the user to input the details of the recipe
        public static void EnterRecipe()
        {
            //User input to get the initial details of the recipe
            RecipeSaved = true;
            Console.WriteLine("Enter recipe name -->");
            RecipeName = Console.ReadLine();

            Console.WriteLine("Enter the number of ingredients in the recipe");
            nrIngr = int.Parse(Console.ReadLine());
            IName = new string[nrIngr];
            IQuantity = new int[nrIngr];
            IUMeasure = new string[nrIngr];
            TempQuantity = new int[nrIngr];

            Console.WriteLine("Enter the number of steps in the recipe");
            nrSteps = int.Parse(Console.ReadLine());
            SDescr = new string[nrSteps];

            Console.WriteLine();

            //For loop for the user to input the ingredients in the recipe
            for (int i = 0; i < nrIngr; i++)
            {
                Console.WriteLine($"Ingredient nr.{i + 1}");
                Console.WriteLine("Enter the ingredient name");
                IName[i] = Console.ReadLine();

                Console.WriteLine("Enter the unit of measurement");
                IUMeasure[i] = Console.ReadLine();

                Console.WriteLine("Enter the quantity");
                IQuantity[i] = int.Parse(Console.ReadLine());
                TempQuantity[i] = IQuantity[i];

                Console.WriteLine();
            }

            //For loop for the user to enter the steps in the recipe
            for (int i = 0;i < nrSteps; i++)
            {
                Console.WriteLine($"Enter step number {i + 1}");
                SDescr[i] = Console.ReadLine();

                Console.WriteLine();
            }

            //Return to the menu in case the user wants to perform more actions on the system
            Menu();
        }

        public static void DisplayRecipe()
        {
            //If statement to check if a recipe has been saved
            if (RecipeSaved == false)
            {
                Console.WriteLine();
                Console.WriteLine("There is no saved recipe, please enter a recipe to display one.");
                Menu();
            }
            else
            {
                //Prints out the recipe in a readable format
                Console.WriteLine();
                Console.WriteLine(RecipeName);
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Ingredients:");
                for (int i = 0; i  < nrIngr; i++)
                {
                    Console.Write(IName[i] + ": ");
                    Console.Write(IQuantity[i] + " ");
                    Console.Write(IUMeasure[i] + "\n");
                }

                Console.WriteLine();
                Console.WriteLine("Steps:");
                for (int i = 0; i < nrSteps; i++)
                {
                    Console.WriteLine($"1: {SDescr[i]}");
                }
                Console.WriteLine();
            }

            //Return to the menu in case the user wants to perform more actions on the system
            Menu();
        }
        
        //Method to scale the recipe by either 0.5, 2 or 3
        public static void ScaleRecipe()
        {
            int OptionScale;

            //Scaling menu
            Console.WriteLine("Scale Menu");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1 - Scale by half");
            Console.WriteLine("2 - Scale by double");
            Console.WriteLine("3 - Scale by triple");
            Console.WriteLine("Enter an option to scale the recipe -->");
            OptionScale = int.Parse(Console.ReadLine());

            //Switch case that scales the recipe based on user input
            switch (OptionScale)
            {
                case 1:
                    for (int i = 0; i < nrIngr; i++)
                    {
                        IQuantity[i] = (int)(IQuantity[i] * 0.5);
                    }
                    break;
                case 2:
                    for (int i = 0; i < nrIngr; i++)
                    {
                        IQuantity[i] = IQuantity[i] * 2;
                    }
                    break;
                case 3:
                    for (int i = 0; i < nrIngr; i++)
                    {
                        IQuantity[i] = IQuantity[i] * 3;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    ScaleRecipe();
                    break;
            }

            //Return to the menu in case the user wants to perform more actions on the system
            Menu();
        }

        //Method to reset the recipe after it has been scaled to the original values
        public static void ResetRecipe()
        {
            for (int i = 0; i < nrIngr; i++)
            {
                IQuantity[i] = TempQuantity[i];
            }

            //Return to the menu in case the user wants to perform more actions on the system
            Menu();
        }

        //Method that resets all values in variables to default, essentially deleting the recipe
        public static void DeleteRecipe()
        {
            nrIngr = default(int);
            IName = default(string[]);
            IQuantity = default(int[]);
            IUMeasure = default(string[]);
            nrSteps = default(int);
            SDescr = default(string[]);
            TempQuantity = default(int[]);
            RecipeName = default(string);
            RecipeSaved = false;

            //Return to the menu in case the user wants to perform more actions on the system
            Menu();
        }
    }
}
