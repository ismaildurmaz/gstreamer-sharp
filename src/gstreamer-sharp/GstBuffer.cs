using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    public class GstBuffer : HandleObject
    {
        public GstBuffer(IntPtr handle) : base(handle)
        {
        }
    }
}
