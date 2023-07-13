namespace GameGUI
{
    partial class FormGameBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameBoard));
            this.BoardTitle = new System.Windows.Forms.Label();
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.Player1Name = new System.Windows.Forms.Label();
            this.Player1Score = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.Player2Score = new System.Windows.Forms.Label();
            this.ScoreBox = new System.Windows.Forms.GroupBox();
            this.OSymbol = new System.Windows.Forms.Label();
            this.XSymbol = new System.Windows.Forms.Label();
            this.ScoreBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoardTitle
            // 
            this.BoardTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoardTitle.AutoSize = true;
            this.BoardTitle.Font = new System.Drawing.Font("Kristen ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoardTitle.Location = new System.Drawing.Point(130, 20);
            this.BoardTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BoardTitle.Name = "BoardTitle";
            this.BoardTitle.Size = new System.Drawing.Size(245, 29);
            this.BoardTitle.TabIndex = 1;
            this.BoardTitle.Text = "Reverse Tic-Tac-Toe";
            this.BoardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BoardPanel
            // 
            this.BoardPanel.AutoSize = true;
            this.BoardPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BoardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoardPanel.Location = new System.Drawing.Point(19, 71);
            this.BoardPanel.Margin = new System.Windows.Forms.Padding(35, 35, 70, 70);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Padding = new System.Windows.Forms.Padding(10);
            this.BoardPanel.Size = new System.Drawing.Size(22, 22);
            this.BoardPanel.TabIndex = 3;
            // 
            // Player1Name
            // 
            this.Player1Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Player1Name.AutoSize = true;
            this.Player1Name.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Name.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Player1Name.Location = new System.Drawing.Point(60, 20);
            this.Player1Name.Margin = new System.Windows.Forms.Padding(0);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(121, 19);
            this.Player1Name.TabIndex = 4;
            this.Player1Name.Text = "Player 1      :";
            this.Player1Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Player1Score
            // 
            this.Player1Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Player1Score.AutoSize = true;
            this.Player1Score.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Score.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Player1Score.Location = new System.Drawing.Point(187, 20);
            this.Player1Score.Margin = new System.Windows.Forms.Padding(0);
            this.Player1Score.Name = "Player1Score";
            this.Player1Score.Size = new System.Drawing.Size(19, 19);
            this.Player1Score.TabIndex = 5;
            this.Player1Score.Text = "0";
            this.Player1Score.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Player2Name
            // 
            this.Player2Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Player2Name.AutoSize = true;
            this.Player2Name.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Name.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Player2Name.Location = new System.Drawing.Point(295, 20);
            this.Player2Name.Margin = new System.Windows.Forms.Padding(0);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(121, 19);
            this.Player2Name.TabIndex = 6;
            this.Player2Name.Text = "Player 2      :";
            this.Player2Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Player2Score
            // 
            this.Player2Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Player2Score.AutoSize = true;
            this.Player2Score.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Score.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Player2Score.Location = new System.Drawing.Point(422, 20);
            this.Player2Score.Margin = new System.Windows.Forms.Padding(0);
            this.Player2Score.Name = "Player2Score";
            this.Player2Score.Size = new System.Drawing.Size(19, 19);
            this.Player2Score.TabIndex = 7;
            this.Player2Score.Text = "0";
            this.Player2Score.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScoreBox
            // 
            this.ScoreBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoreBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ScoreBox.Controls.Add(this.OSymbol);
            this.ScoreBox.Controls.Add(this.XSymbol);
            this.ScoreBox.Controls.Add(this.Player1Name);
            this.ScoreBox.Controls.Add(this.Player2Score);
            this.ScoreBox.Controls.Add(this.Player1Score);
            this.ScoreBox.Controls.Add(this.Player2Name);
            this.ScoreBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreBox.Location = new System.Drawing.Point(0, 336);
            this.ScoreBox.Margin = new System.Windows.Forms.Padding(35);
            this.ScoreBox.Name = "ScoreBox";
            this.ScoreBox.Padding = new System.Windows.Forms.Padding(0);
            this.ScoreBox.Size = new System.Drawing.Size(491, 52);
            this.ScoreBox.TabIndex = 8;
            this.ScoreBox.TabStop = false;
            this.ScoreBox.Text = "Score:";
            // 
            // OSymbol
            // 
            this.OSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OSymbol.AutoSize = true;
            this.OSymbol.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSymbol.ForeColor = System.Drawing.Color.Crimson;
            this.OSymbol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OSymbol.Location = new System.Drawing.Point(271, 20);
            this.OSymbol.Margin = new System.Windows.Forms.Padding(0);
            this.OSymbol.Name = "OSymbol";
            this.OSymbol.Size = new System.Drawing.Size(22, 19);
            this.OSymbol.TabIndex = 9;
            this.OSymbol.Text = "O";
            this.OSymbol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // XSymbol
            // 
            this.XSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.XSymbol.AutoSize = true;
            this.XSymbol.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XSymbol.ForeColor = System.Drawing.Color.RoyalBlue;
            this.XSymbol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.XSymbol.Location = new System.Drawing.Point(43, 20);
            this.XSymbol.Margin = new System.Windows.Forms.Padding(0);
            this.XSymbol.Name = "XSymbol";
            this.XSymbol.Size = new System.Drawing.Size(20, 19);
            this.XSymbol.TabIndex = 8;
            this.XSymbol.Text = "X";
            this.XSymbol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormGameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(491, 388);
            this.Controls.Add(this.ScoreBox);
            this.Controls.Add(this.BoardPanel);
            this.Controls.Add(this.BoardTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "FormGameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tow-Tac-Tic";
            this.ScoreBox.ResumeLayout(false);
            this.ScoreBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BoardTitle;
        private System.Windows.Forms.Panel BoardPanel;
        private System.Windows.Forms.Label Player1Name;
        private System.Windows.Forms.Label Player1Score;
        private System.Windows.Forms.Label Player2Name;
        private System.Windows.Forms.Label Player2Score;
        private System.Windows.Forms.GroupBox ScoreBox;
        private System.Windows.Forms.Label OSymbol;
        private System.Windows.Forms.Label XSymbol;
    }
}