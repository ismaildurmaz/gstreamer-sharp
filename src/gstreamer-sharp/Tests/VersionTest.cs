using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Gst.Tests
{
    [TestFixture]
    class VersionTest
    {
        [Test]
        public void GetVersion()
        {
            Debug.WriteLine(Gst.Version);    
        }
    }
}
