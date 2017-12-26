using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class ListObjects
    {
        public static void DoProc()
        {
            // non-generic IEnumerable valiable can not use LINQ method.
            var list = new Customer1226().GetErrors();
            
            // IEnumerable<T> can use it.
            IEnumerable<string> sList = new string[]{"hello", "every", "one"};

            // IEnumerator can not iteration, access with movenext() and current prop.
            IEnumerator c1 = new Customer12262();
            while (c1.MoveNext())
            {
                Console.WriteLine(c1.Current);
            }

        }
    }

    public class Customer12262 : IEnumerator
    {
        

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public object Current { get; }
    }

    public class Customer1226
    {
        public decimal CreditLimit { get; set; }
        public decimal Type { get; set; }

        public IEnumerable GetErrors()
        {
            return new CreditLimitValidator(this);
        }
    }


    public class CreditLimitValidator : IEnumerable
    {
        private object val;

        public IEnumerator GetEnumerator()
        {
            // IEnumerable interface forces iterator pattern.
            // ienumerable roop call this method in every roop.
            for (int i = 0; i < 5; i++)
            {
                yield return i;
            }
        }

        public CreditLimitValidator(Customer1226 cus)
        {
            val = cus;
        }

    }
}
