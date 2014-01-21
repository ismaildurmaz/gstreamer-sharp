using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    [Flags]
    public enum GstPlayFlags
    {
        Video = (1 << 0),
        Audio = (1 << 1),
        Text = (1 << 2),
        Vis = (1 << 3),
        SoftVolume = (1 << 4),
        NativeAudio = (1 << 5),
        NativeVideo = (1 << 6),
        Download = (1 << 7),
        Buffering = (1 << 8),
        Deinterlace = (1 << 9),
        SoftColorbalance = (1 << 10)
    }
}
