using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    public static class Example4_63
    {
        public static void DoProc()
        {
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source
            , Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
