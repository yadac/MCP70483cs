using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MCP70483cs.Example4
{
    class Example4_65
    {
        public static void DoProc()
        {
            // xml to string
            var doc = new XmlDocument();
            doc.Load("Example4-42.xml");
            string xml = doc.OuterXml;

            // change to ienumerable
            XDocument xdoc = XDocument.Parse(xml);

            // descendant = 子孫
            IEnumerable<string> personNames =
                from p in xdoc.Descendants("person")
                select (string)p.Attribute("firstName")
                       + " "
                       + (string)p.Attribute("lastName");
            foreach (var personName in personNames)
            {
                Console.WriteLine(personName);
            }

            foreach (var person in xdoc.Descendants("person"))
            {
                var first = (string)person.Attribute("firstName");
                var last = (string)person.Attribute("lastName");
                Console.WriteLine($"{first} {last}");
            }

        }
    }
}
