using System;
using System.Runtime.InteropServices;

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