using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MCP70483cs.Example4
{
    class Example4_71
    {
        public static void DoProc()
        {
            var serializer = new XmlSerializer(typeof(Order471), new Type[] { typeof(VIPOrder471) });
            string xml;
            using (var writer = new StringWriter()) 
            {
                var order = CreateOrder();
                serializer.Serialize(writer, order);
                xml = writer.ToString();
            }
            Console.WriteLine(xml);
            using (var reader = new StringReader(xml))
            {
                var o = (Order471) serializer.Deserialize(reader);
                Console.WriteLine(o.IsDirty);
            }

        }

        public static Order471 CreateOrder()
        {
            Product471 p1 = new Product471()
            {
                Id = 1,
                Description = "p2",
                Price = 9
            };
            Product471 p2 = new Product471()
            {
                Id = 2,
                Description = "p3",
                Price = 6
            };
            Order471 order = new VIPOrder471()
            {
                Id = 4,
                Description = "order for john dae. use the nice giftwrap",
                IsDirty = true,
                OrderLines = new List<OrderLine471>()
                {
                    new OrderLine471()
                    {
                        Id = 5,
                        Amount = 1,
                        Product = p1
                    },
                    new OrderLine471()
                    {
                        Id = 6,
                        Amount = 10,
                        Product = p2
                    }
                }
            };
            return order;

        }
    }

    [Serializable]
    public class Person471
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    [Serializable]
    public class Order471
    {
        [XmlAttribute]
        public int Id { get; set; }
        // ignore object not display in xml result.
        // after deserialize, object will be initialized, e.g. IsDirty is always false.
        [XmlIgnore]
        public bool IsDirty { get; set; }
        [XmlArray("Lines")]
        [XmlArrayItem("OrderLine471")]
        public List<OrderLine471> OrderLines { get; set; }
    }

    [Serializable]
    public class VIPOrder471 : Order471
    {
        public string Description { get; set; }
    }

    [Serializable]
    public class OrderLine471
    {
        //XmlAttribute will be xml attribute, not will be just a Node. 
        //<OrderLine471 Id = "5" Amount="1">
        //  <Product Id = "1" >
        //      < Price > 9 </ Price >
        //      < Description > p2 </ Description >
        //  </ Product >
        //</ OrderLine471 >        
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public int Amount { get; set; }
        public Product471 Product { get; set; }
    }

    [Serializable]
    public class Product471
    {
        [XmlAttribute]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
