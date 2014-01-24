namespace Gst
{
    public enum GstIteratorResult
    {
        /// <summary>
        ///     No more items in the iterator.
        /// </summary>
        Done = 0,

        /// <summary>
        ///     An item was retrieved.
        /// </summary>
        Ok = 1,

        /// <summary>
        ///     Datastructure changed while iterating.
        /// </summary>
        ReSync = 2,

        /// <summary>
        ///     An error happened.
        /// </summary>
        Error = 3
    }
}