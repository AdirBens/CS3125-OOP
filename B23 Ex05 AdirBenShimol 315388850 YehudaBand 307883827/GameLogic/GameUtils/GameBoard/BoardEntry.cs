namespace GameLogic.GameUtils
{
    public struct BoardEntry
    {
        public int RowIndex
        {
            get; private set;
        }

        public int ColumnIndex
        {
            get; private set;
        }

        public Player Player
        {
            get; internal set;
        }

        public BoardEntry(Player i_Player, int i_Row, int i_Col)
        {
            Player = i_Player;
            RowIndex = i_Row;
            ColumnIndex = i_Col;
        }
    }
}
