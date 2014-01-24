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
            var pipeline = new GstPipeline();
            var src = new KsVideoSource();
            //var src = GstElementFactory.FactoryMake("autovideosrc");
            var sink = new GstAutoVideoSink();
            //var filterCaps = src.GetStructure<GstCaps>("filter-caps");
            //PrintLine(filterCaps);
            var caps = GstCaps.FromVideoXRaw(VideoXRawFormat.YUY2, 29, 40, 4);
            pipeline.AddElement(src);
            pipeline.AddElement(sink);
            Assert.IsTrue(src.LinkFiltered(sink, caps));
            pipeline.Play();


            GMainLoop loop = GMainLoop.Create(false);
            loop.Run();
        }
    }
}