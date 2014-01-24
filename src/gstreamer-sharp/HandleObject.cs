using System;

namespace Gst
{
    public abstract class HandleObject
    {
        private readonly IntPtr _handle;

        internal HandleObject(IntPtr handle)
        {
            _handle = handle;

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