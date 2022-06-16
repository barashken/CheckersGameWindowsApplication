using System;

namespace CheckersLogic
{
    public class CheckersBoardGame
    {
        public enum eBoardSize
        {
            Small = 6,
            Medium = 8,
            Large = 10
        }

        public enum eBoardColor
        {
            White = 0,
            Black = 1
        }

        private int m_BoardSize;     
        private readonly CheckersTool.eSymbols[,] r_BoardArray;
        private readonly eBoardColor[,] r_BoardColors;

        public CheckersBoardGame() { }

        public CheckersBoardGame(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            r_BoardArray = new CheckersTool.eSymbols[m_BoardSize, m_BoardSize];
            r_BoardColors = new eBoardColor[m_BoardSize, m_BoardSize];
            InitializeNewBoard();
        }

        public CheckersTool.eSymbols[,] BoardArray
        {
            get
            {
                return r_BoardArray;
            }
        }

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }
            set
            {
                m_BoardSize = value;
            }
        }

        public eBoardColor[,] BoardColors
        {
            get
            {
                return r_BoardColors;
            }
        }

        public static bool IsValidSize(int i_BoardSize)
        {
            return i_BoardSize == (int)eBoardSize.Small || i_BoardSize == (int)eBoardSize.Medium || i_BoardSize == (int)eBoardSize.Large;
        }

        public void InitializeNewBoard()
        {
            initBoardColors();
            clearBoard();
        }

        private void initBoardColors()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            r_BoardColors[i, j] = eBoardColor.Black;
                        }
                        else
                        {
                            r_BoardColors[i, j] = eBoardColor.White;
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            r_BoardColors[i, j] = eBoardColor.White;
                        }
                        else
                        {
                            r_BoardColors[i, j] = eBoardColor.Black;
                        }
                    }
                }
            }
        }

        public void InitBoardArray(CheckersPlayer i_Player)
        {
            int i = 0;

            if (i_Player.PlayerSymbol == CheckersTool.eSymbols.PlayerO)
            {
                orderBoardArray(i, (m_BoardSize / 2) - 1, CheckersTool.eSymbols.PlayerO, i_Player);
            }
            else
            {
                i = (m_BoardSize / 2) + 1;
                orderBoardArray(i, m_BoardSize, CheckersTool.eSymbols.PlayerX, i_Player);
            }
        }

        private void orderBoardArray(int i_Start, int i_End, CheckersTool.eSymbols i_Symbol, CheckersPlayer i_Player)
        {
            for (; i_Start < i_End; i_Start++)
            {
                if (i_Start % 2 == 0)
                {
                    initPlayerTool(i_Symbol, 1, i_Start, i_Player);
                }
                else
                {
                    initPlayerTool(i_Symbol, 0, i_Start, i_Player);
                }
            }
        }

        private void initPlayerTool(CheckersTool.eSymbols i_Symbol, int i_Index, int i_Row, CheckersPlayer i_Player)
        {
            for (int i = i_Index; i < m_BoardSize; i += 2)
            {
                r_BoardArray[i_Row, i] = i_Symbol;
                Point newPoint = new Point(i_Row, i);
                i_Player.PlayerTools.Add(new CheckersTool(i_Symbol, newPoint));
            }
        }

        private void clearBoard()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    r_BoardArray[i, j] = CheckersTool.eSymbols.Empty;
                }
            }
        }
    }
}