using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst.Elements
{
    /// <summary>
    /// Windows video capture source
    /// </summary>
    public class KsVideoSource : GstElement
    {
        internal KsVideoSource() : base(GstElementFactory.FactoryMake(GstBaseFactory.KsVideoSource))
        {
        }

        /// <summary>
        /// Get / set video capture device index.
        /// </summary>
        public int DeviceIndex
        {
            get { return GetInt32("device-index"); }
            set { Set("device-index", value);}
        }
    }
}
