using System;
using Gst.Plugins;

namespace Gst
{
    public abstract class GstBaseSrc : GstElement
    {
        internal GstBaseSrc(IntPtr handle) : base(handle)
        {
        }

        internal GstBaseSrc(HandleObject handleObject)
            : base(handleObject)
        {
        }

        internal GstBaseSrc(GstPlugin plugin)
            : base(plugin)
        {
        }
    }
}