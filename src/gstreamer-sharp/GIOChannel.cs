using System;
using System.Runtime.InteropServices;

namespace Gst
{
    public class GIOChannel : HandleObject
    {
        #region wrappers

        private const int StdInputHandle = -10;

        private const int StdOutputHandle = -11;

        private const int StdErrorHandle = -12;

        [DllImport(Library.Libglib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr g_io_channel_win32_new_fd(IntPtr fd);

        [DllImport(Library.Libglib, CallingConvention = CallingConvention.Cdecl)]
        private static extern uint g_io_add_watch(IntPtr handle, GIOCondition condition, Delegates.GIOFunction func,
            IntPtr userData);

        [DllImport(Library.Libglib, CallingConvention = CallingConvention.Cdecl)]
        private static extern GIOStatus g_io_channel_read_line(IntPtr handle, out IntPtr str, out long length,
            out long terminatorPos, out GError error);

        #endregion

        public GIOChannel(IntPtr handle)
            : base(handle)
        {
        }

        public static GIOChannel CreateFromStandardInput()
        {
            IntPtr ptr = Win32.GetStdHandle(StdInputHandle);
            if (ptr == IntPtr.Zero)
            {
                throw new Exception("Standard input handle cannot be initialized");
            }
            return new GIOChannel(g_io_channel_win32_new_fd(ptr));
        }

        public uint AddWatch(GIOCondition condition, Delegates.GIOFunction function, IntPtr userData)
        {
            return g_io_add_watch(Handle, condition, function, userData);
        }

        public GIOStatus ReadLine(out string line)
        {
            IntPtr ptr;
            long length;
            GError error;
            long terminatorPos;
            GIOStatus result = g_io_channel_read_line(Handle, out ptr, out length, out terminatorPos, out error);
            line = Utils.StringFromNativeUtf8(ptr);
            MemoryManagement.Free(ptr);
            return result;
        }
    }
}