using System;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_13
    {
        public static void ThreadMethod()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];

                TaskFactory tf = new TaskFactory(
                    TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);

                return results;

            });

            var finalTask = parent.ContinueWith(parantTask =>
            {
                foreach (int i in parent.Result)
                {
                    Console.WriteLine(i);
                }
            });

            finalTask.Wait();
        }
    }
}
