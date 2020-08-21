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
        }
        
        string jamlocal2;
        string[] pemisah2;
        string url;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        List <IntPtr> allChildWindows;
        IntPtr socket1, socket2, socket3, socket4, socket5, socket6, socket7, socket8 , PASS, FAIL, RUN, CLOSE, RESET;
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

        //Import the SetForeground API to activate it
        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        private static extern IntPtr SetForegroundWindowNative(IntPtr hWnd);
        public IntPtr SetForegroundWindow(IntPtr hWnd)
        {
            return SetForegroundWindowNative(hWnd);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Form7 fm7 = (Form7)Application.OpenForms["Form7"];
            bool socket1 = fm7.socket1;
            bool socket2 = fm7.socket2;
            bool socket3 = fm7.socket3;
            bool socket4 = fm7.socket4;
            bool socket5 = fm7.socket5;
            bool socket6 = fm7.socket6;
            bool socket7 = fm7.socket7;
            bool socket8 = fm7.socket8;

            if(socket1==true)
            {
                guna2TextBox1.Visible = true;
            }
            else
            {
                guna2TextBox1.Visible = false;
            }

            if (socket2 == true)
            {
                guna2TextBox2.Visible = true;
            }
            else
            {
                guna2TextBox2.Visible = false;
            }

            if (socket3 == true)
            {
                guna2TextBox6.Visible = true;
            }
            else
            {
                guna2TextBox6.Visible = false;
            }
            if (socket4 == true)
            {
                guna2TextBox7.Visible = true;
            }
            else
            {
                guna2TextBox7.Visible = false;
            }
            if (socket5 == true)
            {
                guna2TextBox11.Visible = true;
            }
            else
            {
                guna2TextBox11.Visible = false;
            }
            if (socket6 == true)
            {
                guna2TextBox10.Visible = true;
            }
            else
            {
                guna2TextBox10.Visible = false;
            }
            if (socket7 == true)
            {
                guna2TextBox9.Visible = true;
            }
            else
            {
                guna2TextBox9.Visible = false;
            }
            if (socket8 == true)
            {
                guna2TextBox8.Visible = true;
            }
            else
            {
                guna2TextBox8.Visible = false;
            }

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
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SetWindowText(IntPtr hWnd, string txt);
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
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

            int az = 0;
            
            var windows = FindWindowsWithText("Auto");
            foreach (var x in windows)
            {
                
                az++;
                if (az == 1)
                {
                    allChildWindows = new WindowHandleInfo(x).GetAllChildHandles();
                    try
                    {
                        textBox1.Text = GetControlText(allChildWindows[87]);
                        textBox1.Text = GetControlText(allChildWindows[96]);

                        textBox2.Text = GetControlText(allChildWindows[88]);
                        textBox2.Text = GetControlText(allChildWindows[97]);

                        textBox3.Text = GetControlText(allChildWindows[89]);
                        textBox3.Text = GetControlText(allChildWindows[98]);

                        textBox4.Text = GetControlText(allChildWindows[90]);
                        textBox4.Text = GetControlText(allChildWindows[99]);

                        textBox5.Text = GetControlText(allChildWindows[91]);
                        textBox5.Text = GetControlText(allChildWindows[100]);


                        textBox6.Text = GetControlText(allChildWindows[92]);
                        textBox6.Text = GetControlText(allChildWindows[101]);


                        textBox7.Text = GetControlText(allChildWindows[93]);
                        textBox7.Text = GetControlText(allChildWindows[102]);


                        textBox8.Text = GetControlText(allChildWindows[94]);
                        textBox8.Text = GetControlText(allChildWindows[103]);


                        RUN = allChildWindows[14];
                        CLOSE = allChildWindows[15];
                        RESET = allChildWindows[105];
                    }
                    catch
                    { }
                    try
                    {
                        textBox9.Text = GetControlText(socket1);
                        textBox10.Text = GetControlText(socket2);
                        textBox11.Text = GetControlText(socket3);
                        textBox12.Text = GetControlText(socket4);
                        textBox13.Text = GetControlText(socket5);
                        textBox14.Text = GetControlText(socket6);
                        textBox15.Text = GetControlText(socket7);
                        textBox16.Text = GetControlText(socket8);
                        guna2TextBox4.Text = GetControlText(PASS);
                        guna2TextBox3.Text = GetControlText(FAIL);
                    }
                    catch
                    { }
                }
            }
            try
            {
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
            catch
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
        Color Flex = Color.FromArgb(0, 154, 223);

        private const int BN_CLICKED = 245;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(int hWnd, int msg, int wParam, IntPtr lParam);

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SendMessage((int)RUN, BN_CLICKED, 0, IntPtr.Zero);
            Thread.Sleep(100);
            SendMessage((int)RUN, BN_CLICKED, 0, IntPtr.Zero);
            //guna2Button3.Enabled = false;
            guna2Button3.BackColor = Color.DimGray;

            guna2TextBox1.FillColor = Color.Gold;
            guna2TextBox2.FillColor = Color.Gold;
            guna2TextBox6.FillColor = Color.Gold;
            guna2TextBox7.FillColor = Color.Gold;
            guna2TextBox11.FillColor = Color.Gold;
            guna2TextBox10.FillColor = Color.Gold;
            guna2TextBox9.FillColor = Color.Gold;
            guna2TextBox8.FillColor = Color.Gold;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //if (!IsWindow(auto))
            //{
            //    SimpanYield();
            //}
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
            //if (!IsWindow(auto))
            //{
            //    Application.Restart();
            //}
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                socket1 = allChildWindows[55];
                socket2 = allChildWindows[56];
                socket3 = allChildWindows[57];
                socket4 = allChildWindows[58];
                socket5 = allChildWindows[112];
                socket6 = allChildWindows[113];
                socket7 = allChildWindows[114];
                socket8 = allChildWindows[115];
                PASS = allChildWindows[87];
                FAIL = allChildWindows[96];
            }
            catch
            {

            }
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                socket1 = allChildWindows[59];
                socket2 = allChildWindows[60];
                socket3 = allChildWindows[61];
                socket4 = allChildWindows[62];
                socket5 = allChildWindows[116];
                socket6 = allChildWindows[117];
                socket7 = allChildWindows[118];
                socket8 = allChildWindows[119];
                PASS = allChildWindows[88];
                FAIL = allChildWindows[97];
            }
            catch
            {

            }
            
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                socket1 = allChildWindows[63];
                socket2 = allChildWindows[64];
                socket3 = allChildWindows[65];
                socket4 = allChildWindows[66];
                socket5 = allChildWindows[120];
                socket6 = allChildWindows[121];
                socket7 = allChildWindows[122];
                socket8 = allChildWindows[123];
                PASS = allChildWindows[89];
                FAIL = allChildWindows[98];
            }
            catch
            {

            }
            
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                socket1 = allChildWindows[67];
                socket2 = allChildWindows[68];
                socket3 = allChildWindows[69];
                socket4 = allChildWindows[70];
                socket5 = allChildWindows[124];
                socket6 = allChildWindows[125];
                socket7 = allChildWindows[126];
                socket8 = allChildWindows[127];
                PASS = allChildWindows[90];
                FAIL = allChildWindows[99];
            }
            catch
            {

            }
            
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                socket1 = allChildWindows[71];
                socket2 = allChildWindows[70];
                socket3 = allChildWindows[73];
                socket4 = allChildWindows[74];
                socket5 = allChildWindows[128];
                socket6 = allChildWindows[129];
                socket7 = allChildWindows[130];
                socket8 = allChildWindows[131];
                PASS = allChildWindows[91];
                FAIL = allChildWindows[100];
            }
            catch
            {

            }
            
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                socket1 = allChildWindows[75];
                socket2 = allChildWindows[76];
                socket3 = allChildWindows[77];
                socket4 = allChildWindows[78];
                socket5 = allChildWindows[132];
                socket6 = allChildWindows[133];
                socket7 = allChildWindows[134];
                socket8 = allChildWindows[135];
                PASS = allChildWindows[92];
                FAIL = allChildWindows[101];
            }
            catch
            {

            }
            
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                socket1 = allChildWindows[79];
                socket2 = allChildWindows[80];
                socket3 = allChildWindows[81];
                socket4 = allChildWindows[82];
                socket5 = allChildWindows[136];
                socket6 = allChildWindows[137];
                socket7 = allChildWindows[138];
                socket8 = allChildWindows[139];
                PASS = allChildWindows[93];
                FAIL = allChildWindows[102];
            }
            catch
            {

            }
            
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                socket1 = allChildWindows[83];
                socket2 = allChildWindows[84];
                socket3 = allChildWindows[85];
                socket4 = allChildWindows[86];
                socket5 = allChildWindows[140];
                socket6 = allChildWindows[141];
                socket7 = allChildWindows[142];
                socket8 = allChildWindows[143];
                PASS = allChildWindows[94];
                FAIL = allChildWindows[103];
            }
            catch
            {

            }
            
        }
    }
}