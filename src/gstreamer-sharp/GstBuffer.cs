using System;

namespace Gst
{
    public class GstBuffer : HandleObject
    {
        public GstBuffer(IntPtr handle) : base(handle)
        {
        }
    }
}