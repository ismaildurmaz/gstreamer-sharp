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
        private static extern void g_object_set(IntPtr obj, string propertName, object value1, object value2);

        [DllImport(Library.Libgobject)]
        private static extern void g_object_get(IntPtr obj, string propertName, out IntPtr value1, object value2);

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

        public void PropertySet(string propertyName, object value)
        {
            g_object_set(Handle, propertyName, value, null);
        }

        public void PropertyGet(string propertyName, out IntPtr value)
        {
            g_object_get(Handle, propertyName, out value, null);
        }

        public string PropertyReadString(string propertyName)
        {
            IntPtr ptr;
            PropertyGet(propertyName, out ptr);
            return Utils.StringFromNativeUtf8(ptr);
        }

        public IntPtr Handle
        {
            get { return _handle; }
        }
    }
}
