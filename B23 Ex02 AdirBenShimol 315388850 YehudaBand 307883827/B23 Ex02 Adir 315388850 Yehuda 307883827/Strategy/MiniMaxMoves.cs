using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class MiniMaxMoves
    {

        public static (int row, int col) GetBestMove()
        {
            Random rnd = new Random();

            int col = rnd.Next(0, 3);
            int row = rnd.Next(0, 3);
            
            return (row, col);
        }
    }
}
