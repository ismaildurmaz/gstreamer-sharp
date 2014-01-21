using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Gst.Tests
{
    [TestFixture]
    internal class GstObjectTest
    {
        [Test]
        public void NameTest()
        {
            Gst.Init();
            var k = GstElementFactory.FactoryMake(GstBaseFactory.AutoVideoSink);
            k.Name = "test1";
            Assert.AreEqual(k.Name, "test1");
        }
    }
}
