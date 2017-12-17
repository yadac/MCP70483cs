using System;
using System.Threading;

namespace MCP70483cs.Exam
{
    internal class SemaphoreSample
    {
        private static Semaphore _pool;
        private static int _padding;

        public static void DoProc()
        {
            _pool = new Semaphore(0, 3);

            for (var i = 0; i < 5; i++)
            {
                // thread is old, task is now.
                var t = new Thread(Worker);
                t.Start(i);
            }
            Thread.Sleep(5000);
            Console.WriteLine("main thread calls release(3)");
            _pool.Release(3);
            Console.WriteLine("main thread exit.");
        }

        private static void Worker(object num)
        {
            Console.WriteLine($"thread {num} begin, and waits for the semaphore.");
            _pool.WaitOne();
            var padding = Interlocked.Add(ref _padding, 100);
            Console.WriteLine($"thread {num} enters the semaphore.");
            Thread.Sleep(1000 + padding);
            Console.WriteLine($"thread {num} releases the semaphore.");
            Console.WriteLine($"thread {num} previous semaphore count = {_pool.Release()}");
        }
    }
}