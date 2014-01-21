using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public static class Gst
    {
        #region wrappers
        [DllImport(Library.Libgstreamer)]
        private static extern void gst_version(out uint major, out uint minor, out uint micro, out uint nano);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_version_string();

        [DllImport(Library.Libgstreamer)]
        private static extern bool gst_init(int argc, IntPtr argv);

        #endregion

        private static Hashtable _objTable = new Hashtable();
        private static GstVersion _version = null;

        static Gst()
        {
           
        }

        internal static string GenerateName(string type)
        {
            object value = _objTable[type];
            if (value == null)
            {
                _objTable[type] = 0;
                return type;
            }
            else
            {
                value = (int)value + 1;
            }
            _objTable[type] = value;
            return type + "_" + value;
        }

        internal static string GenerateName(Type type)
        {
            return GenerateName(type.Name);
        }

        public static GstVersion Version
        {
            get
            {
                if (_version == null)
                {
                    uint major, minor, micro, nano;
                    gst_version(out major, out minor, out micro, out nano);
                    var desc = Utils.StringFromNativeUtf8(gst_version_string());
                    _version = new GstVersion(major,minor, micro, nano, desc);
                }
                return _version;
            }
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
