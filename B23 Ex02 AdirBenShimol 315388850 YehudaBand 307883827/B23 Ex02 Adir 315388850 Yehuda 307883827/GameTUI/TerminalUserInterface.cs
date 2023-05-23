using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ex02.ConsoleUtils;

using static TicTacToe.GameEngine;
using static TicTacToe.GameBoard;
using static TicTacToe.Player;
using TicTacToe;
using System.Runtime.CompilerServices;

namespace GameTUI
{
    internal class TerminalUserInterface
    {

        private static bool m_isKillSigRaised = false;

        private const string k_KillSignal = "Q";

        private const int k_ColumnWidth = 4;

        private const char k_PlayerOneSymbol = 'X';
        private const char k_PlayerTwoSymbol = 'O';

        private const char k_HorizontalBorder = '=';
        private const char k_VerticalBorder = '|';

        private static MoveACK m_currentMoveACK = new MoveACK(eGameStatus.Empty, null);

        public static void Main()
        {
            runGame();
        }

        private static void runGame()
        {
            drawInitScreen();
            setBoardSizeFromUser();
            if (!m_isKillSigRaised)
            {
                setOpponentStrategyFromUser();
            }

            while (!m_isKillSigRaised)
            {
                runMiniGame();
                endGameSequence();

            }
        }


        private static void drawInitScreen()
        {
            Console.WriteLine(UIMessages.k_WelcomeMessage);
            Console.WriteLine(UIMessages.k_QuitInstructionsMessage);
        }

        private static void setBoardSizeFromUser()
        {
            int maxBoardSize = GameEngine.GetMaxBoardSize();
            int minBoardSize = GameEngine.GetMinBoardSize();
            string userPromtMessage = string.Format(UIMessages.k_BoardSizeRequest, minBoardSize, maxBoardSize);

            bool isParseSuccess = false;
            bool isBoardSizeValid = false;

            while (!m_isKillSigRaised && !isParseSuccess && !isBoardSizeValid)
            {
                string userInput = userInputRequest(userPromtMessage);
                isParseSuccess = int.TryParse(userInput, out int boardSize);

                if (!m_isKillSigRaised && isParseSuccess)
                {
                    m_currentMoveACK = GameEngine.SetGameBoardSize(boardSize);
                    isBoardSizeValid = m_currentMoveACK.m_Status != eGameStatus.Empty;
                }

                userPromtMessage = string.Format(UIMessages.k_InvalidBoardSizeRequest, minBoardSize, maxBoardSize);
                isParseSuccess = false;
            }

            Screen.Clear();
        }

        private static void setOpponentStrategyFromUser()
        {
            string userPromtMessage = UIMessages.k_GameTypeRequest;

            bool isParseSuccess = false;
            bool isBoardSizeValid = false;

            while (!m_isKillSigRaised && !isParseSuccess && !isBoardSizeValid)
            {
                string userInput = userInputRequest(userPromtMessage);
                isParseSuccess = userInput == "H" || userInput == "C";

                if (!m_isKillSigRaised && isParseSuccess)
                {
                    ePlayerStrategy chosenPlayerStrategy = (userInput == "H") ? ePlayerStrategy.Human : ePlayerStrategy.AIStrategy;

                    m_currentMoveACK = GameEngine.SetOpponentType(chosenPlayerStrategy);
                    isBoardSizeValid = m_currentMoveACK.m_Status != eGameStatus.Empty;
                }
                else
                {
                    userPromtMessage = UIMessages.k_InvalidGameTypeRequest;
                }
            }
            Screen.Clear();
        }

        private static void runMiniGame()
        {
            while (!m_isKillSigRaised && m_currentMoveACK.m_Status == eGameStatus.InProgress)
            {
                drawBoard(m_currentMoveACK.m_Board);
                setCoordinateFromUser();
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

                    if (winnerStreak != null && winnerStreak.Contains(boardEntry))
                    {
                        doubleRow.Append(string.Format($"({symbolToInsert})|"));
                    }
                    else
                    {

                        doubleRow.Append(string.Format($" {symbolToInsert} |"));
                    }
                }

                doubleRow.Append("\n ");
                doubleRow.Append(k_HorizontalBorder, (boardSize * k_ColumnWidth) + 1);
                Console.WriteLine(doubleRow.ToString());
            }
        }

