/* Michael J. Petruzzello - CIS 243 - 3/08/12
 * BIGGEST LESSON INCORPORATED FROM PRIMES: Start simple, then get more complex as needed (keep the appropriate perspective).
 * Purpose: To learn more about using loops in complex ways as well as having fun trying to make a sudoku.
 * Algorithm:
 * RandomGrid() - Loop through a 9 by 9 grid
 *                  Put in random numbers.
 *                  
 * RowsGrid() - Loop through a 9 by 9 grid
 *                  Loop until a random number fits
 *                      Generate a random number.
 *                      Loop through row
 *                          If random number is a repeat
 *                              Generate a new number.
 *                          
 * LatinSquare() - Loop through a 9 by 9 grid
 *                  Loop until a random number fits
 *                      Generate a random number.
 *                      Loop through row
 *                          If random number is a repeat    
 *                              Generate a new number.
 *                      Loop through column
 *                          If random number is a repeat
 *                              Generate a new number.
 *                          
 * Sudoku() Loop through a 9 by 9 grid
 *                  Loop until a random number fits
 *                      Generate a random number.
 *                      Loop through row
 *                          If random number is a repeat    
 *                              Generate a new number.
 *                      Loop through column
 *                          If random number is a repeat
 *                              Generate a new number.
 *                      Loop through 3 by 3 square
 *                          If random number is a repeat
 *                              Generate a new number.
 *                          
*/
using System;

namespace GRID
{
    public static class Class1
    {
       private static Random ranNum = new Random(); //Makes sure there are no issues with the same seed being generated.

        /// <summary>
        /// Generates a 9 by 9 grid of random numbers.
        /// </summary>
        /// <returns>Returns the grid.</returns>
        public static int[,] RandomGrid()
        {
            int[,] grid = new int[9, 9];

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = ranNum.Next(1, 10);
                }
            return grid;
        }

