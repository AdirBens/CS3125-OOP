using GameLogic.GameUtils;
using System.Linq;
using System;

namespace GameLogic.AIStrategy
{
    internal class RandomMoves
    {
        internal static GameMove GetMove(Player i_ComputerPlayer, GameBoard i_GameBoard)
        {
            BoardEntry[] emptyEntries = i_GameBoard.GetEmptyCellsIterator().ToArray();
            BoardEntry chosenEntry = getRandomEntry(emptyEntries);

            return new GameMove(i_ComputerPlayer, chosenEntry.RowIndex, chosenEntry.ColumnIndex);
        }

        private static BoardEntry getRandomEntry(BoardEntry[] i_AvailableEntries)
        {
            Random rnd = new Random();
            int entryIndex = rnd.Next(i_AvailableEntries.Length);

            return i_AvailableEntries[entryIndex];
        }
    }
}
