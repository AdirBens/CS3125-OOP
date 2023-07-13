using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameGUI.GUI;
using GameLogic;
using GameLogic.GameUtils;
using static GameLogic.GameUtils.GameStatusChecker;

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

            while (r_GameEngine.GameStatus == eGameStatus.InProgress)
            {
                m_GameBoard.ShowDialog();
            }
        }

        private void runMiniGame()
        {
            while (r_GameEngine.GameStatus == eGameStatus.InProgress)
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
                case eGameStatus.Player1Won:
                    m_GameBoard.HighlighStreak(r_GameEngine.GetWinStreakEntries());
                    m_GameBoard.ShowWinDialog(Player.ePlayerSymbol.PlayerOne);
                    break;
                case eGameStatus.Player2Won:
                    m_GameBoard.HighlighStreak(r_GameEngine.GetWinStreakEntries());
                    m_GameBoard.ShowWinDialog(Player.ePlayerSymbol.PlayerTwo);
                    break;
                case eGameStatus.Tie:
                    m_GameBoard.ShowTieDialog();
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

        private void RematchGame() 
        {
            r_GameEngine.SetRematchGame();
            m_GameBoard.ResetGameBoard();
        }

        private void setupGame()
        {
            m_GameBoard.GameTurnPlayed += setUserMove;
            m_GameBoard.RematchGameRequested += RematchGame;
        }
    }
}
