using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gst.Plugins;

namespace Gst
{
    public abstract class GstPushSrc : GstBaseSrc
    {
        internal GstPushSrc(IntPtr handle) : base(handle)
        {
        }

        internal GstPushSrc(HandleObject handleObject)
            : base(handleObject)
        {
        }

        internal GstPushSrc(GstPlugin plugin)
            : base(plugin)
        {

        }
    }
}
