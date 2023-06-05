namespace GameUtils
{
    public struct Player
    {
        public enum ePlayerSymbol
        {
            Empty = 0,
            PlayerOne,
            PlayerTwo
        }

        public enum eStrategy
        {
            Empty = 0,
            HumanPlayer,
            AIPlayer
        }

        public ePlayerSymbol m_Symbol
        {
            get; internal set;
        }

        public eStrategy m_Strategy
        {
            get; internal set;
        }

        public Player(ePlayerSymbol i_Symbol, eStrategy i_Strategy)
        {
            m_Symbol = i_Symbol;
            m_Strategy = i_Strategy;
        }
    }
}
