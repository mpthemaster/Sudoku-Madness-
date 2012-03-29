/* Michael J. Petruzzello - CIS 243 - 3/08/12
 * Purpose: The base class for some inheritance fun!
*/ 
using System;

namespace WINGRID
{
    class BasicGrid
    {
        protected Random ranNum = new Random(); //Makes sure there are no issues with the same seed being generated.

        protected int[,] grid;
        public int[,] Grid
        {
            get { return grid; }
        }

        /// <summary>
        /// Initializes a 9 x 9 grid full of random numbers.
        /// </summary>
        public BasicGrid()
        {
            GenerateNewGrid();
        }

        /// <summary>
        /// Generates a new 9 x 9 grid full of random numbers.
        /// </summary>
        protected virtual void GenerateNewGrid()
        {
            grid = new int[9, 9];

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = ranNum.Next(1, 10);
                }
        }
    }
}
