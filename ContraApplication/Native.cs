using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ContraApplication
{
    public static class Native
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public Point pt;
            public uint lPrivate;
        }

        [DllImport("user32.dll")]
        public static extern int PeekMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);
    }
}
