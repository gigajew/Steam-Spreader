using System;
using static stsprtest.NativeMethods;

namespace stsprtest
{
    public class ChatWindow
    {
        public IntPtr WindowHandle
        {
            get { return m_WindowHandle; }
            protected set { m_WindowHandle = value; }
        }

        public string DisplayName
        {
            get { return m_DisplayName; }
            protected set { m_DisplayName = value; }
        }

        public void Focus()
        {
            SetForegroundWindow(WindowHandle);
        }

        public void Maximize()
        {
            ShowWindowAsync(WindowHandle, 9);
        }

        public void Minimize()
        {
            ShowWindowAsync(WindowHandle, 6);
        }

        public bool IsMinimized()
        {
            long style = GetWindowLong(WindowHandle, -16);
            return (style & 0x20000000L) == 0x20000000L;
        }

        public static ChatWindow FromHandle(IntPtr handle, string displayName)
        {
            return new ChatWindow() { WindowHandle = handle, DisplayName = displayName };
        }

        ~ChatWindow()
        {
            CloseHandle(WindowHandle);
        }

        private IntPtr m_WindowHandle;
        private string m_DisplayName;
    }
}
