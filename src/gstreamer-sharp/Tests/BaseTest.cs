using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst.Tests
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
            Gst.Init();
        }
    }
}
