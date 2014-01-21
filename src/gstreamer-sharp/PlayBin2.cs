using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    /// <summary>
    /// Autoplug and play media from an uri
    /// </summary>
    public class PlayBin2 : GstPipeline
    {
        public PlayBin2() : base(GstElementFactory.FactoryMake(GstBaseFactory.PlayBin2).Handle)
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
    }
}
