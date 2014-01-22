using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GstPipeline : GstBin
    {
#region wrappers
        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_pipeline_new(string name);

        [DllImport(Library.Libgstreamer)]
        private static extern bool gst_pipeline_set_clock(IntPtr ptr, IntPtr clock);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_pipeline_get_clock(IntPtr ptr);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_pipeline_get_bus(IntPtr ptr);
        
        [DllImport(Library.Libgstreamer)]
        private static extern void gst_pipeline_auto_clock(IntPtr ptr);

        [DllImport(Library.Libgstreamer)]
        private static extern void gst_pipeline_set_auto_flush_bus(IntPtr ptr, bool autoFlush);

        [DllImport(Library.Libgstreamer)]
        private static extern bool gst_pipeline_get_auto_flush_bus(IntPtr ptr);

        [DllImport(Library.Libgstreamer)]
        private static extern void gst_pipeline_set_delay(IntPtr ptr, UInt64 delay);

        [DllImport(Library.Libgstreamer)]
        private static extern UInt64 gst_pipeline_get_delay(IntPtr ptr  );

        [DllImport(Library.Libgstreamer)]
        private static extern void gst_pipeline_use_clock(IntPtr ptr, IntPtr clock);
#endregion

        internal GstPipeline(IntPtr handle) : base(handle)
        {
        }

        public static GstPipeline Create()
        {
            return Create(Gst.GenerateName(typeof (GstPipeline)));
        }

        public static GstPipeline Create(string name)
        {
            return new GstPipeline(gst_pipeline_new(name));
        }

        public new GstClock Clock
        {
            get
            {
                return new GstClock(gst_pipeline_get_clock(Handle));
            }
            set
            {
                if (!gst_pipeline_set_clock(Handle, value.Handle))
                {
                    throw new Exception("Cannot set the clock");
                }
            }
        }

        public void UseClock(GstClock clock)
        {
            gst_pipeline_use_clock(Handle, clock.Handle);
        }

        public void AutoClock()
        {
            gst_pipeline_auto_clock(Handle);
        }

        public bool AutoFlushBus
        {
            get
            {
                return gst_pipeline_get_auto_flush_bus(Handle);
            }
            set
            {
                gst_pipeline_set_auto_flush_bus(Handle, value);
            }
        }

        public UInt64 SetDelay
        {
            get { return gst_pipeline_get_delay(Handle); }
            set { gst_pipeline_set_delay(Handle, value);}
        }
    }
}
