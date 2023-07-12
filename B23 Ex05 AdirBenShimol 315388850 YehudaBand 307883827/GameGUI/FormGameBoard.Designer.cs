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
            this.label1 = new System.Windows.Forms.Label();
            this.Player1Name = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.Player1Score = new System.Windows.Forms.Label();
            this.Player2Score = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GameBoardPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reverse Tic-Tac-Toe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player1Name
            // 
            this.Player1Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player1Name.AutoSize = true;
            this.Player1Name.Location = new System.Drawing.Point(131, 502);
            this.Player1Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(48, 13);
            this.Player1Name.TabIndex = 2;
            this.Player1Name.Text = "Player 1:";
            // 
            // Player2Name
            // 
            this.Player2Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player2Name.AutoSize = true;
            this.Player2Name.Location = new System.Drawing.Point(266, 502);
            this.Player2Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(48, 13);
            this.Player2Name.TabIndex = 3;
            this.Player2Name.Text = "Player 2:";
            // 
            // Player1Score
            // 
            this.Player1Score.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player1Score.AutoSize = true;
            this.Player1Score.Location = new System.Drawing.Point(183, 502);
            this.Player1Score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Player1Score.Name = "Player1Score";
            this.Player1Score.Size = new System.Drawing.Size(27, 13);
            this.Player1Score.TabIndex = 4;
            this.Player1Score.Text = "P1S";
            // 
            // Player2Score
            // 
            this.Player2Score.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player2Score.AutoSize = true;
            this.Player2Score.Location = new System.Drawing.Point(316, 502);
            this.Player2Score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Player2Score.Name = "Player2Score";
            this.Player2Score.Size = new System.Drawing.Size(27, 13);
            this.Player2Score.TabIndex = 5;
            this.Player2Score.Text = "P2S";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "It\'s Player Turn ...";
            // 
            // GameBoardPanel
            // 
            this.GameBoardPanel.AutoSize = true;
            this.GameBoardPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GameBoardPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GameBoardPanel.Location = new System.Drawing.Point(70, 90);
            this.GameBoardPanel.Margin = new System.Windows.Forms.Padding(21, 21, 21, 21);
            this.GameBoardPanel.MinimumSize = new System.Drawing.Size(335, 326);
            this.GameBoardPanel.Name = "GameBoardPanel";
            this.GameBoardPanel.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.GameBoardPanel.Size = new System.Drawing.Size(335, 326);
            this.GameBoardPanel.TabIndex = 7;
            // 
            // FormGameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(489, 524);
            this.Controls.Add(this.GameBoardPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Player2Score);
            this.Controls.Add(this.Player1Score);
            this.Controls.Add(this.Player2Name);
            this.Controls.Add(this.Player1Name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormGameBoard";
            this.Text = "Tow-Tac-Tic";
            this.Load += new System.EventHandler(this.FormGameBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Player1Name;
        private System.Windows.Forms.Label Player2Name;
        private System.Windows.Forms.Label Player1Score;
        private System.Windows.Forms.Label Player2Score;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel GameBoardPanel;
    }
}