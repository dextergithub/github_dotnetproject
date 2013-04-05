using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KinectCore
{
    public static class ExtendMethods
    {
        public static string ExtFormat(this string str, params object[] parms)
        {
            return string.Format(str, parms);
        }

    }
}
