/* Michael J. Petruzzello - CIS 243 - 3/08/12
 * Purpose: To learn more about using loops in complex ways as well as having fun trying to make a sudoku.
 * Algorithm: 
 * Show user menu options.
 * Loop until user wants to quit:
 *      If user selected menu option 0, quit.
 *      If user selected menu option 1, make a random grid and print to screen.
 *      If user selected menu option 2, make a random grid with no repeats in a row and print to screen.*
 *      If user selected menu option 3, make a random grid with no repeats in a row and column (Latin Square) and print to screen.*
 *      If user selected menu option 4, make a random grid with no repeats in a row, column, and 3 by 3 square (Sudoku) and print to screen.*
 *      
 *      *Time to generate and amount of numbers that had to be re-generated are also printed.
*/ 
using System;
using System.Diagnostics;
using GRID;

namespace CONGRID
{
    class Program
    {
        //Note: All color changes are to enhance console readability.
        static void Main()
        {
            bool exiting = false;

            while (!exiting)
            {
                Stopwatch timer = new Stopwatch(); //For keeping track of how long grid generation takes.
                int menuOption;

                //Menu screen.
                Console.WriteLine("(0) Quit.");
                Console.WriteLine("(1) Make a random grid.");
                Console.WriteLine("(2) Make a random grid with no repeats in a row.");
                Console.WriteLine("(3) Make a Latin Square. (No row and column repeats)");
                Console.WriteLine("(4) Make a Sudoku. (No row, column, or 3 by 3 repeats)");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Please choose an option: ");

                //Error checking input to make sure a menu item is selected.
                while (!int.TryParse(Console.ReadLine(), out menuOption) || menuOption < 0 || menuOption > 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please enter a number from 0-4: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.ForegroundColor = ConsoleColor.Gray;

                //Does the user-selected menu item.
                int numOfExtraNumbersGenerated;
                switch (menuOption)
                {
                    case 0: //User chose to exit.
                        exiting = true;
                        Console.WriteLine("Goodbye!");
                        break;

                    case 1: //User chose to make a random grid with repeats.
                        RandomGrid();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("This is a random grid with numbers that repeat.\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;

                    case 2: //User chose to make a random grid with no row repeats.
                        timer.Start();
                        numOfExtraNumbersGenerated = RowsGrid();
                        timer.Stop();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("This is a random grid with numbers that aren't repeated in the same row.");
                        Console.WriteLine(numOfExtraNumbersGenerated + " extra numbers were generated in order to generate 9 vaild rows.");
                        Console.WriteLine(timer.ElapsedMilliseconds + " milliseconds taken.\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;

                    case 3: //User chose to generate a Latin Square.
                        timer.Start();
                        numOfExtraNumbersGenerated = LatinSquare();
                        timer.Stop();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("This is a Latin Square with numbers that aren't repeated in the same row and column.");
                        Console.WriteLine(numOfExtraNumbersGenerated + " extra numbers were generated in order to generate 9 vaild rows.");
                        Console.WriteLine(timer.ElapsedMilliseconds + " milliseconds taken.\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;

                    case 4: //User chose to generate a Sudoku.
                        timer.Start();
                        numOfExtraNumbersGenerated = Sudoku();
                        timer.Stop();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("This is a Sudoku with numbers that aren't repeated in the same row, column, and 3 by 3 square.");
                        Console.WriteLine(numOfExtraNumbersGenerated + " extra numbers were generated in order to generate 9 vaild rows.");
                        Console.WriteLine(timer.ElapsedMilliseconds + " milliseconds taken.\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }
        }

        /// <summary>
        /// Generates a 9 by 9 grid of random integers and prints them to the screen.
        /// </summary>
        private static void RandomGrid()
        {
            GridPrint.ConPrintGrid(Class1.RandomGrid());
        }

        /// <summary>
        /// Generates a 9 by 9 grid of random integers and prints them to the screen amd returns how many extra numbers were generated due to duplicates.
        /// </summary>
        /// <returns>Returns the number of extra numbers generated.</returns>
        private static int RowsGrid()
        {
            int numOfExtraNumberGenerations = 0;
            GridPrint.ConPrintGrid(Class1.RowsGrid(ref numOfExtraNumberGenerations));
            return numOfExtraNumberGenerations;
        }

        /// <summary>
        /// Generates a Latin Square, prints it to the screen, and returns how many extra numbers were generated due to duplicates.
        /// </summary>
        /// <returns>Returns the number of extra numbers generated.</returns>
        private static int LatinSquare()
        {
            int numOfExtraNumberGenerations = 0;
            GridPrint.ConPrintGrid(Class1.LatinSquare(ref numOfExtraNumberGenerations));
            return numOfExtraNumberGenerations;
        }

        /// <summary>
        /// Generates a Sudoku, prints it to the screen, and returns how many extra numbers were generated due to duplicates.
        /// </summary>
        /// <returns>Returns the number of extra numbers generated.</returns>
        private static int Sudoku()
        {
            int numOfExtraNumberGenerations = 0;
            GridPrint.ConPrintGrid(Class1.Sudoku(ref numOfExtraNumberGenerations));
            return numOfExtraNumberGenerations;
        }
    }
}
