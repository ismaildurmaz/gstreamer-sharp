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

            videoTestSrc.PropertySet("pattern", 0);

            Assert.AreEqual(videoTestSrc.Play(), GstStateChangeReturn.Success);

            var bus = pipeline.GetBus();
            var msg = bus.TimedPopFiltered(0, GstMessageType.Error | GstMessageType.Eos);
        }

        [Test]
        public void Test2()
        {
            Gst.Init();
            var playBin2 = GstElementFactory.FactoryMake(GstBaseFactory.PlayBin2);
            playBin2.PropertySet("uri", "file://c/works/test.wmv");
            Debug.WriteLine(playBin2.PropertyReadString("uri"));
        }
    }
}
