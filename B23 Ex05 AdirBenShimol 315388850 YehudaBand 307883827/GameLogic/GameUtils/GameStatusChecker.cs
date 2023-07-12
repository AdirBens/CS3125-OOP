using System.Linq;
using System.Collections.Generic;

namespace GameLogic.GameUtils
{
    public class GameStatusChecker
    {
        public enum eGameStatus
        {
            Empty,
            InProgress,
            Tie,
            Win,
            Player1Won,
            Player2Won
        }

        private static List<BoardEntry> s_WinningStreak = new List<BoardEntry>();

        public static eGameStatus GetGameStatus(GameBoard i_GameBoard, (int row, int col) i_LastMovePlayed)
        {
            eGameStatus currentStatus = eGameStatus.InProgress;

            checkForWinningStreak(i_GameBoard, i_LastMovePlayed);

            if (s_WinningStreak.Count() > 0)
            {
                if (s_WinningStreak.Last().m_Player.m_Symbol == Player.ePlayerSymbol.PlayerOne)
                {
                    currentStatus = eGameStatus.Player2Won;
                }
                else
                {
                    currentStatus = eGameStatus.Player1Won;
                }
            }
            else if (i_GameBoard.CheckIfBoardFull() == true)
            {
                currentStatus = eGameStatus.Tie;
            }

            return currentStatus;
        }

        public static List<BoardEntry> GetWinningStreak()
        {
            return s_WinningStreak;
        }

        public static bool IsStatusTerminal(eGameStatus i_GameStatus)
        {
            return i_GameStatus == eGameStatus.Tie |
                   i_GameStatus == eGameStatus.Player1Won |
                   i_GameStatus == eGameStatus.Player2Won;
        }

        private static bool checkForWinningStreak(GameBoard i_GameBoard,
            (int row, int col) i_LastMovePlayed)
        {
            bool hasWinner = false;

            if (CheckIfOnMainDiagonal(i_LastMovePlayed) == true)
            {
                IEnumerable<BoardEntry> diagonalElements = i_GameBoard.GetMainDiagonalIterator();
                hasWinner |= checkForStreak(diagonalElements);
            }
            if (!hasWinner && CheckIfOnCounterDiagonal(i_GameBoard.m_BoardSize, i_LastMovePlayed) == true)
            {
                IEnumerable<BoardEntry> counterDiagonalElements = i_GameBoard.GetCounterDiagonalIterator();
                hasWinner |= checkForStreak(counterDiagonalElements);
            }
            if (!hasWinner)
            {
                IEnumerable<BoardEntry> columnElements = i_GameBoard.GetColumnIterator(i_LastMovePlayed.col);
                hasWinner |= checkForStreak(columnElements);
            }
            if (!hasWinner)
            {
                IEnumerable<BoardEntry> rowElements = i_GameBoard.GetRowIterator(i_LastMovePlayed.row);
                checkForStreak(rowElements);
            }

            return hasWinner;
        }

        private static bool checkForStreak(IEnumerable<BoardEntry> i_BoardEntryIterator)
        {
            bool isStrike = true;

            foreach (BoardEntry entry in i_BoardEntryIterator)
            {
                if (s_WinningStreak.Count == 0)
                {
                    s_WinningStreak.Add(entry);
                }

                isStrike &= s_WinningStreak.Last().m_Player.m_Symbol == entry.m_Player.m_Symbol;
                if (isStrike)
                {
                    s_WinningStreak.Add(entry);
                }
                else
                {
                    s_WinningStreak.Clear();
                    break;
                }
            }

            return isStrike;
        }

        public static bool CheckIfOnMainDiagonal((int row, int col) i_Coordinate)
        {
            return i_Coordinate.row == i_Coordinate.col;
        }

        public static bool CheckIfOnCounterDiagonal(int i_GameBoardSize, (int row, int col) i_Coordinate)
        {
            return i_Coordinate.row + i_Coordinate.col == i_GameBoardSize - 1;
        }
    }
}
