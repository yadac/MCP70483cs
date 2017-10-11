using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_45
    {
        public static void DoProc()
        {
            //var source = new CancellationTokenSource();
            //var token = source.Token;

            Task longRunning = Task.Run(() =>
            {
                Console.WriteLine("task start");
                Thread.Sleep(10000);
                Console.WriteLine("task finish");
            });

            Task shortRunnig = Task.Run(() =>
            {
                Thread.Sleep(2000); // if value < 1000, index will be 1
                Console.WriteLine();
            });

            // waits for any of the provided tasks to complate execution within specific time frame.
            // Returns the index of the completed task in the array.
            // If timeout occured, return value is -1.
            int index = Task.WaitAny(new[]
            {
                longRunning, shortRunnig
            }, 1000);

            Console.WriteLine($"index = {index}");

            // 配列引数内の完了したタスクのインデックス。タイムアウトが発生した場合は -1。
            if (index == -1)
            {
                Console.WriteLine("task timed out.");
            }
        }
    }
}
