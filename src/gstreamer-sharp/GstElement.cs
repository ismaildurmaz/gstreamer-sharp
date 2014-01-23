using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Gst.Plugins;

namespace Gst
{
    public class GstElement : GstObject
    {
        #region wrappers
        [DllImport(Library.Libgstreamer)]
        private static extern bool gst_element_link(IntPtr sourceElement, IntPtr destinationElement);


        [DllImport(Library.Libgstreamer)]
        private static extern GstStateChangeReturn gst_element_set_state(IntPtr element, GstState state);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_element_get_bus(IntPtr element);

        [DllImport(Library.Libgstreamer)]
        private static extern void gst_element_set_bus(IntPtr element, IntPtr bus);

        [DllImport(Library.Libgstreamer)]
        private static extern bool gst_element_requires_clock(IntPtr element);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_element_get_clock(IntPtr element);

        [DllImport(Library.Libgstreamer)]
        private static extern bool gst_element_set_clock(IntPtr element, IntPtr clock);

        [DllImport(Library.Libgstreamer)]
        private static extern bool gst_element_provides_clock(IntPtr element);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_element_provide_clock(IntPtr element);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_element_create_all_pads(IntPtr element);

        [DllImport(Library.Libgstreamer)]
        private static extern GstStateChangeReturn gst_element_get_state(IntPtr element,out IntPtr state,ref IntPtr pending, UInt64 timeout);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_element_iterate_pads(IntPtr element);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_element_iterate_src_pads(IntPtr element);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_element_iterate_sink_pads(IntPtr element);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_element_request_pad(IntPtr element, IntPtr template, string name, IntPtr caps);

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_element_get_request_pad(IntPtr element, string name);

        [DllImport(Library.Libgstreamer)]
        private static extern void gst_element_release_request_pad(IntPtr element, IntPtr pad);

        [DllImport(Library.Libgstreamer)]
        private static extern bool gst_element_link_pads(IntPtr element, string srcPadName, IntPtr destination, string dstPadName );

        [DllImport(Library.Libgstreamer)]
        private static extern IntPtr gst_element_get_compatible_pad(IntPtr element, IntPtr gstPad, IntPtr gstCaps);

        #endregion

        internal GstElement(IntPtr handle)
            : base(handle)
        {
        }

        internal GstElement(HandleObject handleObject)
            : base(handleObject)
        {
        }

        internal GstElement(GstPlugin plugin)
            : base(plugin)
        {

        }

        internal GstElement(GstPlugin plugin, string name)
            : base(plugin, name)
        {
        }


        /// <summary>
        /// Link element with destinationElement
        /// </summary>
        /// <param name="destinationElement"></param>
        /// <returns></returns>
        public void Link(GstElement destinationElement)
        {
            if (!gst_element_link(Handle, Utils.GetHandle(destinationElement)))
            {
                throw new Exception("Cannot link elements");
            }
        }

        /// <summary>
        /// Set state to playing
        /// </summary>
        public void Play()
        {
            State = GstState.Playing;
        }

        /// <summary>
        /// Get/set state of the element
        /// </summary>
        public GstState State
        {
            get
            {
                IntPtr ptr = new IntPtr();
                IntPtr ptr2 = new IntPtr();
                var result = gst_element_get_state(Handle, out ptr, ref ptr2, 0);
                if (result == GstStateChangeReturn.Failure)
                {
                    throw new Exception("Cannot get state of the element");
                }
                return (GstState) ptr.ToInt32();
            }
            set
            {
                var result = gst_element_set_state(Handle, value);
                if (result == GstStateChangeReturn.Failure)
                {
                    throw new Exception("Cannot change state to " + value);
                }
            }
        }

        /// <summary>
        /// Creates a pad for each pad template that is always available. This function is only useful during object initialization of subclasses of GstElement.
        /// </summary>
        public void CreateAllPads()
        {
            gst_element_create_all_pads(Handle);
        }

        /// <summary>
        /// Set state to paused
        /// </summary>
        public void Pause()
        {
            State = GstState.Paused;
        }

        /// <summary>
        /// The bus of the element. Note that only a GstPipeline will provide a bus for the application.
        /// </summary>
        public GstBus Bus
        {
            get
            {
                return Utils.HandleObject<GstBus>(gst_element_get_bus(Handle));
            }
            set
            {
                gst_element_set_bus(Handle, value.Handle);
            }
        }

        /// <summary>
        /// Query if the element requires a clock.
        /// </summary>
        public bool RequiresClock
        {
            get
            {
                return gst_element_requires_clock(Handle);
            }
        }

        /// <summary>
        /// Gets / sets the currently configured clock of the element.
        /// </summary>
        public GstClock Clock
        {
            get
            {
                return Utils.HandleObject<GstClock>(gst_element_get_clock(Handle));
            }
            set
            {
                if (!gst_element_set_clock(Handle, Utils.GetHandle(value)))
                {
                    throw new Exception("Cannot set the clock");
                }
            }
        }

