using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCP70483cs.Exam
{
    internal class DocBuilder
    {
        private List<string> dict;
        private StringBuilder doc;

        private DocBuilder()
        {
            InitDictionary();
        }

        private void InitDictionary()
        {
        }

        private StringBuilder BuildDoc(ulong words)
        {
            int index = 0;
            doc = new StringBuilder(5000, 40000);
            var pick = new Random();
            for (ulong i = 0; i < words; i++)
            {
                // which line should you add here???
                index = pick.Next(dict.Count());
                if (doc.Length + dict[index].Length <= doc.MaxCapacity)
                {
                    doc.Append(dict[index]);
                }
            }
            return doc;
        }
    }
}