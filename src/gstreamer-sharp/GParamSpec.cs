using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    public class GParamSpec : HandleObject
    {
        internal GParamSpec(IntPtr handle) : base(handle)
        {
        }
    }
}
