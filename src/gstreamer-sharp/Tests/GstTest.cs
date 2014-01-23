﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using Gst.Plugins;
using Gst.Plugins.Base;
using Gst.Plugins.Core;
using Gst.Plugins.Good;
using NUnit.Framework;

namespace Gst.Tests
{
    [TestFixture]
    public class GstTest : BaseTest
    {
        [Test]
        public void Test1()
        {
            var videoTestSrc = GstElementFactory.FactoryMake(GstPlugin.VideoTestSource);
            Debug.WriteLine(videoTestSrc.Name);
            var autoVideoSink = GstElementFactory.FactoryMake(GstPlugin.AutoVideoSink);

            var pipeline = new GstPipeline();

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
            var playBin2 = GstElementFactory.FactoryMake(GstPlugin.PlayBin2);
            playBin2.Set("uri", "file://c/work/test.wmv");
            playBin2.Play();
            Debug.WriteLine(playBin2.GetString("uri"));
            GMainLoop.Create(false).Run();
        }

        [Test]
        public void KsVideoTestSrc()
        {
            var pipeline = new GstPipeline();
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

        [Test]
        public void Test3()
        {
            var src = new GstVideoTestSource();
            var tee = new GstTee();
            var sink1 = new GstAutoVideoSink();
            var sink2 = new GstFileSink();

            var pipeline = new GstPipeline();
            //pipeline.AddElements(src, tee, sink1, sink2);
            pipeline.AddElements(src, tee, sink1, sink2);

            var teePad1 = tee.GetRequestSourcePad();
            var teePad2 = tee.GetRequestSourcePad();
            src.Link(tee);
            var sink1Pad = sink1.GetCompatiblePad(teePad1, null);
            sink2.Location = @"c:\work\test" + DateTime.Now.ToFileTime() + ".avi";
            var sink2Pad = sink2.GetCompatiblePad(teePad2, null);
            teePad1.Link(sink1Pad);
            teePad2.Link(sink2Pad);
            tee.ReleaseRequestPads(teePad1,teePad2);
            
            //teePad2.Link(sink2Pad);
            //var pad1 = tee.GetRequestPad("src%d");
            //tee.ReleaseRequestPad(pad1);
            //tee.Link(sink2);
            
            
            pipeline.AutoClock();
            pipeline.AutoFlushBus = true;
            pipeline.Play();
            GMainLoop.Create(false).Run();
        }
    }
}
