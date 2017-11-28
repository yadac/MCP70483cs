using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_2
    {
        public static void DoProc()
        {
            string root = @"c:\temp\programmingInCSharp";

            var directory = Directory.CreateDirectory(
                @"c:\temp\programmingInCSharp\Directory");
            var directoryInfo = new DirectoryInfo(
                @"c:\temp\programmingInCSharp\DirectoryInfo");
            directoryInfo.Create();

            // add directory security to the directory
            // after execution, folder had a "special permission".
            // this can confirm permission detail in "advanced" window.
            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
            directorySecurity.AddAccessRule(
                new FileSystemAccessRule(
                    "everyone"
                    , FileSystemRights.FullControl
                    , AccessControlType.Allow));
            directoryInfo.SetAccessControl(directorySecurity);
        }
    }
}
