using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    enum Categories
    {
        Unknown = -1,
        Plant,
        Animal,
        Mineral,
        Count,
        Fish
    }

    public class CategorySample
    {
        public static void DoProc()
        {
            // 1
            // Count
            // 3
            Console.WriteLine((int)Categories.Animal);
            Console.WriteLine(Categories.Count);
            Console.WriteLine((int)Categories.Count);
            Console.WriteLine((int)Categories.Fish);
        }
    }
}
