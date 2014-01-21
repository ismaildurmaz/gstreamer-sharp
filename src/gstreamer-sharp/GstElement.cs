using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GstElement : GstObject
    {
        #region wrappers
        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_element_factory_make(string factoryName, string name);

        [DllImport(Library.Libgstreamer)]
        private static extern bool gst_element_link(IntPtr sourceElement, IntPtr destinationElement);


        [DllImport(Library.Libgstreamer)]
        private static extern GstStateChangeReturn gst_element_set_state(IntPtr element, GstState state);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_element_get_bus(IntPtr element);

        #endregion

        internal GstElement(IntPtr handle)
            : base(handle)
        {
        }

        

        public bool Link(GstElement element)
        {
            return gst_element_link(Handle, element.Handle);
        }

        public GstStateChangeReturn Play()
        {
            return gst_element_set_state(Handle, GstState.Playing);
        }

        public GstBus GetBus()
        {
            return new GstBus(gst_element_get_bus(Handle));
        }
    }
}
