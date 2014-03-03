using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
//Download by http://www.codefans.net
namespace QQAutoSend
{

    /// <summary>
    /// 【百木破解】http://www.bmpj.net 希望您的参与，与我们共同进步。
    /// </summary>
    public partial class QQAutoSendMsgForm : Form
    {
        private List<QQChatWindows> _QQListWindows = new List<QQChatWindows>();
        private int _SendIntervalTime = 30;
        private int _CountTime = 0;
        private string _Title = "QQ信息自动发送器 V1.0";
        public QQAutoSendMsgForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.btLoopSend.Enabled = true;
            this.btStopLoop.Enabled = false;
            this.txtIntervalTime.Text = this._SendIntervalTime.ToString();
            this.CheckReg();
            this.EnumQQChatWindows();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            this.EnumQQChatWindows();
        }

        private void btTestSend_Click(object sender, EventArgs e)
        {
            this.listSendRecord.Items.Clear();

            if (this.txtSendText.Text.Equals("<输入要发送的内容>") || this.txtSendText.Text.Equals(String.Empty))
            {
                MessageBox.Show("请输入要发送的内容"); return;
            }

            if (this._QQListWindows.Count <= 0)
            {
                MessageBox.Show("没有可用发送的聊天窗体"); return;
            }

            this.SendQQMsgLoop();
        }

        private void btLoopSend_Click(object sender, EventArgs e)
        {
            if (!QQREG.IsRegSoftware)
            {
                MessageBox.Show("未注册 此功能不能使用");
                btRegister_Click(sender, e);
                return;
            }

            this.listSendRecord.Items.Clear();

            if (this.txtSendText.Text.Equals("<输入要发送的内容>") || this.txtSendText.Text.Equals(String.Empty))
            {
                MessageBox.Show("请输入要发送的内容"); return;
            }

            if (this._QQListWindows.Count <= 0)
            {
                MessageBox.Show("没有可用发送的聊天窗体"); return;
            }

            this.timer1.Start();
            this.btLoopSend.Enabled = false;
            this.btStopLoop.Enabled = true;
        }

