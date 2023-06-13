using System;
using System.Collections.Generic;
using System.Text;

using Ex02.ConsoleUtils;
using GameUtils;
using static GameUtils.GameStatusChecker;
// $G$ CSS-999 (-10) internal methods should start with an uppercase letter


namespace TerminalUI
{
    internal class TerminalRenderer
    {
        private const int k_ColumnWidth = 4;
        private const int k_BaseIndentation = 2;
        private const char k_HorizontalBorder = '=';
        private const char k_VerticalBorder = '|';
        private const char k_EmptySymbol = ' ';
        private const char k_PlayerOneSymbol = 'X';
        private const char k_PlayerTwoSymbol = 'O';
        private const char k_LeftMarkSymbol = '(';
        private const char k_RightMarkSymbol = ')';
        private const string k_BulletSymbol = "[*] ";
        private const string k_ActionSymbol = "[>] ";
        private const string k_WarningSymbol = "[Invalid!] ";

        internal static void renderGameBoard(BoardEntry[,] i_GameBoard, int i_BoardSize, 
            List<BoardEntry> i_WinningStreak = null)
        {
            string topRow = getTopRow(i_BoardSize);
            StringBuilder board = new StringBuilder(topRow);

            for (int row = 0; row < i_BoardSize; row++)
            {
                string rowNumberLabel = getRowNumberLabel(row);
                StringBuilder rowString = new StringBuilder();

                // $G$ CSS-007 (-7) Missing blank line, after "for" block
                rowString.Append(rowNumberLabel);
                for (int col = 0; col < i_BoardSize; col++)
                {
                    BoardEntry boardEntry = i_GameBoard[row, col];
                    rowString.Append(createEntryString(boardEntry, i_WinningStreak));
                }
                board.AppendLine(rowString.ToString());
                board.AppendLine(createHorizontalBorder(i_BoardSize));
            }

            Screen.Clear();
            Console.WriteLine(board.ToString());
        }



        internal static void renderUserInputRequestMessage(string i_MessageDialog)
        {
            StringBuilder message = new StringBuilder();

            message.Append(i_MessageDialog);
            Console.WriteLine(message.ToString());
        }

        internal static void renderTerminalStatusScreen(eGameStatus i_TerminalStatus)
        {
            string terminalTitle = "";
            int playerWon;

            switch (i_TerminalStatus)
            {
                case eGameStatus.Player1Won:
                    playerWon = 1;
                    terminalTitle = createPlayerWonTitle(playerWon);
                    break;
                case eGameStatus.Player2Won:
                    playerWon = 2;
                    terminalTitle = createPlayerWonTitle(playerWon);
                    break;
                case eGameStatus.Tie:
                    terminalTitle = createTieTitle();
                    break;
            }
            Console.WriteLine();
            Console.WriteLine(terminalTitle);
        }

        internal static void renderGameSummaryScreen(int i_PlayerOneScore,
            int i_PlayerTwoScore, int i_NumMiniGamesPlayed)
        {
            StringBuilder gameSummaryMessage = new StringBuilder();

            gameSummaryMessage.Append(asTitleString(UIMessages.k_GameSummaryTitle));
            gameSummaryMessage.AppendLine(createGameSummaryString(i_PlayerOneScore, i_PlayerTwoScore, i_NumMiniGamesPlayed));

            Console.WriteLine(gameSummaryMessage.ToString());
            renderToContinueMessage();
        }

        internal static void renderStartUpScreen()
        {
            StringBuilder startupMessage = new StringBuilder();

            Screen.Clear();
            startupMessage.Append(asTitleString(UIMessages.k_GameTitle));
            startupMessage.AppendLine(k_BulletSymbol + UIMessages.k_WelcomeMessage);
            startupMessage.AppendLine(k_BulletSymbol + UIMessages.k_ObjectivesMessage);
            Console.WriteLine(startupMessage.ToString());
        }

        internal static void renderGoodByeScreen()
        {
            string goodByeMessage = asTitleString(UIMessages.k_EndGameAnnouncement);

            Screen.Clear();
            Console.WriteLine(goodByeMessage);
        }

        internal static void renderToContinueMessage()
        {
            Console.WriteLine(asActionString(UIMessages.k_ToContinueMessage));
        }

        internal static string createRematchScreenString()
        {
            StringBuilder rematchDialogMessage = new StringBuilder();
            
            Screen.Clear();
            rematchDialogMessage.AppendLine();
            rematchDialogMessage.AppendLine(asTitleString(UIMessages.k_RematchDialogTitle, k_BaseIndentation * 4));
            rematchDialogMessage.AppendLine(UIMessages.k_RematchDecisionOptions);

            return rematchDialogMessage.ToString();
        }

