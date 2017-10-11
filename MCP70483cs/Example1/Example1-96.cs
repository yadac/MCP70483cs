using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example1
{
    class Example1_96
    {
        public static void DoProc()
        {
            try
            {
                new Example1_96().ProcessOrder();
            }
            catch (OrderProcessException e)
            {
                Console.WriteLine($"outer exception");
                Console.WriteLine(e);
                Console.WriteLine();
                Console.WriteLine($"inner exception");
                Console.WriteLine(e.InnerException);
                // throw;
            }
        }

        public void ProcessOrder()
        {
            try
            {
                string s = "hello";
                int i = int.Parse(s);

            }
            catch (FormatException e)
            {
                throw new OrderProcessException("error while processing order", e); ;
            }
        }
    }

    public class OrderProcessException : Exception
    {
        public OrderProcessException(string message, Exception e) : base(message, e)
        {
        }
    }
}
