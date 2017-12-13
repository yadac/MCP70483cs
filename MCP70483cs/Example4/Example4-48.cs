using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_48
    {
        public static void DoProc()
        {
            //Dictionary<string, IEnumerable<Tuple<Type, int>>> data = 
            //    new Dictionary<string, IEnumerable<Tuple<Type, int>>>();
            
            // 戻り値の方が自明な場合、左辺はvarにすると可読性が向上する
            var implicitData = new Dictionary<string, IEnumerable<Tuple<Type, int>>>();
            
            // object initialization syntax
            var person = new Person4()
            {
                Id = 1,
                Name = "test",
                Age = 10,
            };

            // the same syntax can be used when creating collections.
            var persons = new List<Person4>()
            {
                new Person4()
                {
                    Id = 2,
                    Name = "test2",
                    Age = 20,
                },
                new Person4()
                {
                    Id = 3,
                    Name = "test3",
                    Age = 30,
                },
            };

            // lambda expression (anonymous method)
            Func<int, int> myDelegate = delegate(int x)
            {
                return x * 2;
            };

            // lambda expression is syntax sugar, for using Func and Action.

            Action<Person4> test = (x) =>
            {
                Console.WriteLine(x.ToString());
            };
            test(person);
        }
    }
}
