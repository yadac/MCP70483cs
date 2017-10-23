using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_71
    {
        public static void DoProc()
        {
            Assembly pluginAssembly = Assembly.Load("xunit.core");
            var plugins = pluginAssembly.GetTypes().Where(
                t => typeof(IPlugin263).IsAssignableFrom(t) && !t.IsInterface);
        }
    }
}
