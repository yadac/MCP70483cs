using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace MCP70483cs.Example4
{
    class Example4_46
    {
        public static void DoProc()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Example4-42.xml");

            XPathNavigator nav = doc.CreateNavigator();
            string query = "//people/person[@firstName='Taro']";
            XPathNodeIterator iterator = nav.Select(query);

            Console.WriteLine($"iterator.Count : {iterator.Count}"); // display 1

            while (iterator.MoveNext())
            {
                string firstName = iterator.Current.GetAttribute("firstName","");
                string lastName = iterator.Current.GetAttribute("lastName", "");
                Console.WriteLine($"Name : {firstName} {lastName}");
            }
        }
    }
}
