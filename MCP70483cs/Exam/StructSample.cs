using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    struct MyStruct
    {
        private double _x;
        private double _y;

        public double X
        {
            get { return this._x; }
            private set { this._x = value; }
        }

        public MyStruct(double x, double y)
        {
            // already assigned X manually
            // this.X = x;
            throw new NotImplementedException();
        }
    }
}
