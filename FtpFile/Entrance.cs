using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Runtime;
using FtpFile.Ftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpFile
{
    public class Entrance : IExtensionApplication
    {
        public void Initialize()
        {
            var ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("Initialize");
        }

        [CommandMethod("Download")]
        public void Download()
        {
            FtpHelper ftpHelper = new FtpHelper();
            ftpHelper.GetFtpFiles("192.168.102.103", "cm", "123");
        }

        public void Terminate()
        {
            var ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("Terminate");
        }
    }
}
