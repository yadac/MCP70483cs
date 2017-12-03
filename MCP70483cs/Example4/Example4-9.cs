using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace MCP70483cs.Example4
{
    class Example4_9
    {
        public static void DoProc()
        {
            string path = @"c:\temp\csharp\test.txt";
            string copyPath = @"c:\temp\csharp\directory-a\copied.txt";
            string movePath = @"c:\temp\csharp\directory-b\moved.txt";

            File.CreateText(path).Close();
            File.Copy(path, copyPath, false);

            FileInfo fileInfo = new FileInfo(copyPath);
            fileInfo.MoveTo(movePath);

            fileInfo = new FileInfo(path);
            fileInfo.CopyTo(copyPath);
        }
    }
}
