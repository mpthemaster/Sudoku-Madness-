/* Michael J. Petruzzello - CIS 243 - 3/08/12
 * Purpose: The fourth and final class for some inheritance fun! Sudoku object for the sudoku game.
 * Changelist:
 * 
 * 1. Don't forget intermediate and expert difficulties!
 * 2. Difficulty testing!
*/
using System;
namespace WINGRID
{
    class SudokuGrid : NRCRGrid
    {
        private Random randomDisplay;

        private int[,] sudokuToUserDisplay = new int[9,9];
        public int[,] SudokuToUserDisplay
        {
            get { return sudokuToUserDisplay; }
        }

        /// <summary>
        /// Initializes a 9 x 9 Sudoku.
        /// </summary>
        /// <param name="difficulty">The difficulty of the Sudoku grid: "Easy", "Intermediate", or "Expert".</param>
        public SudokuGrid(string difficulty)
        {
            GenerateNewGrid();
            randomDisplay = new Random();

            //Takes the newly generated grid and blanks out an amount of numbers from the grid to be displayed to the user based off of the user-selected difficulty.
            if (difficulty == "Easy")
                EasyGridToDisplay();
            else if (difficulty == "Intermediate")
                IntermediateGridToDisplay();
            else
                ExpertGridToDisplay();   
        }

        /// <summary>
        /// Makes an easy sudoku for users to solve.
        /// </summary>
        private void EasyGridToDisplay()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = randomDisplay.Next(0, 4); j < grid.GetLength(1); j+= randomDisplay.Next(1, 4)) //Change these two random ranges to change the difficulty.
                {
                    sudokuToUserDisplay[i, j] = grid[i, j];
                }
        }

        /// <summary>
        /// Makes an intermediate sudoku for users to solve.
        /// </summary>
        private void IntermediateGridToDisplay()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = randomDisplay.Next(0, 4); j < grid.GetLength(1); j += randomDisplay.Next(3, 4)) //Change these two random ranges to change the difficulty.
                {
                    sudokuToUserDisplay[i, j] = grid[i, j];
                }
        }

        /// <summary>
        /// Makes an expert sudoku for users to solve.
        /// </summary>
        private void ExpertGridToDisplay()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = randomDisplay.Next(0, 4); j < grid.GetLength(1); j += randomDisplay.Next(3, 4)) //Change these two random ranges to change the difficulty.
                {
                    sudokuToUserDisplay[i, j] = grid[i, j];
                }
        }

        /// <summary>
        /// Generates a 9 x 9 Sudoku grid.
        /// </summary>
        protected override void GenerateNewGrid()
        {
            grid = new int[9, 9];

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
        }

        /// <summary>
        /// Checksif a number has been repeated in a 3 by 3 square of the sudoku.
        /// </summary>
        /// <param name="grid">The 9 by 9 grid to be checked for repeats.</param>
        /// <param name="indexRow">The row to be checked for repeats.</param>
        /// <param name="indexColumn">The place in the grid at which a new number is to be placed.</param>
        /// <param name="num">The new number to be put into the grid.</param>
        /// <returns>Returns true if the number in that 3 by 3 square has been repeated.</returns>
        private bool IsSquareNumberRepeated(int[,] grid, int indexRow, int indexColumn, int num)
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
    }
}
