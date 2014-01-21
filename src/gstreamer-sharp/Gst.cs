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
        private static Version _version = null;
        private static string _versionDescription = null;

        static Gst()
        {
           
        }

        internal static string GetName(string type)
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

        internal static string GetName(Type type)
        {
            return GetName(type.Name);
        }

        public static Version Version
        {
            get
            {
                if (_version == null)
                {
                    uint major, minor, micro, nano;
                    gst_version(out major, out minor, out micro, out nano);
                    _version = new Version((int)major, (int)minor, (int)micro, (int)nano);
                }
                return _version;
            }
        }

        public static string VersionDescription
        {
            get
            {
                if (_versionDescription == null)
                {
                    _versionDescription = Utils.StringFromNativeUtf8(gst_version_string());
                }
                return _versionDescription;
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
