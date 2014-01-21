using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GstBin : GstElement
    {
        #region wrappers
        [DllImport(Library.Libgstreamer)]
        private static extern void gst_bin_add_many(IntPtr bin, IntPtr[] elements);

        [DllImport(Library.Libgstreamer)]
        private static extern void gst_bin_remove_many(IntPtr bin, IntPtr[] elements);

        [DllImport(Library.Libgstreamer)]
        private static extern bool gst_bin_add(IntPtr bin, IntPtr element);

        [DllImport(Library.Libgstreamer)]
        private static extern bool gst_bin_remove(IntPtr bin, IntPtr element);

        #endregion

        internal GstBin(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Adds a list of elements to a bin. This function is equivalent to calling <b>AddElement</b> for each member of the list. The return value of each <b>AddElement</b> is ignored.
        /// </summary>
        /// <param name="elements"></param>
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

        /// <summary>
        /// Adds the given element to the bin. Sets the element's parent, and thus takes ownership of the element. An element can only be added to one bin.
        /// If the element's pads are linked to other pads, the pads will be unlinked before the element is added to the bin.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool AddElement(GstElement element)
        {
            return gst_bin_add(Handle, element.Handle);
        }

        /// <summary>
        /// Removes the element from the bin, unparenting it as well. 
        /// Unparenting the element means that the element will be dereferenced, 
        /// so if the bin holds the only reference to the element, 
        /// the element will be freed in the process of removing it from the bin. 
        /// If you want the element to still exist after removing, you need to call <b>Ref()</b> before removing it from the bin.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool RemoveElement(GstElement element)
        {
            return gst_bin_remove(Handle, element.Handle);
        }

        /// <summary>
        /// Remove a list of elements from a bin. This function is equivalent to calling <b>RemoveElement</b> with each member of the list.
        /// </summary>
        /// <param name="elements"></param>
        public void RemoveElements(params GstElement[] elements)
        {
            var lst = new IntPtr[elements.Length + 1];
            int i = 0;
            for (i = 0; i < elements.Length; i++)
            {
                lst[i] = elements[i].Handle;
            }
            lst[i] = IntPtr.Zero;
            gst_bin_remove_many(Handle, lst);
        }
    }
}
