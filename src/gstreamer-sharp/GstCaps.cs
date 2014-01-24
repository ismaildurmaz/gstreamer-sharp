using System;
using System.Runtime.InteropServices;
using Gst.Plugins;

namespace Gst
{
    /// <summary>
    /// Structure describing sets of media formats.
    /// </summary>
    public class GstCaps : HandleObject
    {
        #region wrappers
        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gst_caps_from_string(string caps);

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gst_caps_to_string(IntPtr caps);

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gst_caps_new_empty();
        #endregion

        internal GstCaps(IntPtr handle) : base(handle)
        {
        }

        public GstCaps(string caps)
            : base(gst_caps_from_string(caps))
        {
            
        }

        public GstCaps() : base(gst_caps_new_empty())
        {
            
        }



        public static GstCaps FromVideoXRawRGB(int width, int height, int framerate)
        {
            var str = string.Format("video/x-raw-rgb,width={0},height={1},framerate={2}/1", width, height,
                framerate);
            return new GstCaps(str);
        }

        public static GstCaps FromVideoXRawRGB(int width, int height)
        {
            var str = string.Format("video/x-raw-rgb,width={0},height={1}", width, height);
            return new GstCaps(str);
        }

        public static GstCaps FromVideoXRaw(VideoXRawFormat format, int width, int height, int framerate)
        {
            var str = string.Format("video/x-raw,format={0},width={1},height={2},framerate={3}/1", format, width, height,
                framerate);
            return new GstCaps(str);
        }

        public static GstCaps FromVideoXRaw(int width, int height, int framerate)
        {
            var str = string.Format("video/x-raw,width={0},height={1},framerate={2}/1", width, height,
                framerate);
            return new GstCaps(str);
        }

        public static GstCaps FromVideoXRaw(int width, int height)
        {
            var str = string.Format("video/x-raw,width={0},height={1}", width, height);
            return new GstCaps(str);
        }

        /// <summary>
        /// Converts caps to a string representation. This string representation can be converted back to a GstCaps by string.
        /// </summary>
        public string Value
        {
            get { return MemoryManagement.GetManagedString(gst_caps_to_string(Handle)); }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}