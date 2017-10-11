using System;
using System.Threading;

namespace MCP70483cs
{
    class Example1_7
    {
        public static void ThreadMethod()
        {
            // s type is System.Threading.WaitCallback
            // スレッド プール スレッドが実行するコールバック メソッドを表します。
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine($"Working on a thread from thread pool");
            });
            Console.ReadLine();
        }
    }
}
