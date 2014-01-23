using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gst.Plugins.Base;
using Gst.Plugins.Core;
using Gst.Plugins.Good;
using NUnit.Framework;

namespace Gst.Tests
{
    [TestFixture]
    public class GstFileSinkTest : BaseTest
    {
        [Test]
        public void Test1()
        {
            var pipeline = new GstPipeline();
            var videoTest = new GstVideoTestSource();
            var aviMux = new GstAviMux();
            var fileSink = new GstFileSink();
            pipeline.AddElements(videoTest, aviMux, fileSink);
            fileSink.Location = @"c:\work\" + DateTime.Now.ToFileTime() + ".avi";
            PrintLine(videoTest.GetRequestPad("src"));
            PrintLine(videoTest.GetRequestPad("sink"));
            PrintLine(videoTest.GetRequestPad("src%d"));
            PrintLine(videoTest.GetRequestPad("Source"));
            var gtype = new GType(videoTest.Handle);
            PrintLine(gtype.Name);
            PrintLine(videoTest.RequestPad(null, null, null));
            //videoTest.Link(aviMux);
            //aviMux.Link(fileSink);
            //pipeline.Play();
            //GMainLoop.Create(false).Run();
        }
    }
}
