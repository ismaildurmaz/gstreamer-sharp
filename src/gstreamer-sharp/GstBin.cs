using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GstBin : GstElement
    {
        [DllImport(Library.Libgstreamer)]
        public static extern void gst_bin_add_many(IntPtr bin, IntPtr[] elements);

        internal GstBin(IntPtr handle) : base(handle)
        {
        }

        public void AddElements(params GstElement[] elements)
        {
            var lst = new IntPtr[elements.Length + 1];
            int i = 0;
            for (i = 0; i < elements.Length; i++)
            {
                lst[i] = elements[i].Handle;
            }
            lst[i] = IntPtr.Zero;
            gst_bin_add_many(Handle, lst);
        }
    }
}
