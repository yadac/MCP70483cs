using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_12
    {
        private int _p;

        // call other constructor, for avoid duplicate code
        public Example2_12() : this(3)
        {
            
        }

        public Example2_12(int p)
        {
            this._p = p;
        }
    }
}
