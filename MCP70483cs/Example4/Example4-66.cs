using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MCP70483cs.Example4
{
    class Example4_66
    {
        public static void DoProc()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("Example4-42.xml");
            var xml = xmlDoc.OuterXml;

            var doc = XDocument.Parse(xml);

            // let = クエリ内で一時変数を作成する際に利用
            var personName = from p in doc.Descendants("person")
                             where p.Descendants("phoneNumber").Any()
                             let name = (string)p.Attribute("firstName")
                                        + " "
                                        + (string)p.Attribute("lastName")
                             orderby name
                             select name;

        }
    }
}
