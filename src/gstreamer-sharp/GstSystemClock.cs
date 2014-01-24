using System;
using System.Runtime.InteropServices;

namespace Gst
{
    /// <summary>
    ///     Default clock that uses the current system time
    /// </summary>
    public class GstSystemClock : GstClock
    {
        #region wrappers

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gst_system_clock_obtain();

        #endregion

        private static GstSystemClock _instance;

        internal GstSystemClock(IntPtr handle) : base(handle)
        {
        }

        public static GstSystemClock Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GstSystemClock(gst_system_clock_obtain());
                }
                return _instance;
            }
        }

        /// <summary>
        ///     The type of underlying clock implementation used.
        ///     Default value: GST_CLOCK_TYPE_MONOTONIC
        /// </summary>
        public GstClockType ClockType
        {
            get { return (GstClockType) GetInt32("clock-type"); }
            set { Set("clock-type", (int) value); }
        }
    }
}