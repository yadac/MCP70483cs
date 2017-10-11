using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_15
    {
        public static void ThreadMethod()
        {
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(2000);
                return 1;
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return 3;
            });

            // until all tasks finish
            while (tasks.Length > 0)
            {
                // return finished task, first is 2, second is 1, third is 3.
                int i = Task.WaitAny(tasks);
                Task<int> completeTask = tasks[i];
                Console.WriteLine(completeTask.Result);

                // task array re-defined.
                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }

        }
    }
}
