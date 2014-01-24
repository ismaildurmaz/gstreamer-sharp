using System.Diagnostics;
using NUnit.Framework;

namespace Gst.Tests
{
    [TestFixture]
    internal class VersionTest
    {
        [Test]
        public void GetVersion()
        {
            Debug.WriteLine(Gstreamer.Version);
        }
    }
}