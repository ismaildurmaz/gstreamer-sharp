using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GIOChannel : HandleObject
    {
        #region wrappers

        

        [DllImport(Library.Libglib)]
        private static extern IntPtr g_io_channel_win32_new_fd(IntPtr fd);

        [DllImport(Library.Libglib)]
        private static extern uint g_io_add_watch(IntPtr handle, GIOCondition condition, Delegates.GIOFunction func, IntPtr userData);

        [DllImport(Library.Libglib)]
        private static extern GIOStatus g_io_channel_read_line(IntPtr handle, out IntPtr str, out long length,
            out long terminatorPos, out GError error);

        private const int StdInputHandle = -10;

        private const int StdOutputHandle = -11;

        private const int StdErrorHandle = -12;
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
            var result = g_io_channel_read_line(Handle, out ptr, out length, out terminatorPos, out error);
            line = Utils.StringFromNativeUtf8(ptr);
            MemoryManagement.Free(ptr);
            return result;
        }
    }
}
