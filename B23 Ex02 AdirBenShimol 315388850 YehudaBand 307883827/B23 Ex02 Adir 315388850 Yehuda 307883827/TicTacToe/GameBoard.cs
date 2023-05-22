﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameBoard
    {
        private BoardEntry[,] m_Board;
        private int m_NumEmptyEntries;

        public class BoardEntry
        {
            public enum eEntrySymbol
            {
                Empty,
                PlayerOneSymbol,
                PlayerTwoSymbol
            }

            public int m_Row
            {
                get;
                private set;
            }
            public int m_Col
            {
                get;
                private set;
            }

            public eEntrySymbol m_Symbol
            {
                get;
                internal set;
            }

            internal BoardEntry(eEntrySymbol i_EntrySymbol, int i_Row, int i_Col)
            {
                m_Row = i_Row;
                m_Col = i_Col;
                m_Symbol = i_EntrySymbol;
            }

            internal bool CheckIfOccupied()
            {
                return !(m_Symbol == eEntrySymbol.Empty);
            }
        }

        public int m_BoardSize
        {
            get;
            private set;
        }

        internal GameBoard(int i_Size)
        {
            m_Board = new BoardEntry[i_Size, i_Size];
            m_BoardSize = i_Size;
            m_NumEmptyEntries = i_Size * i_Size;
            initBoard(i_Size);
        }

        public BoardEntry GetBoardEntry(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col];
        }

        internal bool SetEntry(BoardEntry.eEntrySymbol i_PlayerEntry, (int row, int column) i_Coordinate)
        {
            bool isFreeToSet = false;
            if (i_Coordinate.column <= m_BoardSize && i_Coordinate.row <= m_BoardSize)
            {
                BoardEntry entryToSet = m_Board[i_Coordinate.row, i_Coordinate.column];
                isFreeToSet = !(entryToSet.CheckIfOccupied());

                if (isFreeToSet)
                {
                    entryToSet.m_Symbol = i_PlayerEntry;
                    m_NumEmptyEntries--;
                }
            }

            return isFreeToSet;
        }
        internal bool CheckIfFull()
        {
            return m_NumEmptyEntries == 0;
        }

        /// internal BoardEntry GetEntry((int row, int column) i_Coordinate)
        ///{
        ///return m_Board[i_Coordinate.row, i_Coordinate.column];
        ///}

        internal void ClearBoard()
        {
            initBoard(m_BoardSize);
            m_NumEmptyEntries = m_BoardSize * m_BoardSize;
        }

        private void initBoard(int i_BoardSize)
        {
            for (int row = 0; row < i_BoardSize; row++)
            {
                for (int col = 0; col < i_BoardSize; col++)
                {
                    m_Board[row, col] = new BoardEntry(BoardEntry.eEntrySymbol.Empty, row, col);
                }
            }
        }

        internal IEnumerable<BoardEntry> GetMainDiagonalIterator()
        {
            for (int row = 0; row < m_BoardSize; row++)
            {
                int col = row;
                yield return m_Board[row, col];
            }
        }

        internal IEnumerable<BoardEntry> GetCounterDiagonalIterator()
        {
            for (int col = m_BoardSize - 1; col >= 0; col--)
            {
                int row = m_BoardSize - 1 - col;
                yield return m_Board[row, col];
            }
        }

        internal IEnumerable<BoardEntry> GetColumnIterator(int i_ColumnNumber)
        {
            for (int row = 0; row < m_BoardSize; row++)
            {
                yield return m_Board[row, i_ColumnNumber];
            }
        }

        internal IEnumerable<BoardEntry> GetRowIterator(int i_RowNumber)
        {
            for (int col = 0; col < m_BoardSize; col++)
            {
                yield return m_Board[i_RowNumber, col];
            }
        }
    }
}
