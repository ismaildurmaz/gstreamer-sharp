using System;

namespace Gst.Plugins.Base
{
    /// <summary>
    /// Autoplug and play media from an uri
    /// </summary>
    public class PlayBin2 : GstPipeline
    {
        public PlayBin2() : base(GstPlugin.PlayBin2)
        {
            
        }

        public PlayBin2(Uri uri) : this()
        {
            Uri = uri;
        }

        public PlayBin2(string uri)
            : this()
        {
            Uri = new Uri(uri);
        }

        /// <summary>
        /// Set the next URI that playbin will play. This property can be set from the about-to-finish signal to queue the next media file.
        /// </summary>
        public Uri Uri
        {
            get
            {
                return GetUri("uri");
            }
            set
            {
                Set("uri", value);
            }
        }

        /// <summary>
        /// Control the behaviour of playbin.
        /// 
        /// Default value: Render the video stream | Render the audio stream | Render subtitles | Use software volume
        /// </summary>
        public GstPlayFlags Flags
        {
            get
            {
                return (GstPlayFlags) GetInt32("flags");
            }
            set
            {
                Set("flags", (int)value);
            }
        }

        /// <summary>
        /// Get video stream count
        /// </summary>
        public int VideoStreamCount
        {
            get
            {
                return GetInt32("n-video");
            }
        }

        /// <summary>
        /// Get audio stream count
        /// </summary>
        public int AudioStreamCount
        {
            get
            {
                return GetInt32("n-audio");
            }
        }

        /// <summary>
        /// Get text stream count
        /// </summary>
        public int TextStreamCount
        {
            get
            {
                return GetInt32("n-text");
            }
        }

        /// <summary>
        /// Get or set the current audio stream volume. 1.0 means 100%, 0.0 means mute. This uses a linear volume scale.
        /// 
        /// Allowed values: [0,10]
        /// Default value: 1
        /// </summary>
        public double Volume
        {
            get
            {
                return GetDouble("volume");
            }
            set
            {
                Set("volume", value);
            }
        }

        /// <summary>
        /// Network connection speed in kbps (0 = unknown).
        /// 
        /// Allowed values: &lt;= 4294967
        /// Default value: 0
        /// </summary>
        public uint ConnectionSpeed
        {
            get
            {
                return GetUInt32("connection-speed");
            }
            set
            {
                Set("connection-speed", value);
            }
        }

        /// <summary>
        /// Get or set the currently playing audio stream. By default the first audio stream with data is played.
        /// 
        /// Allowed values: &gt;= -1
        /// Default value: -1
        /// </summary>
        public int CurrentAudio
        {
            get
            {
                return GetInt32("current-audio");
            }
            set
            {
                Set("current-audio", value);
            }
        }

        /// <summary>
        /// Get or set the currently playing subtitle stream. By default the first subtitle stream with data is played.
        /// 
        /// Allowed values: >= -1
        /// Default value: -1
        /// </summary>
        public int CurrentText
        {
            get
            {
                return GetInt32("current-text");
            }
            set
            {
                Set("current-text", value);
            }
        }

        /// <summary>
        /// Get or set the currently playing video stream. By default the first video stream with data is played.
        /// 
        /// Allowed values: >= -1
        /// Default value: -1
        /// </summary>
        public int CurrentVideo
        {
            get
            {
                return GetInt32("current-video");
            }
            set
            {
                Set("current-video", value);
            }
        }

        /// <summary>
        /// Encoding to assume if input subtitles are not in UTF-8 encoding. If not set, the GST_SUBTITLE_ENCODING environment variable will be checked for an encoding to use. If that is not set either, ISO-8859-15 will be assumed.
        /// 
        /// Default value: null
        /// </summary>
        public string SubtitleEncoding
        {
            get
            {
                return GetString("subtitle-encoding");
            }
            set
            {
                Set("subtitle-encoding", value);
            }
        }



