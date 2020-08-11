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
using System.Windows.Interop;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows.Automation;
using System.IO;
using System.Threading;
using System.Net;


namespace IC_Programming_Launcher
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.guna2TextBox1.Text = "Ready";
            this.guna2TextBox2.Text = "Ready";
            this.guna2TextBox6.Text = "Ready";
        }

        string jamlocal2;
        string[] pemisah2;
        string url;
        IntPtr Windowyield,buttonx,close,auto,unlock,reset;
        IntPtr satu,dua,tiga,empat,lima,enam,tujuh,delapan,sembilan;
        int tx=0;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();
        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

  
        private void Form5_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,(Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            Form3 fm3 = (Form3)Application.OpenForms["Form3"];
            gunaLabel1.Text = "Raw: " + fm3.BlankPart;
            gunaLabel2.Text = "Pro: " + fm3.ProgramPart;
            gunaLabel3.Text = "Checksum: " + fm3.Checksum;
            gunaLabel4.Text = "Dotting: " + fm3.Dotting;
            gunaLabel5.Text = "Color: " + fm3.Color;
            gunaLabel6.Text = "SKID: " + fm3.SKID;
            url = fm3.Link;
            string qtydot = fm3.Dotting;

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
            if(qtydot=="1")
            {
                guna2CircleButton3.FillColor = Color.Transparent;
            }
            
        }

        int kedip = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ShowWindow(close, 0);
                ShowWindow(buttonx, 0);
                ShowWindow(reset, 0);
                ShowWindow(unlock, 0);
            }
            catch
            { }
            if (kedip % 2 == 0)
            {
                guna2CircleButton3.Visible = true;
                guna2CircleButton4.Visible = true;
                kedip++;
            }
            else
            {
                guna2CircleButton3.Visible = false;
                guna2CircleButton4.Visible = false;
                kedip++;
            }

            ShowWindow(close, 0);

            int az = 0;

            var windows = FindWindowsWithText("Auto");
            foreach (var x in windows)
            {
                az++;
                if (az == 1)
                {
                    var allChildWindows = new WindowHandleInfo(x).GetAllChildHandles();
                    int ax = 0;
                    foreach (IntPtr lq in allChildWindows)
                    {
                        if(ax==14)
                        {
                            Windowyield = lq;
                        }
                        GetControlText(lq);
                        
                        ax++;
                    }
                    string baca = GetControlText(buttonx);
                    string baca1 = GetControlText(close);
                    
                    
                    if (gunaLabel3.BackColor != Color.Green)
                    {
                        gunaLabel3.BackColor = Color.Red;
                    }
                }
            }
            var allChildWindowsyiel = new WindowHandleInfo(Windowyield).GetAllChildHandles();
            foreach (IntPtr lq in allChildWindowsyiel)
            {
                GetControlText(lq);
            }
            
            try
            {
                //-------------------------------------------------------
                // 3 Programming adapter Test
                string satu1 = GetControlText(satu);// adapter number
                string dua2 = GetControlText(dua);// Ok adapter 0
                string tiga3 = GetControlText(tiga);// Ok adapter 1
                string empat4 = GetControlText(empat);//Ok adapter 2
                string lima5 = GetControlText(lima);// Total OK
                string enam6 = GetControlText(enam);// NG adapter 0
                string tujuh7 = GetControlText(tujuh);// NG adapter 1
                string delapan8 = GetControlText(delapan);// NG adapter 2
                string sembilan9 = GetControlText(sembilan);// Total NG

                //textBox1.Text = satu1;
                textBox2.Text = dua2;
                textBox3.Text = tiga3;
                textBox4.Text = empat4;
                textBox5.Text = lima5;
                textBox6.Text = enam6;
                textBox7.Text = tujuh7;
                textBox8.Text = delapan8;
                textBox9.Text = sembilan9;

                ///-------------------------------------------------------
                try
                {
                    int pass1 = Convert.ToInt32(guna2TextBox4.Text);
                    int fail1 = Convert.ToInt32(guna2TextBox3.Text);
                    double total = pass1 + fail1;
                    double persen = pass1 / total * 100;
                    if (Double.IsNaN(persen))
                    {
                        persen = 0;
                    }
                    string s = persen.ToString("N2");
                    guna2TextBox5.Text = Convert.ToString(s + "%");
                }
                catch
                { }
            }
            catch(Exception)
            {

            }

        }   

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        const int SW_HIDE = 0;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        // Delegate to filter which windows to include 
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary> Get the text for the window pointed to by hWnd </summary>
        public static string GetWindowText(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd);
            if (size > 0)
            {
                var builder = new StringBuilder(size + 1);
                GetWindowText(hWnd, builder, builder.Capacity);
                return builder.ToString();
            }

            return String.Empty;
        }

        /// <summary> Find all windows that match the given filter </summary>
        /// <param name="filter"> A delegate that returns true for windows
        ///    that should be returned and false for windows that should
        ///    not be returned </param>
        ///    

        public static IEnumerable<IntPtr> FindWindows(EnumWindowsProc filter)
        {
            IntPtr found = IntPtr.Zero;
            List<IntPtr> windows = new List<IntPtr>();
            EnumWindows(delegate(IntPtr wnd, IntPtr param)
            {
                if (filter(wnd, param))
                {

                    windows.Add(wnd);
                }

                return true;
            }, IntPtr.Zero);

            return windows;
        }

        /// <summary> Find all windows that contain the given title text </summary>
        /// <param name="titleText"> The text that the window title must contain. </param>
        public static IEnumerable<IntPtr> FindWindowsWithText(string titleText)
        {
            return FindWindows(delegate(IntPtr wnd, IntPtr param)
            {
                return GetWindowText(wnd).Contains(titleText);
            });
        }
        ////
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);

        const int WM_GETTEXT = 0x000D;
        const int WM_GETTEXTLENGTH = 0x000E;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);
        public string GetControlText(IntPtr hWnd)
        {

            // Get the size of the string required to hold the window title (including trailing null.) 
            Int32 titleSize = SendMessage((int)hWnd, WM_GETTEXTLENGTH, 0, 0).ToInt32();

            // If titleSize is 0, there is no title so return an empty string (or null)
            if (titleSize == 0)
                return String.Empty;

            StringBuilder title = new StringBuilder(titleSize + 1);

            SendMessage(hWnd, (int)WM_GETTEXT, title.Capacity, title);
            
            string ggz = Convert.ToString(title);
            
            Form3 fm3 = (Form3)Application.OpenForms["Form3"];
            if (ggz.Contains("Unlock"))
            {
                unlock = hWnd;
            }
            if (ggz.Contains("Reset"))
            {
                reset = hWnd;
            }
            if (ggz.Contains("Run"))
            {
                buttonx = hWnd;
            }
            if (ggz.Contains("Close"))
            {
                close = hWnd;
            }
            if (ggz == fm3.Checksum)
            {
                gunaLabel3.BackColor = Color.Green;
            }
            if (ggz == "0") /// 3 adapter programming
            {
                string alamat = Convert.ToString(hWnd);               
                if(tx == 0)
                {
                    satu = hWnd;//no adapter
                }
                if(tx == 1)
                {
                    dua = hWnd;//pass
                }
                if (tx == 2)
                {
                    tiga = hWnd;//pass
                }
                if (tx == 3)
                {
                    empat = hWnd;//fail
                }
                if (tx == 4)
                {
                    lima = hWnd;//fail
                }
                if (tx == 5)
                {
                    enam = hWnd;//fail
                }
                if (tx == 6)
                {
                    tujuh = hWnd;//fail
                }
                if (tx == 7)
                {
                    delapan = hWnd;//fail
                }
                if (tx == 8)
                {
                    sembilan = hWnd;//fail
                }
                tx++;
            }
            return title.ToString();
        }
        public class WindowHandleInfo
        {
            private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

            [DllImport("user32")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

            private IntPtr _MainHandle;

            public WindowHandleInfo(IntPtr handle)
            {
                this._MainHandle = handle;

            }

            public List<IntPtr> GetAllChildHandles()
            {
                List<IntPtr> childHandles = new List<IntPtr>();

                GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
                IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);

                try
                {
                    EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                    EnumChildWindows(this._MainHandle, childProc, pointerChildHandlesList);
                }
                finally
                {
                    gcChildhandlesList.Free();
                }
                
                return childHandles;
            }

            private bool EnumWindow(IntPtr hWnd, IntPtr lParam)
            {
                GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);

                if (gcChildhandlesList == null || gcChildhandlesList.Target == null)
                {
                    return false;
                }

                List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
                childHandles.Add(hWnd);

                return true;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        public const UInt32 WM_CLOSE = 0x0010;
        void CloseWindow(IntPtr hwnd)
        {
            SendMessage(hwnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "0" && textBox2.Text != "")
            {
                this.guna2TextBox1.Text = "PASS";
                this.guna2TextBox1.FillColor = Color.Green;
                trigger++;
                if (trigger == 3)
                {
                    guna2Button3.Enabled = true;
                    guna2Button3.BackColor = Flex;
                    trigger = 0;
                }
            }   
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "0" && textBox3.Text != "")
            {
                this.guna2TextBox2.Text = "PASS";
                this.guna2TextBox2.FillColor = Color.Green;
                trigger++;
                if (trigger == 3)
                {
                    guna2Button3.Enabled = true;
                    guna2Button3.BackColor = Flex;
                    trigger = 0;
                }
            }
        }
        int trigger = 0;
        Color Flex = Color.FromArgb(0, 154, 223);
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "0" && textBox4.Text != "")
            {
                this.guna2TextBox6.Text = "PASS";
                this.guna2TextBox6.FillColor = Color.Green;
                trigger++;
                if (trigger == 3)
                {
                    guna2Button3.Enabled = true;
                    guna2Button3.BackColor = Flex;
                    trigger = 0;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox4.Text = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "0" && textBox6.Text != "")
            {
                this.guna2TextBox1.Text = "FAIL";
                this.guna2TextBox1.FillColor = Color.Red;
                trigger++;
                if (trigger == 3)
                {
                    guna2Button3.Enabled = true;
                    guna2Button3.BackColor = Flex;
                    trigger = 0;
                }
            }
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != "0" && textBox7.Text != "")
            {
                this.guna2TextBox2.Text = "FAIL";
                this.guna2TextBox2.FillColor = Color.Red;
                trigger++;
                if (trigger == 3)
                {
                    guna2Button3.Enabled = true;
                    guna2Button3.BackColor = Flex;
                    trigger = 0;
                }
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != "0" && textBox8.Text != "")
            {
                this.guna2TextBox6.Text = "FAIL";
                this.guna2TextBox6.FillColor = Color.Red;
                trigger++;
                if (trigger == 3)
                {
                    guna2Button3.Enabled = true;
                    guna2Button3.BackColor = Flex;
                    trigger = 0;
                }
            }
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox3.Text = textBox9.Text;
        }

        private const int BN_CLICKED = 245;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(int hWnd, int msg, int wParam, IntPtr lParam);

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SendMessage((int)buttonx, BN_CLICKED, 0, IntPtr.Zero);
            Thread.Sleep(100);
            SendMessage((int)buttonx, BN_CLICKED, 0, IntPtr.Zero);
            guna2Button3.Enabled = false;
            guna2Button3.BackColor = Color.DimGray;
            guna2TextBox1.FillColor = Color.Gold;
            guna2TextBox1.Text = "Progressing";
            guna2TextBox2.FillColor = Color.Gold;
            guna2TextBox2.Text = "Progressing";
            guna2TextBox6.FillColor = Color.Gold;
            guna2TextBox6.Text = "Progressing";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!IsWindow(auto))
            {
                SimpanYield();
            }
            Process[] workers = Process.GetProcessesByName("XAHMPU");
            foreach (Process worker in workers)
            {
                worker.Kill();
                worker.WaitForExit();
                worker.Dispose();
            }
            Process[] workers1 = Process.GetProcessesByName("XAUPD78X");
            foreach (Process worker in workers1)
            {
                worker.Kill();
                worker.WaitForExit();
                worker.Dispose();
            }
            if (!IsWindow(auto))
            {
                Application.Restart();
            }
        }
        private void SimpanYield()
        {
            bool jam = false;

            string date;
            Form3 fm3 = (Form3)Application.OpenForms["Form3"];
            Form1 fm1 = (Form1)Application.OpenForms["Form1"];
            try
            {
                using (WebClient client = new WebClient())
                {
                    string ServerTime = client.DownloadString("http://10.201.192.20/AutoParser/SCH/ICT/GetServerDateTime.aspx?txtFFDB=FF2810_SCH");
                    pemisah2 = ServerTime.Split(';');
                    jam = true;
                }
            }
            catch
            {
                jamlocal2 = DateTime.Now.ToString("M/d/yyyy h:mm:ss tt");
                jam = false;
            }
            if (jam == true)
            {
                date = pemisah2[1];
            }
            else
            {
                date = jamlocal2;
            }
            //Date#BadgeID#BlankPart#ProgramPart#SKID#PASS#FAIL
            string LogYield = date + "#" + fm1.BadgeID + "#" + fm3.BlankPart + "#" + fm3.ProgramPart + "#" + fm3.SKID + "#" + guna2TextBox4.Text + "#" + guna2TextBox3.Text;
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "LogYield.txt"))
            {
                System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "LogYield.txt", "Date#BadgeID#BlankPart#ProgramPart#SKID#PASS#FAIL");
            }
            string LogLama = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "LogYield.txt");
            string FinalLog = LogLama + Environment.NewLine + LogYield;
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "LogYield.txt", FinalLog);
        }
    }
}