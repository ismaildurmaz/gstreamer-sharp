using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public static class Utils
    {
        public static IntPtr NativeUtf8FromString(string managedString)
        {
            int len = Encoding.UTF8.GetByteCount(managedString);
            byte[] buffer = new byte[len + 1];
            Encoding.UTF8.GetBytes(managedString, 0, managedString.Length, buffer, 0);
            IntPtr nativeUtf8 = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, nativeUtf8, buffer.Length);
            return nativeUtf8;
        }

        public static double ConvertMillisecondsToNanoseconds(double milliseconds)
        {
            // One million nanoseconds in one nanosecond.
            return milliseconds * 1000000;
        }
        public static double ConvertMicrosecondsToNanoseconds(double microseconds)
        {
            // One thousand microseconds in one nanosecond.
            return microseconds * 0.001;
        }

        public static double ConvertMillisecondsToMicroseconds(double milliseconds)
        {
            // One thousand milliseconds in one microsecond.
            return milliseconds * 1000;
        }

        public static double ConvertNanosecondsToMilliseconds(double nanoseconds)
        {
            // One million nanoseconds in one millisecond.
            return nanoseconds * 0.000001;
        }

        public static double ConvertMicrosecondsToMilliseconds(double microseconds)
        {
            // One thousand microseconds in one millisecond.
            return microseconds * 1000;
        }

        public static double ConvertNanosecondsToMicroseconds(double nanoseconds)
        {
            // One thousand nanoseconds in one microsecond.
            return nanoseconds * 1000;
        }

        public static string StringFromNativeUtf8(IntPtr nativeUtf8)
        {
            int len = 0;
            while (Marshal.ReadByte(nativeUtf8, len) != 0) ++len;
            if (len == 0) return string.Empty;
            byte[] buffer = new byte[len];
            Marshal.Copy(nativeUtf8, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        public static string GetName(GstBaseFactory baseFactory)
        {
            switch (baseFactory)
            {
                case GstBaseFactory.VideoTestSource:
                    return "videotestsrc";
                case GstBaseFactory.AutoVideoSink:
                    return "autovideosink";
                case GstBaseFactory.FileSource:
                    return "filesrc";
                case GstBaseFactory.PlayBin2:
                    return "playbin2";
                case GstBaseFactory.PlayBin:
                    return "playbin";
                case GstBaseFactory.KsVideoSource:
                    return "ksvideosrc";

                default:
                    throw new Exception("Not mapped value " + baseFactory);
            }
        }
    }
}
