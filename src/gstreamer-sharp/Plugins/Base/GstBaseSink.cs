using System;

namespace Gst.Plugins.Core
{
    /// <summary>
    ///     Base class for sink elements.
    /// </summary>
    public abstract class GstBaseSink : GstElement
    {
        internal GstBaseSink(IntPtr handle) : base(handle)
        {
        }

        internal GstBaseSink(HandleObject handleObject)
            : base(handleObject)
        {
        }

        internal GstBaseSink(GstPlugin plugin)
            : base(plugin)
        {
        }

        internal GstBaseSink(GstPlugin plugin, string name)
            : base(plugin, name)
        {
        }
    }
}