using System.Linq;
using System.Collections.Generic;

namespace GameLogic.GameUtils
{
    internal class GameStatusChecker
    {
        internal enum eGameStatus
        {
            Empty,
            InProgress,
            Tie,
            Player1Won,
            Player2Won
        }

        private static List<BoardEntry> s_LosingStreak = new List<BoardEntry>();

        internal static eGameStatus GetGameStatus(GameBoard i_GameBoard, GameMove i_LastMovePlayed)
        {
            eGameStatus currentStatus = eGameStatus.InProgress;

            checkForLosingStreak(i_GameBoard, i_LastMovePlayed);
            if (s_LosingStreak.Count() > 0)
            {
                if (s_LosingStreak.Last().Player.PlayerSymbol == Player.ePlayerSymbol.PlayerOne)
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

        internal static List<BoardEntry> GetLosingStreak()
        {
            return s_LosingStreak;
        }

        internal static bool CheckIfOnMainDiagonal(GameMove i_GameMove)
        {
            return i_GameMove.RowIndex == i_GameMove.ColumnIndex;
        }

        internal static bool CheckIfOnCounterDiagonal(int i_GameBoardSize, GameMove i_GameMove)
        {
            return i_GameMove.RowIndex + i_GameMove.ColumnIndex == i_GameBoardSize - 1;
        }

        private static bool checkForLosingStreak(GameBoard i_GameBoard,
            GameMove i_LastMovePlayed)
        {
            bool hasWinner = false;

            if (CheckIfOnMainDiagonal(i_LastMovePlayed) == true)
            {
                IEnumerable<BoardEntry> diagonalElements = i_GameBoard.GetMainDiagonalIterator();

                hasWinner |= checkForStreak(diagonalElements);
            }

            if (!hasWinner && CheckIfOnCounterDiagonal(i_GameBoard.BoardSize, i_LastMovePlayed) == true)
            {
                IEnumerable<BoardEntry> counterDiagonalElements = i_GameBoard.GetCounterDiagonalIterator();

                hasWinner |= checkForStreak(counterDiagonalElements);
            }

            if (!hasWinner)
            {
                IEnumerable<BoardEntry> columnElements = i_GameBoard.GetColumnIterator(i_LastMovePlayed.ColumnIndex);

                hasWinner |= checkForStreak(columnElements);
            }

            if (!hasWinner)
            {
                IEnumerable<BoardEntry> rowElements = i_GameBoard.GetRowIterator(i_LastMovePlayed.RowIndex);

                checkForStreak(rowElements);
            }

            return hasWinner;
        }

        private static bool checkForStreak(IEnumerable<BoardEntry> i_BoardEntryIterator)
        {
            bool isStrike = true;

            foreach (BoardEntry entry in i_BoardEntryIterator)
            {
                if (s_LosingStreak.Count == 0)
                {
                    s_LosingStreak.Add(entry);
                }

                isStrike &= s_LosingStreak.Last().Player.PlayerSymbol == entry.Player.PlayerSymbol;
                if (isStrike)
                {
                    s_LosingStreak.Add(entry);
                }
                else
                {
                    s_LosingStreak.Clear();
                    break;
                }
            }

            return isStrike;
        }
    }
}
