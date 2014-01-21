using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gst
{
   public static class Delegates
   {
       public delegate void GIOFunction(IntPtr source, GIOCondition condition, IntPtr userData);
   }
}
