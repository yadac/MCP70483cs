using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_23
    {


        // Asyncがついているので非同期メソッド
        // 非同期メソッドではAwaitキーワードが使えるようになる
        // Awaitは同期処理結果待ちと同じ
        // 非同期メソッドをRunで開始、開始したら結果の返却を待たずに後続処理を続ける
        // Awaitの処理が終わったら非同期処理は結果をTaskに詰めて元スレッドに返却する
        public async Task CreateAndWriteAsyncToFile()
        {
            Console.Write("CreateAndWriteAsyncToFile:");
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            using (FileStream fs = new FileStream(
                @"c:\temp\csharp\test.dat", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                // create 100mb file.
                byte[] data = new byte[1024 * 1000 * 100];
                new Random().NextBytes(data);
                await fs.WriteAsync(data, 0, data.Length);
            }
        }

        public void Test423() {
            Console.Write("test423:");
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

        public static void DoProc()
        {
            Console.Write("Main:");
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            var tasks = new List<Task>
            {
                // async calling.
                Task.Run(() => new Example4_23().Test423()),

                // call async method.
                Task.Run(() =>
                {
                    var instance = new Example4_23();
                    instance.CreateAndWriteAsyncToFile();
                })
            };
            Console.WriteLine("after calling task");
            Task.WaitAll(tasks.ToArray());

            foreach (var task in tasks)
            {
                Console.Write(task.Id);
                Console.WriteLine(task.Status);
            }
        }
    }
}
