using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCommon
{
   public class LogHelper
    {
       public static log4net.ILog Log;

       static LogHelper()
       {
           Log = log4net.LogManager.GetLogger("default");
           NameValueCollection appSettings = ConfigurationManager.AppSettings;
           string logFileName = appSettings["TraceLogFile"];
             if (!string.IsNullOrEmpty(logFileName))
             {
                 foreach (TraceListener tl in Trace.Listeners)
                 {
                     var _MyTrace = tl as DefaultTraceListener;
                     if (_MyTrace != null)
                     {
                         _MyTrace.LogFileName = logFileName;
                         MyTrace = _MyTrace;
                         break;
                     }
                 }
             }
             if (MyTrace == null) MyTrace = Trace.Listeners[0];
       }
       public static TraceListener MyTrace;


      
    }
}
