using System;

namespace GameEngine
{
    public class GameManager
    {
        public const int k_One = 1, k_Zero = 0, k_Three = 3, k_Two = 2, k_MaxBoardSize = 9, k_MinBoardSize = 3, k_MinNumOfPlayers = 1, k_MaxNumOfPlayers = 2;
        public const char k_Exit = 'Q', k_OneChar = '1', k_NineChar = '9';

        private int m_Turns;
        private char m_received;
        private bool m_IsEndOfGame = false;
        private int m_BoardSize;
        private int m_NumOfPlayers;
        private string m_PlayerOneName, m_PlayerTwoName;
        private GameEngine m_GameEngineInstance = new GameEngine();
        private GameUI m_GameUserInterfaceInstance;
        public int m_CurrX, m_CurrY;

        public void RunGame()
        {
            InitGame(); // get board size, player names, init GameEngine with data, init GameUI instance

            // game loop?
            while (!m_IsEndOfGame)
            {
                m_Turns = k_One;
                while (!m_GameEngineInstance.m_IsEndOfMatch && !m_IsEndOfGame && m_Turns < (m_BoardSize * m_BoardSize))
                {
                    m_GameUserInterfaceInstance.PrintBoard(m_GameEngineInstance.GetCurrentBoardState(), m_GameEngineInstance.GetPlayers());
                    MakeGameLoop();
                    m_Turns++;
                }

                m_GameUserInterfaceInstance.PrintBoard(m_GameEngineInstance.GetCurrentBoardState(), m_GameEngineInstance.GetPlayers());

                if (!m_IsEndOfGame)
                {
                    Console.WriteLine("Press any key for new game or Q for exit!");
                    m_received = Console.ReadKey(true).KeyChar;
                    if (m_received == k_Exit)
                    {
                        m_IsEndOfGame = true;
                    }
                    else
                    {
                        SetNewMatch();
                    }
                }
            }

            // Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Game Over!!!");
            m_GameUserInterfaceInstance.PrintPlayers(m_GameEngineInstance.GetPlayers());
        }

        public void SetNewMatch()
        {
            m_GameEngineInstance.SetForNewMatch(m_BoardSize);
            m_GameUserInterfaceInstance = new GameUI(m_BoardSize); 
        }

        public void InitGame()
        {
            string receivedFromUser;

            // get board size, player names
            Console.WriteLine("Please insert a value between 3 to 9 for the size of the board:");
            receivedFromUser = Console.ReadLine();
            while (!int.TryParse(receivedFromUser, out m_BoardSize) || (m_BoardSize > k_MaxBoardSize || m_BoardSize < k_MinBoardSize))
            {
                Console.WriteLine("Invalid input! Please try again:");
                receivedFromUser = Console.ReadLine();
            }

            // Game Engine Init
            m_GameEngineInstance.InitializeGame(m_BoardSize, true);

            // Gane UI Init
            m_GameUserInterfaceInstance = new GameUI(m_BoardSize);

            Console.WriteLine("Please enter number of players (1 or 2):");
            receivedFromUser = Console.ReadLine();
            while (!int.TryParse(receivedFromUser, out m_NumOfPlayers) || !(m_NumOfPlayers == k_MinNumOfPlayers || m_NumOfPlayers == k_MaxNumOfPlayers))
            {
                Console.WriteLine("Invalid input! Please try again:");
                receivedFromUser = Console.ReadLine();
            }

            Console.WriteLine("Please enter player one name:");
            m_PlayerOneName = Console.ReadLine();
            m_GameEngineInstance.AddPlayer(m_PlayerOneName, true);

            if (m_NumOfPlayers == k_MaxNumOfPlayers)
            {
                Console.WriteLine("Please enter player two name:");
                m_PlayerTwoName = Console.ReadLine();
                m_GameEngineInstance.AddPlayer(m_PlayerTwoName, true);
            }
            else
            {
                m_PlayerTwoName = "Computer";
                m_GameEngineInstance.AddPlayer(m_PlayerTwoName, false);
            }
        }

        public bool IsADigit(char i_Char)
        {
            bool result = true;
            if (i_Char < k_OneChar)
            {
                result = false;
            }
            else if (i_Char > k_NineChar)
            {
                result = false;
            }

            return result;
        }

        public bool CheckReceivedValues(string i_Received)
        {
            bool result = true;

            if (i_Received.Length != k_Three)
            {
                result = false;
                if (i_Received.Length == k_One)
                {
                    if (i_Received.Length == k_One)
                    {
                        if (i_Received[k_Zero] == k_Exit)
                        {
                            m_IsEndOfGame = true;
                        }
                    }
                }
            }

            if (result && ((!IsADigit(i_Received[k_Zero])) || (i_Received[k_Zero] > char.Parse(m_BoardSize.ToString()))))
            {
                result = false;
            }

            if (result && i_Received[k_One] != ',')
            {
                result = false;
            }

            if (result && (!IsADigit(i_Received[k_Two]) || i_Received[k_Two] > char.Parse(m_BoardSize.ToString())))
            {
                result = false;
            }

            if (result && !m_GameEngineInstance.IsEmptyCell(int.Parse(i_Received[0].ToString()) - k_One, int.Parse(i_Received[k_Two].ToString()) - k_One))
            {
                result = false;
            }

            return result;
        }

        public void MakeGameLoop()
        {
            string receivedFromUser;
            int[] result = new int[k_Two];
            if(m_GameEngineInstance.GetCurrentPlayer().m_IsHuman)
            {
                Console.WriteLine("Player" + m_GameEngineInstance.GetCurrentPlayer().m_Sign + ", Please enter coordinates as (x,y):");
    
                receivedFromUser = Console.ReadLine();
                while (!CheckReceivedValues(receivedFromUser) && !m_IsEndOfGame)
                {
                    Console.WriteLine("Invalid input! Please enter coordinates as (x,y):"); // We need to check coordinates format to avoid exeptions.

                    receivedFromUser = Console.ReadLine();
                }

                if (!m_IsEndOfGame)
                {
                    m_CurrX = int.Parse(receivedFromUser.Split(',')[k_Zero]) - k_One;
                    m_CurrY = int.Parse(receivedFromUser.Split(',')[k_One]) - k_One;
                }
            }
            else
            {
                // AI turn generation
                result = m_GameEngineInstance.GenerateCoordinates();
                m_CurrX = result[k_Zero];
                m_CurrY = result[k_One];
            }
            
            if ((!m_IsEndOfGame) && (m_GameEngineInstance.IsLegalCoordinates(m_CurrX, m_CurrY) && m_GameEngineInstance.IsEmptyCell(m_CurrX, m_CurrY)))
            {
                m_GameEngineInstance.MakeTurn(m_CurrX, m_CurrY);
                m_GameEngineInstance.SwitchPlayer();
            }
        }
    }
}
