using Gst.Plugins;
using NUnit.Framework;

namespace Gst.Tests
{
    [TestFixture]
    internal class GstObjectTest
    {
        [Test]
        public void NameTest()
        {
            Gstreamer.Init();
            GstElement k = GstElementFactory.FactoryMake(GstPlugin.AutoVideoSink);
            k.Name = "test1";
            Assert.AreEqual(k.Name, "test1");
        }
    }
}