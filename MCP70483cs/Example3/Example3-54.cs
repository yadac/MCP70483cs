using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_54
    {
        public static void DoProc()
        {
            if (CreatePerformanceCounters())
            {
                Console.WriteLine("Created performance counters");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }

            // create original counter
            var totalOperationsSeCounter = new PerformanceCounter(
                "MyCategory"
                , "# operations executed"
                , ""
                , false);
            var operationsPerSecond = new PerformanceCounter(
                "MyCategory"
                , "# operations / sec"
                , ""
                , false);
            totalOperationsSeCounter.Increment();
            operationsPerSecond.Increment();

            // delete counter
            PerformanceCounterCategory.Delete("MyCategory");
        }

        private static bool CreatePerformanceCounters()
        {
            if (!PerformanceCounterCategory.Exists("MyCategory"))
            {
                var counters = new CounterCreationDataCollection()
                {
                    new CounterCreationData(
                        "# operations executed"
                        , "Total number of operations executed"
                        , PerformanceCounterType.NumberOfItems32
                    ),
                    new CounterCreationData(
                        "# operations / sec"
                        , "Number of operations executed per second"
                        , PerformanceCounterType.RateOfCountsPerSecond32
                    )
                };
                PerformanceCounterCategory.Create(
                    "MyCategory"
                    , "Sample category for Codeproject"
                    , counters);
                return true;
            }
            return false;
        }
    }
}
