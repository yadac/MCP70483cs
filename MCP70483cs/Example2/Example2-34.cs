using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    public class Example2_34
    {
        private int _privateField = 42;
        protected int _protectedField = 42;

        private void MyPrivateMethod() { }
        protected void MyProtectedMethod() { }
    }

    public class Example2_34Derived : Example2_34
    {
        public void MyDerivedMethod()
        {
            // protected field can be accessed from derived class
            _protectedField = 41;
            MyProtectedMethod();
        }
    }

    internal enum Test
    {
        
    }
}
