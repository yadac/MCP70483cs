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
            // (set)signal = thread start / (reset)non-siglal = thread stop
            // 
            // false = non-signal
            new ManualResetEvent(false),
            new ManualResetEvent(false),
        };


        public static void DoProc()
        {
            var instance = new WaitHandleSample();
        }

        public WaitHandleSample()
        {
            // non-signal
            //ThreadPool.QueueUserWorkItem(val => CalculateSample((AutoResetEvent)val), handles[0]);
            //ThreadPool.QueueUserWorkItem(val => CalculateSample((AutoResetEvent)val), handles[1]);
            ThreadPool.QueueUserWorkItem(new WaitCallback(CalculateSample), handles[0]);
            ThreadPool.QueueUserWorkItem(new WaitCallback(CalculateSample), handles[1]);

            // after sleeping, send signal by set()
            Thread.Sleep(3000);
            (handles[0] as ManualResetEvent).Set();
            Thread.Sleep(3000);
            (handles[1] as ManualResetEvent).Set();

            Console.WriteLine("through");

            // AutoEventReset is already turn non-signal. waitall method waits that all of element receive signal, so wait forever...
            // ManualReset is signaled
            WaitHandle.WaitAll(handles);
            Summarize();
        }

        private void Summarize()
        {
            Console.WriteLine("finish!");
        }


        private void CalculateSample(object state)
        {
            (state as WaitHandle).WaitOne();
            Console.WriteLine("called!!");
        }
    }
}
