using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_42
    {

        public static void DoProc()
        {
            var source = new CancellationTokenSource();
            var token = source.Token;
            int i = 0;

            Task.Run(() =>
            {
                while (i < 5)
                {
                    // alternate is ThrowIfCancellationRequested()
                    if (token.IsCancellationRequested)
                    {
                        throw new OperationCanceledException(token);
                    }

                    Console.WriteLine("*");
                    i++;
                    Thread.Sleep(1000);
                }

            }, token).ContinueWith(t =>
            {
                if (t.IsCanceled)
                {
                    Console.WriteLine("task is cancelled.");
                }
                else
                {
                    Console.WriteLine("task is completed!!");

                }
            });


            Console.WriteLine("Press enter to stop the task.");
            Console.ReadLine();
            source.Cancel();
        }
    }
}
