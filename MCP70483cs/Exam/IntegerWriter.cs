using System.Collections.Generic;
using System.IO;

namespace MCP70483cs.Exam
{
    internal class IntegerWriter
    {
        public static void DoProc()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };

            using (var writer = new StreamWriter(@"c:\temp\test\integers.txt"))
            {
                list.ForEach(i => writer.WriteLine(i));
            }
        }
    }
}