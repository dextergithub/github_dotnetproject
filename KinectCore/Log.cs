using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;

namespace KinectCore
{
    /// <summary>
    /// 日志类
    /// </summary>
    public class Log
    {
        #region 日志记录
        private static Log _logger;
        private static readonly string LogFilePath = string.IsNullOrEmpty(KinectCore.Properties.Settings.Default.LogPath) ? System.Environment.CurrentDirectory + "\\log\\" : KinectCore.Properties.Settings.Default.LogPath;
        private static readonly Mutex Mutex = new Mutex(false);

        public static Log log
        {
            get
            {
                _logger = GetInstance();
                return _logger;
            }
        }
        /// <summary>
        /// 构造
        /// </summary>
        private Log()
        {
        }

        /// <summary>
        /// 单键
        /// </summary>
        /// <returns></returns>
        public static Log GetInstance()
        {

            if (_logger == null)
            {
                _logger = new Log();
                if (!Directory.Exists(LogFilePath))
                {
                    Directory.CreateDirectory(LogFilePath);
                }
            }
            return _logger;
        }

        /// <summary>
        /// 错误日志暴露接口
        /// </summary>
        /// <param name="message">The message.</param>
        public void WriteDebugLog(string message)
        {
            WriteLogFile(message);
        }

        /// <summary>
        /// 错误日志记录
        /// </summary>
        /// <param name="message">The message.</param>
        private static void WriteLogFile(string message)
        {
            if (!Properties.Settings.Default.LogEnable) return;
            try
            {
                Mutex.WaitOne();
                string strSysTime = DateTime.Now.ToString("yyyyMMddHH:mm:ss.FFF");
                string logFullPath = LogFilePath + strSysTime.Substring(0, 10) + "_" + ".log";
                string logstr = message;

                if (!File.Exists(logFullPath))
                {
                    using (StreamWriter sw = File.CreateText(logFullPath))
                    {
                        sw.Write(strSysTime + " " + logstr + "\r\n");
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(logFullPath))
                    {
                        sw.Write(strSysTime + " " + logstr + "\r\n");
                        sw.Close();
                    }
                }
            }
            finally
            {
                Mutex.ReleaseMutex();
            }
        }
        #endregion

        public void Error(string message, Exception ex)
        {
            WriteLogFile(string.Format("{0}.{1} Exception:{2},{3},Detail:{4}", "", "", message, ex.Message, ex.StackTrace));
        }

        public void WriteErrLog(string message, Exception ex, string p_5)
        {
            WriteLogFile(string.Format("{0}.{1} Exception:{2},{3},Detail:{4} \n Addtion:{5}", "", "", message, ex.Message, ex.StackTrace, p_5));
        }


        internal void Error(string p)
        {
            WriteLogFile(p);
        }
    }
}
