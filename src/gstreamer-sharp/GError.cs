using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
