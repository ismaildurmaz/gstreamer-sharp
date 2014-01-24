using System;
using Gst.Plugins;

namespace Gst
{
    /// <summary>
    ///     All the fields in the GInitiallyUnowned structure are private to the GInitiallyUnowned implementation and should
    ///     never be accessed directly.
    /// </summary>
    public abstract class GInitiallyUnowned : GObject
    {
        internal GInitiallyUnowned(IntPtr handle)
            : base(handle)
        {
        }

        internal GInitiallyUnowned(HandleObject handleObject)
            : base(handleObject)
        {
        }

        internal GInitiallyUnowned(GstPlugin plugin)
            : base(plugin)
        {
        }

        internal GInitiallyUnowned(GstPlugin plugin, string name)
            : base(plugin, name)
        {
        }
    }
}