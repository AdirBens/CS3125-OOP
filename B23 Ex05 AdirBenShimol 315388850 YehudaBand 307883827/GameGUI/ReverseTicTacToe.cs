using GameLogic;
using static GameLogic.GameUtils.GameStatusChecker;
using static GameLogic.GameUtils.Player;

namespace GameGUI
{
    internal class ReverseTicTacToe
    {
        private readonly GameEngine r_GameEngine;
        private readonly FormGameSettings r_GameSettings;
        private readonly int[] r_PlayersScore = new int[GameConfig.k_NumPlayers];
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

            setupGame();
            if (r_GameEngine?.GameStatus == eGameStatus.InProgress)
            {
                m_GameBoard.ShowDialog();
            }
        }

        private void setUserMove((int row, int col) i_Coordinate)
        {
            r_GameEngine.SetNextMove(i_Coordinate);
            m_GameBoard.UpdateGameBoard(r_GameEngine.GameBoard);
            checkGameStatus();
        }

        private void checkGameStatus()
        {
            updateGameStats();

            switch (r_GameEngine.GameStatus)
            {
                case eGameStatus.Tie:
                    m_GameBoard.ShowTerminalDialog(UIStrings.k_TieMessage);
                    break;
                case eGameStatus.Player1Won:
                case eGameStatus.Player2Won:
                    ePlayerSymbol winnerSymbol = (r_GameEngine.GameStatus == eGameStatus.Player1Won) ? 
                                                 ePlayerSymbol.PlayerOne : ePlayerSymbol.PlayerTwo;

                    m_GameBoard.HighlighStreak(r_GameEngine.GetWinStreakEntries());
                    m_GameBoard.ShowTerminalDialog(winnerSymbol);
                    break;
                default: 
                    break;
            }
        }

        private void updateGameStats()
        {
            switch (r_GameEngine.GameStatus)
            {
                case eGameStatus.Player1Won:
                    r_PlayersScore[0]++;
                    break;
                case eGameStatus.Player2Won:
                    r_PlayersScore[1]++;
                    break;
                default:
                    break;
            }

            m_GameBoard.UpdatePlayersScore(r_PlayersScore);
        }

        private void rematchGame()
        {
            r_GameEngine.SetRematchGame();
            m_GameBoard.ResetGameBoard();
        }

        private void setupGame()
        {
            m_GameBoard.GameTurnPlayed += setUserMove;
            m_GameBoard.RematchGameRequested += rematchGame;
        }
    }
}
