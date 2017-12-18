using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class DynamicLoader
    {
        public static void DoProc()
        {
            var assembly = Assembly.LoadFrom(@"c:\temp\test\Human.dll");
            var publicTypes = assembly.ExportedTypes;
            foreach (var publicType in publicTypes)
            {
                if (publicType.IsClass && typeof(ISampleFactory).IsAssignableFrom(publicType))
                {
                    var factory = (ISampleFactory) Activator.CreateInstance(publicType);
                    var sample = factory.Create();
                    Console.WriteLine(sample.ToString());
                }
            }
        }
    }
}
