using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GameUI;

namespace GameUI
{
    public class Program
    {
        public static void Main()
        {
            FormGameSettings form = new FormGameSettings();
            form.ShowDialog();
        }
    }
}
