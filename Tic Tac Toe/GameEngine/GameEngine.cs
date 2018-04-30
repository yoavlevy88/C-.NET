using System;
using System.Collections.Generic;

namespace GameEngine
{
    public class GameEngine
    {
        public const int k_One = 1, k_Two = 2, k_Zero = 0, k_None = -1;

        private BoardCell[,] m_GameBoard;
        private Player[] m_Players; 
        private int m_Size;
        private int m_CurrentPlayer = k_Zero;
        private int m_CurrentPlayerToAdd = k_Zero;
        private int m_StepsCounter;
        public bool m_IsEndOfMatch = false;

        public void InitializeGame(int i_Size, bool i_IsNewGame)
        {
            m_Size = i_Size;
            m_StepsCounter = k_Zero;
            m_IsEndOfMatch = false;
            m_GameBoard = new BoardCell[i_Size, i_Size];
            for(int rowIndex = k_Zero; rowIndex < i_Size; rowIndex++)
            {
                for(int colIndex = k_Zero; colIndex < i_Size; colIndex++)
                {
                    m_GameBoard[rowIndex, colIndex] = new BoardCell("Z", false, colIndex, rowIndex);
                }
            }

            if(i_IsNewGame)
            {
                m_Players = new Player[k_Two];
            }
            else
            {
                m_Players[k_Zero].m_Steps.Clear();
                m_Players[k_One].m_Steps.Clear();
            } 
        }

        public bool IsEmptyCell(int i_Row, int i_Col)
        {
            return !m_GameBoard[i_Row, i_Col].m_IsVisible;
        }

        public bool IsLegalCoordinates(int i_Row, int i_Col)
        {
            return i_Row >= k_Zero && i_Row <= m_Size && i_Col >= k_Zero && i_Col <= m_Size;
        }

        public Player[] GetPlayers()
        {
            return m_Players;
        }

        public int GetScores(int i_NumOfPlayer)
        {
            return m_Players[i_NumOfPlayer].m_Score;
        }

        public void MakeTurn(int i_Row, int i_Col)
        {
            m_GameBoard[i_Row, i_Col].m_IsVisible = true;
            m_GameBoard[i_Row, i_Col].m_SignOfCell = m_Players[m_CurrentPlayer].m_Sign;
            m_Players[m_CurrentPlayer].AddStep(i_Col, i_Row);
            m_StepsCounter++;

            m_IsEndOfMatch = CheckWinner(m_Players[m_CurrentPlayer].m_Steps);
            if(m_IsEndOfMatch)
            {
                GetOpponent().m_Score++;
            }
        }

        public void SetForNewMatch(int i_Size)
        {
            InitializeGame(i_Size, false);
        }

        public void AddPlayer(string i_Name, bool i_isHuman)
        {
            string sign = (m_CurrentPlayerToAdd == k_Zero) ? "X" : "Y";
            m_Players[m_CurrentPlayerToAdd] = new Player(i_Name, sign, i_isHuman);
            m_CurrentPlayerToAdd = (m_CurrentPlayerToAdd + k_One) % k_Two;
        }

        public void SwitchPlayer()
        {
            m_CurrentPlayer = (m_CurrentPlayer + k_One) % k_Two;
        }

        public Player GetCurrentPlayer()
        {
            return m_Players[m_CurrentPlayer];
        }

        public Player GetOpponent()
        {
            return m_Players[(m_CurrentPlayer + k_One) % k_Two];
        }

        public BoardCell[,] GetCurrentBoardState()
        {
            return m_GameBoard;
        }

