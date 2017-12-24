using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    internal class Cancellation
    {
        public static IEnumerable<string> GetDataInfoes { get; set; }

        public static void DoProc()
        {
            try
            {
                var cts = new CancellationTokenSource();
                var tasks = new List<Task>();
                foreach (var item in GetDataInfoes)
                    tasks.Add(Task.Run(() => DoSomething(item, cts))
                        .ContinueWith(t => Save(t.Result),
                            TaskContinuationOptions.NotOnRanToCompletion));
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ex)
            {
                // flatten = インスタンスを 1 つの新しいインスタンスにフラット化します
                var canceled = from e in ex.Flatten().InnerExceptions
                    where e.GetType() == typeof(TaskCanceledException)
                    select e;
                foreach (var c in canceled) ProcessCancellation(c);
            }
        }

        private static void ProcessCancellation(Exception exception)
        {
            throw new NotImplementedException();
        }

        private static Task<int> DoSomething(string s, CancellationTokenSource cts)
        {
            throw new NotImplementedException();
        }

        private static Task Save(int i)
        {
            throw new NotImplementedException();
        }
    }
}