        private void btStopLoop_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.btLoopSend.Enabled = true;
            this.btStopLoop.Enabled = false;
        }

        private void btTestSingle_Click(object sender, EventArgs e)
        {
            TestSendToolStripMenuItem_Click(sender, e);
        }

        private void TestSendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.txtSendText.Text.Equals("<输入要发送的内容>") || this.txtSendText.Text.Equals(String.Empty))
            {
                MessageBox.Show("请输入要发送的内容"); return;
            }

            if (this._QQListWindows.Count <= 0)
            {
                MessageBox.Show("没有可用发送的聊天窗体"); return;
            }

            if (this.listQQWindows.SelectedItem == null)
                return;

            string qqcaption = this.listQQWindows.SelectedItem.ToString();

            IntPtr hwnd = IntPtr.Zero;

            for (int i = 0; i < this._QQListWindows.Count; i++)
            {
                if (this._QQListWindows[i].Caption.Equals(qqcaption))
                {
                    hwnd = this._QQListWindows[i].WindowHwnd; break;
                }
            }

            if (hwnd == IntPtr.Zero)
            {
                MessageBox.Show("没有找到可发送信息的QQ聊天窗体");
            }
            else
            {
                if (this.SendQQMsg(hwnd, qqcaption, this.txtSendText.Text))
                {
                    // MessageBox.Show("测试成功");
                }
                else
                    MessageBox.Show("测试失败");
            }

        }

        private void SendQQMsgLoop()
        {
            string text = this.txtSendText.Text;
            for (int i = 0; i < this._QQListWindows.Count; i++)
            {
                IntPtr hwnd = this._QQListWindows[i].WindowHwnd;
                string caption = this._QQListWindows[i].Caption;
                try
                {
                    if (this.listSendRecord.Items.Count >= 1000)
                        this.listSendRecord.Items.Clear();

                    if (this.SendQQMsg(hwnd, caption, text))
                        this.listSendRecord.Items.Insert(0, caption + ":" + "发送成功");
                    else
                        this.listSendRecord.Items.Insert(0, caption + ":" + "发送失败");


                }
                catch (System.Exception ex)
                {
                    this.listSendRecord.Items.Insert(0, caption + ":" + ex.Message);
                }
                finally
                {
                    System.Threading.Thread.Sleep(500);
                }

            }
        }

        private bool SendQQMsg(IntPtr hWnd, string qqcaption, string sendtext)
        {
            try
            {
                NativeMethods.ShowWindow(hWnd, NativeMethods.ShowWindowCommands.Normal);

                NativeMethods.BringWindowToTop(hWnd);

                SendKeys.SendWait(sendtext);

                SendKeys.SendWait("{ENTER}");
                return true;
            }
            catch
            {
                return false;
            }

        }

        private void EnumQQChatWindows()
        {
            this.listQQWindows.Items.Clear();
            this._QQListWindows.Clear();
            NativeMethods.EnumDesktopWindows(IntPtr.Zero, new NativeMethods.EnumDesktopWindowsDelegate(EnumWindowsProc), IntPtr.Zero);
        }

        private bool EnumWindowsProc(IntPtr hWnd, uint lParam)
        {
            string qqproname = this.GetProcessName(hWnd);
            StringBuilder className = new StringBuilder(255 + 1); //ClassName 最长
            NativeMethods.GetClassName(hWnd, className, className.Capacity);

            if (!qqproname.Equals(String.Empty)
                && qqproname.Equals("QQ")
                && className.ToString().Equals("TXGuiFoundation")
                )
            //if (!qqproname.Equals(String.Empty) && qqproname.Equals("WindowsApplication2"))
            {
                StringBuilder caption = new StringBuilder(NativeMethods.GetWindowTextLength(hWnd) + 1);
                NativeMethods.GetWindowText(hWnd, caption, caption.Capacity);
                if (!caption.ToString().Equals(String.Empty)
                    && !caption.ToString().Equals("TXFloatingWnd")
                    && !caption.ToString().Equals("TXMenuWindow")
                    && !caption.ToString().Equals("QQ2011"))
                {

                    QQChatWindows qqchat = new QQChatWindows(hWnd, caption.ToString());
                    this._QQListWindows.Add(qqchat);

                    this.listQQWindows.Items.Add(caption);



                }

            }
            return true;

        }

        private static IntPtr windowFound;
        static NativeMethods.EnumChildWindowsDelegate callback = new NativeMethods.EnumChildWindowsDelegate(EnumChildWindowsProc);

        private static bool EnumChildWindowsProc(IntPtr hWnd, IntPtr lParam)
        {
            //IntPtr hWnd =  (IntPtr)(xx);
            windowFound = hWnd;
            StringBuilder caption = new StringBuilder(NativeMethods.GetWindowTextLength(hWnd) + 1);
            NativeMethods.GetWindowText(hWnd, caption, caption.Capacity);
            System.Diagnostics.Trace.WriteLine("Sub:" + caption.ToString());
            NativeMethods.EnumChildWindows(hWnd, callback, IntPtr.Zero);
            return true;
        }
        public string GetProcessName(IntPtr hWnd)
        {
            try
            {
                string processname = String.Empty;
                int proid = 0;
                uint threadid = NativeMethods.GetWindowThreadProcessId(hWnd, out proid);
                if (threadid > 0 && proid > 0)
                {
                    Process pro = Process.GetProcessById(proid);
                    processname = pro.ProcessName;

                }

                return processname;
            }
            catch
            {
                return String.Empty;
            }


        }

        private void Link_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bmpj.net");
        }

        private void txtSendText_Enter(object sender, EventArgs e)
        {
            if (this.txtSendText.Text.Equals("<输入要发送的内容>"))
            {
                this.txtSendText.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this._CountTime++;
            if (this._CountTime >= this._SendIntervalTime)
            {
                this.SendQQMsgLoop();
                this._CountTime = 0;
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIntervalTime_Leave(object sender, EventArgs e)
        {
            try
            {
                int time = Convert.ToInt32(this.txtIntervalTime.Text);
                if (time >= 10)
                    this._SendIntervalTime = time;
                else
                {
                    this.txtIntervalTime.Text = this._SendIntervalTime.ToString();
                    MessageBox.Show("不能小于 10");
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            this.txtSendText.Text = "";
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            RegForm reg = new RegForm();
            reg.ShowDialog();
            this.CheckReg();
        }

        private void CheckReg()
        {
            if (!QQREG.IsRegSoftware)
            {
                this.Text = this._Title + " 未注册";
                this.btRegister.Enabled = true;
            }
            else
            {
                this.Text = this._Title + " 已注册";
                this.btRegister.Enabled = false;
            }
        }

        public IntPtr IntPtr_MainQQ = IntPtr.Zero;
        public IntPtr IntPtr_FindQQForm = IntPtr.Zero;

        private IntPtr FindQQWindow(string title)
        {
            IntPtr hander = IntPtr.Zero;
            NativeMethods.EnumDesktopWindows(IntPtr.Zero, new NativeMethods.EnumDesktopWindowsDelegate((hWnd, b) =>
            {
                Trace.WriteLine( hWnd .ToInt32() + "---------------------");
                string qqproname = this.GetProcessName(hWnd);
                StringBuilder className = new StringBuilder(255 + 1); //ClassName 最长
                NativeMethods.GetClassName(hWnd, className, className.Capacity);

                Trace.WriteLine("ProcessName:"+ qqproname +",CalssName:" + className);
                if (!qqproname.Equals(String.Empty)
                    && qqproname.Equals("QQ")
                    && className.ToString().Equals("TXGuiFoundation")
                    )
                {

                    StringBuilder caption = new StringBuilder(NativeMethods.GetWindowTextLength(hWnd) + 1);
                    NativeMethods.GetWindowText(hWnd, caption, caption.Capacity);
                    System.Diagnostics.Trace.WriteLine("caption:"+caption.ToString());
                    if (
                        caption.ToString().Equals(title))
                    {
                        hander = hWnd;
                       
                    }

                }
                Trace.WriteLine(hWnd.ToInt32() + "---------------------");
                return hander == IntPtr.Zero;


            }), IntPtr.Zero);
            return hander;
        }

        private void ShowQQFindDialog()
        {
            if (IntPtr_MainQQ == IntPtr.Zero)
                IntPtr_MainQQ = FindQQWindow("QQ");
            if (IntPtr_MainQQ == IntPtr.Zero)
            {
                MessageBox.Show("找不到QQ主窗口");
                return;
            }
            QQAutoSend.NativeMethods.RECT rect = new NativeMethods.RECT();
            //获取大小
            NativeMethods.GetWindowRect(IntPtr_MainQQ, ref rect);
            if (rect.IsEmpty())
            {
                MessageBox.Show("获取主窗口大小失败！");
                return;

            }
            Point p = new Point() { X = rect.left + 180, Y = rect.bottom - 20 };

            NativeMethods.SetCursorPos(p.X, p.Y);
            NativeMethods.BringWindowToTop(IntPtr_MainQQ);
            NativeMethods.mouse_event(Consts.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            NativeMethods.mouse_event(Consts.MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);

        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (IntPtr_FindQQForm == IntPtr.Zero)
            {
                ShowQQFindDialog();
                System.Threading.Thread.Sleep(1000);
                IntPtr_FindQQForm = FindQQWindow("查找联系人");
            }

            if (IntPtr_FindQQForm == IntPtr.Zero)
            {
                MessageBox.Show("打开查找对话框失败！");
                return;
            }

            QQAutoSend.NativeMethods.RECT rect = new NativeMethods.RECT();
            //获取大小
            NativeMethods.GetWindowRect(IntPtr_FindQQForm, ref rect);
            if (rect.IsEmpty())
            {
                MessageBox.Show("获取主窗口大小失败！");
                return;

            }
            Point p = new Point() { X = rect.left + 180, Y = rect.top  + 200 };

            NativeMethods.SetCursorPos(p.X, p.Y);
            NativeMethods.BringWindowToTop(IntPtr_FindQQForm);
            //NativeMethods.mouse_event(Consts.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            //NativeMethods.mouse_event(Consts.MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
            

        }




    }
}