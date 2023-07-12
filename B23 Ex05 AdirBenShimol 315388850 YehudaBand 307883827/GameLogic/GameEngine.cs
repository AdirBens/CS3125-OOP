using GameLogic.GameUtils;
using System.Collections.Generic;
using static GameLogic.GameUtils.GameStatusChecker;
using static GameLogic.AIStrategy.RandomMoves;

namespace GameLogic
{
    public class GameEngine
    {
        public class GameResponse
        {
            public eGameStatus m_Status
            {
                get; set;
            }

            public GameBoard mGameBoard
            {
                get; private set;
            }

            public GameResponse(eGameStatus i_Status, GameBoard i_Board)
            {
                m_Status = i_Status;
                mGameBoard = i_Board;
            }
        }

        public static List<BoardEntry> s_WinningStreak
        {
            get; private set;
        }

        public static (int row, int col) s_LastMovePlayed
        {
            get; private set;
        }

        private const int k_NumOfPlayers = 2;
        private const int k_MinBoardSize = 4;
        private const int k_MaxBoardSize = 10;
        private static GameBoard s_GameBoard;
        private static Player[] s_Players = new Player[k_NumOfPlayers];
        private static int s_NumTurnsPlayed = 0;

        public static GameResponse SetBoardSize(int i_BoardSize)
        {
            eGameStatus gameStatus = eGameStatus.Empty;

            if (s_GameBoard == null)
            {
                if (k_MinBoardSize <= i_BoardSize && i_BoardSize <= k_MaxBoardSize)
                {
                    s_GameBoard = new GameBoard(i_BoardSize);
                    gameStatus = eGameStatus.InProgress;
                }
            }

            return new GameResponse(gameStatus, s_GameBoard);
        }

        public static GameResponse SetOpponentType(Player.eStrategy i_OpponentType)
        {
            eGameStatus gameStatus = eGameStatus.Empty;

            if (i_OpponentType != Player.eStrategy.Empty)
            {
                gameStatus = eGameStatus.InProgress;
                s_Players[0] = new Player(Player.ePlayerSymbol.PlayerOne, i_Strategy: Player.eStrategy.HumanPlayer);
                s_Players[1] = new Player(Player.ePlayerSymbol.PlayerTwo, i_Strategy: i_OpponentType);
            }

            return new GameResponse(gameStatus, s_GameBoard);
        }

        public static GameResponse SetNextMove((int row, int col) i_Coordinate)
        {
            eGameStatus gameStatus = eGameStatus.Empty;
            Player currentPlayer = s_Players[s_NumTurnsPlayed % k_NumOfPlayers];

            if (s_GameBoard.SetEntry(currentPlayer, i_Coordinate.row, i_Coordinate.col) == true)
            {
                s_LastMovePlayed = i_Coordinate;
                gameStatus = GetGameStatus(s_GameBoard, s_LastMovePlayed);
                s_NumTurnsPlayed++;
                currentPlayer = s_Players[s_NumTurnsPlayed % k_NumOfPlayers];

                if ((gameStatus == eGameStatus.InProgress) &&
                    currentPlayer.m_Strategy == Player.eStrategy.AIPlayer)
                {
                    gameStatus = playAIPlayerMove();
                    s_NumTurnsPlayed++;
                }
            }

            return new GameResponse(gameStatus, s_GameBoard);
        }

        public static GameResponse SetRematchGame()
        {
            s_GameBoard.ClearBoard();
            s_NumTurnsPlayed = 0;

            return new GameResponse(eGameStatus.InProgress, s_GameBoard);
        }

        public static (int minSize, int maxSize) GetBoardSizeRange()
        {
            return (k_MinBoardSize, k_MaxBoardSize);
        }

        public static List<BoardEntry> GetWinStreakEntries()
        {
            List<BoardEntry> winningStreak = GetWinningStreak();

            return winningStreak;
        }

        private static eGameStatus playAIPlayerMove()
        {
            Player AIPlayer = s_Players[k_NumOfPlayers - 1];
            (int row, int col) aiMove = GetAIMove(s_GameBoard);

            s_GameBoard.SetEntry(AIPlayer, aiMove.row, aiMove.col);

            return GetGameStatus(s_GameBoard, aiMove);
        }
    }
}
