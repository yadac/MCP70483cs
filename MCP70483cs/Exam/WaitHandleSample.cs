using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class WaitHandleSample
    {
        static WaitHandle[] handles = new WaitHandle[]
        {
            // このオブジェクトは「シグナル状態」と「非シグナル状態」の2つの状態を持ちます。
            // 同期イベントにはAutoResetEventとManualResetEventの2種類あります。
            // signal状態になるまで待機させることができる
            new AutoResetEvent(false),
            new AutoResetEvent(false),
        };


        public static void DoProc()
        {
            var instance = new WaitHandleSample();
        }

        public WaitHandleSample()
        {
            ThreadPool.QueueUserWorkItem(val => CalculateSample((AutoResetEvent)val), handles[0]);
            ThreadPool.QueueUserWorkItem(val => CalculateSample((AutoResetEvent)val), handles[1]);

            Thread.Sleep(3000);
            (handles[0] as AutoResetEvent).Set();
            Thread.Sleep(3000);
            (handles[1] as AutoResetEvent).Set();

            Console.WriteLine("through");

            WaitHandle.WaitAll(handles);
            
        }


        private void CalculateSample(object state)
        {
            var eve = state as AutoResetEvent;
            eve.WaitOne();
            Console.WriteLine("called!!");
        }
    }
}
