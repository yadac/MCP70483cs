using System;
using System.Threading;
using MCP70483cs.Example1;
using MCP70483cs.Example2;

namespace MCP70483cs
{
    public static class Program
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc:{i}");
                Thread.Sleep(0);
            }
        }

        public static void Main(string[] args)
        {
            Example2_40.DoProc();
            Console.ReadLine();
        }
    }
}
