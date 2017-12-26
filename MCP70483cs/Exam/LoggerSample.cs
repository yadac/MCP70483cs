using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    public class LoggerSample
    {
        public LoggerSample(TextWriter logDestination)
        {
            // the StringWriter uses the Append() when writing message.
            logDestination.Write("+++++++");
            logDestination.Write("message");
            logDestination.Write("+++++++");
            Console.WriteLine(logDestination.ToString());
            // logDestination.Flush();
            logDestination.Dispose();
        }

        public static void DoProc()
        {
            var destination = new StringBuilder();

            // stringWriter = write string to xxx
            // streamWriter = write stream to xxxStream
            var writer = new StringWriter(destination);
            var logger = new LoggerSample(writer);
            
        }

        
    }
}
