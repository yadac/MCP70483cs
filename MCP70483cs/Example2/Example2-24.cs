using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_24
    {
        public static void DoProc()
        {
            Example2_24 temp = new Example2_24(42.42M);
            decimal amount = temp;
            int truncatedAmount = (int)temp;
            string stringAmount = (string)temp;
            Console.WriteLine(amount);
            Console.WriteLine(truncatedAmount);
            Console.WriteLine(stringAmount);

        }

        public decimal Amount { get; set; }

        public Example2_24(decimal amount)
        {
            Amount = amount;
        }

        public static implicit operator decimal(Example2_24 moeny)
        {
            return moeny.Amount;
        }

        public static explicit operator int(Example2_24 money)
        {
            return (int)money.Amount;
        }

        // like extention method
        // rule of storing string variables.
        public static explicit operator string(Example2_24 money)
        {
            return $"string expression is {money.Amount}";
        }
    }
}
