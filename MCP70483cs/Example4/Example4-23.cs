using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_23
    {


        public async Task CreateAndWriteAsyncToFile()
        {
            Console.WriteLine("CreateAndWriteAsyncToFile");
            using (FileStream fs = new FileStream(
                @"c:\temp\csharp\test.dat", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                // create 100mb file.
                byte[] data = new byte[1024 * 1000 * 100];
                new Random().NextBytes(data);
                await fs.WriteAsync(data, 0, data.Length);
            }
        }

        public static void DoProc()
        {
            var instance = new Example4_23();
            Task task = instance.CreateAndWriteAsyncToFile();
            Console.WriteLine("after calling task");
            task.Wait();
        }
    }
}
