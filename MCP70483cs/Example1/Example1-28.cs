using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_28
    {
        public static void DoProc()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                //while (true)
                //{
                //    Console.WriteLine(col.Take());
                //}

                // コレクションから項目を取得し続ける
                foreach (string s in col.GetConsumingEnumerable())
                {
                    Console.WriteLine(s);
                }

            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });
            write.Wait();
        }
    }
}
