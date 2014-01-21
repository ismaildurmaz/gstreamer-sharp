using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using NUnit.Framework;

namespace Gst.Tests
{
    [TestFixture]
    public class PlayBinTest : BaseTest
    {

        [Test]
        public void Test1()
        {
            /*
            IntPtr ptr = Win32.CreateConsoleScreenBuffer(0, 0x00000001, IntPtr.Zero, 1, 0);
            Int32 err = Marshal.GetLastWin32Error();
            if (err != 0)
            {
                Debug.WriteLine("Error: " + err);
                throw new System.ComponentModel.Win32Exception(err);
            }
            Win32.SetConsoleActiveScreenBuffer(ptr);
        */

        var p = new PlayBin2();
            p.Uri = new Uri("file://c/work/test.wmv");
            var flags = p.Flags;
            flags |= GstPlayFlags.Video | GstPlayFlags.Audio;
            flags &= ~GstPlayFlags.Text;
            p.Flags = flags;
            /*var gio = GIOChannel.CreateFromStandardInput();
            gio.AddWatch(GIOCondition.In, delegate(IntPtr source, GIOCondition condition, IntPtr data)
            {
                string line;
                if (gio.ReadLine(out line) == GIOStatus.Success)
                {
                    Debug.WriteLine(line);
                }
            }, IntPtr.Zero);*/
            p.Play();
            Debug.WriteLine("video count : " + p.VideoStreamCount);
            Debug.WriteLine("audio count : " + p.AudioStreamCount);
            Debug.WriteLine("text count : " + p.TextStreamCount);
            Debug.WriteLine("volume : " + p.Volume);
            var mainLoop = GMainLoop.Create(false);
            mainLoop.Run();
        }
    }
}
