using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    // simplified version of the support for Nullables
    class Example2_13<T> where T : struct
    {
        private bool _hasValue;
        private T _value;

        public Example2_13(T value)
        {
            this._hasValue = true;
            this._value = value;
        }

        public bool HasValue
        {
            get { return this._hasValue; }
        }

        public T Value
        {
            get
            {
                if (!this.HasValue) throw new ArgumentException();
                return this._value;
            }
        }

        public T GetValueOfDefault()
        {
            return this._value;
        }
    }
}
