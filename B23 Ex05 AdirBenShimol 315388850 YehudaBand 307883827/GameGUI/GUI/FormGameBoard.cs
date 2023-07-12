using GameGUI.GUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameGUI
{
    public partial class FormGameBoard : Form
    {
        private readonly BoardEntry[,] r_Board;

        public FormGameBoard(FormGameSettings i_GameSettings)
        {
            r_Board = new BoardEntry[i_GameSettings.BoardNumRows, i_GameSettings.BoardNumCols];

            InitializeComponent();
            setPlayersNames(i_GameSettings.Player1Name, i_GameSettings.Player2Name);
            setBoardLayout(i_GameSettings.BoardNumCols);
        }

        private void setBoardLayout(int i_BoardSize)
        {
            for (int row = 0; row < i_BoardSize; row++)
            {
                for (int col = 0; col < i_BoardSize; col++)
                {
                    r_Board[row, col] = new BoardEntry(row, col);
                    BoardPanel.Controls.Add(r_Board[row, col]);
                }
            }

            alignAllLabels();
        }

        private void setPlayersNames(string i_Player1Name, string i_Player2Name)
        {
            Player1Name.Text = string.Format("{0}:", i_Player1Name);
            Player2Name.Text = string.Format("{0}:", i_Player2Name);
        }

        private void updatePlayersScore(int i_Player1Score, int i_Player2Score)
        {

        }

        private void horizontalCentralizeObject(Control i_ControlObject)
        {
            i_ControlObject.Location = new Point((Width - i_ControlObject.Width) / 2, i_ControlObject.Location.Y);
        }

        private void alignAllLabels()
        {
            horizontalCentralizeObject(BoardPanel);
            horizontalCentralizeObject(BoardTitle);
            alignScoreBar();
        }

        private void alignScoreBar()
        {
            // TODO: make more accurate calc
            int yOffset = Player1Name.Location.Y;
            int baseMargin = 5;
            int totalWidth = Player1Name.Width + Player2Name.Width + 
                             Player1Score.Width + Player2Score.Width +
                             XSymbol.Width + OSymbol.Width + 12 * baseMargin;
            int xOffset = (ScoreBox.Width - totalWidth) / 2;

            XSymbol.Location = new Point(xOffset, yOffset);
            Player1Name.Location = new Point(XSymbol.Right + baseMargin, yOffset);
            Player1Score.Location = new Point(Player1Name.Right + 2 * baseMargin, yOffset);
            OSymbol.Location = new Point(Player1Score.Right + 6 * baseMargin, yOffset);
            Player2Name.Location = new Point(OSymbol.Right + baseMargin, yOffset);
            Player2Score.Location = new Point(Player2Name.Right + 2 * baseMargin, yOffset);
        }

        private void FormGameBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
