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

        internal void UpdatePlayersScore(int[] i_PlayersScore)
        {
            Player1Score.Text = i_PlayersScore[0].ToString();
            Player2Score.Text = i_PlayersScore[1].ToString();
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
            OnGameTurnPlayed(sender);
        }

        private void rematchOK_Click(object sender, EventArgs e)
        {
            OnRematchRequested();
        }

        private void OnGameTurnPlayed(object sender)
        {
            BoardEntryBtn chosenEntry = (sender as BoardEntryBtn);
            (int row, int col) coordinate = (chosenEntry.RowIndex, chosenEntry.ColumnIndex);
            
            GameTurnPlayed?.Invoke(coordinate);
        }

        private void OnRematchRequested()
        {
            RematchGameRequested?.Invoke();
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

        internal void HighlighStreak(List<BoardEntry> i_StreakEntries)
        {
            foreach (BoardEntry entry in i_StreakEntries)
            {
                r_Board[entry.m_Row, entry.m_Col].HighlightEntry();
            }
        }

        internal void ShowTerminalDialog(string i_Message)
        {
            switch (GuiUtils.ShowQuestionDialog(i_Message, UIStrings.k_GameEndDialogCaption))
            {
                case DialogResult.Yes:
                    rematchOK_Click(this, null);
                    break;
                case DialogResult.No:
                    Close();
                    break;
            }
        }

        internal void ShowTerminalDialog(ePlayerSymbol i_WinnerSymbol)
        {
            string winnerName = i_WinnerSymbol == ePlayerSymbol.PlayerOne ? Player1Name.Text : Player2Name.Text;

            ShowTerminalDialog(string.Format(UIStrings.k_WinMessage, winnerName.Replace(":", string.Empty)));
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

        private void alignAllLabels()
        {
            GuiUtils.HorizontalCentralizeObject(this, BoardPanel);
            GuiUtils.HorizontalCentralizeObject(this, BoardTitle);
            alignScoreBar();
        }

        private void alignScoreBar()
        {
            int baseMargin = 5;
            int marginBetweenPlayers = 4 * baseMargin;
            List<Control> scoreControls = new List<Control>()
            {
                XSymbol, Player1Name, Player1Score,
                OSymbol, Player2Name, Player2Score
            };

            int totalWidth = GuiUtils.CalcTotalWidth(scoreControls) + scoreControls.Count * baseMargin + marginBetweenPlayers;            
            int yOffset = Player1Name.Location.Y;
            int xOffset = (ScoreBox.Width - totalWidth) / 2;

            XSymbol.Location = new Point(xOffset, yOffset);
            GuiUtils.AlignToRightOf(Player1Name, XSymbol);
            GuiUtils.AlignToRightOf(Player1Score, Player1Name);
            GuiUtils.AlignToRightOf(OSymbol, Player1Score, marginBetweenPlayers);
            GuiUtils.AlignToRightOf(Player2Name, OSymbol);
            GuiUtils.AlignToRightOf(Player2Score, Player2Name);
        }
    }
}
