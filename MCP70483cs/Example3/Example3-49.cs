using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_49
    {
        public static void DoProc()
        {
            if (!(EventLog.SourceExists("mySource")))
            {
                EventLog.CreateEventSource("mySource", "myNewLog");
                Console.WriteLine("CreatedEventSource");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }
            // show "myNewLog" in event viewer. 
            EventLog myLog = new EventLog();
            myLog.Source = "mySource";
            myLog.WriteEntry("Log Event!");
        }
    }
}
