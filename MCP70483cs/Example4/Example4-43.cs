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
            var instance = new Example4_43();
            instance.WriteXml();
            instance.ReadXml();
        }

        public void WriteXml()
        {
            string path = @"Example4-43.xml";
            if (File.Exists(path)) File.Delete(path);
            using (XmlWriter writer =
                XmlWriter.Create(path, new XmlWriterSettings()
                {
                    Indent = true,
                    NewLineChars = "\r\n", //default 
                }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("people");
                writer.WriteStartElement("person");
                writer.WriteAttributeString("firstName", "Ichiro");
                writer.WriteAttributeString("lastName", "Toyosu");
                writer.WriteStartElement("contactdetails");
                writer.WriteElementString("emailaddress", "ichiro@example.com");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
            }
        }

        public void ReadXml()
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
