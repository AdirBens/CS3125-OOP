using System;
using System.Text;
using System.Collections.Generic;

using Ex02.ConsoleUtils;
using GameUtils;
using static GameUtils.Player;
using static GameUtils.GameStatusChecker;
using static GameEngine.GameEngine;

namespace TerminalUI
{
    public class TerminalUserInterface
    {
        private const string k_KillSignal = "Q";
        private const string k_RematchSignal = "R";
        private static GameResponse s_GameCurrentRespone = new GameResponse(eGameStatus.Empty, null);
        private static int s_NumRoundsPlayed = 0;
        private static int[] s_PlayersScore = new int[2];

        public static void Main()
        {
            try
            {
                runGame();
            }
            catch (KillSignalRaisedException)
            {
                displayGoodByeDialog();
            }
        }

        private static void runGame()
        {
            bool isRematch = true;

            displayStartapDialog();
            setBoardSize();
            setOpponentStrategy();
            while(isRematch)
            {
                s_GameCurrentRespone.m_Status = eGameStatus.InProgress;
                runMiniGame();
                updateGameDetails(s_GameCurrentRespone.m_Status);
                displayTerminalStatusDialog(s_GameCurrentRespone.m_Status, s_PlayersScore[0], 
                    s_PlayersScore[1], s_NumRoundsPlayed);
                isRematch = setRematchGame();
            }
        }

        private static void runMiniGame()
        {
            while (s_GameCurrentRespone.m_Status == eGameStatus.InProgress)
            {
                displayBoardScreen();
                setUserMove();
            }

            displayBoardScreen();
        }

        private static void setBoardSize()
        {
            (int min, int max) boardSizeRange = GetBoardSizeRange();
            string boardSizeMessage = string.Format(UIMessages.k_BoardSizeRequest, boardSizeRange.min, boardSizeRange.max);
            boardSizeMessage = TerminalRenderer.asActionString(boardSizeMessage);
            bool isBoardSizeValid = false;

            while (!isBoardSizeValid)
            {
                string userInput = readInputLine(boardSizeMessage);
                boardSizeMessage = TerminalRenderer.asWarningString(boardSizeMessage);
                bool isParseSuccuss = int.TryParse(userInput, out int boardSize);

                while (!isParseSuccuss)
                {
                    userInput = readInputLine(boardSizeMessage);
                    isParseSuccuss = int.TryParse(userInput, out boardSize);
                }

                s_GameCurrentRespone = SetBoardSize(boardSize);
                isBoardSizeValid = s_GameCurrentRespone.m_Status != eGameStatus.Empty;
            }
        }

        private static void setOpponentStrategy()
        {
            string selectOpponentStrategyMessage = TerminalRenderer.asActionString(UIMessages.k_GameTypeRequest);
            bool isSelectionValid = false;

            while (!isSelectionValid)
            {
                string userInput = readInputLine(selectOpponentStrategyMessage);
                selectOpponentStrategyMessage = TerminalRenderer.asWarningString(UIMessages.k_GameTypeRequest);
                bool isParseSuccuss = int.TryParse(userInput, out int opponentType);

                while (!isParseSuccuss)
                {
                    userInput = readInputLine(selectOpponentStrategyMessage);
                    isParseSuccuss = int.TryParse(userInput, out opponentType);
                }

                if (opponentType == 0 || opponentType == 1)
                {
                    eStrategy opponentStrategy = (opponentType == 0) ? eStrategy.HumanPlayer : eStrategy.AIPlayer;
                    s_GameCurrentRespone = SetOpponentType(opponentStrategy);
                    isSelectionValid = s_GameCurrentRespone.m_Status != eGameStatus.Empty;
                }
                else
                {
                    isSelectionValid = false;
                }
            }
        }

