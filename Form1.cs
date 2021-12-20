using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Button[,] button;
        String Hod;

        public Form1()
        {
            Hod = "X";
            InitializeComponent();
            button = new Button[20, 20];
            int cnt = 0;
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    button[i, j] = new Button();
                    button[i, j].Parent = panel1;
                    button[i, j].Width = panel1.Width / 20;
                    button[i, j].Height = panel1.Height / 20;
                    button[i, j].Top = j * panel1.Height / 20;
                    button[i, j].Left = i * panel1.Width / 20;
                    button[i, j].Click += new EventHandler(onclick);
                    button[i, j].Tag = cnt;
                    cnt++;

                }
        }
        public void win(String x)
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                    button[i, j].Enabled = false;
            MessageBox.Show(x + " выиграли");
        }
        public void check1(int i, int j, String x)
        {
            if (button[i, j].Text == x && button[i - 1, j].Text == x && button[i - 2, j].Text == x && button[i + 1, j].Text == x && button[i + 2, j].Text == x)
            {
                win(x);
            }
            if (button[i, j].Text == x && button[i, j - 1].Text == x && button[i, j - 2].Text == x && button[i, j + 1].Text == x && button[i, j + 2].Text == x)
            {
                win(x);
            }
            if (button[i, j].Text == x && button[i - 1, j - 1].Text == x && button[i - 2, j - 2].Text == x && button[i + 1, j + 1].Text == x && button[i + 2, j + 2].Text == x)
            {
                win(x);
            }
            if (button[i, j].Text == x && button[i - 1, j + 1].Text == x && button[i - 2, j + 2].Text == x && button[i + 1, j - 1].Text == x && button[i + 2, j - 2].Text == x)
            {
                win(x);
            }
        }
        public void check()
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    check1(i, j, "X");
                    check1(i, j, "0");
                }
        }
        private void onclick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "")
                b.Text = Hod;
            if (Hod == "X")
                Hod = "0";
            else
                Hod = "X";

            check();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
