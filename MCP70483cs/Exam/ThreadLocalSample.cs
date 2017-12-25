using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class ThreadLocalSample
    {
        static ThreadLocal<int> threadLocal = new ThreadLocal<int>();

        public static void DoProc()
        {
            threadLocal.Value = 123;

            // 異なるスレッドからアクセスするためにstatic, しかし値は各スレッド内に格納する
            // 同じ処理を実装するため？
            // thread have own value.
            // 1
            // -1
            // 123
            Task.WhenAll(
                Task.Run(() => { Console.WriteLine(++threadLocal.Value); }),
                Task.Run(() => { Console.WriteLine(--threadLocal.Value); })).Wait();
            Console.WriteLine(threadLocal.Value);
        }
    }
}
