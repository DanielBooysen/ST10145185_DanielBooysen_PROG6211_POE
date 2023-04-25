﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        private static string RecipeName;

        public static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            int Option;

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Welcome to your recipe book!");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1 - Enter recipe");
            Console.WriteLine("2 - Display recipe");
            Console.WriteLine("3 - Scale recipe");
            Console.WriteLine("4 - Reset recipe");
            Console.WriteLine("5 - Delete recipe");
            Console.WriteLine("Please enter an operation -->");
            Option = int.Parse(Console.ReadLine());

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
                default:
                    Console.WriteLine("Invalid option!");
                    Menu();
                    break;
            }
        }

        public static void EnterRecipe()
        {
            Console.WriteLine("Enter recipe name -->");
            RecipeName = Console.ReadLine();

            Console.WriteLine("Enter the number of ingredients in the recipe");
            nrIngr = int.Parse(Console.ReadLine());
            IName = new string[nrIngr];
            IQuantity = new int[nrIngr];
            IUMeasure = new string[nrIngr];

            Console.WriteLine("Enter the number of steps in the recipe");
            nrSteps = int.Parse(Console.ReadLine());
            SDescr = new string[nrSteps];

            Console.WriteLine();

            for (int i = 0; i < nrIngr; i++)
            {
                Console.WriteLine($"Ingredient nr.{i + 1}");
                Console.WriteLine("Enter the ingredient name");
                IName[i] = Console.ReadLine();

                Console.WriteLine("Enter the unit of measurement");
                IUMeasure[i] = Console.ReadLine();

                Console.WriteLine("Enter the quantity");
                IQuantity[i] = int.Parse(Console.ReadLine());

                Console.WriteLine();
            }

            for (int i = 0;i < nrSteps; i++)
            {
                Console.WriteLine($"Enter step number {i + 1}");
                SDescr[i] = Console.ReadLine();

                Console.WriteLine();
            }
        }

        public static void DisplayRecipe()
        {
            if (nrIngr == null)
            {
                Console.WriteLine("There is no saved recipe, please enter one to display one.");
            }
        }

        public static void ScaleRecipe()
        {

        }

        public static void ResetRecipe()
        {

        }

        public static void DeleteRecipe()
        {

        }
    }
}
