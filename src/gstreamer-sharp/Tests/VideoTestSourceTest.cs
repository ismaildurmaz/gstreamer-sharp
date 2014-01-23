using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Gst.Plugins.Base;
using Gst.Plugins.Good;
using NUnit.Framework;

namespace Gst.Tests
{
    [TestFixture]
    public class VideoTestSourceTest : BaseTest
    {
        [Test]
        public void Test1()
        {
            var pipeline = new GstPipeline();
            var src = new GstVideoTestSource();
            var sink = new GstAutoVideoSink();
            
            pipeline.AddElement(src);
            pipeline.AddElement(sink);
            src.Link(sink);
            pipeline.Play();
            

            var loop = GMainLoop.Create(false);
            loop.Run();
        }
    }
}
