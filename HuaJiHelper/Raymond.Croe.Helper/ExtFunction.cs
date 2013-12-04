using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymond.Croe.Helper
{
    public static class ExtFunction
    {
        public static string ExtFormat(this string _self, params object[] par)
        {
            return string.Format(_self, par);
        }

        public static string ExtToJsonString(this object obj)
        {
            if (obj == null) return "{}";

#if DEBUG
            Newtonsoft.Json.Converters.IsoDateTimeConverter isoc = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            isoc.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            isoc.DateTimeStyles = System.Globalization.DateTimeStyles.AssumeLocal;
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
#else
   return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
#endif

        }        

    }
}