        private static string createPlayerWonTitle(int i_PlayerWon)
        {
            int playerWon = i_PlayerWon;
            char playerWonSymbol = (playerWon == 0) ? k_PlayerOneSymbol : k_PlayerTwoSymbol;
            string playerWonTitle = asTitleString(string.Format(UIMessages.k_WinningAnnouncement,
                playerWon, playerWonSymbol), k_BaseIndentation * 4);

            return playerWonTitle;
        }

        private static string createEntryString(BoardEntry i_BoardEntry, List<BoardEntry> i_WinningStreak)
        {
            StringBuilder entryMark = new StringBuilder();
            char symbol = getPlayerSymbol(i_BoardEntry);

            if (i_WinningStreak != null && i_WinningStreak.Contains(i_BoardEntry))
            {
                entryMark.Append(asMarkedString(symbol.ToString()));
                entryMark.Append(k_VerticalBorder);
            }
            else
            {
                entryMark.Append(k_EmptySymbol);
                entryMark.Append(symbol.ToString());
                entryMark.Append(k_EmptySymbol);
                entryMark.Append(k_VerticalBorder);
            }

            return entryMark.ToString();
        }

        private static string createTieTitle()
        {
            return asTitleString(UIMessages.k_TieAnnouncement, k_BaseIndentation * 4);
        }

        private static string createHorizontalBorder(int i_BoardSize)
        {
            StringBuilder horizontalBorder = new StringBuilder();

            horizontalBorder.Append(k_EmptySymbol);
            horizontalBorder.Append(k_HorizontalBorder, repeatCount: k_ColumnWidth * i_BoardSize + 1);

            return horizontalBorder.ToString();
        }

        private static string createGameSummaryString(int i_PlayerOneScore, int i_PlayerTwoScore, int i_NumMiniGamesPlayed)
        {
            StringBuilder gameSummaryMessage = new StringBuilder();

            gameSummaryMessage.AppendLine(String.Format(UIMessages.k_GameSummaryMessage, i_NumMiniGamesPlayed, 
                i_PlayerOneScore, i_PlayerTwoScore));

            return gameSummaryMessage.ToString();
        }

        internal static string asActionString(string i_Message)
        {
            return k_ActionSymbol + i_Message;
        }

        internal static string asWarningString(string i_Message)
        {
            return k_WarningSymbol  + i_Message;
        }

        private static string asMarkedString(string i_String)
        {
            StringBuilder markedString = new StringBuilder();

            markedString.Append(k_LeftMarkSymbol);
            markedString.Append(i_String);
            markedString.Append(k_RightMarkSymbol);

            return markedString.ToString();
        }

        private static string asTitleString(string i_String, int i_Indentation = k_BaseIndentation * 6)
        {
            int indentation = i_Indentation;
            StringBuilder titledString = new StringBuilder();

            titledString.Append(k_HorizontalBorder, repeatCount: (2 * indentation) + i_String.Length);
            titledString.AppendLine();
            titledString.Append(k_EmptySymbol, repeatCount: indentation);
            titledString.Append(i_String);
            titledString.AppendLine();
            titledString.Append(k_HorizontalBorder, repeatCount: (2 * indentation) + i_String.Length);
            titledString.AppendLine();

            return titledString.ToString();
        }

        private static char getPlayerSymbol(BoardEntry i_BoardEntry)
        {
            char playerSymbol = k_EmptySymbol;

            if (i_BoardEntry.m_Player.m_Symbol == Player.ePlayerSymbol.PlayerOne)
            {
                playerSymbol = k_PlayerOneSymbol;
            }
            else if (i_BoardEntry.m_Player.m_Symbol == Player.ePlayerSymbol.PlayerTwo)
            {
                playerSymbol = k_PlayerTwoSymbol;
            }

            return playerSymbol;
        }

        private static string getRowNumberLabel(int i_Col)
        {
            int colNumber = i_Col + 1;
            StringBuilder rowNumberLabel = new StringBuilder();

            rowNumberLabel.Append(colNumber);
            rowNumberLabel.Append(k_VerticalBorder);

            return rowNumberLabel.ToString();
        }

        private static string getTopRow(int i_BoardSize)
        {
            StringBuilder topRow = new StringBuilder();

            topRow.Append(k_EmptySymbol, repeatCount: 2);
            for (int i = 1; i <= i_BoardSize; i++)
            {
                int numSpaces = k_ColumnWidth - 1;
                topRow.Append(i);
                topRow.Append(k_EmptySymbol, repeatCount: numSpaces);
            }

            topRow.AppendLine();

            return topRow.ToString();
        }
    }
}
