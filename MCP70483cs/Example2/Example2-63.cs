using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace MCP70483cs.Example2
{
    public class Example2_63
    {
        // xunit TraitAttribute class is sealed class.
        // so this class can not derived.
        public TraitAttribute TraitAttribute { get; private set; }

        public Example2_63(string value)
        {
            TraitAttribute = new TraitAttribute("category", value);
        }

        public static void DoProc()
        {
            int i = 42;
            System.Type type = i.GetType();
            Console.WriteLine(i.GetType());
        }

    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class UnitTestAttribute263 : CategoryAttribute
    {
        public UnitTestAttribute263() : base("unit test")
        {

        }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    class CompleteCustomAttribute : Attribute
    {
        public CompleteCustomAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }

    public interface IPlugin263
    {
        string Name { get; }
        string Description { get; }
        bool Load(Example2_63 application);
    }

    public class MyPlugin263 : IPlugin263
    {
        public string Name { get { return "MyPlugin"; } }
        public string Description { get { return "My sample plug-in"; } }
        public bool Load(Example2_63 application)
        {
            return true;
        }
    }
}
