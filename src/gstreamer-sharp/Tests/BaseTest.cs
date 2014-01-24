using System.Diagnostics;

namespace Gst.Tests
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
            Gstreamer.Init();
        }

        public void PrintLine(object line)
        {
            Debug.WriteLine(line);
        }
    }
}