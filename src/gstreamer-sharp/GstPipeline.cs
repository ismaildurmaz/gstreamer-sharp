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
    }
}
