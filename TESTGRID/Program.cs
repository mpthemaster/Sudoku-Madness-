/* Michael J. Petruzzello - CIS 243 - 3/08/12
 * Purpose: To test if my sudoku algorithm is correctly working.
 * Algorithm: Compares the sum of my sudoku to the sum of a correct sudoku. If equal, everything is good!
*/ 
using System;
using GRID;

namespace TESTGRID
{
    class Program
    {
        //NOTE******* Can miss a certain bug where repeats are generated in the same square because the alignments used int he algorithm are screwed up.****MUST check manually for this bug!
        static void Main()
        {
            bool repeats = false;

            while (!repeats) //Keeps checking until a repeat is found or I am satisfied by the amount of times the sudoku has been working (just exit out).
            {
                int[,] sudoku = Class1.Sudoku();
                int sum = 0;

                for (int i = 0; i < sudoku.GetLength(0); i++)
                    for (int j = 0; j < sudoku.GetLength(1); j++)
                        sum += sudoku[i, j];

                if (sum != 9 + 18 + 27 + 36 + 45 + 54 + 63 + 72 + 81) //1^9 + 2^9 + 3^9 + .... + 9^9 .
                    repeats = true;

                Console.WriteLine(!repeats ? "The sudoku has no repeats. : )" : "DAMN IT! Try again!");
            }
        }
    }
}
