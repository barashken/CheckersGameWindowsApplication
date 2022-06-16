using System.Windows.Forms;
using System.Drawing;

namespace CheckersUI
{
    partial class ManageGameUI
    {
        private System.Windows.Forms.Label m_LabelPlayerOne;
        private System.Windows.Forms.Label m_LabelPlayerTwo;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_LabelPlayerOne = new System.Windows.Forms.Label();
            this.m_LabelPlayerTwo = new System.Windows.Forms.Label();
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(m_BoardGame.Width + 20, m_BoardGame.Height + 50);
            this.Text = "Damka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            m_BoardGame.Location = new System.Drawing.Point(this.Left + 10, this.Top + 40);

            string playerOneText = string.Format("{0}: {1}", m_Game.CurrentPlayer.PlayerName, m_Game.CurrentPlayer.TotalScore);
            string playerTwoText = string.Format("{0}: {1}", m_Game.OpponentPlayer.PlayerName, m_Game.OpponentPlayer.TotalScore);

            this.m_LabelPlayerOne.Name = "m_LabelPlayerOne";
            this.m_LabelPlayerOne.Text = playerOneText;
            this.m_LabelPlayerOne.Tag = m_Game.CurrentPlayer.PlayerName;
            this.m_LabelPlayerOne.Font = new System.Drawing.Font(Label.DefaultFont, FontStyle.Bold);
            this.m_LabelPlayerOne.Location = new System.Drawing.Point(Left + 10 + BoardButton.BoardButtonWidth, Top + 15);
            this.m_LabelPlayerOne.ForeColor = Color.Red;

            this.m_LabelPlayerTwo.Name = "m_LabelPlayerTwo";
            this.m_LabelPlayerTwo.Text = playerTwoText;
            this.m_LabelPlayerTwo.Tag = m_Game.OpponentPlayer.PlayerName;
            this.m_LabelPlayerTwo.Font = new System.Drawing.Font(Label.DefaultFont, FontStyle.Bold);
            this.m_LabelPlayerTwo.Location = new System.Drawing.Point(Right - 10 - 2*BoardButton.BoardButtonWidth, Top + 15);

            initButtonsArray();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.FormClosing += ManageGameUI_FormClosing;
            addControls();
        }

        private void initButtonsArray()
        {
            for (int i = 0; i < r_GameSettings.BoardSize; i++)
            {
                for (int j = 0; j < r_GameSettings.BoardSize; j++)
                {
                    m_BoardGame.ButtonsArray[i, j].Click += new System.EventHandler(this.BoardButton_Clicked);
                }
            }
        }

        private void addControls()
        {
            this.Controls.Add(m_BoardGame);
            this.Controls.Add(m_LabelPlayerOne);
            this.Controls.Add(m_LabelPlayerTwo);
        }
        #endregion
    }
}