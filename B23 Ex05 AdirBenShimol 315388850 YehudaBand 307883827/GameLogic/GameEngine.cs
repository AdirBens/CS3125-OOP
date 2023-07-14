using GameLogic.GameUtils;
using System.Collections.Generic;
using static GameLogic.GameUtils.GameStatusChecker;
using static GameLogic.AIStrategy.RandomMoves;
using static GameLogic.GameUtils.Player;
using System;

namespace GameLogic
{
    public class GameEngine
    {
        public event Action GameFinishedTie;
        public event Action<Player, List<BoardEntry>> GameFinishedWin;
        public event Action<GameMove> GameMoveConfirmed;
        private readonly GameBoard r_GameBoard;
        private readonly Player[] r_Players;
        private GameMove m_LastMovePlayed;
        private eGameStatus m_GameStatus;
        private int m_NumTurnsPlayed;
        private Player m_CurrentPlayer
        {
            get { return r_Players[m_NumTurnsPlayed % r_Players.Length]; }
        }

        private Player m_WinningPlayer
        {
            get { return r_Players[(m_NumTurnsPlayed - 1) % r_Players.Length]; }
        }

        public bool IsGameInProgress
        {
            get { return m_GameStatus == eGameStatus.InProgress; }
        }

        public GameEngine(int i_BoardSize, eStrategy i_OpponentType)
        {
            r_GameBoard = new GameBoard(i_BoardSize);
            r_Players = new Player[GameConfig.k_NumPlayers];
            startGame(i_OpponentType);
        }

        private void startGame(eStrategy i_OpponentType)
        {
            m_NumTurnsPlayed = 0;
            setOpponentType(i_OpponentType);
            m_GameStatus = eGameStatus.InProgress;
        }

        private void setOpponentType(eStrategy i_OpponentType)
        {
            if (i_OpponentType != eStrategy.Empty)
            {
                r_Players[0] = new Player(ePlayerSymbol.PlayerOne, i_Strategy: eStrategy.HumanPlayer);
                r_Players[1] = new Player(ePlayerSymbol.PlayerTwo, i_Strategy: i_OpponentType);
            }
        }

        public void SetNextMove((int row, int col) i_Coordinate)
        {           
            GameMove playerMove = new GameMove(m_CurrentPlayer, i_Coordinate.row, i_Coordinate.col);

            applyGameMove(playerMove);
            if ((m_GameStatus == eGameStatus.InProgress) &&
                m_CurrentPlayer.Strategy == eStrategy.ComputerPlayer)
            {
                playComputerMove();
            }
        }

        public void SetRematchGame()
        {
            r_GameBoard.ClearBoard();
            m_NumTurnsPlayed = 0;
            m_GameStatus = eGameStatus.InProgress;
        }

        private eGameStatus playComputerMove()
        {
            GameMove computerMove = GetMove(m_CurrentPlayer, r_GameBoard);

            applyGameMove(computerMove);

            return GetGameStatus(r_GameBoard, computerMove);
        }

        private void applyGameMove(GameMove i_GameMove)
        {
            if (r_GameBoard.SetEntry(i_GameMove) == true)
            {
                m_NumTurnsPlayed++;
                m_LastMovePlayed = i_GameMove;
                onGameMoveConfirmed(i_GameMove);
                m_GameStatus = GetGameStatus(r_GameBoard, m_LastMovePlayed);
            }
            else
            {
                m_GameStatus = eGameStatus.Empty;
            }

            checkForTerminalStatus();
        }

        private void checkForTerminalStatus()
        {
            switch (m_GameStatus)
            {
                case eGameStatus.Tie:
                    onGameFinishedTie();
                    break;
                case eGameStatus.Player1Won:
                case eGameStatus.Player2Won:
                    m_WinningPlayer.Score++;
                    onGameFinishedWin(m_WinningPlayer, GetLosingStreak());
                    break;
                default: 
                    break;
            }
        }

        private void onGameFinishedTie()
        {
            GameFinishedTie?.Invoke();
        }

        private void onGameFinishedWin(Player i_Winner, List<BoardEntry> i_LosingStreak)
        {
            GameFinishedWin?.Invoke(i_Winner, i_LosingStreak);
        }

        private void onGameMoveConfirmed(GameMove i_ConfiremdGameMove)
        {
            GameMoveConfirmed?.Invoke(i_ConfiremdGameMove);
        }
    }
}
