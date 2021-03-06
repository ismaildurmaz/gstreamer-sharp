﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using Gst.Plugins;

namespace Gst
{
    public abstract class GObject : HandleObject, IDisposable
    {
        #region wrappers

        [DllImport(Library.Libgobject, CallingConvention = CallingConvention.Cdecl)]
        private static extern void g_object_set(IntPtr obj, string propertName, IntPtr value1, object value2);

        [DllImport(Library.Libgobject, CallingConvention = CallingConvention.Cdecl)]
        private static extern void g_object_get(IntPtr obj, string propertName, out IntPtr value1, object value2);

        [DllImport(Library.Libgobject, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr g_object_class_list_properties(IntPtr obj, out uint count);

        [DllImport(Library.Libgobject, CallingConvention = CallingConvention.Cdecl)]
        private static extern void g_object_run_dispose(IntPtr obj);

        #endregion

        #region structures
        [StructLayout(LayoutKind.Sequential)]
        private struct GObjectStruct
        {
            public GTypeInstance TypeInstance;
            public volatile int RefCount;
            public volatile IntPtr QData;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct GTypeInstance
        {
            public volatile IntPtr GClass;
        }
        #endregion

        internal GObject(IntPtr handle) : base(handle)
        {
        }

        internal GObject(GObject obj) : base(obj.Handle)
        {
        }

        internal GObject(HandleObject handleObject)
            : base(handleObject.Handle)
        {
        }

        internal GObject(GstPlugin plugin)
            : base(GstElementFactory.FactoryMake(plugin).Handle)
        {
        }

        internal GObject(GstPlugin plugin, string name)
            : this(GstElementFactory.FactoryMake(plugin, name))
        {
        }

        public GType Type
        {
            get
            {
                return (GType) GetStruct().TypeInstance.GClass.ToInt64();
            }
        }

        /// <summary>
        ///     Dispose the object
        /// </summary>
        public void Dispose()
        {
            g_object_run_dispose(Handle);
        }


        private GObjectStruct GetStruct()
        {
            return (GObjectStruct) Marshal.PtrToStructure(Handle, typeof (GObjectStruct));
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
            Set(propertyName, Utils.ColorToLong(value));
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
            IntPtr ptr = Get(propertyName);
            if (ptr == IntPtr.Zero)
            {
                return null;
            }
            if (typeof (HandleObject).IsAssignableFrom(type))
            {
                BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

                return Activator.CreateInstance(type, flags, null, new object[] {ptr}, null);
            }
            return Marshal.PtrToStructure(ptr, type);
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
            return Utils.ParseColor(Get(propertyName).ToInt64());
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
        ///     TODO not working
        /// </summary>
        /// <returns></returns>
        public GParamSpec[] ListProperties()
        {
            uint count;
            IntPtr ptr = g_object_class_list_properties(Handle, out count);
            Debug.WriteLine(count);

            return null;
        }

        
    }
}