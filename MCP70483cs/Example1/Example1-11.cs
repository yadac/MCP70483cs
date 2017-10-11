using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_11
    {
        public static void ThreadMethod()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            // canceled
            t.ContinueWith((i) =>
            {
                Console.WriteLine("canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            // fault
            t.ContinueWith((i) =>
            {
                Console.WriteLine("faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            Task<int> completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("completed");
                return 1;
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Console.WriteLine(completedTask.Result);
            Console.ReadLine();
        }
    }
}
