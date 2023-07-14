using System.Collections.Generic;

namespace GameLogic.GameUtils
{
    internal class GameBoard
    {
        private readonly Player r_VoidPlayer = new Player();
        private int m_NumEmptyEntries;
        internal BoardEntry[,] Board
        {
            get; private set;
        }

        internal int BoardSize
        {
            get; private set;
        }

        internal GameBoard(int i_BoardSize)
        {
            BoardSize = i_BoardSize;
            Board = new BoardEntry[BoardSize, BoardSize];
            m_NumEmptyEntries = Board.Length;

            initializeBoard();
        }

        internal bool SetEntry(GameMove i_GameMove)
        {
            bool isSetSuccess = false;

            if (isEntryEmpty(i_GameMove.RowIndex, i_GameMove.ColumnIndex))
            {
                Board[i_GameMove.RowIndex, i_GameMove.ColumnIndex].Player = i_GameMove.PlayerPerformed;
                m_NumEmptyEntries--;
                isSetSuccess = true;
            }
            
            return isSetSuccess;
        }

        internal bool CheckIfBoardFull()
        {
            return m_NumEmptyEntries == 0;
        }

        internal void ClearBoard()
        {
            initializeBoard();
            m_NumEmptyEntries = Board.Length;
        }

        internal IEnumerable<BoardEntry> GetMainDiagonalIterator()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                int col = row;

                yield return Board[row, col];
            }
        }

        internal IEnumerable<BoardEntry> GetCounterDiagonalIterator()
        {
            for (int col = BoardSize - 1; col >= 0; col--)
            {
                int row = BoardSize - 1 - col;

                yield return Board[row, col];
            }
        }

        internal IEnumerable<BoardEntry> GetColumnIterator(int i_ColumnNumber)
        {
            for (int row = 0; row < BoardSize; row++)
            {
                yield return Board[row, i_ColumnNumber];
            }
        }

        internal IEnumerable<BoardEntry> GetRowIterator(int i_RowNumber)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                yield return Board[i_RowNumber, col];
            }
        }

        internal IEnumerable<BoardEntry> GetEmptyCellsIterator()
        {
            foreach (BoardEntry entry in Board)
            {
                if (isEntryEmpty(entry.RowIndex, entry.ColumnIndex))
                {
                    yield return entry;
                }
            }
        }

        private void initializeBoard()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    Board[row, col] = new BoardEntry(r_VoidPlayer, row, col);
                }
            }
        }

        private bool isEntryEmpty(int i_Row, int i_Col)
        {
            return Board[i_Row, i_Col].Player.PlayerSymbol == Player.ePlayerSymbol.Empty;
        }
    }
}
