using Ex02.ConsoleUtils;
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

        private static Player[] players = new Player[2];
        private static int m_scorePlayer1;
        private static int m_scorePlayer2;

        private static int m_boardSize;

        private static eOpponentStrategy m_chosenStrategy = eOpponentStrategy.Unknown;
        private static eGameState m_currentGameState = eGameState.Init;


        private enum eGameState
        {
            Init,
            InProgress,
            Win,
            Tie,
            RematchQuery,
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
            bool rematchDecision;

            DrawInitScreen();
            while (!m_isKillSigRaised)
            {
                switch (m_currentGameState)
                {
                    case eGameState.Init:
                        m_boardSize = getBoardSizeFromUser();
                        while (!GameEngine.setBoardSize(m_boardSize))
                        {
                            m_boardSize = getBoardSizeFromUser();
                            if (m_isKillSigRaised)
                            {
                                break;
                            }
                        }
                        m_chosenStrategy = getOpponentStrategyFromUser();
                        if (m_isKillSigRaised)
                            {
                                break;
                            }
                        m_currentGameState = eGameState.InProgress;
                        break;
                    case eGameState.InProgress:
                        runMiniGame();
                        break;
                    case eGameState.Win:
                        //drawWinMessage();
                    case eGameState.Tie:
                        //drawTieMessage();
                    case eGameState.RematchQuery:
                        rematchDecision = getRematchDecisionFromUser();
                        if (rematchDecision)
                        {
                            m_currentGameState = eGameState.InProgress;
                        }
                        else
                        {
                            m_currentGameState = eGameState.End;
                        }
                        break;
                    case eGameState.End:

                        break;
                }
            }
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
            string userInput = readInputLineWithKillSigValidation();

            while (userInput != "H" && userInput != "C" && !m_isKillSigRaised)
            {
                userInput = userInputRequest("Input is invalid! please press H or C");
            }

            if (!m_isKillSigRaised)
            {
            chosenOpponentStrategy = (userInput == "H") ? eOpponentStrategy.Human : eOpponentStrategy.CPU; 
            }

            Screen.Clear();
            return chosenOpponentStrategy;
        }

        private static void runMiniGame()
        {
            while (!m_isKillSigRaised || m_currentGameState == eGameState.InProgress)
            {
                drawBoard(GameEngine.getCurrentBoardState);
                executeHumanMove();
                switch (m_chosenStrategy)
                {
                    case eOpponentStrategy.CPU:
                        executeCPUMove();
                        break;
                    case eOpponentStrategy.Human:
                        drawBoard(GameEngine.getCurrentBoardState);
                        executeHumanMove();
                        break;
                }
                m_currentGameState = GameEngine.getCurrentGameState();
            }
        }

        private static void executeHumanMove()
        {
            bool isMoveValid = false;
            while (!isMoveValid)
            {
                (int column, int row) nextMoveCoordinates = getCoordinateFromUser();
                isMoveValid = GameEngine.setNextMove(nextMoveCoordinates);
            }
        }

        private static void executeCPUMove()
        {
            (int column, int row) nextMoveCoordinates = GameEnginge.GetCoordinateFromCPU();
            GameEngine.setNextMove(nextMoveCoordinates);
        }

        private static void drawBoard(Board.ePlayerSymbol[,] i_Board)
        {
            StringBuilder row1 = new StringBuilder();
            StringBuilder doubleRow = new StringBuilder();

            row1.Append("  ");
            for (int i = 0;  i < m_boardSize; i++)
            {
                row1.Append(i.ToString() + "   ");
            }
            Console.WriteLine(row1.ToString());

            for(int i = 0; i < m_boardSize; i++)
            {
                doubleRow.Clear();
                doubleRow.Append(i.ToString() + '|');
                for(int j = 0; j < m_boardSize; j++)
                {
                    doubleRow.Append(string.Format($" {i_Board[i,j]} |"));
                }
                doubleRow.Append('\n');
                doubleRow.Append("=", 1, m_boardSize * 5 + 1);
                Console.WriteLine(doubleRow.ToString());
            }
        }

        private static bool getRematchDecisionFromUser()
        {
            bool rematchDecision = false;
            userInputRequest("Would you like to rematch? (Y/N)\nHit Q to terminate the game");
            string userInput = readInputLineWithKillSigValidation();

            while (userInput != "Y" && userInput != "N" && !m_isKillSigRaised)
            {
                userInput = userInputRequest("Input is invalid! please press Y or N");
            }

            if (!m_isKillSigRaised)
            {
                rematchDecision = (userInput == "Y") ? true : false;
            }

            return rematchDecision;
        }

        private static (int column, int row) getCoordinateFromUser()
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

        private static string userInputRequest(string i_invalidInputMessage)
        {
            Console.WriteLine(i_invalidInputMessage);   
            return readInputLineWithKillSigValidation();
            
        }

        private static string readInputLineWithKillSigValidation()
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
