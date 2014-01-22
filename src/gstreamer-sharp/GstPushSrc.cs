using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    public class GstPushSrc : GstBaseSrc
    {
        internal GstPushSrc(IntPtr handle) : base(handle)
        {
        }
    }
}
