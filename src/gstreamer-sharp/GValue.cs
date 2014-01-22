using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GValue : HandleObject
    {
        #region wrappers

        [DllImport(Library.Libgobject)]
        private static extern IntPtr g_strdup_value_contents(IntPtr handle);

        [DllImport(Library.Libgobject)]
        private static extern IntPtr g_type_name(int gType);
        #endregion

        internal GValue(IntPtr handle) : base(handle)
        {
        }

        public string Contents
        {
            get
            {
                return MemoryManagement.GetManagedString(g_strdup_value_contents(Handle));
            }
        }

        public int Value
        {
            get
            {
                return Handle.ToInt32();
            }
        }

        public string TypeName
        {
            get
            {
                return MemoryManagement.GetManagedString(g_type_name(Value));
            }
        }
    }
}
