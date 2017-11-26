using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;

namespace MCP70483cs
{
    class Example3_53
    {
        public static void DoProc()
        {
            Console.WriteLine("Press escape key to stop");

            // performance counter access unmanaged resources.
            // args 1 .. category name
            // args 2 .. counter  name
            using (PerformanceCounter pc = new PerformanceCounter(
                "Memory"
                , "Available Bytes"))
            {
                string text = "Available memory: ";
                Console.Write(text);
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Console.Write(pc.RawValue);
                        Console.SetCursorPosition(text.Length, Console.CursorTop);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        }
    }
}
