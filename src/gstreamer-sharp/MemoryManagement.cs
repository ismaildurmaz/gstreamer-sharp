using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
   public static class MemoryManagement
   {
       #region wrappers
       [DllImport(Library.Libglib)]
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
           var result = Utils.StringFromNativeUtf8(ptr);
           Free(ptr);
           return result;
       }
   }
}
