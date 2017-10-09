using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_43
    {
        public static void DoProc()
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            Task task = Task.Run(() =>
            {
                // loop is here.
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }

                token.ThrowIfCancellationRequested();
                //if (token.IsCancellationRequested)
                //{
                //    Console.WriteLine("throw exception");
                //    throw new OperationCanceledException("A task was canceled.");
                //}

            }, token);

            try
            {
                Console.WriteLine("press enter to stop the task");
                Console.ReadLine();
                source.Cancel();
                task.Wait();
            }
            catch (AggregateException e)
            {
                // Message is fixed message : "A task was canceled" 
                Console.WriteLine(e.InnerExceptions[0].Message);
            }

        }
    }
}