        public bool IsProtectedLine(int i_Index, bool i_Action)
        {
            bool result = false;
            List<BoardCell> steps = GetCurrentPlayer().m_Steps;

            foreach (BoardCell step in steps)
            {
               if (i_Action)
                {
                    if (step.m_Col == i_Index)
                    {
                        result = true;
                    }
                }
                else
                {
                    if (step.m_Row == i_Index)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public bool IsProtectedDiagonal()
        {
            bool result = false;
            List<BoardCell> steps = GetCurrentPlayer().m_Steps;
            foreach (BoardCell step in steps)
            {
                if (step.m_Col == step.m_Row)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        // $G$ DSN-003 (-10) the code should be divided to methods
        public int[] GenerateCoordinates()
        {
            List<BoardCell> steps = GetOpponent().m_Steps;
            int[] coordinates = new int[k_Two] { k_None, k_None };
            int[] colsBucket = new int[m_Size];
            int diagonalCounter = k_Zero;
            int max = k_Zero;
            int maxColIndex = k_Zero;

            Array.Clear(colsBucket, k_Zero, m_Size);
            foreach (BoardCell step in steps)
            {
                colsBucket[step.m_Row]++;

                if (step.m_Col == step.m_Row)
                {
                    diagonalCounter++;
                }
            }

            for (int i = k_Zero; i < m_Size; i++)
            {
                if (colsBucket[i] > max)
                {
                    max = colsBucket[i];
                    maxColIndex = i;
                }
            }

            if (max > diagonalCounter)
            {
                for (int j = k_Zero; j < m_Size; j++)
                {
                    if (IsEmptyCell(maxColIndex, j) && IsLegalCoordinates(maxColIndex, j))
                    {
                        coordinates[k_Zero] = maxColIndex;
                        coordinates[k_One] = j;
                        break;
                    }
                }

                if (IsProtectedLine(maxColIndex, false))
                {
                    Array.Clear(colsBucket, k_Zero, m_Size);
                    max = k_Zero;
                    maxColIndex = k_Zero;
                    foreach (BoardCell step in steps)
                    {
                        colsBucket[step.m_Col]++;
                    }

                    for (int i = k_Zero; i < m_Size; i++)
                    {
                        if (colsBucket[i] > max)
                        {
                            max = colsBucket[i];
                            maxColIndex = i;
                        }
                    }

                    for (int j = k_Zero; j < m_Size; j++)
                    {
                        if (IsEmptyCell(j, maxColIndex) && IsLegalCoordinates(j, maxColIndex))
                        {
                            coordinates[k_Zero] = j;
                            coordinates[k_One] = maxColIndex;
                            break;
                        }
                    }

                    if (IsProtectedLine(maxColIndex, true))
                    {
                        coordinates[k_Zero] = k_None;
                        coordinates[k_One] = k_None;
                    }
                }
            }
            else if (!IsProtectedDiagonal())
            {
                for (int k = k_Zero; k < m_Size; k++)
                {
                    if (IsEmptyCell(k, k) && IsLegalCoordinates(k, k))
                    {
                        coordinates[k_Zero] = k;
                        coordinates[k_One] = k;
                        break;
                    }
                }
            }

            if(coordinates[k_Zero] == k_None)
            {
                Random rnd = new Random();
                coordinates[k_Zero] = rnd.Next() % m_Size;
                coordinates[k_One] = rnd.Next() % m_Size;
                while (!IsEmptyCell(coordinates[k_Zero], coordinates[k_One]) || !IsLegalCoordinates(coordinates[k_Zero], coordinates[k_One]))
                {
                    coordinates[k_Zero] = rnd.Next() % m_Size;
                    coordinates[k_One] = rnd.Next() % m_Size;
                }
            }

            return coordinates;
        }

        public bool CheckWinner(List<BoardCell> i_steps)
        {
            bool result = false;
            int diagonalCounter = k_Zero;
            int colCounter = k_Zero;
            int rowCounter = k_Zero;
            int[] tempBucket = new int[m_Size];
            /// Cols check
            Array.Clear(tempBucket, k_Zero, m_Size);
            foreach (BoardCell step in i_steps)
            {
                tempBucket[step.m_Col]++;
                if(tempBucket[step.m_Col] == m_Size)
                {
                    result = true;
                }

                /// bytheway we can check the main diagonal:
                if(step.m_Col == step.m_Row)
                {
                    diagonalCounter++;
                }
            }

            if(diagonalCounter == m_Size)
            {
                result = true;
            }
            else
            {
                diagonalCounter = k_Zero;
            }

            // Rows check
            Array.Clear(tempBucket, k_Zero, m_Size);
            foreach (BoardCell step in i_steps)
            {
                tempBucket[step.m_Row]++;
                if (tempBucket[step.m_Row] == m_Size)
                {
                    result = true;
                }
            }

            // Back Diagonal check
            diagonalCounter = k_Zero;
            
            foreach (BoardCell step in i_steps)
            {
                rowCounter = k_Zero;
                colCounter = m_Size - k_One;
                for (int i = k_Zero; i < m_Size; i++)
                {
                    if(step.m_Col == colCounter && step.m_Row == rowCounter)
                    {
                        diagonalCounter++;
                        break;
                    }

                    rowCounter++;
                    colCounter--;
                }
            }

            if (diagonalCounter == m_Size)
            {
                result = true;
            }

            return result;
        }
    }
}
