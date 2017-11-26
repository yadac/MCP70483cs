using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_46
    {
        public static void DoProc()
        {
            string test = "test message...";

            TraceSource traceSource = new TraceSource(
                "myTraceSource"
                , SourceLevels.All);

            traceSource.TraceInformation("Tracing application..");

            traceSource.TraceEvent(
                TraceEventType.Critical
                , 0
                , "Critical trace");

            traceSource.TraceData(
                TraceEventType.Information
                , 1
                , new object[] { "a", "b", "c", test });
            traceSource.Flush();
            traceSource.Close();
        }
    }
}
