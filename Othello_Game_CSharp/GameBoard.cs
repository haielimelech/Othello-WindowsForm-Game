using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_Game_CSharp
{
    public class GameBoard
    {
        private const eCellState k_Empty = eCellState.Empty;
        private const eCellState k_Black = eCellState.Black;
        private const eCellState k_White = eCellState.White;
        private eCellState[,] m_Board;
        private int m_EmptyCells;
        private int m_BlackCells;
        private int m_WhiteCells;

        public GameBoard(int i_Size)
        {
            m_Board = new eCellState[i_Size, i_Size];

            for (int i = 0; i < i_Size; i++)
            {
                for (int j = 0; j < i_Size; j++)
                {
                    m_Board[i, j] = k_Empty;
                }
            }

            m_Board[((i_Size / 2) - 1), ((i_Size / 2) - 1)] = k_White;
            m_Board[((i_Size / 2) - 1), (i_Size / 2)] = k_Black;
            m_Board[(i_Size / 2), ((i_Size / 2) - 1)] = k_Black;
            m_Board[(i_Size / 2), (i_Size / 2)] = k_White;
            m_WhiteCells = 2;
            m_BlackCells = 2;
            m_EmptyCells = (i_Size * i_Size) - (m_BlackCells + m_WhiteCells);
        }

        public eCellState[,] Board
        {
            get { return m_Board; }
            set { m_Board = value; }
        }

        public int EmptyCells
        {
            get { return m_EmptyCells; }
            set { m_WhiteCells = value; }
        }

        public int BlackCells
        {
            get { return m_BlackCells; }
            set { m_BlackCells = value; }
        }

        public int WhiteCells
        {
            get { return m_WhiteCells; }
            set { m_WhiteCells = value; }
        }

        public bool IsValidMove(Player i_CurrentPlayer, int i_Row, int i_Col)
        {
            bool isValid = false;

            if (m_Board[i_Row, i_Col] == k_Empty)
            {
                for (int rowDirection = -1; rowDirection <= 1 && !isValid; rowDirection++)
                {
                    for (int colDirection = -1; colDirection <= 1 && !isValid; colDirection++)
                    {
                        if (!((rowDirection == 0) && (colDirection == 0)) && canFlip(i_CurrentPlayer, i_Row, i_Col, rowDirection, colDirection))
                        {
                            isValid = true;
                        }
                    }
                }
            }

            return isValid;
        }

        private bool canFlip(Player i_Player, int i_Row, int i_Col, int i_DirectionRow, int i_DirectionCol)
        {
            bool isPossible = true;

            int rowToCheck = i_Row + i_DirectionRow;
            int colToCheck = i_Col + i_DirectionCol;

            while (rowToCheck >= 0 && rowToCheck < this.m_Board.GetLength(0) && colToCheck >= 0 &&
                colToCheck < this.m_Board.GetLength(0) && (this.m_Board[rowToCheck, colToCheck] == i_Player.GetOpponentState()))
            {
                rowToCheck += i_DirectionRow;
                colToCheck += i_DirectionCol;
            }

            if (rowToCheck < 0 || rowToCheck > this.m_Board.GetLength(0) - 1 || colToCheck < 0 ||
                colToCheck > this.m_Board.GetLength(0) - 1 || (rowToCheck - i_DirectionRow == i_Row && colToCheck - i_DirectionCol == i_Col) ||
                this.m_Board[rowToCheck, colToCheck] != i_Player.State)
            {
                isPossible = false;
            }

            return isPossible;
        }

        public void UpdateBoardState(Player i_Player, int i_Row, int i_Col)
        {
            for (int rowDirection = -1; rowDirection <= 1; rowDirection++)
            {
                for (int colDirection = -1; colDirection <= 1; colDirection++)
                {
                    if (canFlip(i_Player, i_Row, i_Col, rowDirection, colDirection))
                    {
                        flipChips(i_Player, i_Row, i_Col, rowDirection, colDirection);
                    }
                }
            }
        }

        private void flipChips(Player i_Player, int i_Row, int i_Col, int rowDirection, int colDirection)
        {
            m_Board[i_Row, i_Col] = i_Player.State;
            int checkRow = i_Row + rowDirection;
            int checkCol = i_Col + colDirection;

            while (m_Board[checkRow, checkCol] != i_Player.State)
            {
                m_Board[checkRow, checkCol] = i_Player.State;
                checkRow += rowDirection;
                checkCol += colDirection;
            }
        }

        public void CountCells()
        {
            BlackCells = 0;
            EmptyCells = 0;
            WhiteCells = 0;

            for (int i = 0; i < m_Board.GetLength(0); i++)
            {
                for (int j = 0; j < m_Board.GetLength(0); j++)
                {
                    if (Board[i, j] == k_Black)
                    {
                        BlackCells++;
                    }
                    else
                    {
                        if (Board[i, j] == k_White)
                        {
                            WhiteCells++;
                        }
                        else
                        {
                            if (Board[i, j] == k_Empty)
                            {
                                EmptyCells++;
                            }
                        }
                    }
                }
            }
        }
    }
}
