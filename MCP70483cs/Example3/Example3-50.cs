using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_50
    {
        public static void DoProc()
        {
            // EventLog log = new EventLog("myNewLog");
            // Microsoft Office Alerts (official name shows in property dialog)
            EventLog log = new EventLog("OAlerts");
            Console.WriteLine($"Total entries: {log.Entries.Count}");
            EventLogEntry last = log.Entries[log.Entries.Count - 1];
            Console.WriteLine($"Index: {last.Index}");
            Console.WriteLine($"Source: {last.Source}");
            Console.WriteLine($"Type: {last.EntryType}");
            Console.WriteLine($"Time: {last.TimeWritten}");
            Console.WriteLine($"Message: {last.Message}");
            // 
            Console.WriteLine(last.ToString());
            Console.ReadLine();
        }
    }
}
