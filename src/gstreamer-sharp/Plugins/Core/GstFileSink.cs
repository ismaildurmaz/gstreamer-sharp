using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst.Plugins.Core
{
    /// <summary>
    /// Write stream to a file.
    /// </summary>
    public class GstFileSink : GstBaseSink
    {
        public GstFileSink() : base(GstPlugin.FileSink)
        {
            
        }

        /// <summary>
        /// Append to an already existing file.
        /// 
        /// Default value: false
        /// </summary>
        public bool Append
        {
            get { return GetBool("append"); }
            set{Set("append", value);}
        }

        /// <summary>
        /// The buffering mode to use.
        ///
        /// Default value: Default buffering
        /// </summary>
        public GstFileSinkBufferMode BufferMode
        {
            get { return (GstFileSinkBufferMode) GetInt32("buffer-mode"); }
            set { Set("buffer-mode", (int)value); }
        }

        /// <summary>
        /// Size of buffer in number of bytes for line or full buffer-mode.
        /// 
        /// Default value: 65536
        /// </summary>
        public uint BufferSize
        {
            get { return GetUInt32("buffer-size"); }
            set { Set("buffer-size", value); }
        }

        /// <summary>
        /// Location of the file to write.
        /// 
        /// Default value: null
        /// </summary>
        public string Location
        {
            get { return GetString("location"); }
            set { Set("location", value); }
        }
    }
}
