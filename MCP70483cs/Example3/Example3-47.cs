using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_47
    {
        public static void DoProc()
        {
            using (Stream outputFile = File.Create("tracefile.txt"))
            {
                var textListener = new TextWriterTraceListener(outputFile);
                TraceSource traceSource = new TraceSource(
                    "myTraceSource"
                    , SourceLevels.All);
                traceSource.Listeners.Clear();
                traceSource.Listeners.Add(textListener);
                traceSource.TraceInformation("current value is {0}.", 123);
                traceSource.TraceInformation("Trace output");
                traceSource.Flush();
                traceSource.Close();
            }
        }
    }
}
