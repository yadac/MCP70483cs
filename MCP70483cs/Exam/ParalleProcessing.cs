using System;
using System.Linq;

namespace MCP70483cs.Exam
{
    internal class ParalleProcessing
    {
        public static void DoProc()
        {
        }

        public DataPoint[] TransformRawData(RawSample[] rawSamples)
        {
            var query = from s in rawSamples.AsParallel()
                where DataPoint.IsSampleValid(s)
                select DataPoint.CreateFromSample(s);
            return query.ToArray();
        }
    }

    internal class RawSample
    {
        public void LogMessage(dynamic message)
        {
            message.Logging();
        }
        // public void LogMessage(LogMessage2 message) { }
    }

    internal class LogMessage2
    {
    }

    internal class LogMessage1
    {
        public void Logging()
        {
            Console.WriteLine("logmessage1");
        }
    }

    internal class DataPoint
    {
        public static bool IsSampleValid(object o)
        {
            return true;
        }

        public static DataPoint CreateFromSample(object o)
        {
            throw new NotImplementedException();
        }
    }
}