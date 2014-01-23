using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    /// <summary>
    /// The GLib Runtime type identification and management system.
    /// </summary>
    public class GType : HandleObject
    {
        #region wrappers
        [DllImport(Library.Libgobject)]
        private static extern IntPtr g_type_name(IntPtr type);
        #endregion

        internal GType(IntPtr handle) : base(handle)
        {
        }

        public string Name
        {
            get { return MemoryManagement.GetManagedString(g_type_name(Handle)); }
        }
    }
}
