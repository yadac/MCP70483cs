using System;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_17
    {
        public static void ThreadMethod()
        {
            ParallelLoopResult result 
                = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
            {
                if (i == 500)
                {
                    Console.WriteLine("breaking loop");
                    loopState.Break();
                }
            });
            Console.WriteLine($"IsCompleted = {result.IsCompleted}");
            Console.WriteLine($"LowestBreakIteration = {result.LowestBreakIteration}");
            Console.ReadLine();
            // return;
        }
    }
}
