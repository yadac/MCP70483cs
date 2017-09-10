using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_9
    {
        public static void ThreadMethod()
        {
            // if your task return value, you shoule be used Task<T> class.
            // you can add continuation task. excample-10.
            Task<int> t = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return 42;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });
            Console.WriteLine("hello world");
            Console.WriteLine(t.Result);
            Console.ReadLine();
        }
    }
}