        private static void endGameSequence()
        {
            (int PlayerOneScore, int PlayerTwoScore) scoreSummary;
            bool rematchDecision = false;

            scoreSummary = GameEngine.GetScoreSummary();
            switch (m_currentMoveACK.m_Status)
            {
                case (eGameStatus.Win):
                    drawWinMessage(scoreSummary.PlayerOneScore, scoreSummary.PlayerTwoScore, GameEngine.GetWinStreak());
                    break;
                case (eGameStatus.Tie):
                    drawTieMessage(scoreSummary.PlayerOneScore, scoreSummary.PlayerTwoScore);
                    break;
            }
            rematchDecision = getRematchDecisionFromUser();
            if (!m_isKillSigRaised && rematchDecision)
            {
                m_currentMoveACK = GameEngine.SetGameRestart();
            }
            else
            {
                drawEndScreen();
            }
        }
        
        private static bool getRematchDecisionFromUser()
        {
            string userPromtMessage = UIMessages.k_RematchDecisionQuery;

            bool isParseSuccess = false;
            bool rematchDecision = false;

            while (!m_isKillSigRaised && !isParseSuccess)
            {
                string userInput = userInputRequest(userPromtMessage);
                isParseSuccess = userInput.Equals("Y") || userInput.Equals("N");

                userPromtMessage = UIMessages.k_InvalidRematchDecisionQuery;

                if (!m_isKillSigRaised && isParseSuccess)
                {
                    rematchDecision = (userInput == "Y");
                }
            }

            return rematchDecision;
        }

        private static void setCoordinateFromUser()
        {
            string userPromtMessage = UIMessages.k_NextMoveRequest;

            bool isParseSuccess = false;
            bool isCoordinateValid = false;

            while (!m_isKillSigRaised && !isParseSuccess && !isCoordinateValid)
            {
                string userInput = userInputRequest(userPromtMessage + UIMessages.k_RowRequest);
                isParseSuccess = int.TryParse(userInput, out int row);

                if (!m_isKillSigRaised)
                {
                    userInput = userInputRequest(UIMessages.k_ColumnRequest);
                    isParseSuccess &= int.TryParse(userInput, out int column);
                    if (!m_isKillSigRaised && isParseSuccess)
                    {
                        m_currentMoveACK = GameEngine.SetNextMove((row - 1, column - 1));
                        isCoordinateValid = m_currentMoveACK.m_Status != eGameStatus.Empty;
                    }
                }

                int maxBoardSize = GameEngine.GetMaxBoardSize();
                int minBoardSize = GameEngine.GetMinBoardSize();

                userPromtMessage = string.Format(UIMessages.k_InvalidNextMoveRequest);
                isParseSuccess = false;
            }

            Screen.Clear();
        }
    
        private static void drawWinMessage(int i_scoreP1, int i_scoreP2, (Player winner, List<BoardEntry> winningStreak) i_WinningDetails)
        {
            StringBuilder winningMessage = new StringBuilder();

            drawBoard(m_currentMoveACK.m_Board, i_WinningDetails.winningStreak);

            winningMessage.AppendLine(string.Format(UIMessages.k_WinningAnnouncement, (int) i_WinningDetails.winner.m_Symbol));
            winningMessage.Append(string.Format(UIMessages.k_CurrentScoreMessage, i_scoreP1, i_scoreP2));

            Console.WriteLine(winningMessage);
        }

        private static void drawTieMessage(int i_scoreP1, int i_scoreP2)
        {
            StringBuilder tieMessage = new StringBuilder();

            drawBoard(m_currentMoveACK.m_Board);

            tieMessage.AppendLine(UIMessages.k_TieAnnouncement);
            tieMessage.Append(string.Format(UIMessages.k_CurrentScoreMessage, i_scoreP1, i_scoreP2));

            Console.WriteLine(tieMessage);
        }

        private static void drawEndScreen()
        {
            m_isKillSigRaised = true;
            Console.WriteLine(UIMessages.k_EndGameAnnouncement);
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
