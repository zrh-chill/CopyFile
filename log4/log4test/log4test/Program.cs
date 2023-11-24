using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace log4test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string GetLogPath()
            //{
            //    var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //    if (path != null) return Path.Combine(path, "log");
            //    return string.Empty;
            //}

            Logger.Info("info");

        }
    }
}