        /// <summary>
        /// Query if the element provides a clock. 
        /// A GstClock provided by an element can be used as the global GstClock for the pipeline. 
        /// An element that can provide a clock is only required to do so in the PAUSED state, 
        /// this means when it is fully negotiated and has allocated the resources to operate the clock.
        /// </summary>
        public bool ProvidesClock
        {
            get
            {
                return gst_element_provides_clock(Handle);
            }
        }

        /// <summary>
        /// Get the clock provided by the given element.
        /// </summary>
        public GstClock ProvideClock
        {
            get
            {
                return Utils.HandleObject<GstClock>(gst_element_provide_clock(Handle));
            }
        }

        /// <summary>
        /// Retrieves an iterator of element's pads. The iterator should be freed after usage.
        /// </summary>
        /// <returns></returns>
        public GstIterator IteratePads()
        {
            return Utils.HandleObject<GstIterator>(gst_element_iterate_pads(Handle));
        }

        /// <summary>
        /// Retrieves an iterator of element's source pads.
        /// </summary>
        /// <returns></returns>
        public GstIterator IterateSourcePads()
        {
            return Utils.HandleObject<GstIterator>(gst_element_iterate_src_pads(Handle));
        }

        /// <summary>
        /// Retrieves an iterator of element's sink pads.
        /// </summary>
        /// <returns></returns>
        public GstIterator IterateSinkPads()
        {
            return Utils.HandleObject<GstIterator>(gst_element_iterate_sink_pads(Handle));
        }

        /// <summary>
        /// Retrieves a request pad from the element according to the provided template. Pad templates can be looked up using get static pad templates
        /// </summary>
        /// <param name="padTemplate">A GstPadTemplate of which we want a pad of.</param>
        /// <param name="name">The name of the request GstPad to retrieve. Can be null. </param>
        /// <param name="caps">The caps of the pad we want to request. Can be null.</param>
        /// <returns>Requested GstPad if found, otherwise null</returns>
        public GstPad RequestPad(GstPadTemplate padTemplate, string name, GstCaps caps)
        {
            return Utils.HandleObject < GstPad>(gst_element_request_pad(Handle, Utils.GetHandle(padTemplate), name, Utils.GetHandle(caps)));
        }

        /// <summary>
        /// Retrieves a pad from the element by name (e.g. "src_%d"). This version only retrieves request pads. The pad should be released with ReleaseRequestPad().
        /// This method is slow and will be deprecated in the future. New code should use RequestPad() with the requested template.
        /// </summary>
        /// <param name="name">The name of the request GstPad to retrieve.</param>
        /// <returns>Requested GstPad if found, otherwise null. Release after usage.</returns>
        public GstPad GetRequestPad(string name)
        {
            return Utils.HandleObject<GstPad>(gst_element_get_request_pad(Handle, name));
        }

        /// <summary>
        /// Makes the element free the previously requested pad as obtained with <b>RequestPad</b>.
        /// </summary>
        /// <param name="pad">The GstPad to release.</param>
        public void ReleaseRequestPad(GstPad pad)
        {
            gst_element_release_request_pad(Handle, pad.Handle);
        }

        /// <summary>
        /// Makes the elements free the previously requested pads as obtained with <b>RequestPad</b>.
        /// </summary>
        /// <param name="pad">The GstPad to release.</param>
        public void ReleaseRequestPads(params GstPad[] pads)
        {
            foreach (var gstPad in pads)
            {
                ReleaseRequestPad(gstPad);
            }
        }

        public void Link(string sourcePad, GstElement destination, string destinationPad)
        {
            if (!gst_element_link_pads(Handle, sourcePad, destination.Handle, destinationPad))
            {
                throw new Exception("Cannot link elements");
            }
        }

        public void Link(string sourcePad, GstElement destination)
        {
            var srcPad = GetRequestPad(sourcePad);
            var dstPad = destination.GetCompatiblePad(srcPad, null);
            srcPad.Link(dstPad);
            ReleaseRequestPad(srcPad);
            destination.ReleaseRequestPad(dstPad);
        }

        /// <summary>
        /// Looks for an unlinked pad to which the given pad can link. It is not guaranteed that linking the pads will work, though it should work in most cases.
        /// This function will first attempt to find a compatible unlinked Always pad, and if none can be found, it will request a compatible Request pad by looking at the templates of element.
        /// </summary>
        /// <param name="gstPad">The GstPad to find a compatible one for.</param>
        /// <param name="gstCaps">The GstCaps to use as a filter.</param>
        /// <returns>The GstPad to which a link can be made, or null if one cannot be found. Unref after usage.</returns>
        public GstPad GetCompatiblePad(GstPad gstPad, GstCaps gstCaps)
        {
            return Utils.HandleObject<GstPad>(gst_element_get_compatible_pad(Handle, Utils.GetHandle(gstPad), Utils.GetHandle(gstCaps)));
        }
    }
}
