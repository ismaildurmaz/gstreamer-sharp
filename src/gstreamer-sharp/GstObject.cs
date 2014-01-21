using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GstObject : GInitiallyUnowned
    {
        #region wrappers
        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gst_object_get_name([In]IntPtr handle);

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool gst_object_set_name([In]IntPtr handle, [In]string name);

        #endregion

        internal GstObject(IntPtr handle)
            : base(handle)
        {
        }

        public string Name
        {
            get
            {
                return Utils.StringFromNativeUtf8(gst_object_get_name(Handle));
            }
            set
            {
                var r = gst_object_set_name(Handle, value);
                if (!r)
                {
                    throw new Exception("Cannot set the name -> " + value);
                }
            }
        }
    }
}
