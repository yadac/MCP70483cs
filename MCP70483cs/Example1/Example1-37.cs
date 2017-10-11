using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_37
    {
        public static void DoProc()
        {
            object lockA = new object();
            object lockB = new object();
            int test;

            var up = Task.Run(() =>
            {
                // lock (test) // its syntax error, shoule be reference type. because using boxing when getting lock.
                lock (lockA)
                {
                    System.Threading.Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("locked a and b");
                    }
                }
            });

            // this is cause the deadlock.
            // up task wait for get lockB, other thred is same.

            lock (lockB)
            {
                System.Threading.Thread.Sleep(1000);
                lock (lockA)
                {
                    Console.WriteLine("locked b and a");
                }
            }
            up.Wait();

        }
    }
}
