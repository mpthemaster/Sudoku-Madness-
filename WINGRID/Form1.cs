/* Michael J. Petruzzello - CIS 243 - 3/08/12
 * Purpose: A fun sudoku game!
 * Ideas: 
 * 
 * 2. Hint System - Show correct squares or show incorrect squares or both.
 * 3. Cool numbers flashing across.
 * 4. Sudoku solver! *Try after everything else.
 * 5. Implement Exit game. *
 * 6. Change Textbx backcolor feature for user.
 * 6.1 Add color changing support for everything in panel1.
 * 7. Implement a more advanced difficulty system. (have it make each 3 x 3 grid have a preset number of numbers displayed in random positions)
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
            CreateTextboxes(); //Creates and stores the 81 textboxes for the form.


            //Sets tooltips for further description to the user.
            ToolTip radRanGridTip = new ToolTip();
            ToolTip radNRRGridTip = new ToolTip();
            ToolTip radNRCRGridTip = new ToolTip();

            radRanGridTip.SetToolTip(radRanGrid, "Generate a random 9 x 9 grid!");
            radNRRGridTip.SetToolTip(radNRRGrid, "Generate a random 9 x 9 grid with no repetitions in a row!");
            radNRCRGridTip.SetToolTip(radNRCRGrid, "Generate a random 9 x 9 grid with no repetitions in a row or column!");
        }

        TextBox[,] textboxes; //Used for displaying the sudoku and basic grids.
        /// <summary>
        /// Generates the textboxes for the form. Needed for Sudoku game (and to display the other basic grids).
        /// </summary>
        private void CreateTextboxes()
        {  //For a 9 x 9 Sudoku.
            const int AMOUNT = 9; 
            textboxes = new TextBox[AMOUNT, AMOUNT];
            Panel[,] panels = new Panel[AMOUNT, AMOUNT]; //For a nicer looking GUI behind the textboxes.

            for (int i = 0; i < textboxes.GetLength(0); i++)
                for (int j = 0; j < textboxes.GetLength(1); j++)
                {
                    panels[i, j] = new Panel();

                    //Sets up the positioning and size of the panels onto the form.
                    //Checks if the beginning of a 3 by 3 grid's row of the sudoku has been reached and if so, makes the panels sides wider apart.                    
                    if (j >= 6)
                        panels[i, j].Left = 6;
                    else if (j >= 3)
                        panels[i, j].Left = 3;

                    panels[i, j].Left += 5 + 60 * j; //leftStartingPoint + distanceFromPreviousPanel.

                    //Checks if the beginning of a 3 by 3 grid's row of the sudoku has been reached and if so, makes the panels tops wider apart. 
                    if (i >= 6)
                        panels[i, j].Top = 6;
                    else if (i >= 3)
                        panels[i, j].Top = 3;

                    panels[i, j].Top += 6 + 62 * i; //topStartingPoint + distanceFromPreviousPanel.
                    panels[i, j].Width = 57;
                    panels[i, j].Height = 59;
                    panels[i, j].Name = "panel " + i + "_" + j;
                    panels[i, j].BackColor = Color.MistyRose;
                    panel1.Controls.Add(panels[i, j]);

                    
                    textboxes[i, j] = new TextBox();

                    //Sets up the positioning and size of the textboxes onto the form.
                    textboxes[i, j].Left = 3;                                        
                    textboxes[i, j].Top = 5;                                          
                    textboxes[i, j].Width = 51;                                         
                    textboxes[i, j].Height = 49;                                        
                    textboxes[i, j].Name = "txt " + i + "_" + j;                              

                    //Sets up misc. settings for how the textbox is.
                    textboxes[i, j].Multiline = true;
                    textboxes[i, j].MaxLength = 1;
                    textboxes[i, j].TextAlign = HorizontalAlignment.Center;
                    textboxes[i, j].Enabled = false;
                    textboxes[i, j].BackColor = Color.LightPink;

                    Font test = new Font(FontFamily.GenericSansSerif, 29);
                    textboxes[i, j].Font = test;

                    panels[i, j].Controls.Add(textboxes[i, j]);
                }
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
                {     
                    if (grid[i, j] != 0) //If 0, nothing is supposed to be displayed into the textbox, but just incase there is somethinga already in there, it needs to be cleared.
                        textboxes[i, j].Text = grid[i, j].ToString();                                             //and sets the grid value to be displayed in it.
                    else
                        textboxes[i, j].Text = "";
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
            Pen pen = new Pen(Color.DeepPink, 4);

            e.Graphics.DrawLine(pen, 185, 6, 185, 567); //Left vertical line.
            e.Graphics.DrawLine(pen, 368, 6, 368, 567); //Right vertical line.

            e.Graphics.DrawLine(pen, 5, 192, 548, 192); //Top horizontal line.
            e.Graphics.DrawLine(pen, 5, 381, 548, 381); //Bottom horizontal line.
        }
    }
}
