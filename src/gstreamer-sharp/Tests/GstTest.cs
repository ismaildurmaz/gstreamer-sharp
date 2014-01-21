using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Gst.Tests
{
    [TestFixture]
    public class GstTest
    {
        [Test]
        public void Test1()
        {
            Gst.Init();
            var videoTestSrc = GstElementFactory.FactoryMake(GstBaseFactory.VideoTestSource);
            Debug.WriteLine(videoTestSrc.Name);
            var autoVideoSink = GstElementFactory.FactoryMake(GstBaseFactory.AutoVideoSink);

            var pipeline = GstPipeline.Create();

            pipeline.AddElements(videoTestSrc, autoVideoSink);

            Assert.IsTrue(videoTestSrc.Link(autoVideoSink));

            videoTestSrc.PropertySet("pattern", 0, null);

            Assert.AreEqual(videoTestSrc.Play(), GstStateChangeReturn.Success);

            var bus = pipeline.GetBus();
            var msg = bus.TimedPopFiltered(0, GstMessageType.Error | GstMessageType.Eos);
        }

        [Test]
        public void Test2()
        {
            Gst.Init();
            var playBin2 = GstElementFactory.FactoryMake(GstBaseFactory.PlayBin);
            playBin2.PropertySet("uri", "http://docs.gstreamer.com/media/sintel_cropped_multilingual.webm", null);
            IntPtr p = new IntPtr();
            playBin2.PropertyGet("uri", ref p);
            Debug.WriteLine(Utils.StringFromNativeUtf8(p));
        }
    }
}
