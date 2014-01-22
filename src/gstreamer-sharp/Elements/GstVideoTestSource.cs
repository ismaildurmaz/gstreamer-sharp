using System;
using System.ComponentModel;
using System.Drawing;

namespace Gst.Elements
{
    /// <summary>
    /// The videotestsrc element is used to produce test video data in a wide variety of formats. The video test data produced can be controlled with the "pattern" property.
    /// </summary>
    public class GstVideoTestSource : GstPushSrc
    {
        public GstVideoTestSource() : base(GstElementFactory.FactoryMake(GstBaseFactory.VideoTestSource).Handle)
        {
            
        }

        /// <summary>
        /// Type of test pattern to generate.
        /// 
        /// Default value: SMPTE 100% color bars
        /// </summary>
        public GstVideoTestSourcePattern Pattern
        {
            get { return (GstVideoTestSourcePattern) GetInt32("pattern"); }
            set
            {
                Set("pattern", (int) value);
            }
        }

        /// <summary>
        /// An offset added to timestamps set on buffers (in ns).
        /// 
        /// Default value: 0
        /// </summary>
        public Int64 TimestampOffset
        {
            get
            {
                return GetInt64("timestamp-offset");
            }
            set
            {
                Set("timestamp-offset", value);
            }
        }

        /// <summary>
        /// Whether to act as a live source.
        /// 
        /// Default value: false
        /// </summary>
        public bool IsAlive
        {
            get { return GetBool("is-live"); }
            set
            {
                Set("is-live", value);
            }
        }

        /// <summary>
        /// Ask the peer to allocate an output buffer.
        /// 
        /// Default value: true
        /// </summary>
        public bool PeerAlloc
        {
            get
            {
                return GetBool("peer-alloc");
            }
            set
            {
                Set("peer-alloc", value);
            }
        }

        /// <summary>
        /// Generate video in the given color specification (Deprecated: use a caps filter with video/x-raw-yuv,color-matrix="sdtv" or "hdtv" instead).
        /// 
        /// Default value: ITU-R Rec. BT.601
        /// </summary>
        public GstVideoTestSourceColorSpec ColorSpec
        {
            get { return (GstVideoTestSourceColorSpec) GetInt32("colorspec"); }
            set{ Set("colorspec", (int)value);}
        }

        /// <summary>
        /// Zoneplate zero order phase, for generating plain fields or phase offsets.
        /// 
        /// Default value: 0
        /// </summary>
        public int K0
        {
            get { return GetInt32("k0"); }
            set{ Set("k0", value);}
        }

        /// <summary>
        /// Zoneplate 1st order t phase, for generating phase rotation as a function of time.
        /// 
        /// Default value: 0
        /// </summary>
        public int Kt
        {
            get { return GetInt32("kt"); }
            set { Set("kt", value); }
        }

        /// <summary>
        /// Zoneplate 2nd order t phase, t*t/256 cycles per picture.
        /// 
        /// Default value: 0
        /// </summary>
        public int Kt2
        {
            get { return GetInt32("kt2"); }
            set { Set("kt2", value); }
        }

        /// <summary>
        /// Zoneplate 1st order x phase, for generating constant horizontal frequencies.
        /// 
        /// Default value: 0
        /// </summary>
        public int Kx
        {
            get { return GetInt32("kx"); }
            set { Set("kx", value); }
        }

        /// <summary>
        /// Zoneplate 2nd order x phase, normalised to kx2/256 cycles per horizontal pixel at width/2 from origin.
        /// 
        /// Default value: 0
        /// </summary>
        public int Kx2
        {
            get { return GetInt32("kx2"); }
            set { Set("kx2", value); }
        }

        /// <summary>
        /// Zoneplate x*t product phase, normalised to kxy/256 cycles per vertical pixel at width/2 from origin.
        /// 
        /// Default value: 0
        /// </summary>
        public int Kxt
        {
            get { return GetInt32("kxt"); }
            set { Set("kxt", value); }
        }

        /// <summary>
        /// Zoneplate x*y product phase.
        /// 
        /// Default value: 0
        /// </summary>
        public int Kxy
        {
            get { return GetInt32("kxy"); }
            set { Set("kxy", value); }
        }

        /// <summary>
        /// Zoneplate 1st order y phase, for generating contant vertical frequencies.
        /// 
        /// Default value: 0
        /// </summary>
        public int Ky
        {
            get { return GetInt32("ky"); }
            set { Set("ky", value); }
        }

        /// <summary>
        /// Zoneplate 2nd order y phase, normailsed to ky2/256 cycles per vertical pixel at height/2 from origin.
        /// 
        /// Default value: 0
        /// </summary>
        public int Ky2
        {
            get { return GetInt32("ky2"); }
            set { Set("ky2", value); }
        }

        /// <summary>
        /// Zoneplate y*t product phase.
        /// 
        /// Default value: 0
        /// </summary>
        public int Kyt
        {
            get { return GetInt32("kyt"); }
            set { Set("kyt", value); }
        }

        /// <summary>
        /// Zoneplate 2nd order products x offset.
        /// 
        /// Default value: 0
        /// </summary>
        public int XOffset
        {
            get { return GetInt32("xoffset"); }
            set { Set("xoffset", value); }
        }

        /// <summary>
        /// Zoneplate 2nd order products y offset.
        /// 
        /// Default value: 0
        /// </summary>
        public int YOffset
        {
            get { return GetInt32("yoffset"); }
            set { Set("yoffset", value); }
        }

        /// <summary>
        /// Color to use for background color of some patterns. Default is black (0xff000000).
        /// 
        /// Default value: 4278190080
        /// </summary>
        public Color BackgroundColor
        {
            get { return GetColor("background-color"); }
            set { Set("background-color", value); }
        }

        /// <summary>
        /// Color to use for solid-color pattern and foreground color of other patterns. Default is white (0xffffffff).
        /// 
        /// Default value: 4294967295
        /// </summary>
        public Color ForegroundColor
        {
            get { return GetColor("foreground-color"); }
            set { Set("foreground-color", value); }
        }

        /// <summary>
        /// Scroll image number of pixels per frame (positive is scroll to the left).
        /// 
        /// Default value: 0
        /// </summary>
        public int HorizontalSpeed
        {
            get { return GetInt32("horizontal-speed"); }
            set { Set("horizontal-speed", value); }
        }
    }
}
