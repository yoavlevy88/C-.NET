using System;
using System.Collections.Generic;

namespace GameEngine
{
    public class Player
    {
        public string m_Sign;
        public List<BoardCell> m_Steps = new List<BoardCell>();
        public bool m_IsHuman;
        public string m_Name;
        public int m_Score;

        public Player(string i_Name, string i_Sign, bool i_IsHuman)
        {
            m_Sign = i_Sign;
            m_IsHuman = i_IsHuman;
            m_Name = i_Name;
            m_Score = 0;
        }

        public void AddStep(int i_Col, int i_Row)
        {
            m_Steps.Add(new BoardCell(m_Sign, true, i_Col, i_Row));
        }
    }
}
