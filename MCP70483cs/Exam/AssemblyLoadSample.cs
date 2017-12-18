using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MCP70483cs.Exam
{
    class AssemblyLoadSample
    {
        public static void DoProc()
        {
            var assemblyPath = @"C:\Temp\test\Newtonsoft.Json.dll";
            var assembly = Assembly.LoadFrom(assemblyPath);
            foreach (Type publicType in assembly.ExportedTypes)
            {
                if (publicType.ToString().EndsWith("JsonException"))
                {
                    var je = Activator.CreateInstance(publicType);
                    var jj = je as JsonException;
                    Console.WriteLine(jj.ToString());
                }
            }
        }
    }
}
