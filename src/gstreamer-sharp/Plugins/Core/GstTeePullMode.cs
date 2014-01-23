namespace Gst.Plugins.Core
{
    /// <summary>
    /// The different ways that tee can behave in pull mode. Never disables pull mode.
    /// </summary>
    public enum GstTeePullMode
    {
        /// <summary>
        /// Never activate in pull mode.
        /// </summary>
        Never,

        /// <summary>
        /// Only one src pad can be active in pull mode.
        /// </summary>
        Single
    }
}
