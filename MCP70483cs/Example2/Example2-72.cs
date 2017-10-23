using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_72
    {
        public static void DoProc()
        {
            var obj = new Example1_82();
            DumpObject(obj);
        }

        static void DumpObject(object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                // typeof keyword return type.
                if (field.FieldType == typeof(int))
                {
                    // is keyword is judgement.
                    Console.WriteLine($"field.FieldType = {field.FieldType}");
                    Console.WriteLine($"typeof(int) = {typeof(int)}");
                    Console.WriteLine(field.FieldType is Int32);
                    Console.WriteLine(field.FieldType is Type);
                    Console.WriteLine(field.GetValue(obj));
                }
            }
        }
    }
}
