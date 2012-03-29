/* Michael J. Petruzzello - CIS 243 - 3/08/12
 * Purpose: The second class for some inheritance fun!
*/

namespace WINGRID
{
    class NRRGrid : BasicGrid
    {
        /// <summary>
        /// Initializes a 9 x 9 grid with no row repeats.
        /// </summary>
        public NRRGrid()
            : base()
        {
        }

        /// <summary>
        /// Generates a 9 x 9 grid with no row repeats.
        /// </summary>
        protected override void GenerateNewGrid()
        {
            grid = new int[9, 9];

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int newNum = ranNum.Next(1, 10);

                    while (IsRowNumberRepeated(grid, i, j, newNum)) //Makes sure the number to be placed into the row has not been repeated. If it has been, generate a new number.
                        newNum = ranNum.Next(1, 10);
                   
                    grid[i, j] = newNum;
                }
        }

        /// <summary>
        /// Checks if a number has been repeated in a row in a grid.
        /// </summary>
        /// <param name="grid">The grid to be checked for repeats.</param>
        /// <param name="indexRow">The row to be checked for repeats.</param>
        /// <param name="indexColumn">The place in the grid at which a new number is to be placed.</param>
        /// <param name="num">The new number to be put into the grid.</param>
        /// <returns>Returns true if the number in that row has been repeated.</returns>
        protected bool IsRowNumberRepeated(int[,] grid, int indexRow, int indexColumn, int num)
        {
            for (int i = 0; i < indexColumn; i++)
            {
                if (grid[indexRow, i] == num)
                    return true;
            }
            return false;
        }
    }
}
