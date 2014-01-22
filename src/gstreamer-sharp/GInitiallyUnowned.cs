using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    /// <summary>
    /// All the fields in the GInitiallyUnowned structure are private to the GInitiallyUnowned implementation and should never be accessed directly.
    /// </summary>
    public class GInitiallyUnowned : GObject
    {
        internal GInitiallyUnowned(IntPtr handle)
            : base(handle)
        {
        }
    }
}
