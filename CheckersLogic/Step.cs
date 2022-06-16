using System.Collections.Generic;

namespace CheckersLogic
{
    public class Step
    {
        private Point m_StepFrom;
        private Point m_StepTo;
        private Point m_PointToEat;
        private bool m_IsJumpStep = false;

        public Step() { }

        public Step(Point i_StepFrom, Point i_StepTo)
        {
            m_StepFrom = i_StepFrom;
            m_StepTo = i_StepTo;
        }

        public Step(Point i_StepFrom, Point i_StepTo, bool i_IsJumpStep)
        {
            m_StepFrom = i_StepFrom;
            m_StepTo = i_StepTo;
            m_IsJumpStep = i_IsJumpStep;
        }

        public Point StepFrom
        {
            get
            {
                return m_StepFrom;
            }
            set
            {
                m_StepFrom = value;
            }
        }

        public Point StepTo
        {
            get
            {
                return m_StepTo;
            }
            set
            {
                m_StepTo = value;
            }
        }

        public Point PointToEat
        {
            get
            {
                return m_PointToEat;
            }
            set
            {
                m_PointToEat = value;
            }
        }

        public bool IsJumpStep
        {
            get
            {
                return m_IsJumpStep;
            }
            set
            {
                m_IsJumpStep = value;
            }
        }

        public static bool FindStep(ref Step io_Step, List<Step> i_List)
        {
            bool isFound = false;

            foreach (Step currentStep in i_List)
            {
                if (currentStep.IsEqualStep(io_Step))
                {
                    isFound = true;
                    io_Step = currentStep;
                    break;
                }
            }

            return isFound;
        }

        public bool IsEqualStep(Step i_InputStep)
        {
            return m_StepFrom.IsEqualPoint(i_InputStep.m_StepFrom) && m_StepTo.IsEqualPoint(i_InputStep.m_StepTo);
        }

        public bool IsValidStep(CheckersBoardGame i_Board)
        {
            return IsInsideTheBoard(i_Board, m_StepTo) && !isPointOccupied(i_Board.BoardArray[m_StepTo.Row, m_StepTo.Col]);
        }

        private bool isPointOccupied(CheckersTool.eSymbols i_Symbol)
        {
            return i_Symbol != CheckersTool.eSymbols.Empty;
        }

        public bool IsInsideTheBoard(CheckersBoardGame i_Board, Point i_Point)
        {
            return i_Point.Row >= 0 && i_Point.Row < i_Board.BoardSize && i_Point.Col >= 0 && i_Point.Col < i_Board.BoardSize;
        }
    }
}