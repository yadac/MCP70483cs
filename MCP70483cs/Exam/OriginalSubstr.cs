using System;

namespace MCP70483cs.Exam
{
    public class OriginalSubstr
    {
        public Tuple<bool, string> DoProc(string source, string search)
        {
            var position = source.IndexOf(search, StringComparison.Ordinal);
            if (position < 0) return null;
            var remove = source.Remove(position, search.Length);
            return new Tuple<bool, string>(true, remove);
        }
    }
}