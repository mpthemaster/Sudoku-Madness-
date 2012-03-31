/* Michael J. Petruzzello - CIS 243 - 3/08/12
 * Purpose: A fun sudoku game!
 * Ideas: 
 * 
 * 3. Cool numbers flashing across.
 * 4. Sudoku solver! *Try after everything else.
 * 5. Implement Exit game. *
 * 6. Change Textbox backcolor feature for user.
 * 6.1 Add color changing support for everything in panel1.
 * 7.*Might not be necessary* Implement a more advanced difficulty system. (have it make each 3 x 3 grid have a preset number of numbers displayed in random positions)
 * 8. Rename method names to distinguish between private and public.
 * 9. Hint System - add support to display as many free numbers to the grid as the user wants.
 * 10. Add scoring system.
 * 11. Make GUI nicer.
 * 12. Hint system - add support to bring a textbox to the user's attention that has an easy number put in. (i.e. the number HAS to be 5).
 * 13. Based on the user's numbers, display numbers that they have finished using. (i.e. they use nine 5s).
*/ 
using System;
using System.Drawing;
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
            ToolTip chkHintsTip = new ToolTip();

            radRanGridTip.SetToolTip(radRanGrid, "Generate a random 9 x 9 grid!");
            radNRRGridTip.SetToolTip(radNRRGrid, "Generate a random 9 x 9 grid with no repetitions in a row!");
            radNRCRGridTip.SetToolTip(radNRCRGrid, "Generate a random 9 x 9 grid with no repetitions in a row or column!");
            chkHintsTip.SetToolTip(chkHints, "Numbers you have entered are displayed in green if correct and red if wrong.");
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

                    textboxes[i, j].KeyPress += new KeyPressEventHandler(NumbersOnly_KeyPress); //Stops crap from being entered.
                    textboxes[i, j].TextChanged += new EventHandler(Textboxes_TextChanged); //Checks if the user is done playing, if they sucessfully completed the sudoku, and also utilizes the hint system.
                    panels[i, j].Controls.Add(textboxes[i, j]);
                }
        }

        private bool sudokuGridGenerated; //Keeps track of whether or not a sudoku grid has been generated. If not, certain features are ignored.
        private void btnGenDebug_Click(object sender, EventArgs e)
        {
            sudokuGridGenerated = false;

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
                    {
                        textboxes[i, j].Text = grid[i, j].ToString();              //and sets the grid value to be displayed in it.
                        textboxes[i, j].Enabled = false;
                    }
                    else
                    {
                        textboxes[i, j].Text = "";
                        textboxes[i, j].Enabled = true;
                    }
                }
        }

        private SudokuGrid sudokuGrid;
        private void btnPlaySudoku_Click(object sender, EventArgs e)
        {
            sudokuGridGenerated = true;

            //Generates the sudoku with the difficulty set.
            if (radEasy.Checked)
                sudokuGrid = new SudokuGrid("Easy");
            else if (radIntermediate.Checked)
                sudokuGrid = new SudokuGrid("Intermediate");
            else
                sudokuGrid = new SudokuGrid("Expert");

            DisplayGrid(sudokuGrid.SudokuToUserDisplay);

            //AutoFillGrid(); //For testing purposes.
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

        /// <summary>
        /// Makes sure only number keys are used by the user; any other input is discarded. Also checks if the user is done playing and if they are correct.
        /// </summary>
        private void NumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace
                (e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        /// <summary>
        /// Checks if the user has finished playing, and if so, checks if the user won and displays a corresponding message.
        /// </summary>
        private void Textboxes_TextChanged(object sender, EventArgs e)         //<======================================================MUST FINISH IMPLEMENTING*****************************
        {
            if (sudokuGridGenerated) //Don't want any of this to happen unless a sudoku grid has been generated.
            {
                if (chkHints.Checked) //If the user pressed a number key and wants hints...Make correct input green and wrong input red.
                    HintChecker(sender as TextBox);
                else //Set text color to black.
                    (sender as TextBox).ForeColor = Color.Black;

                if (DonePlaying())
                    if (CheckIfCorrect())
                    {
                        //If the user wants to play again at the same difficulty, do it!
                        if (MessageBox.Show("Congratulations! You've succesfully completed this Sudoku challenge! Play again with the same difficulty?", "Yay!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            btnPlaySudoku_Click(null, null);
                    }
                    else //If the user wants to see what is wrong, do it!
                        if (MessageBox.Show("You have unsucessfully completed the Sudoku. Would you like all incorrect answers to be marked?", "Sorry...", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            for (int i = 0; i < textboxes.GetLength(0); i++)
                                for (int j = 0; j < textboxes.GetLength(1); j++)
                                {
                                    HintChecker(textboxes[i, j]);
                                }
            }
            else
                (sender as TextBox).ForeColor = Color.Black; //Sets the text color back to black incase the hint system was used.
        }

        /// <summary>
        /// Checks if the player has completely filled all the grids (and thusly, is done playing).
        /// </summary>
        /// <returns>Returns true if the user has filled up all the textboxes.</returns>
        private bool DonePlaying()
        {
            for (int i = 0; i < textboxes.GetLength(0); i++)
                for (int j = 0; j < textboxes.GetLength(1); j++)
                    if (textboxes[i, j].Text == "")
                        return false;
            return true;
        }

        /// <summary>
        /// Compare the user's numbers with the sudoku.
        /// </summary>
        /// <returns>Returns true if the user is correct.</returns>
        private bool CheckIfCorrect()
        {
            for (int i = 0; i < textboxes.GetLength(0); i++)
                for (int j = 0; j < textboxes.GetLength(1); j++)
                    if (textboxes[i, j].Text != sudokuGrid.Grid[i, j].ToString())
                        return false;
            return true;
        }

        /// <summary>
        /// Debug for quickly filling the sudoku grid for testing purposes. *Try to figure out how to connect to a sequence of key presses.
        /// </summary>
        private void AutoFillGrid()
        {
            for (int i = 0; i < textboxes.GetLength(0); i++)
                for (int j = 0; j < textboxes.GetLength(1); j++)
                    textboxes[i, j].Text = sudokuGrid.Grid[i, j].ToString();
        }

        /// <summary>
        /// Part of Hint System - Checks if a textbox with text entered into it is correct (green) or wrong (red).
        /// </summary>
        private void HintChecker(TextBox textbox)
        {
            //Gets the corresponding sudoku grid index numbers from the textbox's name.
            string[] indexes = textbox.Name.Remove(0, 4).Split('_');
            int indexOne = int.Parse(indexes[0]), indexTwo = int.Parse(indexes[1]);
            
            //Mark the user's input as either green (correct) or red (wrong).
            if (textbox.Text == sudokuGrid.Grid[indexOne, indexTwo].ToString())
                textbox.ForeColor = Color.Green;
            else
                textbox.ForeColor = Color.Red;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Makes sure the user wants to exit and if the user is, do it!
            if (MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
