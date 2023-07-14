namespace GameLogic.GameUtils
{
    public class Player
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
            ComputerPlayer
        }

        public ePlayerSymbol PlayerSymbol
        {
            get; internal set;
        }

        public eStrategy Strategy
        {
            get; internal set;
        }

        public int Score
        {
            get; internal set;
        }

        public Player(ePlayerSymbol i_Symbol = ePlayerSymbol.Empty, eStrategy i_Strategy = eStrategy.Empty)
        {
            PlayerSymbol = i_Symbol;
            Strategy = i_Strategy;
            Score = 0;
        }
    }
}