        /// <summary>
        /// Generates a 9 by 9 grid of random numbers that have no repeats in a row.
        /// </summary>
        /// <param name="numberOfExtraRowAttempts">Keeps track of how many times past the first time a new number is generated.</param>
        /// <returns>Returns the grid.</returns>
        public static int[,] RowsGrid(ref int numberOfExtraRowAttempts)
        {
            int[,] grid = new int[9, 9];

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int newNum = ranNum.Next(1, 10);

                    while (IsRowNumberRepeated(grid, i, j, newNum)) //Makes sure the number to be placed into the row has not been repeated. If it has been, generate a new number.
                    {
                        newNum = ranNum.Next(1, 10);

                        numberOfExtraRowAttempts++; //Keeps track of how many times past the first time a new number is generated.
                    }
                    grid[i, j] = newNum;
                }
            return grid;
        }

        /// <summary>
        /// Checks if a number has been repeated in a row in a grid.
        /// </summary>
        /// <param name="grid">The grid to be checked for repeats.</param>
        /// <param name="indexRow">The row to be checked for repeats.</param>
        /// <param name="indexColumn">The place in the grid at which a new number is to be placed.</param>
        /// <param name="num">The new number to be put into the grid.</param>
        /// <returns>Returns true if the number in that row has been repeated.</returns>
        private static bool IsRowNumberRepeated(int[,] grid, int indexRow, int indexColumn, int num)
        {
            for (int i = 0; i < indexColumn; i++)
            {
                if (grid[indexRow, i] == num)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a number has been repeated in a column.
        /// </summary>
        /// <param name="grid">The grid to be checked for repeats.</param>
        /// <param name="indexRow">The row to be checked for repeats.</param>
        /// <param name="indexColumn">The place in the grid at which a new number is to be placed.</param>
        /// <param name="num">The new number to be put into the grid.</param>
        /// <returns>Returns true if the number in that column has been repeated.</returns>
        private static bool IsColNumberRepeated(int[,] grid, int indexRow, int indexColumn, int num)
        {
            for (int i = 0; i < indexRow; i++)
            {
                if (grid[i, indexColumn] == num)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checksif a number has been repeated in a 3 by 3 square of the sudoku.
        /// </summary>
        /// <param name="grid">The 9 by 9 grid to be checked for repeats.</param>
        /// <param name="indexRow">The row to be checked for repeats.</param>
        /// <param name="indexColumn">The place in the grid at which a new number is to be placed.</param>
        /// <param name="num">The new number to be put into the grid.</param>
        /// <returns>Returns true if the number in that 3 by 3 square has been repeated.</returns>
        private static bool IsSquareNumberRepeated(int[,] grid, int indexRow, int indexColumn, int num)
        {
            int rowPlaceDist, columnPlaceDist, maxColumnPlace, minColumnPlace;

            //Figures out how far away the current row index is from the start of the 3 by 3 square.
            if (indexRow == 0 || indexRow == 3 || indexRow == 6)
                rowPlaceDist = 0;
            else if (indexRow == 1 || indexRow == 4 || indexRow == 7)
                rowPlaceDist = 1;
            else
                rowPlaceDist = 2;

            //Figures out how far away the current column index is from the start of the 3 by 3 square.
            if (indexColumn == 0 || indexColumn == 3 || indexColumn == 6)
                columnPlaceDist = 0;
            else if (indexColumn == 1 || indexColumn == 4 || indexColumn == 7)
                columnPlaceDist = 1;
            else
                columnPlaceDist = 2;

            minColumnPlace = indexColumn - columnPlaceDist; //The lowest column index for the 3 by 3 grid the newly generated number is in.
            maxColumnPlace = indexColumn + 3 - columnPlaceDist; //The maximum column index for the 3 by 3 grid the newly generated number is in.

            for (int i = indexRow - rowPlaceDist; i < indexRow; i++) //For the start of the 3 by 3 grid until (and including) the row index currently stopped at for the new number.
                for (int j = minColumnPlace; j < maxColumnPlace; j++)
                    if (grid[i, j] == num)
                        return true;
            return false;
        }

        /// <summary>
        /// Generates a Latin Square.
        /// </summary>
        /// <param name="numberOfExtraAttempts">Keeps track of how many times past the first time a new number is generated.</param>
        /// <returns>Returns the Latin Square.</returns>
        public static int[,] LatinSquare(ref int numberOfExtraAttempts)
        {
            int[,] grid = new int[9, 9];

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int newNum = ranNum.Next(1, 10), timesLooped = 0;

                    //Makes sure the number to be placed into the row has not been repeated. If it has been, generate a new number.
                    while (IsRowNumberRepeated(grid, i, j, newNum) || IsColNumberRepeated(grid, i, j, newNum))
                    {
                        newNum = ranNum.Next(1, 10);

                        numberOfExtraAttempts++; //Keeps track of how many times past the first time a new number is generated.
                        timesLooped++; //Keeps track of how many times this has looped. If more than 18 times, break.

                        if (timesLooped > 19)
                        {
                            j = 0; //Resets the row.
                        }
                    }
                    grid[i, j] = newNum;
                }
            return grid;
        }

        /// <summary>
        /// Generates a Sudoku.
        /// </summary>
        /// <param name="numberOfExtraAttempts">Keeps track of how many times past the first time a new number is generated.</param>
        /// <returns>Returns the Sudoku.</returns>
        public static int[,] Sudoku(ref int numberOfExtraAttempts)
        {
            int[,] grid = new int[9, 9];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                bool stop = false; //Keeps track of whether or not a bigger reset is needed.
                int timesLoopedTooMany = 0;

                for (int j = 0; j < grid.GetLength(1) && !stop; j++)
                {
                    int newNum = ranNum.Next(1, 10), timesLooped = 0;

                    try //In rare cases the index i will become less than 0 due to an optimization (lowering the timesLoopedTooMany threshold and having less if statements).
                    {
                        //Makes sure the number to be placed into the row has not been repeated. If it has been, generate a new number.
                        while (IsRowNumberRepeated(grid, i, j, newNum) || IsColNumberRepeated(grid, i, j, newNum) || IsSquareNumberRepeated(grid, i, j, newNum))
                        {
                            newNum = ranNum.Next(1, 10);

                            numberOfExtraAttempts++; //Keeps track of how many times past the first time a new number is generated.
                            timesLooped++; //Keeps track of how many times this has looped. If more than 18 times, break.

                            if (timesLooped > 19)
                            {
                                timesLoopedTooMany++;
                                j = 0; //Resets the row.

                                if (timesLoopedTooMany > 9) //Resets 2 to 3 rows back if resetting one row hasn't been working.
                                {
                                    i -= 3;
                                    stop = true;
                                }
                                break;
                            }
                        }
                    }
                    catch (IndexOutOfRangeException) //Reset the i index.
                    {
                        i = 0;
                    }

                    if (!stop) //If there has been no problem generating a new number...
                        grid[i, j] = newNum;
                }
            }
            return grid;
        }

        /// <summary>
        /// Generates a Sudoku.
        /// </summary>
        /// <returns>Returns the Sudoku.</returns>
        public static int[,] Sudoku()
        {
            int[,] grid = new int[9, 9];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                bool stop = false; //Keeps track of whether or not a bigger reset is needed.
                int timesLoopedTooMany = 0;

                for (int j = 0; j < grid.GetLength(1) && !stop; j++)
                {
                    int newNum = ranNum.Next(1, 10), timesLooped = 0;

                    try //In rare cases the index i will become less than 0 due to an optimization (lowering the timesLoopedTooMany threshold and having less if statements).
                    {
                        //Makes sure the number to be placed into the row has not been repeated. If it has been, generate a new number.
                        while (IsRowNumberRepeated(grid, i, j, newNum) || IsColNumberRepeated(grid, i, j, newNum) || IsSquareNumberRepeated(grid, i, j, newNum))
                        {
                            newNum = ranNum.Next(1, 10);

                            timesLooped++; //Keeps track of how many times this has looped. If more than 18 times, break.

                            if (timesLooped > 19)
                            {
                                timesLoopedTooMany++;
                                j = 0; //Resets the row.

                                if (timesLoopedTooMany > 9) //Resets 2 to 3 rows back if resetting one row hasn't been working.
                                {
                                    i -= 3;
                                    stop = true;
                                }
                                break;
                            }
                        }
                    }
                    catch (IndexOutOfRangeException) //Reset the i index.
                    {
                        i = 0;
                    }

                    if (!stop) //If there has been no problem generating a new number...
                        grid[i, j] = newNum;
                }
            }
            return grid;
        }
    }
}
