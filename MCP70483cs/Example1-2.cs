using System;
using System.Threading;

namespace MCP70483cs
{
    class Example1_2
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
