using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Gst.Plugins;

namespace Gst
{
    public static class Utils
    {
        public static string ExecuteGstInspect()
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "gst-inspect-1.0.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            var stringBuilder = new StringBuilder();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                stringBuilder.AppendLine(line);
            }
            return stringBuilder.ToString();
        }

        public static IntPtr GetHandle(HandleObject handleObject)
        {
            if (handleObject == null)
            {
                return IntPtr.Zero;
            }
            return handleObject.Handle;
        }

        public static IntPtr NativeUtf8FromString(string managedString)
        {
            if (managedString == null)
            {
                return IntPtr.Zero;
            }
            int len = Encoding.UTF8.GetByteCount(managedString);
            var buffer = new byte[len + 1];
            Encoding.UTF8.GetBytes(managedString, 0, managedString.Length, buffer, 0);
            IntPtr nativeUtf8 = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, nativeUtf8, buffer.Length);
            return nativeUtf8;
        }

        public static Color ParseColor(long value)
        {
            int a = (byte) ((value) >> 24) & 0xff;
            int r = (byte) ((value) >> 16) & 0xff;
            int g = (byte) ((value) >> 8) & 0xff;
            int b = (byte) ((value)) & 0xff;
            return Color.FromArgb(a, r, g, b);
        }

        public static long ColorToLong(Color value)
        {
            return value.A << 24 | value.R << 16 | value.G << 8 | value.B;
        }

        public static double ConvertMillisecondsToNanoseconds(double milliseconds)
        {
            // One million nanoseconds in one nanosecond.
            return milliseconds*1000000;
        }

        public static double ConvertMicrosecondsToNanoseconds(double microseconds)
        {
            // One thousand microseconds in one nanosecond.
            return microseconds*0.001;
        }

        public static double ConvertMillisecondsToMicroseconds(double milliseconds)
        {
            // One thousand milliseconds in one microsecond.
            return milliseconds*1000;
        }

        public static double ConvertNanosecondsToMilliseconds(double nanoseconds)
        {
            // One million nanoseconds in one millisecond.
            return nanoseconds*0.000001;
        }

        public static double ConvertMicrosecondsToMilliseconds(double microseconds)
        {
            // One thousand microseconds in one millisecond.
            return microseconds*1000;
        }

        public static double ConvertNanosecondsToMicroseconds(double nanoseconds)
        {
            // One thousand nanoseconds in one microsecond.
            return nanoseconds*1000;
        }


        public static T HandleObject<T>(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                return default(T);
            }
            Type type = typeof (T);
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

            return (T) Activator.CreateInstance(type, flags, null, new object[] {ptr}, null);
        }

        public static object HandleObject(IntPtr ptr, Type type)
        {
            if (ptr == IntPtr.Zero)
            {
                return null;
            }
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

            return Activator.CreateInstance(type, flags, null, new object[] {ptr}, null);
        }

        public static string StringFromNativeUtf8(IntPtr nativeUtf8)
        {
            int len = 0;
            if (nativeUtf8 == IntPtr.Zero)
            {
                return null;
            }
            while (Marshal.ReadByte(nativeUtf8, len) != 0) ++len;
            if (len == 0) return string.Empty;
            var buffer = new byte[len];
            Marshal.Copy(nativeUtf8, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        public static string GetName(GstPlugin plugin)
        {
            switch (plugin)
            {
                case GstPlugin.AviMux:
                    return "avimux";
                case GstPlugin.VideoTestSource:
                    return "videotestsrc";
                case GstPlugin.AutoVideoSink:
                    return "autovideosink";
                case GstPlugin.FileSource:
                    return "filesrc";
                case GstPlugin.PlayBin2:
                    return "playbin2";
                case GstPlugin.PlayBin:
                    return "playbin";
                case GstPlugin.KsVideoSource:
                    return "ksvideosrc";
                case GstPlugin.Tee:
                    return "tee";
                case GstPlugin.Pipeline:
                    return "pipeline";
                case GstPlugin.FdSink:
                    return "fdsink";
                case GstPlugin.FileSink:
                    return "filesink";
                case GstPlugin.UdpSink:
                    return "udpsink";

                default:
                    throw new Exception("Not mapped plugin " + plugin);
            }
        }
    }
}