using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst.Plugins.Good
{
    /// <summary>
    /// Muxes raw or compressed audio and/or video streams into an AVI file.
    /// </summary>
    public class GstAviMux : GstElement
    {
        public GstAviMux() : base(GstPlugin.AviMux)
        {
            
        }

        /// <summary>
        /// Get audio pad.
        /// </summary>
        public GstPad AudioPad
        {
            get { return GetRequestPad("audio_%u"); }
        }

        /// <summary>
        /// Get video pad.
        /// </summary>
        public GstPad VideoPad
        {
            get { return GetRequestPad("video_%u"); }
        }

        /// <summary>
        /// Support for openDML-2.0 (big) AVI files.
        /// Default value: true
        /// </summary>
        public bool BigFile
        {
            get { return GetBool("bigfile"); }
            set{ Set("bigfile", value);}
        }
    }
}
