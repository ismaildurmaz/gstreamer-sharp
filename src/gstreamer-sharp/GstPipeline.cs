using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Gst.Plugins;

namespace Gst
{
    /// <summary>
    /// Top-level bin with clocking and bus management functionality.
    /// </summary>
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

         internal GstPipeline(HandleObject handleObject) : base(handleObject)
        {
            
        }

         internal GstPipeline(GstPlugin plugin)
            : base(plugin)
        {

        }

        public GstPipeline() : base(GstPlugin.Pipeline)
        {
            
        }

        public GstPipeline(string name)
            : base(GstPlugin.Pipeline, name)
        {

        }

        public new GstClock Clock
        {
            get
            {
                return Utils.HandleObject<GstClock>(gst_pipeline_get_clock(Handle));
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
