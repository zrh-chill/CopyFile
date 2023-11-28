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
            ed.WriteMessage("111");
        }

        [CommandMethod("Login")]
        public void Login()
        {
            FtpHelper ftpHelper = new FtpHelper();
            ftpHelper.GetFtpFiles("192.168.102.103", "cm", "123");
        }

        public void Terminate()
        {
            
        }
    }
}
