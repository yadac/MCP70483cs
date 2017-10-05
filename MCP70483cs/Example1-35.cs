using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_35
    {
        public static void DoProc()
        {
            int n = 0;

            // its wrong example.
            // multithread access variable at same time.

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    // msil = read, store, write
                    // there is a possible to overwrite other thread updates.
                    n++;
                }
            });
            for (int i = 0; i < 1000000; i++)
            {
                n--;
            }
            up.Wait();
            Console.WriteLine(n); // not zero
        }
    }
}
