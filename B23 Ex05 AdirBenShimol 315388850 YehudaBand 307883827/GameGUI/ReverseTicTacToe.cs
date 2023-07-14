using GameLogic;
using GameLogic.GameUtils;
using System.Collections.Generic;

namespace GameGUI
{
    internal class ReverseTicTacToe
    {
        private readonly GameEngine r_GameEngine;
        private readonly FormGameSettings r_GameSettings;
        private FormGameBoard m_GameBoard;

        internal ReverseTicTacToe()
        {
            r_GameSettings = new FormGameSettings(GameConfig.k_MinBoardSize, GameConfig.k_MaxBoardSize);

            r_GameSettings.ShowDialog();
            if (r_GameSettings.IsSettingsValid)
            {
                r_GameEngine = new GameEngine(r_GameSettings.BoardSize, r_GameSettings.OpponentType);
            }
        }

        internal void RunGame()
        {
            m_GameBoard = new FormGameBoard(r_GameSettings);

            if (r_GameEngine?.IsGameInProgress == true)
            {
                setupGame();
                m_GameBoard.ShowDialog();
            }
        }

        private void gameBoard_TurnPlayed((int row, int col) i_Coordinate)
        {
            r_GameEngine.SetNextMove(i_Coordinate);
        }

        private void gameBoard_RematchRequested()
        {
            r_GameEngine.SetRematchGame();
            m_GameBoard.ResetGameBoard();
        }

        private void gameEngine_GameFinishedTie()
        {
            m_GameBoard.ShowTerminalDialog(UIStrings.k_TieMessage);
        }

        private void gameEngine_GameFinishedWin(Player i_WinnerPlayer, List<BoardEntry> i_WinningStreak)
        {
            m_GameBoard.UpdatePlayerScore(i_WinnerPlayer.PlayerSymbol, i_WinnerPlayer.Score);
            m_GameBoard.HighlighStreak(i_WinningStreak);
            m_GameBoard.ShowTerminalDialog(i_WinnerPlayer.PlayerSymbol);
        }

        private void gameEngine_MoveConfirmed(GameMove i_GameMove)
        {
            m_GameBoard.UpdateGameBoard(i_GameMove);
        }

        private void setupGame()
        {
            m_GameBoard.GameTurnPlayed += gameBoard_TurnPlayed;
            m_GameBoard.RematchGameRequested += gameBoard_RematchRequested;
            r_GameEngine.GameFinishedTie += gameEngine_GameFinishedTie;
            r_GameEngine.GameFinishedWin += gameEngine_GameFinishedWin;
            r_GameEngine.GameMoveConfirmed += gameEngine_MoveConfirmed;
        }
    }
}
