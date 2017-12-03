using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_19
    {
        public static void DoProc()
        {
            string path = @"c:\temp\bufferedStream.txt";

            using (FileStream fs = File.Create(path))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamWriter sw = new StreamWriter(bs))
                    {
                        sw.WriteLine("a line of text");
                    }
                }
            }
        }
    }
}
