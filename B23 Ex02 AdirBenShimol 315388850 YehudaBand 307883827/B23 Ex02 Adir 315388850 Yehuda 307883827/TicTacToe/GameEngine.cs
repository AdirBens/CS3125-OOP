using System.Collections.Generic;


namespace TicTacToe
{
    public class GameEngine
    {
        public enum eGameStatus
        {
            Empty,
            InProgress,
            Tie,
            Win,
            Player1Won,
            Player2Won
        }

        public struct MoveACK
        {
            public eGameStatus m_Status
            {
                get;
                private set;
            }

            public GameBoard m_Board
            {
                get;
                private set;
            }

            public MoveACK(eGameStatus status, GameBoard board)
            {
                m_Board = board;
                m_Status = status;
            }
        }

        private static GameBoard m_Board;
        private const int k_NumberOfPlayers = 2;
        private const int k_MinBoardSize = 3;
        private const int k_MaxBoardSize = 9;

        public static List<GameBoard.BoardEntry> m_WinningStrike;

        private static int m_NumOfTurnPlayed = 0;
        private static Player[] m_Players = new Player[k_NumberOfPlayers];
        
        public static GameBoard.BoardEntry m_lastMovePlayed
        {
            get; private set;
        }


        public static MoveACK SetGameBoardSize(int i_BoardSize)
        {
            eGameStatus gameStatus = eGameStatus.Empty;

            if (m_Board == null)
            {
                if (k_MinBoardSize <= i_BoardSize && i_BoardSize <= k_MaxBoardSize)
                {
                    m_Board = new GameBoard(i_BoardSize);
                    gameStatus = eGameStatus.InProgress;
                }
            }
            return new MoveACK(gameStatus, m_Board);
        }
        public static MoveACK SetOpponentType(Player.ePlayerStrategy i_OpponentStrategy)
        {
            eGameStatus gameStatus = eGameStatus.Empty;
            if (i_OpponentStrategy == Player.ePlayerStrategy.Human || 
                i_OpponentStrategy == Player.ePlayerStrategy.AIStrategy)
            {
                gameStatus = eGameStatus.InProgress;
                m_Players[0] = new Player(GameBoard.BoardEntry.eEntrySymbol.PlayerOneSymbol, i_Strategy: Player.ePlayerStrategy.Human);
                m_Players[1] = new Player(GameBoard.BoardEntry.eEntrySymbol.PlayerTwoSymbol, i_Strategy: i_OpponentStrategy);
            }

            return new MoveACK(gameStatus, m_Board);
        }
        public static MoveACK SetNextMove((int row, int column) i_Coordinate)
        {
            eGameStatus gameStatus = eGameStatus.Empty;
            Player currentPlayer = m_Players[m_NumOfTurnPlayed % k_NumberOfPlayers];

            if (m_Board.SetEntry(currentPlayer.m_Symbol, i_Coordinate) == true)
            {
                gameStatus = GameStatusCheker.GetGameStatus(m_Board, m_lastMovePlayed, out m_WinningStrike);
                m_NumOfTurnPlayed++;
                currentPlayer = m_Players[m_NumOfTurnPlayed % k_NumberOfPlayers];

                if ((gameStatus == eGameStatus.InProgress) && 
                    currentPlayer.m_Strategy == Player.ePlayerStrategy.AIStrategy)
                {
                    gameStatus = playAIPlayer();
                }
            }

            return new MoveACK(gameStatus, m_Board);
        }
        public static MoveACK SetGameRestart()
        {
            m_NumOfTurnPlayed = 0;
            m_Board.ClearBoard();
            return new MoveACK(eGameStatus.InProgress, m_Board);
        }
        public static (int PlayerOneScore, int PlayerTwoScore) GetScoreSummary()
        {
            return (m_Players[0].m_Score, m_Players[1].m_Score);
        }
        public static List<GameBoard.BoardEntry> GetWinStreak()
        {
            return m_WinningStrike;
        }
        public static int GetMinBoardSize()
        {
            return k_MinBoardSize;
        }
        public static int GetMaxBoardSize()
        {
            return k_MaxBoardSize;
        }


        private static eGameStatus playAIPlayer()
        {
            Player AIPlayer = m_Players[1];
            (int row, int column) aiCoordinate = Strategy.MiniMaxMoves.GetBestMove();

            m_Board.SetEntry(AIPlayer.m_Symbol, aiCoordinate);
            m_NumOfTurnPlayed++;
            
            return GameStatusCheker.GetGameStatus(m_Board, m_lastMovePlayed, out m_WinningStrike);
        }


    }
}
