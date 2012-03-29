/* Michael J. Petruzzello - CIS 243 - 3/08/12
 * Purpose: A fun sudoku game!
 * Ideas: 
 * 
 * 2. Hint System - Show correct squares or show incorrect squares or both.
 * 3. Cool numbers flashing across.
 * 4. Sudoku solver! *Try after everything else.
 * 5. Implement Exit game. *
*/ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WINGRID
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Sets tooltips for further description to the user.
            ToolTip radRanGridTip = new ToolTip();
            ToolTip radNRRGridTip = new ToolTip();
            ToolTip radNRCRGridTip = new ToolTip();

            radRanGridTip.SetToolTip(radRanGrid, "Generate a random 9 x 9 grid!");
            radNRRGridTip.SetToolTip(radNRRGrid, "Generate a random 9 x 9 grid with no repetitions in a row!");
            radNRCRGridTip.SetToolTip(radNRCRGrid, "Generate a random 9 x 9 grid with no repetitions in a row or column!");
        }

        private void btnGenDebug_Click(object sender, EventArgs e)
        {
            //Generates the simple grid specified by the user.
            if (radRanGrid.Checked)
            {
                BasicGrid basicGrid = new BasicGrid();
                DisplayGrid(basicGrid.Grid);
            }
            else if (radNRRGrid.Checked)
            {
                NRRGrid nrrGrid = new NRRGrid();
                DisplayGrid(nrrGrid.Grid);
            }
            else
            {
                NRCRGrid nrcrGrid = new NRCRGrid();
                DisplayGrid(nrcrGrid.Grid);
            }
            
        }

        /// <summary>
        /// Displays a 9 x 9 grid to the screen.
        /// </summary>
        /// <param name="grid">The 9 x 9 grid to display.</param>
        private void DisplayGrid(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {                                       //i.e. txt0_0 is a TextBox name. Goes from txt0_0 to txt8_8 . 
                    TextBox txtbx = this.Controls.Find("txt" + i + "_" + j, true)[0] as TextBox;    //Finds the reference to the TextBox specified

                    if (grid[i, j] != 0) //If 0, nothing is supposed to be displayed into the textbox, but just incase there is somethinga already in there, it needs to be cleared.
                        txtbx.Text = grid[i, j].ToString();                                             //and sets the grid value to be displayed in it.
                    else
                        txtbx.Text = "";
                }
        }

        private SudokuGrid sudokuGrid;
        private void btnPlaySudoku_Click(object sender, EventArgs e)
        {
            //Generates the sudoku with the difficulty set.
            if (radEasy.Checked)
                sudokuGrid = new SudokuGrid("Easy");
            else if (radIntermediate.Checked)
                sudokuGrid = new SudokuGrid("Intermediate");
            else
                sudokuGrid = new SudokuGrid("Expert");

            DisplayGrid(sudokuGrid.SudokuToUserDisplay);
        }

        //Draws Graphical lines to visually split up the 9 x 9 grid in the windows form.
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.LightPink, 4);

            e.Graphics.DrawLine(pen, 185, 6, 185, 582); //Left vertical line.
            e.Graphics.DrawLine(pen, 368, 6, 368, 582); //Right vertical line.

            e.Graphics.DrawLine(pen, 5, 197, 548, 197); //Top horizontal line.
            e.Graphics.DrawLine(pen, 5, 391, 548, 391); //Bottom horizontal line.
        }
    }
}
