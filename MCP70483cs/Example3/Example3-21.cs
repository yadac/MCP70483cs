using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_21<T>
    {
        private static List<T> list;

        public static void DoProc(T t)
        {
            Insert(t);
        }

        public static void Insert(T item)
        {
            if (!Contains(item)) list.Add(item);
        }

        public static bool Contains(T item)
        {
            foreach (var member in list)
            {
                if (member.Equals(item)) return true;
            }
            return false;
        }
    }
}
