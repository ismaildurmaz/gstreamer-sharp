using System;

namespace Gst
{
    public static class Delegates
    {
        public delegate void GIOFunction(IntPtr source, GIOCondition condition, IntPtr userData);

        public delegate void GstIteratorForeachFunction(IntPtr gValue, IntPtr userData);
    }
}