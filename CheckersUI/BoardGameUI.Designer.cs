using System.Windows.Forms;
using System.Drawing;
using CheckersLogic;

namespace CheckersUI
{
    partial class BoardGameUI
    {
        private readonly Image r_ImageX = Resources.xlogo;
        private readonly Image r_ImageO = Resources.ologo;
        private readonly Image r_ImageKingX = Resources.xkinglogo;
        private readonly Image r_ImageKingO = Resources.okinglogo;

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
            this.components = new System.ComponentModel.Container();
            this.ClientSize = new System.Drawing.Size(r_BoardSize * BoardButton.BoardButtonWidth, r_BoardSize * BoardButton.BoardButtonHeigth);

            InitButtonsArray();
            InitBoard();
        }

        public void InitButtonsArray()
        {
            int i = 0, j = 0, left = 0, top = 0;

            for (i = 0; i < r_BoardSize; i++)
            {
                for (j = 0; j < r_BoardSize; j++)
                {
                    m_ButtonsArray[i, j] = new BoardButton(i, j);
                    m_ButtonsArray[i, j].Location = new System.Drawing.Point(left, top);
                    left = m_ButtonsArray[i, j].Right;

                    if (m_BoardGame.BoardColors[i, j] == CheckersBoardGame.eBoardColor.White)
                    {
                        m_ButtonsArray[i, j].BackColor = Color.White;
                    }
                    else
                    {
                        m_ButtonsArray[i, j].BackColor = Color.DimGray;
                        m_ButtonsArray[i, j].Enabled = false;
                    }
                    this.Controls.Add(m_ButtonsArray[i, j]);
                }

                j--;
                top = m_ButtonsArray[i, j].Top + m_ButtonsArray[i, j].Height;
                left = 0;
            }
        }

        public void InitBoard()
        {
            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    switch (m_BoardGame.BoardArray[row, col])
                    {
                        case CheckersTool.eSymbols.PlayerX:
                            m_ButtonsArray[row, col].BackgroundImage = r_ImageX;
                            m_ButtonsArray[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                            m_ButtonsArray[row, col].Tag = CheckersTool.eSymbols.PlayerX;
                            break;
                        case CheckersTool.eSymbols.PlayerO:
                            m_ButtonsArray[row, col].BackgroundImage = r_ImageO;
                            m_ButtonsArray[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                            m_ButtonsArray[row, col].Tag = CheckersTool.eSymbols.PlayerO;
                            break;
                        case CheckersTool.eSymbols.KingX:
                            m_ButtonsArray[row, col].BackgroundImage = r_ImageKingX;
                            m_ButtonsArray[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                            m_ButtonsArray[row, col].Tag = CheckersTool.eSymbols.KingX;
                            break;
                        case CheckersTool.eSymbols.KingO:
                            m_ButtonsArray[row, col].BackgroundImage = r_ImageKingO;
                            m_ButtonsArray[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                            m_ButtonsArray[row, col].Tag = CheckersTool.eSymbols.KingO;
                            break;
                        case CheckersTool.eSymbols.Empty:
                            m_ButtonsArray[row, col].BackgroundImage = null;
                            m_ButtonsArray[row, col].Tag = CheckersTool.eSymbols.Empty;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion
    }
}