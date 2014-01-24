namespace Gst
{
    public class GstVersion
    {
        private readonly string _description;
        private readonly uint _major;
        private readonly uint _micro;
        private readonly uint _minor;
        private readonly uint _nano;

        internal GstVersion(uint major, uint minor, uint micro, uint nano, string description)
        {
            _major = major;
            _minor = minor;
            _micro = micro;
            _nano = nano;
            _description = description;
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