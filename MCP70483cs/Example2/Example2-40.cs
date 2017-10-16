using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    internal class Example2_40 : ILeft240, IRight240
    {
        public static void DoProc()
        {
            var i = new Example2_40();

            // this is usual
            i.Move();

            // this is special
            ((IRight240)i).Move();
        }

        // public modifier is not valid for explicit interface implementation.
        // method of interface is public.

        public void Move()
        {
            Console.WriteLine("called");
        }

        void IRight240.Move()
        {
            Console.WriteLine("right called!");
        }


    }

    interface ILeft240
    {
        void Move();
    }

    public interface IRight240
    {
        void Move();
    }
}
