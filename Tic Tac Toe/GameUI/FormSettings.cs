using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameUI
{
    public partial class FormGameSettings : Form
    {
        public string m_Player1Name;
        public string m_Player2Name = "[Computer]";

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Rows, Cols, BoardSize;
            Rows = int.Parse(NumericUpDown_Rows.Value.ToString());
            Cols = int.Parse(NumericUpDown_Cols.Value.ToString());

            if (Rows > Cols)
            {
                BoardSize = Rows;
            }
            else
            {
                BoardSize = Cols;
            }

            this.Hide();

            FormPlayboardManager PM = new FormPlayboardManager(BoardSize, m_Player1Name, m_Player2Name, TextBox_Player2Name.Enabled);
            PM.ShowDialog();
        }

        private void TextBox_Player2Name_TextChanged(object sender, EventArgs e)
        {
            m_Player2Name = TextBox_Player2Name.Text;
            if (m_Player2Name.Length > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void TextBox_Player1Name_TextChanged(object sender, EventArgs e)
        {
            m_Player1Name = TextBox_Player1Name.Text;
            if(m_Player1Name.Length > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void checkBox_Player2_CheckedChanged(object sender, EventArgs e)
        {
            if (TextBox_Player2Name.Enabled == false)
            {
                TextBox_Player2Name.Enabled = true;
                TextBox_Player2Name.Text = string.Empty;
            }
            else
            {
                TextBox_Player2Name.Enabled = false;
                TextBox_Player2Name.Text = "[Computer]";
            }
        }

        private void FormGameSettings_Clicked(object sender, EventArgs e)
        {
            this.Enabled = false;
        }

        private void NumericUpDown_Rows_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown_Cols.Value = NumericUpDown_Rows.Value;
        }

        private void NumericUpDown_Cols_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown_Rows.Value = NumericUpDown_Cols.Value;
        }
    }
}
