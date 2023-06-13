namespace TerminalUI
{
    internal class UIMessages
    {
        internal const string k_AddressToPlayerOne = "[X] Player One Turn";
        internal const string k_AddressToPlayerTwo = "[O] Player Two Turn";
        internal const string k_ToContinueMessage = "To Continue Press the [Enter] key.";

        internal const string k_GameTitle = "Reveres Tic-Tac-Toe";
        internal const string k_WelcomeMessage = "Welcome to the TicTacToe Reversed game!";
        internal const string k_ObjectivesMessage = @"Each player must place their symbol in an empty cell.
[*] Winning and Losing
    [#] The WINNER The Player who avoids creating his own symbol sequence
    [#] The LOSER The Player who creates his own symbol sequence
    [#] Its a TIE In case of no sequence and full board, TIE is declare";

        internal const string k_BoardSizeRequest = @"Please enter a board size between {0} and {1}:
[Board Size]: ";

        internal const string k_GameTypeRequest = @"Select Opponent Type by pressing the correspond number:
    [0] Human Opponent
    [1] AI-Opponent
[Opponent]: ";

        internal const string k_RequestMoveCoordinates = @"Enter the row and column, seperate with space to set your next move
[Row Col]: ";

        internal const string k_InvalidNextMoveRequest = "Invalid Move! Selected Cell must be on the board range and unoccupied.";
        internal const string k_RematchDialogTitle = "Do you Want to play again?";
        internal const string k_RematchDecisionOptions = @"
    [R] Yes! Rematch Game now!
    [Q] No. Just Quit The Game.
[Rematch]: ";

        internal const string k_WinningAnnouncement = @"[{0}]  Player #{0} Have Won this Round!  [{0}]";
        internal const string k_TieAnnouncement = "[X=O] Round End With TIE [O=X]";
        internal const string k_GameSummaryTitle = "Game Summary:";
        internal const string k_GameSummaryMessage = @"[*] You Have Been Play For {0} Rounds!
[X] Player #1: {1} pts.
[O] Player #2: {2} pts.";

        internal const string k_EndGameAnnouncement = "Thanks for playing our game!";
    }
}