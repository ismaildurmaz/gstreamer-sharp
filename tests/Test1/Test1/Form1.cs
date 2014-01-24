using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gst;
using Gst.Plugins.Base;
using Gst.Plugins.Core;
using Gst.Plugins.Good;

namespace Test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Gstreamer.Init();
            var pipeline = new GstPipeline();
            var videotestsrc = new GstVideoTestSource();
            var autovideosink = new GstAutoVideoSink();
            var ogg = GstElementFactory.FactoryMake("asfmux");
            var queue = GstElementFactory.FactoryMake("queue");
            var queue2 = GstElementFactory.FactoryMake("queue");
            var queue3 = GstElementFactory.FactoryMake("queue");
            var theora = GstElementFactory.FactoryMake("avenc_wmv2");
            var ffmpegcolorspace = GstElementFactory.FactoryMake("videoconvert");
            var fd = new GstFileSink();

            pipeline.AddElements(videotestsrc, ogg, queue, fd, theora, queue2, queue3, ffmpegcolorspace);
            fd.Location = @"c:\work\test.flv";
            videotestsrc.Link(queue);
            queue.Link(ffmpegcolorspace);

            ffmpegcolorspace.Link(theora);

            theora.Link(queue2);
            queue2.Link(ogg);
            ogg.Link(queue3);
            queue3.Link(fd);
            pipeline.AutoClock();
            pipeline.AutoFlushBus = true;
            pipeline.Play();
            
        }
    }
}

