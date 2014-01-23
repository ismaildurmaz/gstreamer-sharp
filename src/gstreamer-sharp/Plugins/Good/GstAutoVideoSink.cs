using System;

namespace Gst.Plugins.Good
{
    /// <summary>
    /// autovideosink is a video sink that automatically detects an appropriate video sink to use. It does so by scanning the registry for all elements that have “Sink” and “Video” in the class field of their element information, and also have a non-zero autoplugging rank.
    /// </summary>
    public class GstAutoVideoSink : GstBin
    {
        public GstAutoVideoSink() : base(GstPlugin.AutoVideoSink)
        {
            
        }

        /// <summary>
        /// This property will filter out candidate sinks that can handle the specified caps. By default only video sinks that support raw rgb and yuv video are selected.
        /// This property can only be set before the element goes to the READY state.
        /// </summary>
        public GstCaps FilterCaps
        {
            get
            {
                return GetStructure<GstCaps>("filter-caps");
            }
            set
            {
                Set("filter-caps", value);
            }
        }

        /// <summary>
        /// Timestamp offset
        /// </summary>
        public TimeSpan Offset
        {
            get
            {
                return GetTimeSpan("ts-offset");
            }
            set
            {
                Set("ts-offset", value);
            }
        }

        /// <summary>
        /// Sync on the clock.
        /// Default value: true
        /// </summary>
        public bool Sync
        {
            get
            {
                return GetBool("sync");
            }
            set
            {
                Set("sync", value);
            }
        }
    }
}
