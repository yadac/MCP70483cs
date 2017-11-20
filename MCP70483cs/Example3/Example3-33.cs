using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_33
    {
        public static void DoProc()
        {
            Timer t = new Timer(TimerCallback, null, 0, 2000);
            Console.ReadLine();
        }

        private static void TimerCallback(object o)
        {
            Console.WriteLine("in timercallback: " + DateTime.Now);
            GC.Collect();
        }
    }
}
