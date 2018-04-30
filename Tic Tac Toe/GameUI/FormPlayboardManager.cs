using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GameUI
{
    public class FormPlayboardManager : Form
    {
        public const int k_One = 1, k_Zero = 0, k_Three = 3, k_Two = 2, k_MaxBoardSize = 9, k_MinBoardSize = 6, k_MinNumOfPlayers = 1, k_MaxNumOfPlayers = 2;
        private int m_Turns;
        private bool m_IsEndOfGame = false;
        private int m_BoardSize;
        private Label m_Scores = new Label();
        private List<Button> m_cells = new List<Button>();
        private GameEngine.GameEngine m_GameEngineInstance = new GameEngine.GameEngine();
        public int m_CurrX, m_CurrY;

        public FormPlayboardManager(int i_BoardSize, string i_Player1Name, string i_Player2Name, bool isPlayer2Enabled)
        {
            this.Text = "TicTacToeMisere";
            this.Icon = new Icon(string.Format(@"{0}//Tic_Tac_Toe_ico.ico", Environment.CurrentDirectory.ToString()));
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size(0, 0);
            this.StartPosition = FormStartPosition.CenterScreen;

            m_BoardSize = i_BoardSize;
            m_GameEngineInstance.InitializeGame(m_BoardSize, true);
            m_GameEngineInstance.AddPlayer(i_Player1Name, true);
            m_GameEngineInstance.AddPlayer(i_Player2Name, isPlayer2Enabled);
            if (m_BoardSize >= k_MinBoardSize)
            {
                this.Height = (m_BoardSize * 50) + 100;
                this.Width = m_BoardSize * 50;
            }
            else
            {
                this.Height = (k_MinBoardSize * 50) + 40;
                this.Width = k_MinBoardSize * 50;
            }

            this.m_Scores.Text = string.Format(@"{0}: {1}   {2}: {3}", i_Player1Name, m_GameEngineInstance.GetScores(0), i_Player2Name, m_GameEngineInstance.GetScores(1));
            this.m_Scores.Top = this.Top + 10 + (m_BoardSize * 50);
            this.m_Scores.Left = (this.Width / 2) - (m_Scores.Text.Length * 2);

            this.Controls.Add(m_Scores);
            DrawBoard();
        }

        public void DrawBoard()
        {
            int CurrentXPosition = (this.Width / 2) - (m_BoardSize * 45 / 2);
            int CurrentYPosition = this.Top + 10;
            for (int i = 0; i < m_BoardSize; i++)
            {
                for(int j = 0; j < m_BoardSize; j++)
                {
                    Button cell = new Button();
                    cell.Width = 40;
                    cell.Height = 40;
                    cell.Margin = new Padding(5);
                    cell.Left = CurrentXPosition;
                    cell.Tag = i + "," + j;
                    cell.Top = CurrentYPosition;
                    cell.Click += ButtonWithIndexWasClicked;
                    this.Controls.Add(cell);
                    m_cells.Add(cell);
                    CurrentXPosition += 45;
                }

                CurrentYPosition += 45;
                CurrentXPosition = (this.Width / 2) - (m_BoardSize * 45 / 2);
            }
        }

        public void ButtonWithIndexWasClicked(object sender, EventArgs e)
        {
            int[] result = new int[k_Two];
            int i_index = 0;
            string[] coordinates;
            Button btn = sender as Button;
            btn.Enabled = false;
            coordinates = btn.Tag.ToString().Split(',');
            m_GameEngineInstance.MakeTurn(int.Parse(coordinates[0]), int.Parse(coordinates[1].ToString()));
            btn.Text = m_GameEngineInstance.GetCurrentPlayer().m_Sign;
            m_GameEngineInstance.SwitchPlayer();
            m_Turns++;

            ShowUpDialogIfHaveWinner();
            while(!m_GameEngineInstance.GetCurrentPlayer().m_IsHuman)
            {
                result = m_GameEngineInstance.GenerateCoordinates();
                m_CurrX = result[k_Zero];
                m_CurrY = result[k_One];
                if (m_GameEngineInstance.IsLegalCoordinates(m_CurrX, m_CurrY) && m_GameEngineInstance.IsEmptyCell(m_CurrX, m_CurrY))
                {
                    m_GameEngineInstance.MakeTurn(m_CurrX, m_CurrY);
                    i_index = m_CurrX + (m_CurrY * m_BoardSize);
                    m_cells[i_index].Text = m_GameEngineInstance.GetCurrentPlayer().m_Sign;
                    m_cells[i_index].Enabled = false;
                    m_GameEngineInstance.SwitchPlayer();
                }
            }

            ShowUpDialogIfHaveWinner();
        }

        public void ShowUpDialogIfHaveWinner()
        {
            if (m_GameEngineInstance.m_IsEndOfMatch || m_Turns >= (m_BoardSize * m_BoardSize))
            {
                DialogResult result = MessageBox.Show("The winner is " + m_GameEngineInstance.GetCurrentPlayer().m_Name + "\n" + "Would you like to play another round?", string.Empty, MessageBoxButtons.YesNo);
                
                if (result == DialogResult.Yes)
                {
                    // Yes...
                    m_GameEngineInstance.SetForNewMatch(m_BoardSize);
                    RedrawBoard();
                }
                else if (result == DialogResult.No)
                {
                    this.Hide();
                }
            }
        }

        public void RedrawBoard()
        {
            foreach(Button btn in m_cells)
            {
                btn.Text = string.Empty;
                btn.Enabled = true;
            }

            m_Scores.Text = string.Format(@"{0}: {1}   {2}: {3}", m_GameEngineInstance.GetPlayers()[0].m_Name, m_GameEngineInstance.GetScores(0), m_GameEngineInstance.GetPlayers()[1].m_Name, m_GameEngineInstance.GetScores(1));
        }
    }
}
