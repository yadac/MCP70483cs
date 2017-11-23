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
            runner.PrintSum(10);
            runner.PrintSum2("1d");
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

        public void PrintSum(object o)
        {
            if (o is null) return; // constant pattern
            if (!(o is int i)) return; // type pattern(int)
            int sum = 0;
            for (int j = 0; j <= i; j++)
                sum += j;
            Console.WriteLine($"(printsum)The sum of 1 to {i} is {sum}");
        }

        public void PrintSum2(object o)
        {
            if (o is int i || o is string s && int.TryParse(s, out i))
            {
                int sum = 0;
                for (int j = 0; j <= i; j++)
                    sum += j;
                Console.WriteLine($"(printsum2)The sum of 1 to {i} is {sum}");
            }
        }

        private void GetTime(out int hour, out int minutes, out int seconds)
        {
            hour = 1;
            minutes = 30;
            seconds = 20;
        }

    }
}
