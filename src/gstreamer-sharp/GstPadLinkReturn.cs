namespace Gst
{
    /// <summary>
    ///     Result values from gst_pad_link and friends.
    /// </summary>
    public enum GstPadLinkReturn
    {
        /// <summary>
        ///     Link succeeded.
        /// </summary>
        Ok = 0,

        /// <summary>
        ///     Pads have no common grandparent.
        /// </summary>
        WrongHierarchy = -1,

        /// <summary>
        ///     Pad was already linked.
        /// </summary>
        WasLinked = -2,

        /// <summary>
        ///     Pads have wrong direction.
        /// </summary>
        WrongDirection = -3,

        /// <summary>
        ///     Pads do not have common format.
        /// </summary>
        NoFormat = -4,

        /// <summary>
        ///     Pads cannot cooperate in scheduling.
        /// </summary>
        NoSched = -5,

        /// <summary>
        ///     Refused for some reason.
        /// </summary>
        Refused = -6
    }
}