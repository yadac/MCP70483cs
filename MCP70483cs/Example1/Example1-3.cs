using System;
using System.Threading;

namespace MCP70483cs
{
    class Example1_3
    {
        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int) o; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(0);
            }
        }
    }
}
