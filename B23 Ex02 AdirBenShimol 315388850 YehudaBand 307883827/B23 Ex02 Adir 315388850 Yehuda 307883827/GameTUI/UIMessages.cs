using System.Reflection.Emit;

namespace GameTUI
{
    internal class UIMessages
    {
        internal const string k_GeneralInvalidInputMessage = "Invalid Input, try again.";

        internal const string k_WelcomeMessage = "Welcome to the TicTacToe Reversed game!";
        internal const string k_QuitInstructionsMessage = "Hit Q at any stage to quit the game";

        internal const string k_BoardSizeRequest = "Please enter a board size between {0} and {1}:";
        internal const string k_InvalidBoardSizeRequest = "Invalid Input. Enter a board size between {0} and {1}:";

        internal const string k_GameTypeRequest = "Please enter game type, H for human opponent and C for playing against the computer:";
        internal const string k_InvalidGameTypeRequest = "Invalid Input. Please press H or C:";

        internal const string k_NextMoveRequest = "Please enter your next move as a column number and row number:";
        internal const string k_InvalidNextMoveRequest = "Invalid input. Cell must be on the board and unoccupied.";

        internal const string k_RowRequest = "\nEnter row:";
        internal const string k_ColumnRequest = "Enter column:";

        internal const string k_RematchDecisionQuery = "Would you like to rematch? (Y/N)";
        internal const string k_InvalidRematchDecisionQuery = "Invalid input. Hit Y to rematch and N to end game.";

        internal const string k_WinningAnnouncement = "Well Done Player {0}! You have won this round!";
        internal const string k_TieAnnouncement = "Its a TIE!";
        internal const string k_CurrentScoreMessage = "The current score is P1:{0} , P2:{1} ({0}:{1})";

        internal const string k_EndGameAnnouncement = "Thanks for playing our game!";



    }
}
