using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace MCP70483cs.Example4
{
    internal class Example4_90 : List<Person4>
    {
        public static void DoProc()
        {
            var p1 = new Person4 { Id = 1, Name = "taro", Age = 10 };
            var p2 = new Person4 { Id = 2, Name = "jiro", Age = 20 };
            var p3 = new Person4 { Id = 3, Name = "saburo", Age = 30 };

            var list = new Example4_90 { p1, p2, p3 };
            list.RemoveByAge(20);
            WriteLine(list.ToString());
        }

        public void RemoveByAge(int age)
        {
            // foreach can not change during loop, but for can change.
            // "this" is indexer.
            for (var index = Count - 1; index >= 0; index--)
                if (this[index].Age == age)
                    RemoveAt(index);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var p in this)
                sb.AppendFormat(p + "\r\n");
            return sb.ToString();
        }
    }
}