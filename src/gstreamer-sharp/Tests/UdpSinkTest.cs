using Gst.Plugins.Base;
using Gst.Plugins.Good;
using NUnit.Framework;

namespace Gst.Tests
{
    [TestFixture]
    internal class UdpSinkTest : BaseTest
    {
        [Test]
        public void Test1()
        {
            var pipeline = new GstPipeline();
            var src = new GstVideoTestSource();
            var udp = new GstUDPSink();
            pipeline.AddElements(src, udp);
            src.Link(udp);
            pipeline.Play();
            GMainLoop.Create(false).Run();
        }
    }
}