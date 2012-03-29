/* Michael J. Petruzzello - CIS 243 - 3/08/12
 * Purpose: The third class for some inheritance fun! Latin Square object.
*/

namespace WINGRID
{
    class NRCRGrid : NRRGrid
    {
        /// <summary>
        /// Initializes a 9 x 9 Latin Square.
        /// </summary>
        public NRCRGrid()
            : base()
        {
        }

        /// <summary>
        /// Generates a 9 x 9 grid with no row or column repeats.
        /// </summary>
        protected override void GenerateNewGrid()
        {
            grid = new int[9, 9];

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int newNum = ranNum.Next(1, 10), timesLooped = 0;

                    //Makes sure the number to be placed into the row has not been repeated. If it has been, generate a new number.
                    while (IsRowNumberRepeated(grid, i, j, newNum) || IsColNumberRepeated(grid, i, j, newNum))
                    {
                        newNum = ranNum.Next(1, 10);
                        timesLooped++; //Keeps track of how many times this has looped. If more than 18 times, break.

                        if (timesLooped > 19)
                            j = 0; //Resets the row.
                    }
                    grid[i, j] = newNum;
                }
        }

        /// <summary>
        /// Checks if a number has been repeated in a column.
        /// </summary>
        /// <param name="grid">The grid to be checked for repeats.</param>
        /// <param name="indexRow">The row to be checked for repeats.</param>
        /// <param name="indexColumn">The place in the grid at which a new number is to be placed.</param>
        /// <param name="num">The new number to be put into the grid.</param>
        /// <returns>Returns true if the number in that column has been repeated.</returns>
        protected bool IsColNumberRepeated(int[,] grid, int indexRow, int indexColumn, int num)
        {
            for (int i = 0; i < indexRow; i++)
            {
                if (grid[i, indexColumn] == num)
                    return true;
            }
            return false;
        }
    }
}
