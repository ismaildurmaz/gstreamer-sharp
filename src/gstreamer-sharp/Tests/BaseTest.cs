using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void PrintLine(object line)
        {
            Debug.WriteLine(line);
        }
    }
}
