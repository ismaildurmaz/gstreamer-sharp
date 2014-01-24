namespace Gst
{
    internal static class Library
    {
#if GSTREAMER_0_10
        internal const string Libgstreamer = "libgstreamer-0.10-0.dll";

        internal const string Libgobject = "libgobject-2.0-0.dll";

        internal const string Libglib = "libglib-2.0-0.dll";
#endif

#if GSTREAMER_1_0
        internal const string Libgstreamer = @"libgstreamer-1.0-0.dll";

        internal const string Libgobject = @"libgobject-2.0-0.dll";

        internal const string Libglib = @"libglib-2.0-0.dll";
#endif
    }
}