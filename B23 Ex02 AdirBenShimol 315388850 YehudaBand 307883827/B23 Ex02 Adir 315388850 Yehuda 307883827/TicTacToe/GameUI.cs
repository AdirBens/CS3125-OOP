/// Jehudddddda

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class GameUI
    {
        private const string k_KillSignal = "Q";
        private const char k_PlayerOneSymbol = 'X';
        private const char k_PlayerTwoSymbol = 'O';
        private const char k_HorizontalBorder = '=';
        private const char k_VerticalBorder = '|';


        /// Excpect to get from the ADIR:
        ///   (Board.ePlayerSymbol, int, int) m_lastMovePlayed;

        internal static void DrawInitScreen()
        {
            StringBuilder a = new StringBuilder();
        }

        internal static void DrawBoard(Board.ePlayerSymbol[,,] i_Board)
        {

        }

        internal static Tuple<int, int> GetCoordinateFromUser()
        {
            return Tuple.Create(0, 0);
        }

        internal static string GetBoardSizeFromUser()
        {
            return "3";
        }

        internal static string GetOpponentStrategy()
        {
            /// Need do create enum of strategies
            return "1"; // 0 / 1 : 0==ManualStrategy, 1==AIStrategy
        }

        private static void raiseKillSignal()
        {
            GameController.m_isKillSigRaised = true;
        }

        private static string readInputLine()
        {
            string userInput = Console.ReadLine();
            if (userInput == k_KillSignal) 
            {
                raiseKillSignal();
            }
            return userInput;
        }
    }
}
