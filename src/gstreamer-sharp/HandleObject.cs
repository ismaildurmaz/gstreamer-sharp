using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    public abstract class HandleObject
    {
        private IntPtr _handle;

        internal HandleObject(IntPtr handle)
        {
            this._handle = handle;

            if (handle == IntPtr.Zero)
            {
                throw new Exception("Handle cannot be initialized");
            }
        }

        public IntPtr Handle
        {
            get { return _handle; }
        }
    }
}
