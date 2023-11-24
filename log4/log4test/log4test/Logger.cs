using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using log4net;
using log4net.Appender;

namespace log4test
{

    /// <summary>
    /// 日记记录器
    /// </summary>
    public class Logger
    {
        //[ThreadStatic]
        private static ILog _logPlugin;

        /// <summary>
        /// 获取日志实例
        /// </summary>
        /// <returns></returns>
        private static ILog GetLogger()
        {
            if (_logPlugin == null)
            {
                //当前dll文件夹
                string path = Assembly.GetExecutingAssembly().Location;
                string dllDir = Path.GetDirectoryName(path);

                string appDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');

                //读取log4net配置文件
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net.config"));

                _logPlugin = log4net.LogManager.GetLogger("AppLogger");

                IAppender[] appenders = _logPlugin.Logger.Repository.GetAppenders();
                foreach (IAppender appender in appenders)
                {
                    if (appender is RollingFileAppender rollingFileAppender)
                    {
                        string file = rollingFileAppender.File;
                        if (!string.IsNullOrEmpty(appDir) && file.StartsWith(appDir))
                        {
                            file = file.Replace(appDir, dllDir);
                        }
                        else
                        {
                            string fileName = Path.GetFileName(file);
                            file = Path.Combine(dllDir, "Logs", fileName);
                        }
                        rollingFileAppender.File = file;
                        rollingFileAppender.ActivateOptions();
                    }
                }
            }
            return _logPlugin;
        }

        public static void Debug(string message)
        {
            GetLogger().Debug(message);
        }

        public static void Warn(string message)
        {
            GetLogger().Warn(message);
        }

        public static void Info(string message)
        {
            GetLogger().Info(message);
        }

        public static void Error(string message)
        {
            GetLogger().Error(message);
        }

        public static void Fatal(string message)
        {
            GetLogger().Fatal(message);
        }

        public static void Debug(string message, System.Exception ex)
        {
            GetLogger().Debug(message, ex);
        }

        public static void Warn(string message, System.Exception ex)
        {
            GetLogger().Warn(message, ex);
        }

        public static void Info(string message, System.Exception ex)
        {
            GetLogger().Info(message, ex);
        }

        public static void Error(string message, System.Exception ex)
        {
            GetLogger().Error(message, ex);
        }

        public static void Fatal(string message, System.Exception ex)
        {
            GetLogger().Fatal(message, ex);
        }

        public static void Error(System.Exception ex)
        {
            GetLogger().Error(ex);
        }

        public static void Fatal(System.Exception ex)
        {
            GetLogger().Fatal(ex);
        }

    }
}
