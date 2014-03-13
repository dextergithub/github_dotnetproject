using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCommon
{
    public static  class ExtMethod
    {
        public static string ExtFormat(this string str,params object[] p)
        {
            return string.Format(str, p);
        }

        public static int TryInt(this string str)
        {
            int v = default(int);
            int.TryParse(str, out v);
            return v;
        }

    }
}
