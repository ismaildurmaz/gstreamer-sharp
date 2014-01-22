using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GstIterator : HandleObject
    {
        [DllImport(Library.Libgstreamer)]
        private static extern GstIteratorResult gst_iterator_foreach(IntPtr ptr,
                                                         Delegates.GstIteratorForeachFunction func,
                                                         IntPtr userData);

        internal GstIterator(IntPtr handle) : base(handle)
        {
        }

        public GstIteratorResult Foreach(Delegates.GstIteratorForeachFunction function, IntPtr userData)
        {
            return gst_iterator_foreach(Handle, function, userData);
        }
    }
}
