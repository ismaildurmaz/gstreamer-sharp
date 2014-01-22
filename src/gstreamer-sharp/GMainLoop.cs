using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public class GMainLoop : HandleObject
    {
        #region wrappers

        

        [DllImport(Library.Libglib)]
        private static extern IntPtr g_main_loop_new(IntPtr mainContext, bool running);

        [DllImport(Library.Libglib)]
        private static extern void g_main_loop_run(IntPtr mainLoop);

        [DllImport(Library.Libglib)]
        private static extern void g_main_loop_quit(IntPtr mainLoop);

        [DllImport(Library.Libglib)]
        private static extern bool g_main_loop_is_running(IntPtr mainLoop);

        [DllImport(Library.Libglib)]
        private static extern bool g_main_loop_unref(IntPtr mainLoop);

        [DllImport(Library.Libglib)]
        private static extern bool g_main_loop_ref(IntPtr mainLoop);

#endregion

        internal GMainLoop(IntPtr handle)
            : base(handle)
        {
        }

        /// <summary>
        /// Creates a new GMainLoop structure.
        /// </summary>
        /// <param name="running">set to true to indicate that the loop is running. This is not very important since calling g_main_loop_run() will set this to true anyway.</param>
        /// <returns></returns>
        public static GMainLoop Create(bool running)
        {
            var r = g_main_loop_new(IntPtr.Zero, running);
            return new GMainLoop(r);
        }

        /// <summary>
        /// Runs a main loop until <b>Quit</b> is called on the loop. If this is called for the thread of the loop's GMainContext, it will process events from the loop, otherwise it will simply wait.
        /// </summary>
        public void Run()
        {
            g_main_loop_run(Handle);
        }

        /// <summary>
        /// Stops a GMainLoop from running. Any calls to <b>Run</b> for the loop will return.
        /// Note that sources that have already been dispatched when <b>Quit</b> is called will still be executed.
        /// </summary>
        public void Quit()
        {
            g_main_loop_quit(Handle);
        }

        /// <summary>
        /// Decreases the reference count on a GMainLoop object by one. If the result is zero, free the loop and free all associated memory.
        /// </summary>
        public void UnRef()
        {
            g_main_loop_unref(Handle);
        }

        /// <summary>
        /// Increases the reference count on a GMainLoop object by one.
        /// </summary>
        public void Ref()
        {
            g_main_loop_ref(Handle);
        }

        /// <summary>
        /// Checks to see if the main loop is currently being run via <b>Run</b>
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return g_main_loop_is_running(Handle);
            }
        }
    }
}
