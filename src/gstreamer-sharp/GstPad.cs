using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    /// <summary>
    /// Object contained by elements that allows links to other elements
    /// </summary>
    public class GstPad : GstObject
    {
        #region wrappers

        [DllImport(Library.Libgstreamer)]
        private static extern GstPadLinkReturn gst_pad_link(IntPtr sourcePad, IntPtr destinationPad);
        #endregion
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

        public void Link(GstPad destinationPad)
        {
            var result = gst_pad_link(Handle, destinationPad.Handle);
            if (result != GstPadLinkReturn.Ok)
            {
                throw new Exception("Pads cannot linked -> " + result);
            }
        }
    }
}
