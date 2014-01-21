using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    public class GstVersion
    {
        private readonly uint _major;
        private readonly uint _minor;
        private readonly uint _micro;
        private readonly uint _nano;
        private readonly string _description;

        internal GstVersion(uint major, uint minor, uint micro, uint nano, string description)
        {
            this._major = major;
            this._minor = minor;
            this._micro = micro;
            this._nano = nano;
            this._description = description;
        }

        public string Description
        {
            get { return _description; }
        }

        public uint Major
        {
            get { return _major; }
        }

        public uint Minor
        {
            get { return _minor; }
        }

        public uint Micro
        {
            get { return _micro; }
        }

        public uint Nano
        {
            get { return _nano; }
        }

        public override string ToString()
        {
            return _description;
        }
    }
}
