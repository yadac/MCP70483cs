using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_4
    {
        public static void ThreadMethod()
        {
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("running ...");
                    Thread.Sleep(1000);
                }
            }));
            t.Start();
            Thread.Sleep(3000);
            Console.WriteLine("press any key to exit"); // just output message to console.
            Console.ReadLine(); // this is waiting for user input, other thread execute in this waiting time.
            stopped = true;
            t.Join(); // finish other thread.
        }
    }
}
