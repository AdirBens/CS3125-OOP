using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Player
    {
        internal int m_Score
        {
            get;
            set;
        } = 0;

        internal eStrategy m_Strategy
        { 
            get;
        }

        internal enum eStrategy
        {
            AIStrategy,
            ManualStrategy
        }

        internal Player(eStrategy i_PlayerStrategy)
        {
            m_Strategy = i_PlayerStrategy;
        }
    }
}
