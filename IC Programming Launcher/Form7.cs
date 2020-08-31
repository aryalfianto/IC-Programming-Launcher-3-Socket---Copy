using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IC_Programming_Launcher
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public bool socket1, socket2, socket3, socket4, socket5, socket6, socket7, socket8;
        readonly Color Flex = Color.FromArgb(0, 154, 223);
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form5 fm5 = new Form5();
            fm5.Show();
            this.Hide();
        }

        private int kedip1 = 0;
        private int kedip2 = 0;
        private int kedip3 = 0;
        private int kedip4 = 0;
        private int kedip5 = 0;
        private int kedip6 = 0;
        private int kedip7 = 0;
        private int kedip8 = 0;

        private void Form7_Load(object sender, EventArgs e)
        {
            socket1 = true;
            socket2 = true;
            socket3 = true;
            socket4 = true;
            socket5 = true;
            socket6 = true;
            socket7 = true;
            socket8 = true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            kedip1++;
            if (kedip1 % 2 == 0)
            {
                guna2Button2.FillColor = Flex;
                socket1 = true;

            }
            else
            {
                guna2Button2.FillColor = Color.Black;
                socket1 = false;
            }
        }
       
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            kedip2++;
            if (kedip2 % 2 == 0)
            {
                guna2Button3.FillColor = Flex;
                socket2 = true;

            }
            else
            {
                guna2Button3.FillColor = Color.Black;
                socket2 = false;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            kedip3++;
            if (kedip3 % 2 == 0)
            {
                guna2Button4.FillColor = Flex;
                socket3 = true;

            }
            else
            {
                guna2Button4.FillColor = Color.Black;
                socket3 = false;
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            kedip4++;
            if (kedip4 % 2 == 0)
            {
                guna2Button5.FillColor = Flex;
                socket4 = true;

            }
            else
            {
                guna2Button5.FillColor = Color.Black;
                socket4 = false;
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            kedip5++;
            if (kedip5 % 2 == 0)
            {
                guna2Button6.FillColor = Flex;
                socket5 = true;

            }
            else
            {
                guna2Button6.FillColor = Color.Black;
                socket5 = false;
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            kedip6++;
            if (kedip6 % 2 == 0)
            {
                guna2Button7.FillColor = Flex;
                socket6 = true;

            }
            else
            {
                guna2Button7.FillColor = Color.Black;
                socket6 = false;
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            kedip7++;
            if (kedip7 % 2 == 0)
            {
                guna2Button8.FillColor = Flex;
                socket7 = true;

            }
            else
            {
                guna2Button8.FillColor = Color.Black;
                socket7 = false;
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            kedip8++;
            if (kedip8 % 2 == 0)
            {
                guna2Button9.FillColor = Flex;
                socket8 = true;

            }
            else
            {
                guna2Button9.FillColor = Color.Black;
                socket8 = false;
            }
        }

    }
}
