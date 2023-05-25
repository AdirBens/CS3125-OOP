using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameUtils;

namespace UnitTests
{
    internal class Tester
    {
        private static List<BoardEntry> s_EmptyEntries;

        public static void Test()
        {
            GameEngine.GameEngine.SetBoardSize(3);
            GameEngine.GameEngine.GameResponse r = GameEngine.GameEngine.SetOpponentType(Player.eStrategy.HumanPlayer);
            IEnumerable<BoardEntry> it = r.mGameBoard.GetEmptyCellsIterator();

            listPrinter(it);
            r = GameEngine.GameEngine.SetNextMove((0, 2));
            it = r.mGameBoard.GetEmptyCellsIterator();
            Console.WriteLine();
            listPrinter(it);

            r = GameEngine.GameEngine.SetNextMove((2, 2));
            it = r.mGameBoard.GetEmptyCellsIterator();
            Console.WriteLine();
            listPrinter(it);
        }

        private static void listPrinter(IEnumerable<BoardEntry> list)
        {
            foreach (BoardEntry entry in list)
            {
                Console.WriteLine(entry.ToString());
            }
        }
    }
}
