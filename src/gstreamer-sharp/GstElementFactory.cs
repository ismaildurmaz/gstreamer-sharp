using System;
using System.Runtime.InteropServices;
using Gst.Plugins;

namespace Gst
{
    public class GstElementFactory : GstPluginFeature
    {
        #region wrappers

        [DllImport(Library.Libgstreamer, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr gst_element_factory_make(string factoryName, string name);

        #endregion

        internal GstElementFactory(IntPtr handle) : base(handle)
        {
        }

        public static GstElement FactoryMake(string factoryName, string name)
        {
            return new GstElement(gst_element_factory_make(factoryName, name));
        }

        public static GstElement FactoryMake(string factoryName)
        {
            return FactoryMake(factoryName, Gstreamer.GenerateName(factoryName));
        }

        public static GstElement FactoryMake(GstPlugin plugin)
        {
            return FactoryMake(Utils.GetName(plugin));
        }

        public static GstElement FactoryMake(GstPlugin plugin, string name)
        {
            return FactoryMake(Utils.GetName(plugin), name);
        }
    }
}