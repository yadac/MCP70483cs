using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    public static class IntrusiveListExtensions
    {
        public static void Add<T>(this IInstrusiveList<T> node, T item) { }
        public static void Remove<T>(this IInstrusiveList<T> node, T item) { }

        public static long Count<T>(this IInstrusiveList<T> node)
        {
            return 0;
        }
    }

    public interface IInstrusiveList<T>
    {
        IInstrusiveList<T> Next { get; set; }
        IInstrusiveList<T> Previous { get; set; }
        T Self { get; }

    }

    public static class ExtensionSample
    {
        public static IEnumerable<int> Where(this IEnumerable<int> array, Func<int, bool> pred)
        {
            foreach (var i in array)
            {
                if (pred(i))
                {
                    yield return i;
                }
            }
        }

        public static IEnumerable<int> Select(this IEnumerable<int> array, Func<int, int> filter)
        {
            foreach (var i in array)
            {
                yield return filter(i);
            }
        }

        public static void DoProc()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var result =
                ExtensionSample.Select(
                    ExtensionSample.Where(array, x => x % 2 == 0),
                    x => x * x);
        }

    }

}
