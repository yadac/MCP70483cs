using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_51
    {
        public static void DoProc()
        {
            // application = windowslog.application
            EventLog applicationLog = new EventLog("Application"
                , "."
                , "testEventLogEvent");
            applicationLog.EntryWritten += (sender, e) =>
            {
                Console.WriteLine("event fire!!");
                Console.WriteLine(e.Entry.Message);
            };
            applicationLog.EnableRaisingEvents = true;
            applicationLog.WriteEntry("Test message"
                , EventLogEntryType.Information);
            Console.ReadKey();
        }
    }
}
