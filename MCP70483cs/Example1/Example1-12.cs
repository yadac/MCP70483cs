using System;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_12
    {
        public static void ThreadMethod()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];

                new Task(() =>
                        results[0] = 0
                    , TaskCreationOptions.AttachedToParent).Start();

                new Task(() =>
                        results[1] = 1
                    , TaskCreationOptions.AttachedToParent).Start();

                new Task(() =>
                        results[2] = 2
                    , TaskCreationOptions.AttachedToParent).Start();

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
