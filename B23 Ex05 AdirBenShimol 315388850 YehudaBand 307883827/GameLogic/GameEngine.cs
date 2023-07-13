using GameLogic.GameUtils;
using System.Collections.Generic;
using static GameLogic.GameUtils.GameStatusChecker;
using static GameLogic.AIStrategy.RandomMoves;
using static GameLogic.GameUtils.Player;

namespace GameLogic
{
    public class GameEngine
    {
        private readonly GameBoard r_GameBoard;
        private readonly Player[] r_Players = new Player[GameConfig.k_NumPlayers];
        private (int row, int col) m_LastMovePlayed;
        private int m_NumTurnsPlayed = 0;
        private eGameStatus m_GameStatus;
        public eGameStatus GameStatus
        {
            get { return m_GameStatus; }
        }

        public BoardEntry[,] GameBoard
        {
            get { return r_GameBoard.m_Board; }
        }

        public (ePlayerSymbol symbol, int row, int col) LastMovePlayed
        {
            get 
            {
                ePlayerSymbol symbol = r_GameBoard.m_Board[m_LastMovePlayed.row, m_LastMovePlayed.col].m_Player.m_Symbol;

                return (symbol, m_LastMovePlayed.row, m_LastMovePlayed.col); 
            }
        }

        public GameEngine(int i_BoardSize, eStrategy i_OpponentType)
        {
            r_GameBoard = new GameBoard(i_BoardSize);
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
            Player currentPlayer = r_Players[m_NumTurnsPlayed % r_Players.Length];
            
            m_GameStatus = eGameStatus.Empty;
            if (r_GameBoard.SetEntry(currentPlayer, i_Coordinate.row, i_Coordinate.col) == true)
            {
                m_LastMovePlayed = i_Coordinate;
                m_GameStatus = GetGameStatus(r_GameBoard, m_LastMovePlayed);
                m_NumTurnsPlayed++;
                currentPlayer = r_Players[m_NumTurnsPlayed % r_Players.Length];

                if ((m_GameStatus == eGameStatus.InProgress) &&
                    currentPlayer.m_Strategy == eStrategy.AIPlayer)
                {
                    m_GameStatus = playAIPlayerMove();
                    m_NumTurnsPlayed++;
                }
            }
        }

        public void SetRematchGame()
        {
            r_GameBoard.ClearBoard();
            m_NumTurnsPlayed = 0;
            m_GameStatus = eGameStatus.InProgress;
        }

        public List<BoardEntry> GetWinStreakEntries()
        {
            List<BoardEntry> winningStreak = GetWinningStreak();

            return winningStreak;
        }

        private eGameStatus playAIPlayerMove()
        {
            Player AIPlayer = r_Players[r_Players.Length - 1];
            (int row, int col) aiMove = GetAIMove(r_GameBoard);

            r_GameBoard.SetEntry(AIPlayer, aiMove.row, aiMove.col);

            return GetGameStatus(r_GameBoard, aiMove);
        }
    }
}
