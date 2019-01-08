﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace stsprtest
{
    public class ChatWindow
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr whandle);

        public IntPtr WindowHandle
        {
            get { return m_WindowHandle; }
            protected set { m_WindowHandle = value; }
        }

        public void Open()
        {
            SetForegroundWindow(WindowHandle);
        }

        public static ChatWindow FromHandle(IntPtr handle)
        {
            return new ChatWindow() { WindowHandle = handle };
        }

        private IntPtr m_WindowHandle;
    }
}