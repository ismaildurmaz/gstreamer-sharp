using System;
using System.Collections;
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

        
        /// <summary>
        /// Link element with destinationElement
        /// </summary>
        /// <param name="destinationElement"></param>
        /// <returns></returns>
        public bool Link(GstElement destinationElement)
        {
            return gst_element_link(Handle, destinationElement.Handle);
        }

        /// <summary>
        /// Set state to playing
        /// </summary>
        public void Play()
        {
            var result = gst_element_set_state(Handle, GstState.Playing);
            if (result == GstStateChangeReturn.Failure)
            {
                throw new Exception("Cannot change state to playing");
            }
        }

        /// <summary>
        /// Set state to paused
        /// </summary>
        public void Pause()
        {
            var result = gst_element_set_state(Handle, GstState.Paused);
            if (result == GstStateChangeReturn.Failure)
            {
                throw new Exception("Cannot change state to paused");
            }
        }

        public GstBus GetBus()
        {
            return new GstBus(gst_element_get_bus(Handle));
        }
    }
}
