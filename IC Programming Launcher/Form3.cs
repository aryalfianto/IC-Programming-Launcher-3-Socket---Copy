using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace IC_Programming_Launcher
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent(); 
        }
        public string BlankPart;
        public string ProgramPart;
        public string SKID;
        public string Color;
        public string Checksum;
        public string Link;
        public string Dotting;
        public bool open=false;
        Form6 fm6 = new Form6();
        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
        }

        private void guna2TextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {            
                guna2Button1_Click(this, new EventArgs());
            }
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            Application.Restart(); 
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "" && guna2TextBox3.Text != "")
            {
                string[] config = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Config.txt");
                foreach (string baris in config)
                {
                    try
                    {
                        string[] pemisah = baris.Split('|');
                        if (pemisah[0] == guna2TextBox1.Text && pemisah[1] == guna2TextBox2.Text)
                        {
                            BlankPart = pemisah[0];
                            ProgramPart = pemisah[1];
                            Checksum = pemisah[2];
                            Dotting = pemisah[3];
                            Color = pemisah[4];
                            SKID = guna2TextBox3.Text;
                            Link = pemisah[5];
                            open = true;
                            break;
                        }
                    }
                    catch
                    {

                    }

                }
                if (open != true)
                {
                    fm6.Show();
                    fm6.gunaLabel1.Text = "Project Salah Atau Belum Terdaftar!";
                    guna2TextBox1.Text = "";
                    guna2TextBox2.Text = "";
                    guna2TextBox3.Text = "";
                    this.guna2TextBox1.Focus();
                    
                }
            }
            else
            {
                fm6.Show();
                fm6.gunaLabel1.Text = "Scan Semua Data dengan Lengkap";
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                guna2TextBox3.Text = "";
                this.guna2TextBox1.Focus();
            }

            if (open == true)
            {

                Form4 fm4 = new Form4();
                fm4.Show();
                this.Hide();
            }
        }     
    }
}