        private static void setUserMove()
        {
            string selectMoveCoordinatesMessage = TerminalRenderer.asActionString(UIMessages.k_RequestMoveCoordinates);
            bool isMoveValid = false;

            while (!isMoveValid)
            {
                string userInput = readInputLine(selectMoveCoordinatesMessage);
                bool isParseSuccuss = coordinateTryParse(userInput, out (int row, int col) coordinate);
                StringBuilder invalidMessage = new StringBuilder();

                invalidMessage.Append(UIMessages.k_InvalidNextMoveRequest);
                invalidMessage.AppendLine();
                invalidMessage.Append(selectMoveCoordinatesMessage);
                selectMoveCoordinatesMessage = TerminalRenderer.asWarningString(invalidMessage.ToString());

                while (!isParseSuccuss)
                {
                    userInput = readInputLine(invalidMessage.ToString());
                    isParseSuccuss = coordinateTryParse(userInput, out coordinate);
                }
                
                s_GameCurrentRespone = SetNextMove(coordinate);
                isMoveValid = s_GameCurrentRespone.m_Status != eGameStatus.Empty;
            }
        }

        private static bool setRematchGame()
        {
            string rematchString = TerminalRenderer.createRematchScreenString();
            bool isRematchRequested = false;

            while (!isRematchRequested)
            {
                string userInput = readInputLine(rematchString);

                isRematchRequested = userInput.Equals(k_RematchSignal);
                Screen.Clear();
            }

            s_GameCurrentRespone = SetRematchGame();

            return isRematchRequested;
        }

        private static void updateGameDetails(eGameStatus i_GameTerminalStatus)
        {
            switch (i_GameTerminalStatus)
            {
                case eGameStatus.Player1Won:
                    s_PlayersScore[0]++;
                    break;
                case eGameStatus.Player2Won:
                    s_PlayersScore[1]++;
                    break;
                default:
                    break;
            }

            s_NumRoundsPlayed++;
        }

        private static void displayStartapDialog()
        {
            TerminalRenderer.renderStartUpScreen();
            TerminalRenderer.renderToContinueMessage();
            readInputLine("");
        }

        private static void displayBoardScreen()
        {
            
            GameBoard gameBoard = s_GameCurrentRespone.mGameBoard;
            List<BoardEntry> winningStreak = GetWinStreakEntries();

            TerminalRenderer.renderGameBoard(gameBoard.m_Board, gameBoard.m_BoardSize, winningStreak);
        }

        private static void displayTerminalStatusDialog(eGameStatus i_GameTerminalStatus,
            int i_PlayerOneScore, int i_PlayerTwoScore, int i_NumRoundsPlayed)
        {
            TerminalRenderer.renderTerminalStatusScreen(i_GameTerminalStatus);
            TerminalRenderer.renderGameSummaryScreen(i_PlayerOneScore, i_PlayerTwoScore, i_NumRoundsPlayed);
            readInputLine("");

        }

        private static void displayGoodByeDialog()
        {
            TerminalRenderer.renderGoodByeScreen();
            readInputLine("");
        }

        private static string readInputLine(string i_MessageDialog)
        {
            Console.WriteLine();
            TerminalRenderer.renderUserInputRequestMessage(i_MessageDialog);
            string userInput = Console.ReadLine();
            
            if (userInput.Equals(k_KillSignal) == true)
            {
                throw new KillSignalRaisedException();
            }

            return userInput;
        }

        private static bool coordinateTryParse(string i_CoordinateString, out (int row, int col) o_Coordinate)
        {
            int row = -1;
            int col = -1;
            string[] coordinateComponents = i_CoordinateString.Trim().Split();
            bool isParseSuccess = coordinateComponents.Length == 2;

            if (isParseSuccess)
            {
                isParseSuccess &= int.TryParse(coordinateComponents[0], out row);
                isParseSuccess &= int.TryParse(coordinateComponents[1], out col);
            }

            o_Coordinate = (row - 1, col - 1);

            return isParseSuccess;
        }
    }
}
