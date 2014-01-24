using System;

namespace Gst
{
    public class GParamSpec : HandleObject
    {
        internal GParamSpec(IntPtr handle) : base(handle)
        {
        }
    }
}