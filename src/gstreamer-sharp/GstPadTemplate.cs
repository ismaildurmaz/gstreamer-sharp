using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    /// <summary>
    /// Describe the media type of a pad.
    /// </summary>
    public class GstPadTemplate : GstObject
    {
        internal GstPadTemplate(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// The capabilities of the pad described by the pad template.
        /// 
        /// Since 0.10.21
        /// </summary>
        public GstCaps Caps
        {
            get
            {
                return GetStructure<GstCaps>("caps");
            }
        }

        /// <summary>
        /// The direction of the pad described by the pad template.
        /// 
        /// Default value: Unknown
        /// Since 0.10.21
        /// </summary>
        public GstPadDirection Direction
        {
            get
            {
                return (GstPadDirection)GetInt32("direction");
            }
            set
            {
                Set("direction", (int)value);
            }
        }

        /// <summary>
        /// The name template of the pad template.
        /// 
        /// Default value: null
        /// Since 0.10.21
        /// </summary>
        public string NameTemplate
        {
            get
            {
                return GetString("name-template");
            }
            set
            {
                Set("name-template", value);
            }
        }

        /// <summary>
        /// When the pad described by the pad template will become available.
        /// 
        /// Default value: Always
        /// Since 0.10.21
        /// </summary>
        public GstPadPresence Presence
        {
            get
            {
                return (GstPadPresence) GetInt32("presence");
            }
            set
            {
                Set("presence", (int) value);
            }
        }
    }
}
