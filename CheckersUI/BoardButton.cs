using System.ComponentModel;
using System.Windows.Forms;
using CheckersLogic;

namespace CheckersUI
{
    public partial class BoardButton : Button
    {
        private static readonly int sr_BoardButtonWidth = 70;
        private static readonly int sr_BoardButtonHeigth = 70;
        private readonly Point r_ButtonPoint;

        public BoardButton(int i_Row, int i_Col)
        {
            r_ButtonPoint = new Point(i_Row, i_Col);
            this.Width = sr_BoardButtonWidth;
            this.Height = sr_BoardButtonHeigth;
            
            InitializeComponent();
        }

        public static int BoardButtonWidth
        {
            get
            {
                return sr_BoardButtonWidth;
            }
        }

        public static int BoardButtonHeigth
        {
            get
            {
                return sr_BoardButtonHeigth;
            }
        }

        public Point ButtonPoint
        {
            get
            {
                return r_ButtonPoint;
            }
        }

        public BoardButton(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
}