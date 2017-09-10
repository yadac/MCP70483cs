using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_14
    {
        public static void ThreadMethod()
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            // wait for multiple tasks to finish before continuing execution.
            // Task.WaitAll(tasks);
            Task.WhenAll(tasks).ContinueWith(t =>
            {
                // Creates a task that will complete when all of the supplied tasks have completed.
                // WaitAll vs WhenAll
                Console.WriteLine("all tasks done.");
            });

            // after 1,2,3 number show, this message will be shown.
            Console.WriteLine("finished all tasks.");
            Console.ReadLine();

        }
    }
}
