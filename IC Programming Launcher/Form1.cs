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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string BadgeID;
        Form6 fm6 = new Form6();
            
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Badge.txt") == false)
            {
                System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Badge.txt", "b11498#ary");
            }
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Config.txt") == false)
            {
                fm6.Show();
                fm6.gunaLabel1.Text = "File Config tidak ada panggil Engineering Team";
            }
        }   
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text!=""&&guna2TextBox2.Text!="")
            {
                bool login = false;
                    string[] badge = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Badge.txt");
                    foreach (string baris in badge)
                    {
                        string[] idps = baris.Split('#');
                        string badgest = guna2TextBox1.Text;;
                        if (badgest != string.Empty && char.IsUpper(badgest[0]))
                        {
                            badgest = char.ToLower(badgest[0]) + badgest.Substring(1);
                        }
                        if(badgest==idps[0]&&guna2TextBox2.Text==idps[1])
                        {
                            BadgeID = badgest;
                            Form3 fm3 = new Form3();
                            fm3.Show();
                            this.Hide();
                            login = true;
                            break;
                        }
                        
                    }
                if (login == false)
                {
                    fm6.Show();
                    fm6.gunaLabel1.Text = "ID atau Password Salah";
                    guna2TextBox1.Text = "";
                    guna2TextBox2.Text = "";
                }

            }
            else
            {
                fm6.Show();
                fm6.gunaLabel1.Text = "isi data dengan lengkap";
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
            }
            
        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.Show();
            this.Hide();
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("\t");
            }
            
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && guna2TextBox1.Text != "")
            {
                guna2Button1_Click(this, new EventArgs());
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void gunaLabel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
