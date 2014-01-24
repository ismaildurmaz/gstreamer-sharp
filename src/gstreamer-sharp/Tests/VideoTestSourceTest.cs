using System;
using Gst.Plugins;
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
            //Console.Write(Utils.ExecuteGstInspect());
            var pipeline = new GstPipeline();
            var src = GstElementFactory.FactoryMake("camerabin2");
            //var src = GstElementFactory.FactoryMake("autovideosrc");
            var sink = new GstAutoVideoSink();
            //var filterCaps = src.GetStructure<GstCaps>("filter-caps");
            //PrintLine(filterCaps);
            GstCaps caps = null;//GstCaps.FromVideoXRawRGB(400, 300,35);
            pipeline.AddElement(src);
            pipeline.AddElement(sink);
            Assert.IsTrue(src.LinkFiltered(sink, caps));
            pipeline.Play();


            GMainLoop loop = GMainLoop.Create(false);
            loop.Run();
        }
    }
}