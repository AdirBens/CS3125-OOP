using System;
using System.Linq;
using System.Collections.Generic;

using GameUtils;

namespace AIStrategy
{
    public class RandomMoves
    {
        public static (int row, int col) GetAIMove(GameBoard i_GameBoard)
        {
            BoardEntry[] emptyEntries = getEmptyEntriesArray(i_GameBoard);

            Random rnd = new Random();
            int entryIndex = rnd.Next(emptyEntries.Length);
            BoardEntry chosenEntry = emptyEntries[entryIndex];

            return (chosenEntry.m_Row, chosenEntry.m_Col);
        }

        private static BoardEntry[] getEmptyEntriesArray(GameBoard i_GameBoard)
        {
            IEnumerable<BoardEntry> emptyEntries = i_GameBoard.GetEmptyCellsIterator();

            return emptyEntries.ToArray();
        }
    }
}
