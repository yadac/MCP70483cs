using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_22<T>
    {
        private List<T>[] buckets = new List<T>[100];

        public void Insert(T item)
        {
        }

        private int GetBucket(int hashcode)
        {
            return 0;
        }

        private bool Contains(T item, int bucket)
        {
            return false;
        }
    }
}
