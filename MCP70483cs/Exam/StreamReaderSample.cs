using System.IO;

namespace MCP70483cs.Exam
{
    internal class StreamReaderSample
    {
        public void DoProc(MemoryStream memoryStream)
        {
            using (var reader = new StreamReader(memoryStream))
            {
                var data = reader.ReadToEnd();
            }
        }
    }
}