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

        [DllImport(Library.Libgobject, CallingConvention = CallingConvention.Cdecl)]
        private static extern void g_object_set(IntPtr obj, string propertName, IntPtr value1, object value2);

        [DllImport(Library.Libgobject, CallingConvention = CallingConvention.Cdecl)]
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

        public void Set(string propertyName, IntPtr value)
        {
            g_object_set(Handle, propertyName, value, null);
        }

        public void Set(string propertyName, int value)
        {
            Set(propertyName, new IntPtr(value));
        }

        public void Set(string propertyName, Uri value)
        {
            Set(propertyName, value.ToString());
        }

        public void Set(string propertyName, bool value)
        {
            Set(propertyName, Convert.ToInt32(value));
        }

        public void Set(string propertyName, uint value)
        {
            Set(propertyName, new IntPtr(value));
        }


        public void Set(string propertyName, long value)
        {
            Set(propertyName, new IntPtr(value));
        }

        public void Set(string propertyName, double value)
        {
            Set(propertyName, BitConverter.DoubleToInt64Bits(value));
        }

        public void Set(string propertyName, string value)
        {
            Set(propertyName, Utils.NativeUtf8FromString(value));
        }

        public void Get(string propertyName, out IntPtr value)
        {
            g_object_get(Handle, propertyName, out value, null);
        }

        public string GetString(string propertyName)
        {
            IntPtr ptr;
            Get(propertyName, out ptr);
            return Utils.StringFromNativeUtf8(ptr);
        }

        public Uri GetUri(string propertyName)
        {
            return new Uri(GetString(propertyName));
        }

        public int GetInt32(string propertyName)
        {
            IntPtr ptr;
            Get(propertyName, out ptr);
            return ptr.ToInt32();
        }

        public bool GetBool(string propertyName)
        {
            return Convert.ToBoolean(GetInt32(propertyName));
        }

        public uint GetUInt32(string propertyName)
        {
            IntPtr ptr;
            Get(propertyName, out ptr);
            return Convert.ToUInt32(ptr.ToInt64());
        }

        public double GetDouble(string propertyName)
        {
            IntPtr ptr;
            Get(propertyName, out ptr);
            return BitConverter.Int64BitsToDouble(ptr.ToInt64());
        }

        public IntPtr Handle
        {
            get { return _handle; }
        }
    }
}
