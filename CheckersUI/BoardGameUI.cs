using System.Drawing;
using System.Windows.Forms;
using CheckersLogic;

namespace CheckersUI
{
    public partial class BoardGameUI : Control
    {
        private readonly int r_BoardSize;
        private BoardButton[,] m_ButtonsArray;
        private CheckersBoardGame m_BoardGame;

        public BoardGameUI(int i_BoardSize, CheckersBoardGame i_Board)
        {
            r_BoardSize = i_BoardSize;
            m_ButtonsArray = new BoardButton[r_BoardSize, r_BoardSize];
            m_BoardGame = i_Board;
            InitializeComponent();
        }

        public BoardButton[,] ButtonsArray
        {
            get
            {
                return m_ButtonsArray;
            }
        }

        public CheckersBoardGame BoardGame
        {
            get
            {
                return m_BoardGame;
            }
            set
            {
                m_BoardGame = value;
            }
        }

        public Image ImageX
        {
            get
            {
                return r_ImageX;
            }
        }

        public Image ImageO
        {
            get
            {
                return r_ImageO;
            }
        }

        public Image ImageKingX
        {
            get
            {
                return r_ImageKingX;
            }
        }

        public Image ImageKingO
        {
            get
            {
                return r_ImageKingX;
            }
        }

        public void IntializeNewBoard(CheckersBoardGame i_Board)
        {
            m_BoardGame = i_Board;
            Controls.Clear();
            m_ButtonsArray = new BoardButton[r_BoardSize, r_BoardSize];
            InitButtonsArray();
            InitBoard();
        }
    }
}
