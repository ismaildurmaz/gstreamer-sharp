using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Gst
{
    public class GstIterator: HandleObject, IEnumerator
    {
        #region wrappers
        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern GstIteratorResult gst_iterator_foreach(IntPtr ptr,
            Delegates.GstIteratorForeachFunction func,
            IntPtr userData);

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern GstIteratorResult gst_iterator_next(IntPtr iterator, out IntPtr next);

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern void gst_iterator_free(IntPtr iterator);
        #endregion

        private object _current;
        private bool _done;
        private Type _type;

        protected GstIterator(IntPtr handle, Type type) : base(handle)
        {
            this._type = type;
        }

        public void Dispose()
        {
            gst_iterator_free(Handle);
        }

        public bool MoveNext()
        {
            IntPtr next;
            GstIteratorResult result = gst_iterator_next(Handle, out next);
            if (result == GstIteratorResult.Error)
            {
                throw new Exception("Cannot get next item");
            }
            if (result == GstIteratorResult.Done)
            {
                _done = true;
            }
            Current = Utils.HandleObject(next, _type);

            return !_done;
        }

        public void Reset()
        {
        }

        
        object IEnumerator.Current
        {
            get { return _current; }
        }

        public object Current
        {
            get { return _current; }
            private set { _current = value; }
        }

        

        public static GstIterator Create(IntPtr ptr, Type type)
        {
            if (ptr == IntPtr.Zero)
            {
                return null;
            }
            return new GstIterator(ptr, type);
        }
    }
}