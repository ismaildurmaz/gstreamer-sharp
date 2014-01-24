namespace Gst.Plugins.Good
{
    public class GstUDPSink : GstMultiUDPSink
    {
        public GstUDPSink()
            : base(GstPlugin.UdpSink)
        {
        }


        /// <summary>
        ///     The host/IP/Multicast group to send the packets to.
        ///     Default value: "localhost"
        /// </summary>
        public string Host
        {
            get { return GetString("host"); }
            set { Set("host", value); }
        }

        /// <summary>
        ///     The port to send the packets to.
        ///     Default value: 5004
        /// </summary>
        public int Port
        {
            get { return GetInt32("port"); }
            set { Set("port", value); }
        }
    }
}