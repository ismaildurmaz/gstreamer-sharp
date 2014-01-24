namespace Gst.Plugins
{
    /// <summary>
    ///     Windows video capture source
    /// </summary>
    public class KsVideoSource : GstElement
    {
        public KsVideoSource()
            : base(GstPlugin.KsVideoSource)
        {
        }

        /// <summary>
        ///     Get / set video capture device index.
        /// </summary>
        public int DeviceIndex
        {
            get { return GetInt32("device-index"); }
            set { Set("device-index", value); }
        }
    }
}