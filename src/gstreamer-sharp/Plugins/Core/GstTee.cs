namespace Gst.Plugins.Core
{
    /// <summary>
    /// 1-to-N pipe fitting
    /// </summary>
    public class GstTee : GstElement
    {
        public GstTee()
            : base(GstPlugin.Tee)
        {
        }

        /// <summary>
        /// The pad allocation queries will be proxied to (unused).
        /// </summary>
        public GstPad AllocPad
        {
            get { return GetStructure<GstPad>("alloc-pad"); }
            set
            {
                Set("alloc-pad", value);
            }
        }

        /// <summary>
        /// Get request src%d pad.
        /// </summary>
        /// <returns>Returns src% pad</returns>
        public GstPad GetRequestSourcePad()
        {
            return GetRequestPad("src%d");
        }

        /// <summary>
        /// If the element can operate in push mode.
        /// 
        /// Default value: true
        /// </summary>
        public bool HasChain
        {
            get { return GetBool("has-chain"); }
            set{ Set("has-chain", value);}
        }

        /// <summary>
        /// The message describing current status.
        /// 
        /// Default value: null
        /// </summary>
        public string LastMessage
        {
            get { return GetString("last-message"); }
        }

        /// <summary>
        /// The number of source pads.
        /// 
        /// Allowed values: >= 0
        /// Default value: 0
        /// </summary>
        public int SourcePadCount
        {
            get { return GetInt32("num-src-pads"); }
        }

        /// <summary>
        /// Behavior of tee in pull mode.
        /// 
        /// Default value: Never activate in pull mode
        /// </summary>
        public GstTeePullMode PullMode
        {
            get { return (GstTeePullMode) GetInt32("pull-mode"); }
            set { Set("pull-mode", (int) value);}
        }

        /// <summary>
        /// Don't produce last_message events.
        /// 
        /// Default value: true
        /// </summary>
        public bool Silent
        {
            get { return GetBool("silent"); }
            set { Set("silent", value); }
        }
    }
}
