using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class GameController
    {
        private const int k_MinBoardSize = 3;
        private const int k_MaxBoardSize = 9;
        private static Player[] players = new Player[2];
        private static GameModel m_GameModel;
        internal static bool m_isKillSigRaised = false;
        
        public static void Main()
        {
            runGame();
        }

        private static void runGame()
        {
            GameUI.DrawInitScreen();
            int boardSize = getBoardSizeFromUser();
            m_GameModel = new GameModel(boardSize);
            setPlayersStrategy();


            while (!m_isKillSigRaised)
            {
                runMiniGame();
            }

            /// TODO:
            /// Ask if rematch or quit.
            /// if remach -> m_GameModel.reset();
            ///         runMiniGame();
            /// else: MESIBA
        }

        private static void runMiniGame()
        {
            bool isMiniGameEnd = false;
                  
            while (!m_isKillSigRaised || isMiniGameEnd)
            {
                Player currentPlayer = players[m_GameModel.GetTurnsPlayed() % players.Length];
                
                switch (currentPlayer.m_Strategy)
                {
                    case Player.eStrategy.AIStrategy:
                        /// except for Tuple<int, int> GetNextMove From AIStrategy (as coordinate)
                        break;
                    case Player.eStrategy.ManualStrategy:
                        /// except for Tuple<int, int> GetNextMove From User, using UI (as coordinate)
                        break;
                }
                
                GameUI.DrawBoard(m_GameModel.GetGameRepresentation());

                switch (m_GameModel.GetGameState())
                {
                    case GameModel.eGameStatus.InProgress:
                        break;
                    case GameModel.eGameStatus.Win:
                        Player winner = players[m_GameModel.GetTurnsPlayed() % players.Length];
                        winner.m_Score++;
                        isMiniGameEnd = true;
                        break;
                    case GameModel.eGameStatus.Tie:
                        isMiniGameEnd = true;
                        break;
                }
            }
        }

        private static int getBoardSizeFromUser()
        {
            int boardSize = 0;
            bool isParseSuccess = false;

            while (!isParseSuccess && !m_isKillSigRaised)
            {
                string userInputString = GameUI.GetBoardSizeFromUser();

                isParseSuccess = int.TryParse(userInputString, out boardSize);
                isParseSuccess &= (k_MinBoardSize <= boardSize) && (boardSize <= k_MaxBoardSize);
            }

            return boardSize;
        }

        private static string getOpponentStrategyFromUser()
        {
            string opponentStrategy = null;

            while ((opponentStrategy != "0" | opponentStrategy != "1") && !m_isKillSigRaised)
            { 
                opponentStrategy = GameUI.GetOpponentStrategy();
            }

            return opponentStrategy;
        }

        private static void setPlayersStrategy()
        {
            string opponentUserChoice = getOpponentStrategyFromUser();
            Player.eStrategy opponentStrategy = Player.eStrategy.ManualStrategy;
            if (opponentUserChoice == "0")
            {
                opponentStrategy = Player.eStrategy.AIStrategy;
            }

            players[0] = new Player(Player.eStrategy.ManualStrategy);
            players[1] = new Player(opponentStrategy);
        }
    }    
}
