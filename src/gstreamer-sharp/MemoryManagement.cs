using System;
using System.Runtime.InteropServices;

namespace Gst
{
    public static class MemoryManagement
    {
        #region wrappers

        [DllImport(Library.Libglib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void g_free(IntPtr ptr);

        #endregion

        public static void Free(IntPtr ptr)
        {
            g_free(ptr);
        }

        public static string GetManagedString(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                return null;
            }
            string result = Utils.StringFromNativeUtf8(ptr);
            Free(ptr);
            return result;
        }
    }
}