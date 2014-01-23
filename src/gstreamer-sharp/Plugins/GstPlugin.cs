namespace Gst.Plugins
{
    /// <summary>
    /// GstPlugin list.
    /// </summary>
    public enum GstPlugin
    {
        /// <summary>
        /// Muxes audio and video into an avi stream.
        /// </summary>
        AviMux,

        /// <summary>
        /// Write stream to a file.
        /// </summary>
        FileSink,


        /// <summary>
        /// The videotestsrc element is used to produce test video data in a wide variety of formats. The video test data produced can be controlled with the "pattern" property.
        /// </summary>
        VideoTestSource,
        /// <summary>
        /// autovideosink is a video sink that automatically detects an appropriate video sink to use. It does so by scanning the registry for all elements that have “Sink” and “Video” in the class field of their element information, and also have a non-zero autoplugging rank.
        /// </summary>
        AutoVideoSink,


        FileSource,
        /// <summary>
        /// Autoplug and play media from an uri
        /// </summary>
        PlayBin2,
        /// <summary>
        /// Autoplug and play media from an uri
        /// </summary>
        PlayBin,
        /// <summary>
        /// Windows video capture source
        /// </summary>
        KsVideoSource,
        /// <summary>
        /// 1-to-N pipe fitting
        /// </summary>
        Tee,

        /// <summary>
        /// Top-level bin with clocking and bus management functionality.
        /// </summary>
        Pipeline,

        /// <summary>
        /// Write data to a file descriptor
        /// </summary>
        FdSink
    }
}
