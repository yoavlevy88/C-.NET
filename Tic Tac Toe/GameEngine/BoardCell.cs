using System;

namespace GameEngine
{
    public class BoardCell
    {
        public string m_SignOfCell;
        public bool m_IsVisible;
        public int m_Col;
        public int m_Row;

        public BoardCell(string i_SignOfCell, bool i_IsVisible, int i_Col, int i_Row)
        {
            m_SignOfCell = i_SignOfCell;
            m_IsVisible = i_IsVisible;
            m_Col = i_Col;
            m_Row = i_Row;
        }
    }
}
