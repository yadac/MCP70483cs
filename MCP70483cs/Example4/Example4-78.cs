using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_78
    {
        public static void DoProc()
        {
            var p = new PersonDataContract()
            {
                Id = 1,
                Name = "Taro"
            };

            using (Stream stream = new FileStream("data.xml", FileMode.Create))
            {
                var ser = new DataContractSerializer(typeof(PersonDataContract));
                ser.WriteObject(stream, p);
            }

            using (Stream stream = new FileStream("data.xml", FileMode.Open))
            {
                var ser = new DataContractSerializer(typeof(PersonDataContract));
                var result = (PersonDataContract)ser.ReadObject(stream);
            }

        }
    }

    [DataContract]
    public class PersonDataContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        private bool isDirty = false;

        public override string ToString()
        {
            return string.Format($"id = {Id}, Name = {Name}");
        }
    }
}
