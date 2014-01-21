using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
