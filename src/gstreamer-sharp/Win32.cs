using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    internal static class Win32
    {
        [DllImport("Kernel32.dll")]
        public static extern IntPtr CreateConsoleScreenBuffer(
             UInt32 dwDesiredAccess,
             UInt32 dwShareMode,
             IntPtr secutiryAttributes,
             UInt32 flags,
             [MarshalAs(UnmanagedType.U4)] UInt32 screenBufferData
             );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        public static extern bool SetConsoleActiveScreenBuffer(IntPtr hConsoleOutput);
    }
}
