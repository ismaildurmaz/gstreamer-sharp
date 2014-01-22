using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    public class GstBaseSrc : GstElement
    {
        internal GstBaseSrc(IntPtr handle) : base(handle)
        {
        }
    }
}
