using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_14
    {
        public static void DoProc()
        {
            string path = @"c:\temp\csharp\test.dat";
            using (FileStream fs = File.Create(path))
            {
                string myValue = "myvalue";
                byte[] data = Encoding.UTF8.GetBytes(myValue);
                fs.Write(data, 0, data.Length);
            }
        }
    }
}
