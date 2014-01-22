using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GstCaps : HandleObject
    {
        internal GstCaps(IntPtr handle) : base(handle)
        {
        }
    }
}
