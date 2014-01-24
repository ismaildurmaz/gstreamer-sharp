using System;
using System.Runtime.InteropServices;
using Gst.Plugins;

namespace Gst
{
    public class GstObject : GInitiallyUnowned
    {
        #region wrappers

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gst_object_get_name([In] IntPtr handle);

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool gst_object_set_name([In] IntPtr handle, [In] string name);

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gst_object_get_path_string(IntPtr ptr);

        #endregion

        internal GstObject(IntPtr handle)
            : base(handle)
        {
        }

        internal GstObject(HandleObject handleObject)
            : base(handleObject)
        {
        }

        internal GstObject(GstPlugin plugin)
            : base(plugin)
        {
        }


        internal GstObject(GstPlugin plugin, string name)
            : base(plugin, name)
        {
        }

        public string Name
        {
            get { return MemoryManagement.GetManagedString(gst_object_get_name(Handle)); }
            set
            {
                bool r = gst_object_set_name(Handle, value);
                if (!r)
                {
                    throw new Exception("Cannot set the name -> " + value);
                }
            }
        }


        public string Path
        {
            get { return MemoryManagement.GetManagedString(gst_object_get_path_string(Handle)); }
        }
    }
}