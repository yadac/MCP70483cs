using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_85
    {
        private static WeakReference data;

        public static void DoProc()
        {
            object resutlt = GetData();
            // uncommenting this line will make data.Target null
            // GC.Collect();

            // if Gc execute, GetData again.
            // if Gc not execute, return value from weakreference.
            // weakreference will not be a target of Gc.
            resutlt = GetData();
        }

        private static object GetData()
        {
            if (data == null)
            {
                data = new WeakReference(LoadLargeList());
            }

            if (data.Target == null)
            {
                data.Target = LoadLargeList();
            }
            return data.Target;
        }

        private static object LoadLargeList()
        {
            throw new NotImplementedException();
        }
    }
}
