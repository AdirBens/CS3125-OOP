using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Need to think about Coordinate object: is Tuple<int, int> sufficient? 
///                                         maybe need to use namedTuple? or a propiretry object?
/// checkIfOccupied ??? 


namespace TicTacToe
{
    internal class Board
    {
        [Flags]
        internal enum ePlayerSymbol
        {
            Empty,
            PlayerOneSymbol,
            PlayerTwoSymbol
        }
       

        private ePlayerSymbol[,] m_Board;
        private int m_NumEmptyEntries;
      
        internal Board(int i_Size)
        {
            m_Board = new ePlayerSymbol[i_Size, i_Size];
            m_NumEmptyEntries = i_Size * i_Size;
        }


        /// Change to GetLastMove
        internal IEnumerable<ePlayerSymbol> GetBoardIterator()
        {
            foreach(ePlayerSymbol boardEntry in m_Board)
            {
                yield return boardEntry;
            }
        }

        internal bool SetEntry(ePlayerSymbol i_PlayerEntry, Tuple<int, int> i_Coordinate)
        {
            /// check if coords in board range
            bool isFreeToSet = !checkIfOccupied(i_Coordinate);
            if(isFreeToSet)
            {
                m_Board.SetValue(i_PlayerEntry, i_Coordinate.Item1, i_Coordinate.Item2);
                m_NumEmptyEntries--;
            }
            
            return isFreeToSet;
        }

        internal ePlayerSymbol GetEntry(Tuple<int, int> i_Coordinate)
        {
            return m_Board[i_Coordinate.Item1, i_Coordinate.Item2];
        }

        internal bool IsFull()
        {
            return m_NumEmptyEntries == 0;
        }

        internal void ClearBoard()
        {
        }

        private bool checkIfOccupied(Tuple<int, int> i_Coordinate)
        {
            return !(m_Board[i_Coordinate.Item1, i_Coordinate.Item2] == ePlayerSymbol.Empty);
        }
    }
}
