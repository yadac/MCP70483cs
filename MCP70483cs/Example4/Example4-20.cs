using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_20
    {
        public static string DoProc()
        {
            string path = @"c:\temp\csharp\test.dat";

            if (File.Exists(path))
            {
                try
                {
                    return File.ReadAllText(path);
                }
                catch (DirectoryNotFoundException)
                {
                }
                catch (FileNotFoundException)
                {
                    
                }
            }

            return string.Empty;
        }
    }
}
