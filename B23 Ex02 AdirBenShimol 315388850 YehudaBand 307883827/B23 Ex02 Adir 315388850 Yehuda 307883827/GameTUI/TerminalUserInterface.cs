using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ex02.ConsoleUtils;
using TicTacToe;


namespace GameTUI
{
    internal class TerminalUserInterface
    {

        private static bool m_isKillSigRaised = false;

        private const string k_KillSignal = "Q";

        private const char k_PlayerOneSymbol = 'X';
        private const char k_PlayerTwoSymbol = 'O';

        private const char k_HorizontalBorder = '=';
        private const char k_VerticalBorder = '|';


        private static MoveACK m_currentMoveACK = new MoveACK(eGameStatus.Empty, null);  ///######

        public static void Main()
        {
            runGame();
        }

        private static void runGame()
        {
            drawInitScreen();
            setGameParemetersFromUserInput();

            while (!m_isKillSigRaised)
            {
                (int scoreP1, int scoreP2) = GameEngine.GetScoreSummary();
                switch (m_currentMoveACK.m_Status)
                {
                    case eGameStatus.InProgress:
                        runMiniGame();
                        break;
                    case eGameStatus.Win:
                        drawWinMessage(scoreP1, scoreP2, GameEngine.GetWinStreak());
                        break;
                    case eGameStatus.Tie:
                        drawTieMessage(scoreP1, scoreP2);
                        break;
                }

                bool rematchDecision = false;

                if (!m_isKillSigRaised)
                {
                    rematchDecision = getRematchDecisionFromUser();
                }
                if (!m_isKillSigRaised && rematchDecision)
                {
                    m_currentMoveACK = GameEngine.SetGameRestart();
                }
                else
                {
                    drawEndScreen();
                    break;
                }
            }
        }

        private static void drawInitScreen()
        {
            Console.WriteLine("Welcome to the TicTacToe Reversed game!\nHit Q at any stage to quit the game");
        }

        private static int getBoardSizeFromUser()
        {
            int maxBoardSize = GameEngine.GetMaxBoardSize();
            int minBoardSize = GameEngine.GetMinBoardSize();

            string userInput = userInputRequest(string.Format($"Please enter a board size between {maxBoardSize} and {minBoardSize}:"));
            bool isParseSuccess = int.TryParse(userInput, out int boardSize);

            while (!isParseSuccess && !m_isKillSigRaised)
            {
                userInputRequest("Board size invalid! Please enter a valid board size:");
                isParseSuccess = int.TryParse(userInput, out boardSize);
            }

            Screen.Clear();
            return boardSize;
        }

        private static ePlayerStrategy getOpponentStrategyFromUser()
        {
            ePlayerStrategy chosenPlayerStrategy = new ePlayerStrategy();

            userInputRequest("Please enter game type:\nH for human opponent and C for playing against the computer");
            string userInput = readInputLineWithKillSigValidation();

            while (userInput != "H" && userInput != "C" && !m_isKillSigRaised)
            {
                userInput = userInputRequest("Input is invalid! please press H or C");
            }

            if (!m_isKillSigRaised)
            {
                chosenPlayerStrategy = (userInput == "H") ? ePlayerStrategy.Human : ePlayerStrategy.AIStrategy;

            }

            Screen.Clear();
            return chosenPlayerStrategy;
        }

        private static void setGameParemetersFromUserInput()
        {
            int boardSize;
            while (!m_isKillSigRaised && m_currentMoveACK.m_Status != eGameStatus.InProgress)
            {
                boardSize = getBoardSizeFromUser();
                if (!m_isKillSigRaised)
                {
                    m_currentMoveACK = GameEngine.SetGameBoardSize(boardSize);
                }
            }
            if (!m_isKillSigRaised)
            {
                ePlayerStrategy chosenPlayerStrategy = getOpponentStrategyFromUser();
                if (!m_isKillSigRaised)
                {
                    GameEngine.SetOpponentType(chosenPlayerStrategy);
                }
            }
        }


