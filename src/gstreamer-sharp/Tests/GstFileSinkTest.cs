using System;
using Gst.Plugins.Base;
using Gst.Plugins.Core;
using Gst.Plugins.Good;
using NUnit.Framework;

namespace Gst.Tests
{
    [TestFixture]
    public class GstFileSinkTest : BaseTest
    {
        [TestCase]
        public void Test1()
        {
            var pipeline = new GstPipeline();
            var videoTest = new GstVideoTestSource();
            var aviMux = new GstAviMux();
            var fileSink = new GstFileSink();
            var fileSink2 = new GstFileSink();
            GstElement demux = GstElementFactory.FactoryMake("avidemux");
            var tee = new GstTee();
            pipeline.AddElements(videoTest, aviMux, fileSink, fileSink2, demux);
            fileSink.Location = @"c:\work\" + DateTime.Now.ToFileTime() + ".avi";
            /*var it = tee.IteratePads();
            while (it.MoveNext())
            {
                PrintLine(it.Current);    
            }
            it.Dispose();
            */

            //videoTest.Link(aviMux);
            //aviMux.Link(fileSink);
            //pipeline.Play();
            //GMainLoop.Create(false).Run();
        }
    }
}