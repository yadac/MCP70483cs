using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.C7
{
    class SampleOut
    {
        public static void DoProc()
        {
            var runner = new Runner();
            runner.Run();
            runner.Run2();
        }
    }

    class Runner
    {
        public void Run()
        {
            int hour;
            int minutes;
            int seconds;
            GetTime(out hour,out minutes, out seconds);
            Console.WriteLine($"{hour}:{minutes}:{seconds}");
        }
        public void Run2()
        {
            GetTime(out int hour, out int minutes, out int seconds);
            Console.WriteLine($"{hour}:{minutes}:{seconds}");
        }

        private void GetTime(out int hour, out int minutes, out int seconds)
        {
            hour = 1;
            minutes = 30;
            seconds = 20;
        }

    }
}
