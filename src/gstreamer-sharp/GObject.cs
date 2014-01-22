using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GObject : HandleObject
    {
        #region wrappers

        [DllImport(Library.Libgobject, CallingConvention = CallingConvention.Cdecl)]
        private static extern void g_object_set(IntPtr obj, string propertName, IntPtr value1, object value2);

        [DllImport(Library.Libgobject, CallingConvention = CallingConvention.Cdecl)]
        private static extern void g_object_get(IntPtr obj, string propertName, out IntPtr value1, object value2);

        [DllImport(Library.Libgobject)]
        private static extern IntPtr g_object_class_list_properties(IntPtr obj, out uint count);
        #endregion

        internal GObject(IntPtr handle) : base(handle)
        {
            
        }

        internal GObject(GObject obj) : base(obj.Handle)
        {

        }

        public void Set(string propertyName, IntPtr value)
        {
            g_object_set(Handle, propertyName, value, null);
        }

        public void Set(string propertyName, Int32 value)
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

        public void Set(string propertyName, UInt32 value)
        {
            Set(propertyName, new IntPtr(value));
        }

        public void Set(string propertyName, UInt64 value)
        {
            Set(propertyName, Convert.ToInt64(value));
        }

        public void Set(string propertyName, Int64 value)
        {
            Set(propertyName, new IntPtr(value));
        }

        public void Set(string propertyName, Color value)
        {
            Set(propertyName, value.ToArgb());
        }

        public void Set(string propertyName, double value)
        {
            Set(propertyName, BitConverter.DoubleToInt64Bits(value));
        }

        public void Set(string propertyName, TimeSpan value)
        {
            Set(propertyName, Convert.ToInt64(Utils.ConvertMillisecondsToNanoseconds(value.TotalMilliseconds)));
        }


        public void Set(string propertyName, object value)
        {
            var o = value as HandleObject;
            if (o != null)
            {
                Set(propertyName, o.Handle);
            }
            else
            {
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(value));
                Marshal.StructureToPtr(value, ptr, true);
                Set(propertyName, ptr);
            }
        }

        public void Set(string propertyName, string value)
        {
            Set(propertyName, Utils.NativeUtf8FromString(value));
        }

        public IntPtr Get(string propertyName)
        {
            var ptr = new IntPtr();
            g_object_get(Handle, propertyName, out ptr, null);
            return ptr;
        }

        public object GetStructure(string propertyName, Type type)
        {
            var ptr = Get(propertyName);
            if (ptr == IntPtr.Zero)
            {
                return null;
            }
            if (typeof (HandleObject).IsAssignableFrom(type))
            {
                BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

                return Activator.CreateInstance(type, flags, null, new object[] { ptr }, null);
            }
            else
            {
                return Marshal.PtrToStructure(ptr, type);
            }
        }

        public T GetStructure<T>(string propertyName)
        {
            return (T) GetStructure(propertyName, typeof (T));
        }

        public string GetString(string propertyName)
        {
            return Utils.StringFromNativeUtf8(Get(propertyName));
        }

        public Uri GetUri(string propertyName)
        {
            return new Uri(GetString(propertyName));
        }

        public Int32 GetInt32(string propertyName)
        {
            return Get(propertyName).ToInt32();
        }

        public Color GetColor(string propertyName)
        {
            return Color.FromArgb(Get(propertyName).ToInt32());
        }

        public TimeSpan GetTimeSpan(string propertyName)
        {
            return TimeSpan.FromMilliseconds(Utils.ConvertNanosecondsToMilliseconds(GetInt64(propertyName)));
        }

        public Int64 GetInt64(string propertyName)
        {
            return Get(propertyName).ToInt64();
        }

        public UInt64 GetUInt64(string propertyName)
        {
            return Convert.ToUInt64(Get(propertyName).ToInt64());
        }

        public bool GetBool(string propertyName)
        {
            return Convert.ToBoolean(GetInt32(propertyName));
        }

        public uint GetUInt32(string propertyName)
        {
            return Convert.ToUInt32(Get(propertyName).ToInt64());
        }

        public double GetDouble(string propertyName)
        {
            return BitConverter.Int64BitsToDouble(Get(propertyName).ToInt64());
        }

        /// <summary>
        /// TODO not working
        /// </summary>
        /// <returns></returns>
        public GParamSpec[] ListProperties()
        {
            uint count;
            var ptr = g_object_class_list_properties(Handle, out count);
            Debug.WriteLine(count);
            
            return null;
        }
    }
}
