namespace GameLogic.GameUtils
{
    public struct BoardEntry
    {
        public int m_Row
        {
            get; private set;
        }

        public int m_Col
        {
            get; private set;
        }

        public Player m_Player
        {
            get; internal set;
        }

        public BoardEntry(Player i_Player, int i_Row, int i_Col)
        {
            m_Player = i_Player;
            m_Row = i_Row;
            m_Col = i_Col;
        }
    }
}
