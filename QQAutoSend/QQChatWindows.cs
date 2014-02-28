using System;
using System.Collections.Generic;
using System.Text;

namespace QQAutoSend
{
    internal class QQChatWindows
    {
        private IntPtr _WindowHwnd = IntPtr.Zero;

        public IntPtr WindowHwnd
        {
            get { return _WindowHwnd; }
            set { _WindowHwnd = value; }
        }
        private string _Caption = String.Empty;

        public string Caption
        {
            get { return _Caption; }
            set { _Caption = value; }
        }
        public QQChatWindows(IntPtr windowhwnd, string caption)
        {
            _WindowHwnd = windowhwnd;
            _Caption = caption;
        }
    }
}
