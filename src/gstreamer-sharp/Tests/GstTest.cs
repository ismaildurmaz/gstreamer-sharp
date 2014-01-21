using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Gst.Tests
{
    [TestFixture]
    public class GstTest : BaseTest
    {
        [Test]
        public void Test1()
        {
            var videoTestSrc = GstElementFactory.FactoryMake(GstBaseFactory.VideoTestSource);
            Debug.WriteLine(videoTestSrc.Name);
            var autoVideoSink = GstElementFactory.FactoryMake(GstBaseFactory.AutoVideoSink);

            var pipeline = GstPipeline.Create();

            pipeline.AddElements(videoTestSrc, autoVideoSink);

            Assert.IsTrue(videoTestSrc.Link(autoVideoSink));

            videoTestSrc.Set("pattern", 0);

            //Assert.AreEqual(videoTestSrc.Play(), GstStateChangeReturn.Success);

            var bus = pipeline.GetBus();
            var msg = bus.TimedPopFiltered(0, GstMessageType.Error | GstMessageType.Eos);
        }

        [Test]
        public void Test2()
        {
            var playBin2 = GstElementFactory.FactoryMake(GstBaseFactory.PlayBin2);
            playBin2.Set("uri", "file://c/work/test.wmv");
            playBin2.Play();
            Debug.WriteLine(playBin2.GetString("uri"));
        }
    }
}
