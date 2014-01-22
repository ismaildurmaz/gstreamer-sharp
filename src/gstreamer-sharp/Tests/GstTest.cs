using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Gst.Elements;
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

            videoTestSrc.Link(autoVideoSink);

            videoTestSrc.Set("pattern", 0);

            //Assert.AreEqual(videoTestSrc.Play(), GstStateChangeReturn.Success);

            var bus = pipeline.Bus;
            var msg = bus.TimedPopFiltered(0, GstMessageType.Error | GstMessageType.Eos);
        }

        [Test]
        public void Test2()
        {
            var playBin2 = GstElementFactory.FactoryMake(GstBaseFactory.PlayBin2);
            playBin2.Set("uri", "file://c/work/test.wmv");
            playBin2.Play();
            Debug.WriteLine(playBin2.GetString("uri"));
            GMainLoop.Create(false).Run();
        }

        [Test]
        public void KsVideoTestSrc()
        {
            var pipeline = GstPipeline.Create();
            pipeline.AutoClock();
            pipeline.AutoFlushBus = true;
            //GstSystemClock.Instance.ClockType = GstClockType.Realtime;
            //pipeline.Clock = GstSystemClock.Instance;
            
            Debug.WriteLine(GstSystemClock.Instance.ClockType);
            var src = new KsVideoSource();
            var sink = new GstAutoVideoSink();
            pipeline.AddElement(src);
            pipeline.AddElement(sink);
            src.DeviceIndex = 1;
            var result = sink.IterateSourcePads().Foreach(delegate(IntPtr value, IntPtr data)
            {
                var p = new GValue(value);
                Debug.WriteLine(p.Contents);
            }, IntPtr.Zero);
            Debug.WriteLine(result);

            result = sink.IterateSinkPads().Foreach(delegate(IntPtr value, IntPtr data)
            {
                var p = new GValue(value);
                Debug.WriteLine(p.TypeName);
            }, IntPtr.Zero);
            Debug.WriteLine(result);
            //src.CreateAllPads();
            //sink.CreateAllPads();
            src.Link(sink);
            
            pipeline.Play();
            //var loop = GMainLoop.Create(false);
            //loop.Run();
        }
    }
}
