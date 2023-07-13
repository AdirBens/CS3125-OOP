using System.Collections.Generic;

namespace GameLogic.GameUtils
{
    public class GameBoard
    {
        private int m_NumEmptyEntries;
        private readonly Player r_VoidPlayer = new Player(Player.ePlayerSymbol.Empty, Player.eStrategy.Empty);
        public BoardEntry[,] m_Board
        {
            get; private set;
        }

        public int m_BoardSize
        {
            get; private set;
        }

        public GameBoard(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            m_Board = new BoardEntry[m_BoardSize, m_BoardSize];
            m_NumEmptyEntries = m_Board.Length;

            initializeBoard();
        }

        public bool SetEntry(Player i_Player, int i_Row, int i_Col)
        {
            bool isFreeToSet = false;

            if (isCoordinateOnBoardRange(i_Row, i_Col))
            {
                isFreeToSet = isEntryEmpty(i_Row, i_Col);

                if (isFreeToSet)
                {
                    m_Board[i_Row, i_Col].m_Player = i_Player;
                    m_NumEmptyEntries--;
                }
            }

            return isFreeToSet;
        }

        public bool CheckIfBoardFull()
        {
            return m_NumEmptyEntries == 0;
        }

        public void ClearBoard()
        {
            initializeBoard();
            m_NumEmptyEntries = m_Board.Length;
        }

        public IEnumerable<BoardEntry> GetMainDiagonalIterator()
        {
            for (int row = 0; row < m_BoardSize; row++)
            {
                int col = row;

                yield return m_Board[row, col];
            }
        }

        public IEnumerable<BoardEntry> GetCounterDiagonalIterator()
        {
            for (int col = m_BoardSize - 1; col >= 0; col--)
            {
                int row = m_BoardSize - 1 - col;

                yield return m_Board[row, col];
            }
        }

        public IEnumerable<BoardEntry> GetColumnIterator(int i_ColumnNumber)
        {
            for (int row = 0; row < m_BoardSize; row++)
            {
                yield return m_Board[row, i_ColumnNumber];
            }
        }

        public IEnumerable<BoardEntry> GetRowIterator(int i_RowNumber)
        {
            for (int col = 0; col < m_BoardSize; col++)
            {
                yield return m_Board[i_RowNumber, col];
            }
        }

        public IEnumerable<BoardEntry> GetEmptyCellsIterator()
        {
            foreach (BoardEntry entry in m_Board)
            {
                if (isEntryEmpty(entry.m_Row, entry.m_Col))
                {
                    yield return entry;
                }
            }
        }

        private void initializeBoard()
        {
            for (int row = 0; row < m_BoardSize; row++)
            {
                for (int col = 0; col < m_BoardSize; col++)
                {
                    m_Board[row, col] = new BoardEntry(r_VoidPlayer, row, col);
                }
            }
        }

        private bool isCoordinateOnBoardRange(int i_Row, int i_Col)
        {
            return i_Row < m_BoardSize &&
                   i_Col < m_BoardSize &&
                   i_Row >= 0 &&
                   i_Col >= 0;
        }

        private bool isEntryEmpty(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col].m_Player.m_Symbol == Player.ePlayerSymbol.Empty;
        }
    }
}
