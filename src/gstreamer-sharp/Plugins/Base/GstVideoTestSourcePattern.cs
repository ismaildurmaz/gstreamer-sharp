namespace Gst.Plugins.Base
{
    /// <summary>
    ///     The test pattern to produce.
    ///     The Gamut pattern creates a checkerboard pattern of colors at the edge of the YCbCr gamut and nearby colors that
    ///     are out of gamut. The pattern is divided into 4 regions: black, white, red, and blue. After conversion to RGB, the
    ///     out-of-gamut colors should be converted to the same value as their in-gamut neighbors. If the checkerboard pattern
    ///     is still visible after conversion, this indicates a faulty conversion. Image manipulation, such as adjusting
    ///     contrast or brightness, can also cause the pattern to be visible.
    ///     The Zone Plate pattern is based on BBC R&D Report 1978/23, and can be used to test spatial frequency response of a
    ///     system. This pattern generator is controlled by the xoffset and yoffset parameters and also by all the parameters
    ///     starting with 'k'. The default parameters produce a grey pattern. Try 'videotestsrc pattern=zone-plate kx2=20
    ///     ky2=20 kt=1' to produce something interesting.
    /// </summary>
    public enum GstVideoTestSourcePattern
    {
        /// <summary>
        ///     A standard SMPTE test pattern
        /// </summary>
        Smtpe,

        /// <summary>
        ///     Random noise
        /// </summary>
        Snow,

        /// <summary>
        ///     A black image
        /// </summary>
        Black,

        /// <summary>
        ///     A white image
        /// </summary>
        White,

        /// <summary>
        ///     A red image
        /// </summary>
        Red,

        /// <summary>
        ///     A green image
        /// </summary>
        Green,

        /// <summary>
        ///     A blue image
        /// </summary>
        Blue,

        /// <summary>
        ///     Checkers pattern (1px)
        /// </summary>
        Checkers1,

        /// <summary>
        ///     Checkers pattern (2px)
        /// </summary>
        Checkers2,

        /// <summary>
        ///     Checkers pattern (4px)
        /// </summary>
        Checkers4,

        /// <summary>
        ///     Checkers pattern (8px)
        /// </summary>
        Checkers8,

        /// <summary>
        ///     Circular pattern
        /// </summary>
        Circular,

        /// <summary>
        ///     Alternate between black and white
        /// </summary>
        Blink,

        /// <summary>
        ///     SMPTE test pattern (75% color bars)
        /// </summary>
        Smpte75,

        /// <summary>
        ///     Zone plate
        /// </summary>
        ZonePlate,

        /// <summary>
        ///     Gamut checking pattern
        /// </summary>
        Gamut,

        /// <summary>
        ///     Chroma zone plate
        /// </summary>
        ChromaZonePlate,
        Solid,

        /// <summary>
        ///     Moving ball
        /// </summary>
        Ball,

        /// <summary>
        ///     SMPTE test pattern (100% color bars)
        /// </summary>
        Smpte100,

        /// <summary>
        ///     Bar with foreground color
        /// </summary>
        Bar,

        /// <summary>
        ///     Pinwheel
        /// </summary>
        Pinwheel,

        /// <summary>
        ///     Spokes
        /// </summary>
        Spokes
    }
}