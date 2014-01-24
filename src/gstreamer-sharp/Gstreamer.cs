using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Gst
{
    public static class Gstreamer
    {
        #region wrappers

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern void gst_version(out uint major, out uint minor, out uint micro, out uint nano);

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gst_version_string();

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool gst_init(int argc, IntPtr argv);

        #endregion

        private static readonly Hashtable _objTable = new Hashtable();
        private static GstVersion _version;

        static Gstreamer()
        {
        }

        public static GstVersion Version
        {
            get
            {
                if (_version == null)
                {
                    uint major, minor, micro, nano;
                    gst_version(out major, out minor, out micro, out nano);
                    string desc = Utils.StringFromNativeUtf8(gst_version_string());
                    _version = new GstVersion(major, minor, micro, nano, desc);
                }
                return _version;
            }
        }

        internal static string GenerateName(string type)
        {
            object value = _objTable[type];
            if (value == null)
            {
                _objTable[type] = 0;
                return type;
            }
            value = (int) value + 1;
            _objTable[type] = value;
            return type + "_" + value;
        }

        internal static string GenerateName(Type type)
        {
            return GenerateName(type.Name);
        }

        public static void Init()
        {
            if (!gst_init(0, IntPtr.Zero))
            {
                throw new TargetException("GST cannot be init");
            }
        }
    }
}