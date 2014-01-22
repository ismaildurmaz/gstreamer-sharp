using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    /// <summary>
    /// The direction of a pad.
    /// </summary>
    public enum GstPadDirection
    {
        /// <summary>
        /// Direction is unknown.
        /// </summary>
        Unknown,

        /// <summary>
        /// The pad is a source pad.
        /// </summary>
        Source,

        /// <summary>
        /// The pad is a sink pad.
        /// </summary>
        Sink
    }
}
