using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    public class GstPluginFeature : GstObject
    {
        internal GstPluginFeature(IntPtr handle) : base(handle)
        {
        }
    }
}
