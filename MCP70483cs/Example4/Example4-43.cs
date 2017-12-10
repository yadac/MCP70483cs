using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MCP70483cs.Example4
{
    class Example4_43
    {
        public static void DoProc()
        {
            using (XmlReader reader =
                XmlReader.Create(@"Example4-42.xml", new XmlReaderSettings()
                {
                    IgnoreWhitespace = true
                }))
            {
                reader.MoveToContent();

                reader.ReadStartElement("people");
                string firstName = reader.GetAttribute("firstName");
                string lastName = reader.GetAttribute("lastName");
                Console.WriteLine($"Person: {firstName} {lastName}");

                // readstartelementは一足飛びに指定できない
                // people -> person -> contactdetails というように階層を辿る
                Console.WriteLine("ContactDetail");
                reader.ReadStartElement("person");
                reader.ReadStartElement("contactdetails");
                string emailAddress = reader.ReadString();
                Console.WriteLine($"Email address: {emailAddress}");
            }
        }
    }
}
