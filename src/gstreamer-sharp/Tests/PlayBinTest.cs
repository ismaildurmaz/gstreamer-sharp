using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Gst.Plugins.Base;
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
            p.Play();
            Debug.WriteLine("video count : " + p.VideoStreamCount);
            Debug.WriteLine("audio count : " + p.AudioStreamCount);
            Debug.WriteLine("text count : " + p.TextStreamCount);
            Debug.WriteLine("volume : " + p.Volume);
            Debug.WriteLine("source : " + p.Source.Name);
            Debug.WriteLine("state : " + p.State);
            var mainLoop = GMainLoop.Create(false);
            mainLoop.Run();
        }
    }
}
