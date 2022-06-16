using System;

namespace CheckersLogic
{
    public class ManageGame
    {
        private CheckersBoardGame m_Board;
        private CheckersPlayer m_CurrentPlayer;
        private CheckersPlayer m_OpponentPlayer;

        public ManageGame() { }

        public ManageGame(int i_BoardSize, CheckersPlayer.eType i_Type, string i_CurrentPlayerName, string i_OpponentPlayerName, int i_CurrentTotalScore = 0, int i_OpponentTotalScore = 0)
        {
            m_Board = new CheckersBoardGame(i_BoardSize);
            m_CurrentPlayer = new CheckersPlayer(CheckersPlayer.eType.Player, CheckersTool.eSymbols.PlayerX, ref m_Board, i_CurrentPlayerName, i_CurrentTotalScore);
            m_OpponentPlayer = new CheckersPlayer(i_Type, CheckersTool.eSymbols.PlayerO, ref m_Board, i_OpponentPlayerName, i_OpponentTotalScore);      
            buildPlayerStepsLists();
        }

        public CheckersBoardGame Board
        {
            get
            {
                return m_Board;
            }
        }

        public CheckersPlayer CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
            set
            {
                m_CurrentPlayer = value;
            }
        }

        public CheckersPlayer OpponentPlayer
        {
            get
            {
                return m_OpponentPlayer;
            }
            set
            {
                m_OpponentPlayer = value;
            }
        }

        public void RunGame(Step i_CurrentStep, CheckersPlayer.eType i_PlayerType, ref bool io_IsAnotherJump)
        {
            CheckersTool currentTool;
            bool isOptionToJump = m_CurrentPlayer.CanJump(), isJumpStep = true;

            if (i_PlayerType == CheckersPlayer.eType.Player)
            {
                if (!m_CurrentPlayer.IsValidSquare(m_Board, i_CurrentStep.StepFrom))
                {
                    throw new Exception("The step is not valid - cant move opponent tool!!!");
                }
            }

            currentTool = m_CurrentPlayer.GetTool(i_CurrentStep.StepFrom, !isJumpStep, isOptionToJump, io_IsAnotherJump);

            if (i_PlayerType == CheckersPlayer.eType.Computer)
            {
                i_CurrentStep = currentTool.GetPcStep();
            }

            if (io_IsAnotherJump)
            {
                if (!i_CurrentStep.StepFrom.IsEqualPoint(m_CurrentPlayer.LastStep.StepTo) || !m_CurrentPlayer.LastStep.IsJumpStep)
                {
                    throw new Exception("The step is not valid - must continue the jump!!!");
                }
            }

            if (!m_CurrentPlayer.PerformStep(m_Board, currentTool, i_CurrentStep.StepTo, m_OpponentPlayer, ref io_IsAnotherJump, isOptionToJump))
            {
                throw new Exception("The step is not valid!!!");
            }
            
            if (!io_IsAnotherJump)
            {
                CheckersPlayer.SwapPlayers(ref m_CurrentPlayer, ref m_OpponentPlayer);
            }
            
            m_CurrentPlayer.BuildListsOfValidSteps(m_Board);
        }

        public void InitializeNewGame()
        {
            m_Board.InitializeNewBoard();
            m_OpponentPlayer.InitilazlizePlayer(ref m_Board);
            m_CurrentPlayer.InitilazlizePlayer(ref m_Board);
            buildPlayerStepsLists();
        }

        private void buildPlayerStepsLists()
        {
            m_CurrentPlayer.BuildListsOfValidSteps(m_Board);
        }

        public void IsWin()
        {
            string message = string.Empty;

            if(!m_CurrentPlayer.IsCheckersTools() || !m_CurrentPlayer.IsValidSteps())
            {
                message = string.Format("{0}'s win!", m_OpponentPlayer.PlayerName);
                throw new Exception(message);
            }
        }

        public void IsTie()
        {
            if (!m_CurrentPlayer.IsValidSteps() && !m_OpponentPlayer.IsValidSteps())
            {
                throw new Exception("Tie!");
            }
        }

        public void SwapPlayers()
        {
            CheckersPlayer.SwapPlayers(ref m_CurrentPlayer, ref m_OpponentPlayer);
        }
    }
}