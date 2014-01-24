using System;

namespace Gst
{
    public class GstClock : GstObject
    {
        internal GstClock(IntPtr handle) : base(handle)
        {
        }
    }
}