        /// <summary>
        /// Set the next subtitle URI that playbin will play. This property can be set from the about-to-finish signal to queue the next subtitle media file.
        /// 
        /// Default value: null
        /// </summary>
        public Uri SubtitleUri
        {
            get
            {
                return GetUri("suburi");
            }
            set
            {
                Set("suburi", value);
            }
        }

        /// <summary>
        /// Mute the audio channel without changing the volume.
        /// 
        /// Default value: false
        /// </summary>
        public bool Mute
        {
            get
            {
                return GetBool("mute");
            }
            set
            {
                Set("mute", value);
            }
        }

        /// <summary>
        /// Pango font description of font to be used for subtitle rendering.
        /// 
        /// Default value: null
        /// </summary>
        public string SubtitleFontDescription
        {
            set
            {
                Set("subtitle-font-desc", value);
            }
        }

        /// <summary>
        /// The video output element to use (null = default sink).
        /// </summary>
        public GstElement VideoSink
        {
            get
            {
                return GetStructure<GstElement>("video-sink");
            }
            set
            {
                Set("video-sink", value);
            }
        }

        /// <summary>
        /// The audio output element to use (null = default sink).
        /// </summary>
        public GstElement AudioSink
        {
            get
            {
                return GetStructure<GstElement>("audio-sink");
            }
            set
            {
                Set("audio-sink", value);
            }
        }

        /// <summary>
        /// The text output element to use (null = default textoverlay).
        /// </summary>
        public GstElement TextSink
        {
            get
            {
                return GetStructure<GstElement>("text-sink");
            }
            set
            {
                Set("text-sink", value);
            }
        }

        /// <summary>
        /// The subpicture output element to use (null = default dvdspu).
        /// </summary>
        public GstElement SubPictureSink
        {
            get
            {
                return GetStructure<GstElement>("subpic-sink");
            }
            set
            {
                Set("subpic-sink", value);
            }
        }

        /// <summary>
        /// The visualization element to use (null = default).
        /// </summary>
        public GstElement VisualizationPlugin
        {
            get
            {
                return GetStructure<GstElement>("vis-plugin");
            }
            set
            {
                Set("vis-plugin", value);
            }
        }

        /// <summary>
        /// Control the synchronisation offset between the audio and video streams. Positive values make the audio ahead of the video and negative values make the audio go behind the video.
        /// 
        /// Since 0.10.30
        /// </summary>
        public Int64 AvOffset
        {
            get { return GetInt64("av-offset"); }
            set{ Set("av-offset", value);}
        }

        /// <summary>
        /// Buffer size when buffering network streams.
        /// 
        /// Allowed values: >= -1
        /// Default value: -1
        /// </summary>
        public Int32 BufferSize
        {
            get { return GetInt32("buffer-size"); }
            set { Set("buffer-size", value); }
        }

        /// <summary>
        /// Buffer duration when buffering network streams.
        /// 
        /// Allowed values: >= -1
        /// Default value: -1
        /// </summary>
        public Int64 BufferDuration
        {
            get { return GetInt64("buffer-duration"); }
            set { Set("buffer-duration", value); }
        }

        /// <summary>
        /// Max. amount of data in the ring buffer (bytes, 0 = ring buffer disabled).
        /// 
        /// Allowed values: &lt;= max uint
        /// Default value: 0
        /// </summary>
        public UInt64 RingBufferMaxSize
        {
            get { return GetUInt64("ring-buffer-max-size"); }
            set { Set("ring-buffer-max-size", value); }
        }

        /// <summary>
        /// Get the currently rendered or prerolled frame in the video sink. The GstCaps on the buffer will describe the format of the buffer.
        /// </summary>
        public GstBuffer Frame
        {
            get { return GetStructure<GstBuffer>("frame"); }
            set{ Set("frame", value);}
        }

        /// <summary>
        /// Source element.
        /// </summary>
        public GstElement Source
        {
            get
            {
                return GetStructure<GstElement>("source");
            }
        }
    }
}
