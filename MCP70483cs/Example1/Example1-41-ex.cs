using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{
    class Example1_41_ex
    {
        private int _totalValue = 0;

        public int Total { get { return _totalValue; } }

        public static void DoProc()
        {
            int t = new Example1_41_ex().AddToTotal(5);
            Console.WriteLine(t);
            
        }

        public int AddToTotal(int addend)
        {
            int initialValue, computedValue;
            do
            {
                initialValue = _totalValue;
                computedValue = initialValue + addend;

                // compareexchange compares totalvalue to initialvalue.
                // if they are not equal, then another thread has updated the 
                // running total since this loop started.
                //      
                // compareexchange returns the contents of totalvalues
                // which do not equal initialvalue, so the loop executes again.
                //
                Console.WriteLine($"total = {_totalValue}");
                Console.WriteLine($"compute = {computedValue}");
                Console.WriteLine($"initial = {initialValue}");

            } while (initialValue != Interlocked.CompareExchange(
                         ref _totalValue, computedValue, initialValue));

            // if no other thread updated the running total, then totalvalue and 
            // initalvalue are equal when compareexchane compare them, 
            // and computed value is stored in totalvalue. 
            // compareexchange returns the value that was
            // in totalvalue before the update, which is equal to initialvalue,
            // so the loop ends.
            return computedValue;
        }
    }
}
