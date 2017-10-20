using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    public class Example2_58
    {
        public static void DoProc()
        {
            new Example2_58().MyMthod();

            ConditionalAttribute c = (ConditionalAttribute)Attribute.GetCustomAttribute(typeof(Person258), typeof(ConditionalAttribute));
            Console.WriteLine($"c.ConditionString = {c.ConditionString}");
        }

        // multi attributes
        [Conditional("CONDITION1"), Conditional("DEBUG")]
        void MyMthod()
        {
            if (Attribute.IsDefined(typeof(Person258), typeof(SerializableAttribute)))
            {
                Console.WriteLine($"Person258 IsDefined SerializableAttribute");
            }
            else
            {
                Console.WriteLine($"Person258 Is *not* Defined SerializableAttribute");
            }

        }
    }

    [Serializable]
    public class Person258
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}


