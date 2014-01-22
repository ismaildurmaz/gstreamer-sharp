using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
	/// <summary>
    /// The different kind of clocks.
	/// </summary>
    public enum GstClockType
    {
		/// <summary>
        /// Time since Epoch.
		/// </summary>
		Realtime = 0,

		/// <summary>
        /// Monotonic time since some unspecified starting point.
		/// </summary>
		Monotonic = 1,
		
		/// <summary>
        /// Some other time source is used (Since: 1.0.5).
		/// </summary>
		Other = 2
    }
}
