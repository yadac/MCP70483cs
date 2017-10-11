using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_19
    {
        public static void ThreadMethod()
        {
            var e19 = new Example1_19();

            // there are two difference task generator methods.
            // the B method does not occupy a thread while waiting for the timer to run. 
            // the B method give you scalability.
        }

        public Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(millisecondsTimeout);
            });
        }

        public Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate
            {
                tcs.TrySetResult(true);
            }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1); // duetime, period
            return tcs.Task;
        }

    }
}
