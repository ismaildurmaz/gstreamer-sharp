using System;
using System.Runtime.InteropServices;

namespace Gst
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GstMessage
    {
        public GstMiniObject MiniObject;
        public GstMessageType MessageType;
        public UInt64 TimeStamp;
        public UInt32 SeqNum;
    }
}