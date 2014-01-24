using System;
using Gst.Plugins.Core;

namespace Gst.Plugins.Good
{
    /// <summary>
    ///     Send data over the network via UDP
    /// </summary>
    public class GstMultiUDPSink : GstBaseSink
    {
        internal GstMultiUDPSink(IntPtr handle) : base(handle)
        {
        }

        internal GstMultiUDPSink(HandleObject handleObject)
            : base(handleObject)
        {
        }

        internal GstMultiUDPSink(GstPlugin plugin)
            : base(plugin)
        {
        }

        internal GstMultiUDPSink(GstPlugin plugin, string name)
            : base(plugin, name)
        {
        }
    }
}