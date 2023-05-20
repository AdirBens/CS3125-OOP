/// ADiR?

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class GameModel
    {
        internal enum eGameStatus
        { 
            InProgress,
            Tie,
            Win
        }

        private Board m_GameBoard;
        private Board.ePlayerSymbol[] m_Players;    /// If player is object, it has score attribute
        private int m_TurnsPlayed = 0;             /// need to implement getter ??????!!!!!!! and change amodifier to private hopefully

        private (Board.ePlayerSymbol, int, int) m_lastMovePlayed;

        internal GameModel(int i_BoardSize)
        {
            m_GameBoard = new Board(i_BoardSize);
        }
        
        internal bool PlayMove(Board.ePlayerSymbol i_PlayerSymbol, Tuple<int, int> i_Coordinate)
        {
            bool isMoveValid = m_GameBoard.SetEntry(i_PlayerSymbol, i_Coordinate);
            
            if (isMoveValid)
            {
                m_TurnsPlayed++;
            }
            return isMoveValid;
        }

        internal eGameStatus GetGameState()
        {
            /// Can be optimized if we store the last coordinate modified ...

            /// 1. check for diag's
            /// 2. check for rows
            /// 3. check for cols
            /// 4. check if board is full
            /// 
            return eGameStatus.InProgress;
        }


        internal Board.ePlayerSymbol[,,] GetGameRepresentation()
        {
            /// 3D Array represents the game board, the 3rd dim is for marking victories?
            return null;
        }

        internal int GetTurnsPlayed()
        {
            return m_TurnsPlayed;
        }

        internal void Reset()
        {

        }
    }
}
