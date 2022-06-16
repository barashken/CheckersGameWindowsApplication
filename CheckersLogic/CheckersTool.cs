using System;
using System.Collections.Generic;

namespace CheckersLogic
{
    public class CheckersTool
    {
        public enum eSymbols
        {
            PlayerX = 'X',
            PlayerO = 'O',
            KingX = 'K',
            KingO = 'U',
            Empty = ' '
        }

        private enum eDirections
        {
            Up = -1,
            Down = 1,
            Left = -1,
            Right = 1
        }

        private eSymbols m_Symbol;
        private eSymbols m_KingSymbol;
        private Point m_Point;
        private List<Step> m_ListOfRegularSteps;
        private List<Step> m_ListOfJumpsSteps;

        public CheckersTool() { }

        public CheckersTool(eSymbols i_Symbol, Point i_Point)
        {
            m_Symbol = i_Symbol;
            m_Point = i_Point;
            m_KingSymbol = i_Symbol == eSymbols.PlayerO ? eSymbols.KingO : eSymbols.KingX;
        }

        public eSymbols Symbol
        {
            get
            {
                return m_Symbol;
            }
            set
            {
                m_Symbol = value;
            }
        }

        public Point Point
        {
            get
            {
                return m_Point;
            }
            set
            {
                m_Point = value;
            }
        }

        public eSymbols KingSymbol
        {
            set
            {
                m_KingSymbol = value;
            }
        }

        public List<Step> ListOfRegularSteps
        {
            get
            {
                return m_ListOfRegularSteps;
            }
        }

        public List<Step> ListOfJumpsSteps
        {
            get
            {
                return m_ListOfJumpsSteps;
            }
        }

        public void BuildList(CheckersBoardGame i_Board)
        {
            eDirections currentDirection = m_Symbol == eSymbols.PlayerO ? eDirections.Down : eDirections.Up;
            Step currentStep = new Step();

            currentStep.StepFrom = m_Point;
            m_ListOfJumpsSteps = new List<Step>();
            m_ListOfRegularSteps = new List<Step>();
            insertStepToList(currentStep, i_Board, currentDirection, eDirections.Right);
            insertStepToList(currentStep, i_Board, currentDirection, eDirections.Left);
            if (isKing())
            {
                currentDirection = m_Symbol != eSymbols.PlayerO ? eDirections.Down : eDirections.Up;
                insertStepToList(currentStep, i_Board, currentDirection, eDirections.Right);
                insertStepToList(currentStep, i_Board, currentDirection, eDirections.Left);
            }
        }

        private void insertStepToList(Step i_Step, CheckersBoardGame i_Board, eDirections i_DirectionUpOrDown, eDirections i_DirectionLeftOrRight)
        {
            Step newStep = new Step(i_Step.StepFrom, new Point(m_Point.Row + (int)i_DirectionUpOrDown, m_Point.Col + (int)i_DirectionLeftOrRight));

            if(isOpponent(newStep, i_Board))
            {
                newStep.PointToEat = newStep.StepTo;
                newStep.StepTo = new Point(m_Point.Row + ((int)i_DirectionUpOrDown * 2), m_Point.Col + ((int)i_DirectionLeftOrRight * 2));
                newStep.IsJumpStep = true;
            }
            if (newStep.IsValidStep(i_Board))
            {
                if(newStep.IsJumpStep)
                {
                    m_ListOfJumpsSteps.Add(newStep);
                }
                else
                {
                    m_ListOfRegularSteps.Add(newStep);
                }
            }
        }

        private bool isKing()
        {
            return m_Symbol == eSymbols.KingX || m_Symbol == eSymbols.KingO;
        }

        private bool isOpponent(Step i_Step, CheckersBoardGame i_Board)
        {
            bool isOpponent = true;
            eSymbols currentSymbol;

            if (i_Step.IsInsideTheBoard(i_Board, i_Step.StepTo))
            {
                currentSymbol = i_Board.BoardArray[i_Step.StepTo.Row, i_Step.StepTo.Col];
                if (currentSymbol == m_Symbol || currentSymbol == m_KingSymbol || currentSymbol == eSymbols.Empty)
                {
                    isOpponent = false;
                }
            }
            else
            {
                isOpponent = false;
            }

            return isOpponent;
        }

        public bool IsAnotherJump(CheckersBoardGame i_Board)
        {
            bool returnValue = true;

            BuildList(i_Board);
            if(m_ListOfJumpsSteps.Count == 0)
            {
                returnValue = false;
            }

            return returnValue;
        }

        public bool IsStepsLeft(bool i_IsOptionToJump)
        {
            bool isSteps;

            if(i_IsOptionToJump)
            {
                isSteps = m_ListOfJumpsSteps.Count != 0;
            }
            else
            {
                isSteps = m_ListOfRegularSteps.Count != 0;
            }

            return isSteps;
        }

        public Step GetPcStep()
        {
            Step returnStep;
            int randomIndex;

            if (ListOfJumpsSteps.Count != 0)
            {
                randomIndex = new Random().Next(0, m_ListOfJumpsSteps.Count - 1);
                returnStep = m_ListOfJumpsSteps[randomIndex];
            }
            else
            {
                randomIndex = new Random().Next(0, m_ListOfRegularSteps.Count - 1);
                returnStep = m_ListOfRegularSteps[randomIndex];
            }

            return returnStep;
        }

        public void ChangeToKing(CheckersBoardGame i_Board, Point i_Point)
        {
            if(Symbol == eSymbols.PlayerX && i_Point.Row == 0)
            {
                Symbol = eSymbols.KingX;
                KingSymbol = eSymbols.PlayerX;
            }
            else if(Symbol == eSymbols.PlayerO && i_Point.Row == i_Board.BoardSize - 1)
            {
                Symbol = eSymbols.KingO;
                KingSymbol = eSymbols.PlayerO;
            }
        }
    }
}