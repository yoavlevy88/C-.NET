using System;

namespace GameEngine
{
    public class GameUI
    {
        public const int k_One = 1, k_Two = 2, k_Zero = 0;

        private int m_Size;

        public GameUI(int i_Size)
        {
            m_Size = i_Size;
        }

        public void PrintPlayer(Player i_PlayerToPrint)
        {
            Console.Write("Player" + i_PlayerToPrint.m_Sign + "(" + i_PlayerToPrint.m_Name + "), Score: " + i_PlayerToPrint.m_Score);
            Console.Write(System.Environment.NewLine);
        }

        public void PrintPlayers(Player[] i_Players)
        {
            PrintPlayer(i_Players[k_Zero]);
            PrintPlayer(i_Players[k_One]);
        }

        public void PrintBoard(BoardCell[,] i_GameBoard, Player[] i_Players)
        {
            // Ex02.ConsoleUtils.Screen.Clear();
            string stringToWrite;

            PrintPlayers(i_Players);
            Console.Write("  ");
            for (int j = k_One; j <= m_Size; j++)
            {
                Console.Write(j + "   ");
            }
            
            for (int i = k_Zero; i < m_Size; i++)
            {
                Console.Write(System.Environment.NewLine);
                Console.Write(i + k_One + "|");
                for (int j = k_Zero; j < m_Size; j++)
                {
                    stringToWrite = i_GameBoard[i, j].m_IsVisible ? " " + i_GameBoard[i, j].m_SignOfCell + " |" : "   |";
                    Console.Write(stringToWrite);
                }

                Console.Write(System.Environment.NewLine + " =");
                for (int j = k_One; j <= m_Size; j++)
                {
                    Console.Write("====");
                }
            }

            Console.WriteLine();
        }
    }
}
