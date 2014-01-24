using System;

namespace Gst
{
    public class GstPluginFeature : GstObject
    {
        internal GstPluginFeature(IntPtr handle) : base(handle)
        {
        }
    }
}