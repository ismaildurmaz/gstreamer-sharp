using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    public class GInitiallyUnowned : GObject
    {
        internal GInitiallyUnowned(IntPtr handle)
            : base(handle)
        {
        }
    }
}
