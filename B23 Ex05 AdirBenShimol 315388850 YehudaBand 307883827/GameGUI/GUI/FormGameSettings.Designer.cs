namespace GameGUI
{
    partial class FormGameSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.PlayersBox = new System.Windows.Forms.GroupBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BoardSizeBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericBoxCols = new System.Windows.Forms.NumericUpDown();
            this.numericBoxRows = new System.Windows.Forms.NumericUpDown();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.PlayersBox.SuspendLayout();
            this.BoardSizeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoxCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoxRows)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kristen ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayersBox
            // 
            this.PlayersBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayersBox.Controls.Add(this.textBoxPlayer2);
            this.PlayersBox.Controls.Add(this.checkBoxPlayer2);
            this.PlayersBox.Controls.Add(this.textBoxPlayer1);
            this.PlayersBox.Controls.Add(this.label2);
            this.PlayersBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayersBox.Location = new System.Drawing.Point(21, 105);
            this.PlayersBox.Margin = new System.Windows.Forms.Padding(2);
            this.PlayersBox.Name = "PlayersBox";
            this.PlayersBox.Padding = new System.Windows.Forms.Padding(2);
            this.PlayersBox.Size = new System.Drawing.Size(286, 103);
            this.PlayersBox.TabIndex = 1;
            this.PlayersBox.TabStop = false;
            this.PlayersBox.Text = "Players:";
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayer2.Location = new System.Drawing.Point(98, 66);
            this.textBoxPlayer2.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPlayer2.MaxLength = 12;
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(165, 22);
            this.textBoxPlayer2.TabIndex = 3;
            this.textBoxPlayer2.Text = "[ COMPUTER ]";
            this.textBoxPlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPlayer2.Location = new System.Drawing.Point(13, 68);
            this.checkBoxPlayer2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(82, 20);
            this.checkBoxPlayer2.TabIndex = 2;
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.player2CheckBox_Checked);
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.AccessibleDescription = "";
            this.textBoxPlayer1.AccessibleName = "";
            this.textBoxPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPlayer1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayer1.Location = new System.Drawing.Point(98, 34);
            this.textBoxPlayer1.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPlayer1.MaxLength = 12;
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(165, 22);
            this.textBoxPlayer1.TabIndex = 1;
            this.textBoxPlayer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Player 1: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BoardSizeBox
            // 
            this.BoardSizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoardSizeBox.Controls.Add(this.label4);
            this.BoardSizeBox.Controls.Add(this.label3);
            this.BoardSizeBox.Controls.Add(this.numericBoxCols);
            this.BoardSizeBox.Controls.Add(this.numericBoxRows);
            this.BoardSizeBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoardSizeBox.Location = new System.Drawing.Point(21, 226);
            this.BoardSizeBox.Margin = new System.Windows.Forms.Padding(2);
            this.BoardSizeBox.Name = "BoardSizeBox";
            this.BoardSizeBox.Padding = new System.Windows.Forms.Padding(2);
            this.BoardSizeBox.Size = new System.Drawing.Size(286, 68);
            this.BoardSizeBox.TabIndex = 2;
            this.BoardSizeBox.TabStop = false;
            this.BoardSizeBox.Text = "Board Size:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(152, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cols:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rows:";
            // 
            // numericBoxCols
            // 
            this.numericBoxCols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericBoxCols.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericBoxCols.Location = new System.Drawing.Point(195, 29);
            this.numericBoxCols.Margin = new System.Windows.Forms.Padding(2);
            this.numericBoxCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericBoxCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericBoxCols.Name = "numericBoxCols";
            this.numericBoxCols.Size = new System.Drawing.Size(45, 22);
            this.numericBoxCols.TabIndex = 1;
            this.numericBoxCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBoxCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericBoxCols.ValueChanged += new System.EventHandler(this.boardSizeBox_ValueChanged);
            // 
            // numericBoxRows
            // 
            this.numericBoxRows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericBoxRows.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericBoxRows.Location = new System.Drawing.Point(88, 29);
            this.numericBoxRows.Margin = new System.Windows.Forms.Padding(2);
            this.numericBoxRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericBoxRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericBoxRows.Name = "numericBoxRows";
            this.numericBoxRows.Size = new System.Drawing.Size(45, 22);
            this.numericBoxRows.TabIndex = 1;
            this.numericBoxRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBoxRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericBoxRows.ValueChanged += new System.EventHandler(this.boardSizeBox_ValueChanged);
            // 
            // StartGameButton
            // 
            this.StartGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartGameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGameButton.Location = new System.Drawing.Point(99, 313);
            this.StartGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(141, 37);
            this.StartGameButton.TabIndex = 3;
            this.StartGameButton.Text = "Start!";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Reverse Tic-Tac-Toe Game\r\nDo Not Complete a line!";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormGameSettings
            // 
            this.AcceptButton = this.StartGameButton;
            this.AccessibleDescription = "Set Players names and types, and choose board size";
            this.AccessibleName = "Game Settings Dialog";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 361);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.BoardSizeBox);
            this.Controls.Add(this.PlayersBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.Text = "ToeTacTic: Game Settings";
            this.PlayersBox.ResumeLayout(false);
            this.PlayersBox.PerformLayout();
            this.BoardSizeBox.ResumeLayout(false);
            this.BoardSizeBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoxCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoxRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox PlayersBox;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.GroupBox BoardSizeBox;
        private System.Windows.Forms.NumericUpDown numericBoxCols;
        private System.Windows.Forms.NumericUpDown numericBoxRows;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Label label5;
    }
}