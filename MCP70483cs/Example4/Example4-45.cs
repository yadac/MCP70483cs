using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MCP70483cs.Example4
{
    class Example4_45
    {
        public static void DoProc()
        {
            XmlDocument doc = new XmlDocument();
            // LoadXml is xml string, Load is file.
            // doc.LoadXml(@"Example4-42.xml"); 
            doc.Load(@"Example4-42 - Copy.xml");
            XmlNodeList nodes = doc.GetElementsByTagName("person");

            // output the names of the people in the document
            foreach (XmlNode node in nodes)
            {
                string firstName = node.Attributes["firstName"].Value;
                string lastName = node.Attributes["lastName"].Value;
                Console.WriteLine($"Name: {firstName} {lastName}");
            }

            // start creating a new node
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "person", "");
            XmlAttribute firstNameAttribute = doc.CreateAttribute("firstName");
            firstNameAttribute.Value = "Foo";
            XmlAttribute lastNameAttribute = doc.CreateAttribute("lastName");
            lastNameAttribute.Value = "Bar";

            newNode.Attributes?.Append(firstNameAttribute);
            newNode.Attributes?.Append(lastNameAttribute);

            doc.DocumentElement?.AppendChild(newNode);
            Console.WriteLine("modified xml ... ");
            doc.Save(@"Example4-42 - Copy2.xml");
        }
    }
}
