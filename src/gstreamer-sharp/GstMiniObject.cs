using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GstMiniObject
    {
        public int GType;
        public int RefCount;
        public int LockState;
        public uint Flags;
        public IntPtr MiniObjectCopyFunction;
        public IntPtr MiniObjectDisposeFunction;
        public IntPtr MiniObjectFreeFunction;
    }
}
