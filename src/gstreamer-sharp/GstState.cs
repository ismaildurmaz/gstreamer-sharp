﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
    public enum GstState
    {
        Pending = 0,
        Null = 1,
        Ready = 2,
        Paused = 3,
        Playing = 4,
    }
}
