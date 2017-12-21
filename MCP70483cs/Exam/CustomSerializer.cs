using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class CustomSerializer
    {
        public BinaryWriter Writer { get; set; }
        public void SerializeClass1(Class1 c) { }
        public void SerializeClass2(Class2 c) { }

        public void Serialize(dynamic o)
        {
            Writer.Write(o);
        }

    }

    internal class Class2
    {
    }

    internal class Class1
    {
    }

    public class CustomSerializerWork
    {
        public static void DoProc()
        {
            ArrayList array = new ArrayList() { new Class1(), new Class2() };
            var serializer = new CustomSerializer()
            {
                Writer = new BinaryWriter(new FileStream("test.txt", FileMode.Open))
            };

            foreach (var o in array)
            {
                serializer.Serialize(o);
            }

        }
    }
}
