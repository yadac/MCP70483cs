using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_44
    {
        public static void DoProc()
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            Task task = Task.Run(() =>
            {

                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);

                }
                throw new OperationCanceledException();

            }, token).ContinueWith(t =>
            {
                // AggregationException.Handle(Func<Exception, bool> predicate)
                // 例外が処理されたかどうかを示すブール値を返します。
                t.Exception.Handle(e => true);
                Console.WriteLine("you have canceled the task");
            }, 
            // task continue with if task is canceled.
            TaskContinuationOptions.OnlyOnCanceled);
        }
    }
}
