using System;
using System.Drawing;
using System.Windows.Forms;
using CheckersLogic;

namespace CheckersUI
{
    public partial class ManageGameUI : Form
    {
        private enum eGameState
        {
            Process,
            ProcessComputer,
            AnotherGame,
            Finish
        }

        private readonly GameSettings r_GameSettings;
        private readonly string r_FirstPlayerName;
        private ManageGame m_Game;
        private BoardGameUI m_BoardGame;
        private BoardButton m_ButtonLastClicked;
        private BoardButton m_ButtonCurrentClicked;

        public ManageGameUI()
        {
            r_GameSettings = new GameSettings();
            if (r_GameSettings.IsDoneClicked)
            {
                r_FirstPlayerName = r_GameSettings.FirstPlayerName;
                initializeGame();
            }
        }

        private void initializeGame()
        {
            m_Game = new ManageGame(r_GameSettings.BoardSize, r_GameSettings.GameType, r_GameSettings.FirstPlayerName, r_GameSettings.SecondPlayerName);
            m_BoardGame = new BoardGameUI(r_GameSettings.BoardSize, m_Game.Board);
            InitializeComponent();
        }

        private eGameState runGame(ref bool io_IsAnotherJump)
        {
            eGameState gameState = eGameState.ProcessComputer;
            string outputMessage = string.Empty;
            Step inputStep = new Step();
            bool canStep = true;
            DialogResult wantToContinue;

            try
            {
                if (m_Game.CurrentPlayer.PlayerType == CheckersPlayer.eType.Player)
                {
                    canStep = getStep(ref inputStep);
                    gameState = eGameState.Process;
                }

                if (canStep)
                {
                    try
                    {
                        m_Game.RunGame(inputStep, m_Game.CurrentPlayer.PlayerType, ref io_IsAnotherJump);
                        m_BoardGame.InitBoard();
                        Refresh();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                m_Game.IsTie();
                m_Game.IsWin();
            }
            catch (Exception exception)
            {
                outputMessage = string.Format("{0}" + Environment.NewLine + "Another Round?", exception.Message);
                wantToContinue = MessageBox.Show(outputMessage, "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (wantToContinue == DialogResult.Yes)
                {
                    gameState = eGameState.AnotherGame;
                    calcScore();
                    changeScore(m_Game.CurrentPlayer.TotalScore, m_Game.OpponentPlayer.TotalScore);
                    if(m_Game.CurrentPlayer.PlayerName != r_FirstPlayerName)
                    {
                        m_Game.SwapPlayers();
                    }
                }
                else if (wantToContinue == DialogResult.No)
                {
                    gameState = eGameState.Finish;
                }
            }

            return gameState;
        }

        public void BoardButton_Clicked(object sender, EventArgs e)
        {
            bool isWantToDoStep = false, isAnotherJump = false;
            eGameState gameState;

            m_ButtonLastClicked = m_ButtonCurrentClicked;
            m_ButtonCurrentClicked = sender as BoardButton;

            if (m_ButtonCurrentClicked.Tag.Equals(m_Game.OpponentPlayer.PlayerSymbol) || m_ButtonCurrentClicked.Tag.Equals(m_Game.OpponentPlayer.PlayerKingSymbol))
            {
                m_ButtonCurrentClicked = m_ButtonLastClicked;
            }
            else
            {
                if (m_ButtonCurrentClicked.BackColor == Color.White)
                {
                    if (m_ButtonCurrentClicked.Tag.Equals(CheckersTool.eSymbols.Empty))
                    {
                        isWantToDoStep = clickedEmptyButton();
                    }
                    else
                    {
                        changeButtonBackColor();
                    }
                }
                else
                {
                    cancelButtonClicked();
                }

                if (isWantToDoStep)
                {
                    gameState = runGame(ref isAnotherJump);
                    executeGameState(gameState, ref isAnotherJump);
                    while (m_Game.CurrentPlayer.PlayerType == CheckersPlayer.eType.Computer)
                    {
                        System.Threading.Thread.Sleep(1500);
                        gameState = runGame(ref isAnotherJump);
                        executeGameState(gameState, ref isAnotherJump);
                        if (gameState == eGameState.AnotherGame)
                        {
                            break;
                        }

                        changePlayerNameColor();
                        Refresh();
                    }
                }
            }
        }

        private void ManageGameUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void resetGame()
        {
            m_ButtonCurrentClicked = m_ButtonLastClicked = null;
            this.Controls.Clear();
            m_Game.InitializeNewGame();
            m_BoardGame.IntializeNewBoard(m_Game.Board);
            initButtonsArray();
            addControls();
            changePlayerNameColor();
        }

        private void processGame(ref bool io_IsAnotherJump)
        {
            m_ButtonLastClicked.BackColor = Color.White;
            if (!io_IsAnotherJump)
            {
                cancelButtonClicked();
            }
            else
            {
                m_ButtonCurrentClicked.BackColor = Color.LightBlue;
            }

            changePlayerNameColor();
            Refresh();
        }

        private void executeGameState(eGameState i_GameState, ref bool io_IsAnotherJump)
        {
            switch (i_GameState)
            {
                case eGameState.Process:
                    processGame(ref io_IsAnotherJump);
                    break;
                case eGameState.AnotherGame:
                    resetGame();
                    break;
                case eGameState.Finish:
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }

        private bool clickedEmptyButton()
        {
            bool isWantToDoStep = false;

            if (m_ButtonLastClicked != null)
            {
                isWantToDoStep = true;
            }
            else
            {
                m_ButtonCurrentClicked = null;
            }

            return isWantToDoStep;
        }

        private void cancelButtonClicked()
        {
            m_ButtonCurrentClicked.BackColor = Color.White;
            m_ButtonCurrentClicked = null;
            m_ButtonLastClicked = null;
        }

        private void changeButtonBackColor()
        {
            if (m_ButtonLastClicked == null)
            {
                m_ButtonCurrentClicked.BackColor = Color.LightBlue;
            }
            else
            {
                if (m_ButtonLastClicked.BackColor == Color.LightBlue)
                {
                    m_ButtonCurrentClicked = m_ButtonLastClicked;
                }
            }
        }

        private bool getStep(ref Step io_Step)
        {
            bool getStep = true;

            if (m_ButtonLastClicked != null && m_ButtonCurrentClicked != null)
            {
                io_Step = new Step(m_ButtonLastClicked.ButtonPoint, m_ButtonCurrentClicked.ButtonPoint);
                getStep = true;
            }
            else
            {
                getStep = false;
            }

            return getStep;
        }

        private void changePlayerNameColor()
        {
            if (m_Game.CurrentPlayer.PlayerName == r_FirstPlayerName)
            {
                m_LabelPlayerOne.ForeColor = Color.Red;
                m_LabelPlayerTwo.ForeColor = Color.Black;
            }
            else
            {
                m_LabelPlayerTwo.ForeColor = Color.Red;
                m_LabelPlayerOne.ForeColor = Color.Black;
            }
        }

        private void calcScore()
        {
            int prevScoreCurrentPlayer = m_Game.CurrentPlayer.Score;

            m_Game.CurrentPlayer.CalcScore();
            m_Game.OpponentPlayer.CalcScore();
            m_Game.OpponentPlayer.TotalScore = m_Game.OpponentPlayer.Score - (m_Game.CurrentPlayer.Score - prevScoreCurrentPlayer);
        }

        private void changeScore(int i_PlayerOneScore, int i_PlayerTwoScore)
        {
            string playerOneText = string.Empty;
            string playerTwoText = string.Empty;

            m_Game.CurrentPlayer.TotalScore = i_PlayerOneScore;
            m_Game.OpponentPlayer.TotalScore = i_PlayerTwoScore;
            if (m_Game.CurrentPlayer.PlayerName == r_GameSettings.FirstPlayerName)
            {
                changeStringLabelsText(ref playerOneText, ref playerTwoText);
            }
            else
            {
                changeStringLabelsText(ref playerTwoText, ref playerOneText);
            }

            if (m_LabelPlayerOne.Tag.ToString() == r_FirstPlayerName)
            {
                changeLabelsText(playerOneText, playerTwoText);
            }
            else
            {
                changeLabelsText(playerTwoText, playerOneText);
            }
        }

        private void changeLabelsText(string i_LabelOne, string i_LabelTwo)
        {
            m_LabelPlayerOne.Text = i_LabelOne;
            m_LabelPlayerTwo.Text = i_LabelTwo;
        }

        private void changeStringLabelsText(ref string io_LabelOne, ref string io_LabelTwo)
        {
            io_LabelOne = string.Format("{0}: {1}", m_Game.CurrentPlayer.PlayerName, m_Game.CurrentPlayer.TotalScore);
            io_LabelTwo = string.Format("{0}: {1}", m_Game.OpponentPlayer.PlayerName, m_Game.OpponentPlayer.TotalScore);
        }
    }
}