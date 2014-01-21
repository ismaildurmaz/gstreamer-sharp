using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    public enum GstStateChangeReturn
    {
        Failure = 0,
        Success = 1,
        Async = 2,
        NoPreroll = 3
    }
}
