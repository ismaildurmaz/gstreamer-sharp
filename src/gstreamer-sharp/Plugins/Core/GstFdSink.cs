using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst.Plugins.Core
{
    /// <summary>
    /// Write data to a file descriptor.
    /// </summary>
    public class GstFdSink : GstBaseSink
    {
        public GstFdSink() : base(GstPlugin.FdSink)
        {
            
        }

        /// <summary>
        /// Open the sink file to write.
        /// </summary>
        /// <param name="fileName">The file path.</param>
        /// <param name="openFileStyle">File open style.</param>
        public void OpenFile(string fileName, Win32.OpenFileStyle openFileStyle)
        {
            Win32.Ofstruct ofstruct;
            Fd = Win32.OpenFile(fileName, out ofstruct, openFileStyle);

        }

        /// <summary>
        /// An open file descriptor to write to.
        /// 
        /// Allowed values: >= 0
        /// Default value: 1
        /// </summary>
        public int Fd
        {
            get { return GetInt32("fd"); }
            set{ Set("fd", value);}
        }
    }
}
