using System;
using System.Runtime.InteropServices;

namespace Gst
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GError
    {
        public UInt32 Domain;
        public int Code;
        public IntPtr Message;
    }
}