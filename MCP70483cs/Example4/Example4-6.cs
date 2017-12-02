using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MCP70483cs.Example4
{
    class Example4_6
    {
        public static void DoProc()
        {
            DirectoryInfo info = new DirectoryInfo(@"c:\temp\csharp\directory1");
            info.Create();
            Directory.CreateDirectory(@"c:\temp\csharp\directory2");
            info.MoveTo(@"c:\temp\csharp\directory3");
        }
    }
}
