using System;
using System.Windows.Forms;
using CheckersLogic;

namespace CheckersUI
{
    public partial class GameSettings : Form
    {
        private const string k_ComputerString = "[Computer]";

        private string m_FirstPlayerName;
        private string m_SecondPlayerName = "Computer";
        private int m_BoardSize;
        private CheckersPlayer.eType m_GameType = CheckersPlayer.eType.Computer;
        private bool m_IsButtonDoneClicked = false;

        public GameSettings()
        {
            InitializeComponent();
            ShowDialog();
        }

        public string FirstPlayerName
        {
            get
            {
                return m_FirstPlayerName;
            }
        }

        public string SecondPlayerName
        {
            get
            {
                return m_SecondPlayerName;
            }
        }

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }
        }

        public CheckersPlayer.eType GameType
        {
            get
            {
                return m_GameType;
            }
        }

        public bool IsDoneClicked
        {
            get
            {
                return m_IsButtonDoneClicked;
            }
        }

        private void m_CheckBoxPlayerTwo_CheckedChanged(object sender, EventArgs e)
        {
            if(m_CheckBoxPlayerTwo.Checked)
            {
                m_TextBoxPlayerTwo.Enabled = true;
                m_TextBoxPlayerTwo.Text = string.Empty;
            }
            else
            {
                m_TextBoxPlayerTwo.Enabled = false;
                m_TextBoxPlayerTwo.Text = k_ComputerString;
            }
        }

        private void m_ButtonDone_Click(object sender, EventArgs e)
        {
            if (m_TextBoxPlayerOne.Text != string.Empty && CheckersPlayer.IsValidName(m_TextBoxPlayerOne.Text))
            {
                m_FirstPlayerName = m_TextBoxPlayerOne.Text;
                if (m_CheckBoxPlayerTwo.Checked)
                {
                    if (m_TextBoxPlayerTwo.Text != string.Empty && CheckersPlayer.IsValidName(m_TextBoxPlayerTwo.Text))
                    {
                        m_SecondPlayerName = m_TextBoxPlayerTwo.Text;
                        m_BoardSize = getBoardSizeFromRadioButtons();
                        m_GameType = CheckersPlayer.eType.Player;
                        m_IsButtonDoneClicked = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Player 2 name is not valid!");
                    }
                }
                else
                {
                    m_BoardSize = getBoardSizeFromRadioButtons();
                    m_IsButtonDoneClicked = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Player 1 name is not valid!");
            }
        }

        private int getBoardSizeFromRadioButtons()
        {
            int boardSize = 0;

            if(m_RadioButton6BoardSize.Checked)
            {
                boardSize = (int)CheckersBoardGame.eBoardSize.Small;
            }
            else if(m_RadioButton8BoardSize.Checked)
            {
                boardSize = (int)CheckersBoardGame.eBoardSize.Medium;
            }
            else if(m_RadioButton10BoardSize.Checked)
            {
                boardSize = (int)CheckersBoardGame.eBoardSize.Large;
            }

            return boardSize;
        }

        private void GameSettings_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if(!m_IsButtonDoneClicked)
            {
                Application.Exit();
            }
        }
    }
}