        private static void runMiniGame()
        {
            while (!m_isKillSigRaised || m_currentMoveACK.m_Status != eGameStatus.InProgress)
            {
                drawBoard(m_currentMoveACK.m_Board);
                (int column, int row) coordinatesFromUser = getCoordinateFromUser();
                if (!m_isKillSigRaised)
                {
                    m_currentMoveACK = GameEngine.SetNextMove(coordinatesFromUser);
                }
            }
        }

        private static void drawBoard(GameBoard i_Board, List<BoardEntry> winnerStreak = null)
        {
            StringBuilder row1 = new StringBuilder();
            StringBuilder doubleRow = new StringBuilder();

            int boardSize = i_Board.m_BoardSize;
            char symbolToInsert = ' ';

            Screen.Clear();
            row1.Append("  ");
            for (int col = 0; col < boardSize; col++)
            {
                row1.Append((col+1).ToString() + "   ");
            }
            Console.WriteLine(row1.ToString());

            for (int row = 0; row < boardSize; row++)
            {
                doubleRow.Clear();
                doubleRow.Append((row+1).ToString() + k_VerticalBorder);
                for (int col = 0; col < boardSize; col++)
                {
                    BoardEntry boardEntry = i_Board.GetBoardEntry(row, col);
                    switch (boardEntry.m_Symbol)
                    {
                        case BoardEntry.eEntrySymbol.Empty:
                            symbolToInsert = ' ';
                            break;
                        case BoardEntry.eEntrySymbol.PlayerOneSymbol:
                            symbolToInsert = k_PlayerOneSymbol;
                            break;
                        case BoardEntry.eEntrySymbol.PlayerTwoSymbol:
                            symbolToInsert = k_PlayerTwoSymbol;
                            break;
                    }

                    if (winnerStreak.Contains(boardEntry))
                    {
                        doubleRow.AppendLine(string.Format($"({symbolToInsert})|"));
                    }
                    else
                    {
                        doubleRow.Append(string.Format($" {symbolToInsert} |"));
                    }
                }

                doubleRow.Append('\n');
                doubleRow.Append(k_HorizontalBorder.ToString(), 1, (boardSize * 5) + 1);
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
                if (!m_isKillSigRaised)
                {
                    break;
                }
                string rowInput = userInputRequest("Enter Row: ");
                if (!m_isKillSigRaised)
                {
                    coordinateInputIsValid = int.TryParse(columnInput, out column) && int.TryParse(rowInput, out row);
                    if (!coordinateInputIsValid)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid coordinate: ");
                    }
                }
            }
            return (column, row);
        }

        private static void drawWinMessage(int i_scoreP1, int i_scoreP2, List<BoardEntry> i_winningStreak)
        {
            GameBoard.BoardEntry.eEntrySymbol winnerPlayerSymbol = i_winningStreak.Last().m_Symbol;
            StringBuilder winningMessage = new StringBuilder();

            drawBoard(m_currentMoveACK.m_Board, i_winningStreak);

            winningMessage.Append(string.Format($"Well Done Player {(int)winnerPlayerSymbol}! You have won this round!"));
            winningMessage.Append(string.Format($"\nThe current score is {i_scoreP1} : {i_scoreP2}"));

            Console.WriteLine(winningMessage);
        }

        private static void drawTieMessage(int i_scoreP1, int i_scoreP2)
        {
            StringBuilder tieMessage = new StringBuilder();

            drawBoard(m_currentMoveACK.m_Board);

            tieMessage.Append(string.Format($"Its a TIE!"));
            tieMessage.Append(string.Format($"\nThe current score is {i_scoreP1} : {i_scoreP2}"));

            Console.WriteLine(tieMessage);
        }
        private static void drawEndScreen()
        {
            Console.WriteLine("Thanks for playing our game!");
            Console.ReadLine();
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
