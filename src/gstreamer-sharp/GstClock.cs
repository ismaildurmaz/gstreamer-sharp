using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
   public class GstClock : GstObject
    {
        public GstClock(IntPtr handle) : base(handle)
        {
        }
    }
}
