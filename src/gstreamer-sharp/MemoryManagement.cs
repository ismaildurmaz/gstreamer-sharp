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
   }
}
