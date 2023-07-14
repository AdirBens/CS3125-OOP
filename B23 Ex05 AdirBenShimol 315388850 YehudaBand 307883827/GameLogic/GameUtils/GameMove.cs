using static GameLogic.GameUtils.Player;

namespace GameLogic.GameUtils
{
    public struct GameMove
    {
        public int RowIndex
        {
            get; private set;
        }

        public int ColumnIndex
        {
            get; private set;
        }

        public ePlayerSymbol PlayerSymbol
        {
            get; private set;
        }

        public Player PlayerPerformed
        {
            get; private set;
        }

        public GameMove(Player i_Player, int i_RowIndex, int i_ColumnIndex)
        {
            PlayerPerformed = i_Player;
            PlayerSymbol = i_Player.PlayerSymbol;
            RowIndex = i_RowIndex;
            ColumnIndex = i_ColumnIndex;
        }
    }
}
