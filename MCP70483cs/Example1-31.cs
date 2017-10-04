using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_31
    {
        public static void DoProc()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Task.Run(() =>
            {
                bag.Add(42);
                System.Threading.Thread.Sleep(1000);
                bag.Add(21);
            });

            Task.Run(() =>
            {
                // take snapshot before iteration. so 21 will not show.
                foreach (int i in bag)
                {
                    Console.WriteLine(i);
                }
            }).Wait();
        }
    }
}
