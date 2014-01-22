using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    /// <summary>
    /// Indicates when this pad will become available.
    /// </summary>
    public enum GstPadPresence
    {
        /// <summary>
        /// The pad is always available.
        /// </summary>
        Always,

        /// <summary>
        /// The pad will become available depending on the media stream
        /// </summary>
        Sometimes,

        /// <summary>
        /// The pad is only available on request with <b>RequestPad</b>
        /// </summary>
        Request
    }
}
