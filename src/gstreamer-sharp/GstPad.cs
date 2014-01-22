using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    /// <summary>
    /// Object contained by elements that allows links to other elements
    /// </summary>
    public class GstPad : GstObject
    {
        internal GstPad(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// The capabilities of the pad.
        /// </summary>
        public GstCaps Caps
        {
            get
            {
                return GetStructure<GstCaps>("caps");
            }
        }

        /// <summary>
        /// The direction of the pad.
        /// 
        /// Default value: Unknown
        /// </summary>
        public GstPadDirection Direction
        {
            get
            {
                return (GstPadDirection) GetInt32("direction");
            }
            set
            {
                Set("direction", (int)value);
            }
        }

        /// <summary>
        /// The GstPadTemplate of this pad.
        /// </summary>
        public GstPadTemplate Template
        {
            get
            {
                return GetStructure<GstPadTemplate>("template");
            }
            set
            {
                Set("template", value);
            }
        }
    }
}
