using Ex02.ConsoleUtiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameUI
    {
        internal static bool m_isKillSigRaised = false;

        private const string k_KillSignal = "Q";

        private const char k_PlayerOneSymbol = 'X';
        private const char k_PlayerTwoSymbol = 'O';

        private const char k_HorizontalBorder = '=';
        private const char k_VerticalBorder = '|';

        private static int scoreP1;
        private static int scoreP2;

        private static eOpponentStrategy chosenStrategy = eOpponentStrategy.Unknown;
        private static eGameState currentGameState = eGameState.Init;


        private enum eGameState
        {
            Init,
            InProgress,
            Win,
            Tie,
            End
        }

        public enum eOpponentStrategy
        {
            Unknown,
            CPU,
            Human
        }

        public static void Main()
        {
            runGame();
        }

        private static void runGame()
        {
            DrawInitScreen();
            while (!m_isKillSigRaised)
            {
                switch (currentGameState)
                {
                    case eGameState.Init:
                        int boardSize = getBoardSizeFromUser();
                        while (!GameEngine.setBoardSize(boardSize))
                        {
                            boardSize = getBoardSizeFromUser();
                            if (m_isKillSigRaised)
                            {
                                break;
                            }
                        }
                        chosenStrategy = getOpponentStrategyFromUser();
                        if (m_isKillSigRaised)
                            {
                                break;
                            }
                        currentGameState = eGameState.InProgress;
                        break;
                    case eGameState.InProgress:
                        runMiniGame();
                        break;
                    case eGameState.Win:
                        //win message
                        //another minigame? message
                        if (anotherGame)
                        {
                            currentGameState = eGameState.InProgress;
                        }
                        break;
                    case eGameState.Tie:
                        //tie message
                        //another minigame? message
                        if (anotherGame)
                        {
                            currentGameState = eGameState.InProgress;
                        }
                        else
                        {
                            currentGameState = eGameState.End;
                        }
                        break;
                    case eGameState.End: 
                        //Summary message and shutdown
                        break;
                }
            }


            /// TODO:
            /// Ask if rematch or quit.
            /// if remach -> m_GameModel.reset();
            ///         runMiniGame();
            /// else: MESIBA
        }
        internal static void DrawInitScreen()
        {
            Console.WriteLine("Welcome to the TicTacToe Reversed game!\nHit Q at any stage to quit the game");
        }

        private static int getBoardSizeFromUser()
        {
            int boardSize;

            string userInput = userInputRequest("Please enter a board size between 3 and 9:");
            bool isParseSuccess = int.TryParse(userInput, out boardSize);

            while (!isParseSuccess && !m_isKillSigRaised)
            {
                userInputRequest("Board size invalid! Please enter a valid board size:");
                isParseSuccess = int.TryParse(userInput, out boardSize);
            }
            Screen.clear();


            return boardSize;
        }

        private static eOpponentStrategy getOpponentStrategyFromUser()
        {
            eOpponentStrategy chosenOpponentStrategy = eOpponentStrategy.Unknown;

            userInputRequest("Please enter game type:\nH for human opponent and C for playing against the computer");
            string userInput = readInputLine();

            while (userInput != "H" && userInput != "C" && !m_isKillSigRaised)
            {
                userInput = userInputRequest("Input is invalid! please press H or C");
            }

            if (!m_isKillSigRaised)
            {
            chosenOpponentStrategy = (userInput == "H") ? eOpponentStrategy.Human : eOpponentStrategy.CPU; 
            }

            Screen.clear();
            return chosenOpponentStrategy;
        }

        private static void runMiniGame()
        {
            bool isMiniGameEnd = false;

            while (!m_isKillSigRaised || isMiniGameEnd)
            {
                DrawBoard(GameEngine.getCurrentBoardState);
                executeHumanMove();
                currentGameState = GameEngine.getCurrentGameState();
                if (currentGameState == eGameState.InProgress)
                {
                    DrawBoard(GameEngine.getCurrentBoardState);
                    switch (chosenStrategy)
                    {
                        case eOpponentStrategy.CPU:
                            /// except for Tuple<int, int> GetNextMove From AIStrategy (as coordinate)
                            break;
                        case eOpponentStrategy.Human:
                            executeHumanMove();
                            break;

                    }
                }
                else
                {
                    isMiniGameEnd = true;
                }
            }
        }

        private static void executeHumanMove()
        {
            bool isMoveValid = false;
            while (!isMoveValid)
            {
                (int column, int row) nextMoveCoordinates = GetCoordinateFromUser();
                isMoveValid = GameEngine.setNextMove(nextMoveCoordinates);
            }
        }

        private static void DrawBoard(Board.ePlayerSymbol[,,] i_Board)
        {
            //Get from GameEngine board matrix copy and flag of last move was legit
        }


        private static (int column, int row) GetCoordinateFromUser()
        {
            int column = 0;
            int row = 0;
            bool coordinateInputIsValid = false;

            Console.WriteLine("Please enter your next move as a column number and row number:");
            while (!coordinateInputIsValid)
            {
                string columnInput = userInputRequest("Enter Column: ");
                string rowInput= userInputRequest("Enter Row: ");
                coordinateInputIsValid = int.TryParse(columnInput, out column) && int.TryParse(rowInput, out row);

                if (!coordinateInputIsValid)
                {
                    Console.WriteLine("Invalid input. Please enter a valid coordinate: ");
                }
            }
            return (column, row);
        }

        private static

        private static string userInputRequest(string i_invalidInputMessage)
        {
            Console.WriteLine(i_invalidInputMessage);   
            return readInputLine();
            
        }
        private static string readInputLine()
        {
            string userInput = Console.ReadLine();
            if (userInput == k_KillSignal) 
            {
                m_isKillSigRaised = true;
            }
            return userInput;
        }
    }
}
