using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;

namespace MCP70483cs.Example4
{
    class Example4_70
    {
        public static void DoProc()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person4));
            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                Person4 p = new Person4()
                {
                    Id = 1,
                    Name = "Taro",
                    Age = 20,
                };
                serializer.Serialize(stringWriter, p);
                xml = stringWriter.ToString();
            }

            Console.WriteLine(xml);

            using (StringReader stringReader = new StringReader(xml))
            {
                Person4 p = (Person4)serializer.Deserialize(stringReader);
                Console.WriteLine(p.ToString());
            }
        }
    }
}
