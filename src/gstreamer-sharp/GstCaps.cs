using System;
using System.Runtime.InteropServices;

namespace Gst
{
    /// <summary>
    /// Structure describing sets of media formats.
    /// </summary>
    public class GstCaps : HandleObject
    {
        #region wrappers
        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gst_caps_from_string(string caps);

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gst_caps_to_string(IntPtr caps);

        #endregion

        internal GstCaps(IntPtr handle) : base(handle)
        {
        }

        public GstCaps(string caps)
            : base(gst_caps_from_string(caps))
        {
            
        }

        /// <summary>
        /// Converts caps to a string representation. This string representation can be converted back to a GstCaps by string.
        /// </summary>
        public string Value
        {
            get { return MemoryManagement.GetManagedString(gst_caps_to_string(Handle)); }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}