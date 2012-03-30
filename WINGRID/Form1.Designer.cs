namespace WINGRID
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenDebug = new System.Windows.Forms.Button();
            this.radNRCRGrid = new System.Windows.Forms.RadioButton();
            this.radNRRGrid = new System.Windows.Forms.RadioButton();
            this.radRanGrid = new System.Windows.Forms.RadioButton();
            this.btnPlaySudoku = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.radEasy = new System.Windows.Forms.RadioButton();
            this.radIntermediate = new System.Windows.Forms.RadioButton();
            this.radExpert = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.btnGenDebug);
            this.groupBox1.Controls.Add(this.radNRCRGrid);
            this.groupBox1.Controls.Add(this.radNRRGrid);
            this.groupBox1.Controls.Add(this.radRanGrid);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simple Grids";
            // 
            // btnGenDebug
            // 
            this.btnGenDebug.Location = new System.Drawing.Point(91, 42);
            this.btnGenDebug.Name = "btnGenDebug";
            this.btnGenDebug.Size = new System.Drawing.Size(75, 23);
            this.btnGenDebug.TabIndex = 1;
            this.btnGenDebug.Text = "Generate!";
            this.btnGenDebug.UseVisualStyleBackColor = true;
            this.btnGenDebug.Click += new System.EventHandler(this.btnGenDebug_Click);
            // 
            // radNRCRGrid
            // 
            this.radNRCRGrid.AutoSize = true;
            this.radNRCRGrid.Location = new System.Drawing.Point(176, 19);
            this.radNRCRGrid.Name = "radNRCRGrid";
            this.radNRCRGrid.Size = new System.Drawing.Size(78, 17);
            this.radNRCRGrid.TabIndex = 3;
            this.radNRCRGrid.Text = "NRCR Grid";
            this.radNRCRGrid.UseVisualStyleBackColor = true;
            // 
            // radNRRGrid
            // 
            this.radNRRGrid.AutoSize = true;
            this.radNRRGrid.Location = new System.Drawing.Point(99, 19);
            this.radNRRGrid.Name = "radNRRGrid";
            this.radNRRGrid.Size = new System.Drawing.Size(71, 17);
            this.radNRRGrid.TabIndex = 2;
            this.radNRRGrid.Text = "NRR Grid";
            this.radNRRGrid.UseVisualStyleBackColor = true;
            // 
            // radRanGrid
            // 
            this.radRanGrid.AutoSize = true;
            this.radRanGrid.Checked = true;
            this.radRanGrid.Location = new System.Drawing.Point(6, 19);
            this.radRanGrid.Name = "radRanGrid";
            this.radRanGrid.Size = new System.Drawing.Size(87, 17);
            this.radRanGrid.TabIndex = 1;
            this.radRanGrid.TabStop = true;
            this.radRanGrid.Text = "Random Grid";
            this.radRanGrid.UseVisualStyleBackColor = true;
            // 
            // btnPlaySudoku
            // 
            this.btnPlaySudoku.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaySudoku.Location = new System.Drawing.Point(12, 187);
            this.btnPlaySudoku.Name = "btnPlaySudoku";
            this.btnPlaySudoku.Size = new System.Drawing.Size(280, 55);
            this.btnPlaySudoku.TabIndex = 1;
            this.btnPlaySudoku.Text = "Play Sudoku!";
            this.btnPlaySudoku.UseVisualStyleBackColor = true;
            this.btnPlaySudoku.Click += new System.EventHandler(this.btnPlaySudoku_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(298, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 573);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please select a difficulty:";
            // 
            // radEasy
            // 
            this.radEasy.AutoSize = true;
            this.radEasy.Checked = true;
            this.radEasy.Location = new System.Drawing.Point(145, 101);
            this.radEasy.Name = "radEasy";
            this.radEasy.Size = new System.Drawing.Size(48, 17);
            this.radEasy.TabIndex = 5;
            this.radEasy.TabStop = true;
            this.radEasy.Text = "Easy";
            this.radEasy.UseVisualStyleBackColor = true;
            // 
            // radIntermediate
            // 
            this.radIntermediate.AutoSize = true;
            this.radIntermediate.Location = new System.Drawing.Point(145, 124);
            this.radIntermediate.Name = "radIntermediate";
            this.radIntermediate.Size = new System.Drawing.Size(83, 17);
            this.radIntermediate.TabIndex = 6;
            this.radIntermediate.Text = "Intermediate";
            this.radIntermediate.UseVisualStyleBackColor = true;
            // 
            // radExpert
            // 
            this.radExpert.AutoSize = true;
            this.radExpert.Location = new System.Drawing.Point(145, 147);
            this.radExpert.Name = "radExpert";
            this.radExpert.Size = new System.Drawing.Size(55, 17);
            this.radExpert.TabIndex = 7;
            this.radExpert.Text = "Expert";
            this.radExpert.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 595);
            this.Controls.Add(this.radExpert);
            this.Controls.Add(this.radIntermediate);
            this.Controls.Add(this.radEasy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPlaySudoku);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Welcome to Sudoku MADNESS!";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenDebug;
        private System.Windows.Forms.RadioButton radNRCRGrid;
        private System.Windows.Forms.RadioButton radNRRGrid;
        private System.Windows.Forms.RadioButton radRanGrid;
        private System.Windows.Forms.Button btnPlaySudoku;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radEasy;
        private System.Windows.Forms.RadioButton radIntermediate;
        private System.Windows.Forms.RadioButton radExpert;
    }
}

