using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        }
    }
}
