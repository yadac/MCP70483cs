using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_12
    {
        public static void DoProc()
        {
            string folder = @"c:\temp";
            string fileName = @"test.dat";

            string fullPath = Path.Combine(folder, fileName);
            Console.WriteLine(fullPath);

            // you can get other infomations
            Console.WriteLine(Path.GetDirectoryName(fullPath));
            Console.WriteLine(Path.GetExtension(fullPath));
            Console.WriteLine(Path.GetFileName(fullPath));
            Console.WriteLine(Path.GetPathRoot(fullPath));

        }
    }
}
