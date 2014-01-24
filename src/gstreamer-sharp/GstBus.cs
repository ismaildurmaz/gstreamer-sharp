using System;
using System.Runtime.InteropServices;

namespace Gst
{
    public class GstBus : GstObject
    {
        #region wrappers

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gst_bus_timed_pop_filtered(IntPtr bus, uint timeout, GstMessageType messageType);

        #endregion

        internal GstBus(IntPtr handle) : base(handle)
        {
        }

        public GstMessage? TimedPopFiltered(uint timeout, GstMessageType messageType)
        {
            IntPtr ptr = gst_bus_timed_pop_filtered(Handle, timeout, messageType);
            if (ptr == IntPtr.Zero)
            {
                return null;
            }
            return (GstMessage) Marshal.PtrToStructure(ptr, typeof (GstMessage));
        }
    }
}