using System;
using System.Collections.Generic;
using System.Linq;
using static TicTacToe.GameEngine;

namespace TicTacToe
{
    internal class GameStatusCheker
    {
        public static eGameStatus GetGameStatus(GameBoard i_GameBoard, GameBoard.BoardEntry i_lastMovePlayed, out List<GameBoard.BoardEntry> io_WinningStrike)
        {
            eGameStatus currentStatus = eGameStatus.InProgress;
            io_WinningStrike = new List<GameBoard.BoardEntry>();
            GameStatusCheker.CheckForWinningStrike(i_GameBoard, i_lastMovePlayed, io_WinningStrike);

            if (io_WinningStrike.Count() > 0)
            {
                currentStatus = eGameStatus.Win;
            }
            else if (i_GameBoard.CheckIfFull() == true)
            {
                currentStatus = eGameStatus.Tie;
            }

            return currentStatus;
        }

        private static List<GameBoard.BoardEntry> CheckForWinningStrike(GameBoard i_GameBoard, GameBoard.BoardEntry i_lastMovePlayed, List<GameBoard.BoardEntry> i_WinningStrike)
        {
            bool hasWinner = false;

            if (checkIfOnMainDiagonal(i_lastMovePlayed) == true)
            {
                IEnumerable<GameBoard.BoardEntry> diagonalElements = i_GameBoard.GetMainDiagonalIterator();
                hasWinner |= checkForStrike(diagonalElements, i_WinningStrike);
            }
            if (!hasWinner && checkIfOnCounterDiagonal(i_GameBoard.m_BoardSize, i_lastMovePlayed) == true)
            {
                IEnumerable<GameBoard.BoardEntry> counterDiagonalElements = i_GameBoard.GetCounterDiagonalIterator();
                hasWinner |= checkForStrike(counterDiagonalElements, i_WinningStrike);
            }
            if (!hasWinner)
            {
                IEnumerable<GameBoard.BoardEntry> columnElements = i_GameBoard.GetColumnIterator(i_lastMovePlayed.m_Col);
                hasWinner |= checkForStrike(columnElements, i_WinningStrike);
            }
            if (!hasWinner)
            {
                IEnumerable<GameBoard.BoardEntry> rowElements = i_GameBoard.GetRowIterator(i_lastMovePlayed.m_Row);
                checkForStrike(rowElements, i_WinningStrike);
            }

            return m_WinningStrike;
        }

        private static bool checkForStrike(IEnumerable<GameBoard.BoardEntry> i_BoardEntryIterator, List<GameBoard.BoardEntry> i_WinningStrike)
        {
            bool isStrike = true;

            foreach (GameBoard.BoardEntry entry in i_BoardEntryIterator)
            {
                if (m_WinningStrike.Count == 0)
                {
                    i_WinningStrike.Add(entry);
                }

                isStrike &= i_WinningStrike.Last().m_Symbol == entry.m_Symbol;
                if (isStrike)
                {
                    i_WinningStrike.Add(entry);
                }
                else
                {
                    i_WinningStrike.Clear();
                    break;
                }
            }
            return isStrike;
        }

        private static bool checkIfOnMainDiagonal(GameBoard.BoardEntry i_BoardEntry)
        {
            return i_BoardEntry.m_Row == i_BoardEntry.m_Col;
        }

        private static bool checkIfOnCounterDiagonal(int i_GameBoardSize, GameBoard.BoardEntry i_BoardEntry)
        {
            return i_BoardEntry.m_Row + i_BoardEntry.m_Col == i_GameBoardSize - 1;
        }
    }
}
