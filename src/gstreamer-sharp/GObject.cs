using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GObject
    {
        #region wrappers

        [DllImport(Library.Libgobject)]
        public static extern void g_object_set(IntPtr obj, string propertName, object[] values);

        [DllImport(Library.Libgobject)]
        public static extern void g_object_get(IntPtr obj, string propertName, ref IntPtr values);

        #endregion

        private IntPtr _handle;

        internal GObject(IntPtr handle)
        {
            this._handle = handle;
            if (handle == IntPtr.Zero)
            {
                throw new Exception("Handle cannot be initialized");
            }
        }

        public void PropertySet(string propertyName, params object[] values)
        {
            g_object_set(Handle, propertyName, values);
        }

        public void PropertyGet(string propertyName, ref IntPtr values)
        {
            g_object_get(Handle, propertyName, ref values);
        }

        public IntPtr Handle
        {
            get { return _handle; }
        }
    }
}
