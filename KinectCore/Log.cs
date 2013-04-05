using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KinectCore
{
    public class Log
    {
        public static log4net.ILog log;

         static Log()
        {
            log4net.Config.XmlConfigurator.Configure();
            log = log4net.LogManager.GetLogger(Assembly.GetEntryAssembly(), "default");            
        }        
    }
}
