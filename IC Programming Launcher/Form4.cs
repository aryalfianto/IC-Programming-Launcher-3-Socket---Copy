using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;

namespace IC_Programming_Launcher
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public string url;
        public string date;
        bool jam = false;
        string jamlocal;
        string[] pemisah;
        Form3 fm3 = (Form3)Application.OpenForms["Form3"];
        Form1 fm1 = (Form1)Application.OpenForms["Form1"];
        private void Form4_Load(object sender, EventArgs e)
        {
            
            gunaLabel1.Text = "Raw Part : " + fm3.BlankPart;
            gunaLabel2.Text = "Prog Part : " + fm3.ProgramPart;
            gunaLabel3.Text = "Checksum : " + fm3.Checksum;
            gunaLabel4.Text = "Dotting : " + fm3.Dotting;
            gunaLabel5.Text = "Color : " + fm3.Color;
            gunaLabel6.Text = "SKID : " + fm3.SKID;
            string qtydot = fm3.Dotting;
            url = fm3.Link;
            if (fm3.Color == "GREEN")
            {
                guna2CircleButton3.FillColor = Color.Green;
                guna2CircleButton4.FillColor = Color.Green;
            }
            if (fm3.Color == "ORANGE")
            {
                guna2CircleButton3.FillColor = Color.Orange;
                guna2CircleButton4.FillColor = Color.Orange;
            }
            if (fm3.Color == "SILVER")
            {
                guna2CircleButton3.FillColor = Color.Silver;
                guna2CircleButton4.FillColor = Color.Silver;
            }
            if (fm3.Color == "WHITE")
            {
                guna2CircleButton3.FillColor = Color.White;
                guna2CircleButton4.FillColor = Color.White;
            }
            if (fm3.Color == "RED")
            {
                guna2CircleButton3.FillColor = Color.Red;
                guna2CircleButton4.FillColor = Color.Red;
            }
            if (fm3.Color == "BLUE")
            {
                guna2CircleButton3.FillColor = Color.Blue;
                guna2CircleButton4.FillColor = Color.Blue;
            }
            if (fm3.Color == "YELLOW")
            {
                guna2CircleButton3.FillColor = Color.Yellow;
                guna2CircleButton4.FillColor = Color.Yellow;
            }
            if (fm3.Color == "PINK")
            {
                guna2CircleButton3.FillColor = Color.Pink;
                guna2CircleButton4.FillColor = Color.Pink;
            }
            if (fm3.Color == "PURPLE")
            {
                guna2CircleButton3.FillColor = Color.Purple;
                guna2CircleButton4.FillColor = Color.Purple;
            }
            if (qtydot == "1")
            {
                guna2CircleButton3.FillColor = Color.Transparent;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string ServerTime = client.DownloadString("http://10.201.192.20/AutoParser/SCH/ICT/GetServerDateTime.aspx?txtFFDB=FF2810_SCH");
                    pemisah = ServerTime.Split(';');
                    jam = true;
                }
            }
            catch
            {
                jamlocal = DateTime.Now.ToString("M/d/yyyy h:mm:ss tt");
                jam = false;
            }
            if (jam == true)
            {
                date = pemisah[1];
            }
            else
            {
                date = jamlocal;
            }
            
            string LogConvert = date + "#" + fm1.BadgeID + "#" + fm3.BlankPart + "#" + fm3.ProgramPart+ "#" + fm3.SKID;
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "LogConvert.txt")==false)
            {
                System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "LogConvert.txt","Date#BadgeID#BlankPart#ProgramPart#SKID");
            }
            string LogLama = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "LogConvert.txt");
            string FinalLog = LogLama + Environment.NewLine + LogConvert;
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "LogConvert.txt", FinalLog);
            try { Process.Start(url); }
            catch { MessageBox.Show("Aplikasi Gagal Dipanggil"); }
            this.Hide();
            Form7 fm7 = new Form7();
            fm7.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
