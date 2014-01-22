using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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

        #endregion

        internal GstElement(IntPtr handle)
            : base(handle)
        {
        }

        internal GstElement(GstElement element)
            : base(element.Handle)
        {
        }

        
        /// <summary>
        /// Link element with destinationElement
        /// </summary>
        /// <param name="destinationElement"></param>
        /// <returns></returns>
        public void Link(GstElement destinationElement)
        {
            if (!gst_element_link(Handle, destinationElement.Handle))
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
                return new GstBus(gst_element_get_bus(Handle));
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
                return new GstClock(gst_element_get_clock(Handle));
            }
            set
            {
                if (!gst_element_set_clock(Handle, value.Handle))
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
                return new GstClock(gst_element_provide_clock(Handle));
            }
        }

        /// <summary>
        /// Retrieves an iterator of element's pads. The iterator should be freed after usage.
        /// </summary>
        /// <returns></returns>
        public GstIterator IteratePads()
        {
            return new GstIterator(gst_element_iterate_pads(Handle));
        }

        /// <summary>
        /// Retrieves an iterator of element's source pads.
        /// </summary>
        /// <returns></returns>
        public GstIterator IterateSourcePads()
        {
            return new GstIterator(gst_element_iterate_src_pads(Handle));
        }

        /// <summary>
        /// Retrieves an iterator of element's sink pads.
        /// </summary>
        /// <returns></returns>
        public GstIterator IterateSinkPads()
        {
            return new GstIterator(gst_element_iterate_sink_pads(Handle));
        }
    }
}
