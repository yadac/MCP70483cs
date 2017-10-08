using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_39
    {
        private static volatile int _flag = 0;
        private static volatile int _value = 0;

        public static void DoProc()
        {
            var task1 = Task.Run(() =>
            {
                Thread1();
            });

            var task2 = Task.Run(() =>
            {
                Thread2();
            });

            // normally, no output or an output of 5.
            // however, the compiler switches two lines in thread 1.
            // if thread 2 then executes, it could be that _flag has 1, _value has 0.

            // its avoid by volatile keyword.
            // volatile does not support Visual Basic, and it hinders performance.
            Task.WaitAll(new [] {task1, task2});
            Console.WriteLine("finish");
        }

        // method can not apply volatile
        private static void Thread1()
        {
            _value = 5;
            _flag = 1;
        }

        private static void Thread2()
        {
            if (_flag == 1)
            {
                Console.WriteLine(_value);
            }
        }
    }
}
