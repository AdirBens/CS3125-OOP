using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace GameGUI
{
    public class Program
    {
        public static void Main()
        {
            GameEngine gameEngine = new GameEngine();
            
            RunGame();
        }

        private static void RunGame()
        {
            FormGameSettings settings = new FormGameSettings();
            settings.ShowDialog();

            FormGameBoard gameBoard = new FormGameBoard(settings);
            gameBoard.ShowDialog();
        }
    }
}
