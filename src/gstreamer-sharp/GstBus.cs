using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GstBus : GstObject
    {
        #region wrappers
        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_bus_timed_pop_filtered(IntPtr bus, uint timeout, GstMessageType messageType);
        #endregion

        internal GstBus(IntPtr handle) : base(handle)
        {

        }

        public GstMessage? TimedPopFiltered(uint timeout, GstMessageType messageType)
        {
            var ptr = gst_bus_timed_pop_filtered(Handle, timeout, messageType);
            if (ptr == IntPtr.Zero)
            {
                return null;
            }
            return (GstMessage) Marshal.PtrToStructure(ptr, typeof(GstMessage));
        }


    }
}
