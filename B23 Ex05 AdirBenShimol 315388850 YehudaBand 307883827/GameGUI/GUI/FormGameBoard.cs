using GameGUI.GUI;
using GameLogic.GameUtils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static GameLogic.GameUtils.Player;

namespace GameGUI
{
    public partial class FormGameBoard : Form
    {
        private readonly BoardEntryBtn[,] r_Board;
        public event Action<(int row, int col)> GameTurnPlayed;
        public event Action RematchGameRequested;

        internal FormGameBoard(FormGameSettings i_GameSettings)
        {
            r_Board = new BoardEntryBtn[i_GameSettings.BoardSize, i_GameSettings.BoardSize];

            InitializeComponent();
            setPlayersNames(i_GameSettings.Player1Name, i_GameSettings.Player2Name);
            setBoardLayout(i_GameSettings.BoardSize);
        }

        private void setBoardLayout(int i_BoardSize)
        {
            for (int row = 0; row < i_BoardSize; row++)
            {
                for (int col = 0; col < i_BoardSize; col++)
                {
                    BoardEntryBtn newEntry = new BoardEntryBtn(row, col);
                    newEntry.Click += boardEntry_Click;
                    r_Board[row, col] = newEntry;
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

        internal void UpdatePlayersScore(int[] i_PlayersScore)
        {
            Player1Score.Text = i_PlayersScore[0].ToString();
            Player2Score.Text = i_PlayersScore[1].ToString();
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

        internal void ResetGameBoard()
        {
            foreach (BoardEntryBtn entry in r_Board)
            {
                entry.ResetEntry();
            }
        }

        private void boardEntry_Click(object sender, EventArgs e)
        {
            onGameTurnPlayed(sender);
        }

        private void onGameTurnPlayed(object sender)
        {
            BoardEntryBtn chosenEntry = (sender as BoardEntryBtn);
            (int row, int col) coordinate = (chosenEntry.RowIndex, chosenEntry.ColumnIndex);

            if (GameTurnPlayed != null)
            {
                GameTurnPlayed.Invoke(coordinate);
            }
        }

        private void rematchOK_Click(object sender, EventArgs e)
        {
            onRematchRequested();
        }

        private void onRematchRequested()
        {
            if (RematchGameRequested != null)
            {
                RematchGameRequested.Invoke();
            }
        }

        internal void UpdateGameBoard(BoardEntry[,] i_GameBoardState)
        {
            for (int i = 0; i <  r_Board.GetLength(0); i++)
            {
                for (int j = 0; j < r_Board.GetLength(1); j++)
                {
                    r_Board[i, j].UpdateEntry(i_GameBoardState[i, j].m_Player.m_Symbol);
                }
            }
        }

        internal void UpdateGameBoard((ePlayerSymbol symbol, int row, int col) i_LastMovePlayed)
        {
            r_Board[i_LastMovePlayed.row, i_LastMovePlayed.col].UpdateEntry(i_LastMovePlayed.symbol);
        }

        internal void HighlighStreak(List<BoardEntry> i_StreakEntries)
        {
            foreach (BoardEntry entry in i_StreakEntries)
            {
                r_Board[entry.m_Row, entry.m_Col].HighlightEntry();
            }
        }

        internal void ShowWinDialog(ePlayerSymbol i_Winner)
        {
            string winnerName = i_Winner == ePlayerSymbol.PlayerOne ? Player1Name.Text : Player2Name.Text;

            string message = string.Format(@"{0} has won the game!
Do you want to try another round?", winnerName.Replace(":", string.Empty));

            DialogResult toRematch = MessageBox.Show(message, "We have a Winner!", MessageBoxButtons.YesNo);

            if (toRematch == DialogResult.Yes)
            {
                rematchOK_Click(this, null);
            }
            else
            {
                Close();
            }
        }

        internal void ShowTieDialog()
        {
            string message = string.Format(@"It's a TIE!
Do you want to try another round?");

            DialogResult toRematch = MessageBox.Show(message, "It's a TIE!", MessageBoxButtons.YesNo);

            if (toRematch == DialogResult.Yes)
            {
                rematchOK_Click(this, null);
            }
            else
            {
                Close();
            }
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
    }
}
