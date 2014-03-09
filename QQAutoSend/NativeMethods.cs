//Download by http://www.codefans.net
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace QQAutoSend
{
    /// <summary>
    /// API声明类
    /// </summary>
    internal static class NativeMethods
    {
        #region Callback Delegate Section
        public delegate bool EnumDesktopWindowsDelegate(IntPtr hWnd, uint lParam);
        public delegate bool EnumChildWindowsDelegate(IntPtr hwnd, IntPtr lParam);
        public delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        #endregion

        internal struct POINTAPI
        {
            internal int x;
            internal int y;
        }

        internal struct RECT
        {
            internal int left;
            internal int top;
            internal int right;
            internal int bottom;

            internal bool IsEmpty()
            {
                return left == 0 && top == 0 && right == 0 && bottom == 0;
            }
        }

        #region Windows API Import Section


        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextLength", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowText", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);


        [DllImport("kernel32.dll ", CharSet = CharSet.Auto)]
        public extern static IntPtr GetModuleHandle(string lpModuleName);


        [DllImport("user32.dll", EntryPoint = "GetClassName", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int GetClassName(IntPtr hWnd, StringBuilder buf, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows", ExactSpelling = false,
            CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumDesktopWindows(IntPtr hDesktop,
            EnumDesktopWindowsDelegate lpEnumCallbackFunction, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "EnumChildWindows", ExactSpelling = false,
            CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumChildWindows(IntPtr parentHandle, EnumChildWindowsDelegate callback, IntPtr lParam);


        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, IntPtr wParam, string lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetWindow", SetLastError = true)]
        internal static extern IntPtr GetWindow(IntPtr hWnd, uint wCmd);

        [DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int dwProcessId);



        [DllImport("Psapi.dll")]
        public static extern int EnumProcessModules(IntPtr hProcess, out IntPtr hMoudle, int cb, out int cbNeed);


        [DllImport("psapi.dll")]
        public static extern uint GetModuleBaseName(IntPtr hProcess, IntPtr hModule, out StringBuilder lpBaseName, uint nSize);


        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hwnd, String lpString);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumThreadWindows(IntPtr  dwThreadId, EnumDesktopWindowsDelegate callback, IntPtr  lParam);

        #region Mouse
        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "SwapMouseButton")]
        internal extern static int SwapMouseButton(int bSwap);

        [DllImport("user32", EntryPoint = "ClipCursor")]
        internal extern static int ClipCursor(ref   RECT lpRect);

        [DllImport("user32.dll", EntryPoint = "GetCursorPos")]
        internal extern static int GetCursorPos(ref   POINTAPI lpPoint);

        [DllImport("user32.dll", EntryPoint = "ShowCursor")]
        internal extern static bool ShowCursor(bool bShow);

        [DllImport("user32.dll", EntryPoint = "EnableWindow")]
        internal extern static int EnableWindow(int hwnd, int fEnable);

        [DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        internal extern static int GetWindowRect(IntPtr hwnd, ref   RECT lpRect);

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        internal extern static int SetCursorPos(int x, int y);

        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        internal extern static int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetDoubleClickTime")]
        internal extern static int SetDoubleClickTime(int wCount);

        [DllImport("user32.dll", EntryPoint = "GetDoubleClickTime")]
        internal extern static int GetDoubleClickTime();

        [DllImport("kernel32.DLL", EntryPoint = "Sleep")]
        internal extern static void Sleep(int dwMilliseconds);

        #endregion

        #endregion

        #region Windows Message Declaration Section

        internal const uint BM_CLICK = 0xF5;
        internal const uint GW_HWNDNEXT = 0x02;
        internal const uint EM_REPLACESEL = 0xC2;


        internal const int WM_VSCROLL = 0x115;
        internal const int SB_LINEDOWN = 0x1;
        internal const int WM_LBUTTONDOWN = 0x201;
        internal const int MK_LBUTTON = 0x1;
        internal const int WM_LBUTTONUP = 0x202;
        internal const int WM_LBUTTONDBLCLK = 0x203;
        internal const int WM_CHAR = 0x102;
        internal const int WM_CLOSE = 0x10;

        internal const int GWL_ID = -12;
        internal const int GWL_STYLE = -16;
        internal const int GWL_EXSTYLE = -20;

        internal const int WM_IME_CHAR = 0x286;
        internal const int WM_KEYDOWN = 0x0100;


        public enum ShowWindowCommands : int
        {
            /// <summary>
            /// Hides the window and activates another window.
            /// </summary>
            Hide = 0,
            /// <summary>
            /// Activates and displays a window. If the window is minimized or 
            /// maximized, the system restores it to its original size and position.
            /// An application should specify this flag when displaying the window 
            /// for the first time.
            /// </summary>
            Normal = 1,
            /// <summary>
            /// Activates the window and displays it as a minimized window.
            /// </summary>
            ShowMinimized = 2,
            /// <summary>
            /// Maximizes the specified window.
            /// </summary>
            Maximize = 3, // is this the right value?
            /// <summary>
            /// Activates the window and displays it as a maximized window.
            /// </summary>       
            ShowMaximized = 3,
            /// <summary>
            /// Displays a window in its most recent size and position. This value 
            /// is similar to <see cref="Win32.ShowWindowCommand.Normal"/>, except 
            /// the window is not actived.
            /// </summary>
            ShowNoActivate = 4,
            /// <summary>
            /// Activates the window and displays it in its current size and position. 
            /// </summary>
            Show = 5,
            /// <summary>
            /// Minimizes the specified window and activates the next top-level 
            /// window in the Z order.
            /// </summary>
            Minimize = 6,
            /// <summary>
            /// Displays the window as a minimized window. This value is similar to
            /// <see cref="Win32.ShowWindowCommand.ShowMinimized"/>, except the 
            /// window is not activated.
            /// </summary>
            ShowMinNoActive = 7,
            /// <summary>
            /// Displays the window in its current size and position. This value is 
            /// similar to <see cref="Win32.ShowWindowCommand.Show"/>, except the 
            /// window is not activated.
            /// </summary>
            ShowNA = 8,
            /// <summary>
            /// Activates and displays the window. If the window is minimized or 
            /// maximized, the system restores it to its original size and position. 
            /// An application should specify this flag when restoring a minimized window.
            /// </summary>
            Restore = 9,
            /// <summary>
            /// Sets the show state based on the SW_* value specified in the 
            /// STARTUPINFO structure passed to the CreateProcess function by the 
            /// program that started the application.
            /// </summary>
            ShowDefault = 10,
            /// <summary>
            ///  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread 
            /// that owns the window is not responding. This flag should only be 
            /// used when minimizing windows from a different thread.
            /// </summary>
            ForceMinimize = 11
        }
        #endregion




    }
    public class Consts
    {
        /// <summary>
        /// 移动鼠标
        /// </summary>
        public const int MOUSEEVENTF_MOVE = 0x0001;
        /// <summary>
        /// 模拟鼠标左键按下
        /// </summary>
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        /// <summary>
        /// 模拟鼠标左键抬起
        /// </summary>

        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        /// <summary>
        /// 模拟鼠标右键按下
        /// </summary>

        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        /// <summary>
        ///  模拟鼠标右键抬起
        /// </summary>
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        /// <summary>
        /// 模拟鼠标中键按下 
        /// </summary>
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        /// <summary>
        /// 模拟鼠标中键抬起
        /// </summary>
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        /// <summary>
        /// 标示是否采用绝对坐标
        /// </summary>
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;
    }
}
