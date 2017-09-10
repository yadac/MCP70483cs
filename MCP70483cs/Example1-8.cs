using System;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_8
    {
        public static void ThreadMethod()
        {
            // task tell you when finished it.
            // task uses thread pool internal.
            var t = Task.Run(() =>
            {
                for (var i = 0; i < 100; i++)
                {
                    Console.Write("*");
                }
            });
            // wait method is equivalent to calling join on a thread.
            t.Wait();
            Console.ReadLine();
        }
    }
}
