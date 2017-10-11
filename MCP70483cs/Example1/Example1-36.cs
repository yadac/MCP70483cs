﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_36
    {
        public static void DoProc()
        {
            int n = 0;
            object _lock = new object();

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (_lock)
                    {
                        n++;
                    }
                }
            });
            for (int i = 0; i < 1000000; i++)
            {
                n--;
            }
            up.Wait();
            Console.WriteLine(n);
        }
    }
}
