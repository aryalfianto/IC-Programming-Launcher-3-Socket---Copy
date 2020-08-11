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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Form6 fm6 = new Form6();
        private void Form2_Load(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Badge.txt") == false)
            {
                System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Badge.txt", "b11498#ary");
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bool doubleid = false;
            if(guna2TextBox1.Text!=""&&guna2TextBox2.Text!=""&&guna2TextBox3.Text!="")
            {
                string[] badge = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Badge.txt");
                foreach (string baris in badge)
                {
                    string[] badge1 = baris.Split('#');
                    if (badge1[0]==guna2TextBox1.Text)
                    {
                        doubleid = true;
                        break;
                    } 
                }
                if (doubleid==false)
                {
                    if (guna2TextBox2.Text == guna2TextBox3.Text)
                    {
                        if (guna2TextBox1.Text.StartsWith("b") || guna2TextBox1.Text.StartsWith("B"))
                        {
                            string badgest = guna2TextBox1.Text;
                            badgest = char.ToLower(badgest[0]) + badgest.Substring(1);
                            string badgeid = badgest + "#" + guna2TextBox2.Text;
                            string oldbadgeid = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Badge.txt");
                            string final = oldbadgeid + Environment.NewLine + badgeid;
                            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Badge.txt", final);
                            fm6.Show();
                            fm6.gunaLabel1.Text = "Pendaftaran Berhasil, Silahkan Login";

                            Form1 fm1 = new Form1();
                            fm1.Show();
                            this.Hide();
                            fm6.Focus();
                        }
                        else
                        {
                            fm6.Show();
                            fm6.gunaLabel1.Text = "BadgeID harus diawali huruf b";
                            guna2TextBox1.Text = "";
                            guna2TextBox2.Text = "";
                            guna2TextBox3.Text = "";
                            this.guna2TextBox1.Focus();
                        }
                    }
                    else
                    {
                        fm6.Show();
                        fm6.gunaLabel1.Text = "Konfirmasi Password Salah!";
                        guna2TextBox1.Text = "";
                        guna2TextBox2.Text = "";
                        guna2TextBox3.Text = "";
                        this.guna2TextBox1.Focus();
                    }
                }
                else
                {
                    fm6.Show();
                    fm6.gunaLabel1.Text = "Badge ID Sudah Terdaftar!";
                    guna2TextBox1.Text = "";
                    guna2TextBox2.Text = "";
                    guna2TextBox3.Text = "";
                    this.guna2TextBox1.Focus();
                }
                  
            }
            else
            {
                fm6.Show();
                fm6.gunaLabel1.Text = "Isi Data Dengan Lengkap!";
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                guna2TextBox3.Text = "";
                this.guna2TextBox1.Focus();
            }
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            Application.Restart(); 
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && guna2TextBox1.Text!="")
            {
                SendKeys.Send("\t");
            }
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && guna2TextBox2.Text != "")
            {
                SendKeys.Send("\t");
            }
        }

        private void guna2TextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && guna2TextBox3.Text != "")
            {
                guna2Button1_Click(this, new EventArgs());
   
            }
        }

    }
}
