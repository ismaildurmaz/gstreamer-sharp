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
        [DllImport(Library.Libgstreamer)]
        public static extern IntPtr gst_object_get_name(IntPtr ptr);

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
        }
    }
}
