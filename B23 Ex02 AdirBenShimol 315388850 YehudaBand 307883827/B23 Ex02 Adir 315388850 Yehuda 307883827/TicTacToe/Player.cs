using static TicTacToe.GameEngine;

namespace TicTacToe
{
    public class Player
    {

        public enum ePlayerStrategy
        {
            Empty,
            Human,
            AIStrategy
        }

        public ePlayerStrategy m_Strategy
        {
            get; private set;
        }
        public GameBoard.BoardEntry.eEntrySymbol m_Symbol
        {
            get; private set;
        }

        public int m_Score
        {
            get; internal set;
        }

        public Player(GameBoard.BoardEntry.eEntrySymbol i_Symbol, ePlayerStrategy i_Strategy)
        {
            m_Symbol = i_Symbol;
            m_Strategy = i_Strategy;
            m_Score = 0;
        }
    }
}
