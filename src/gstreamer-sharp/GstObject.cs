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

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_object_get_path_string(IntPtr ptr);

        #endregion

        internal GstObject(IntPtr handle)
            : base(handle)
        {
        }

        public string Name
        {
            get
            {
                var ptr = gst_object_get_name(Handle);
                var result = Utils.StringFromNativeUtf8(ptr);
                MemoryManagement.Free(ptr);
                return result;
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

        public string Path
        {
            get
            {
                var ptr = gst_object_get_path_string(Handle);
                var result = Utils.StringFromNativeUtf8(ptr);
                MemoryManagement.Free(ptr);
                return result;
            }
        }
    }
}
