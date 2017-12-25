using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace MCP70483cs.Exam
{
    public abstract class RootCustomer
    {
        public string Name { get; set; }

        public virtual IEnumerable<RootCustomer> GetCustomer()
        {
            throw new NotImplementedException();
        }
    }

    [DataContract]
    internal class DerivedCustomerSample : RootCustomer
    {
        [DataMember] private int age;

        public int Salaly { get; set; }

        public override IEnumerable<RootCustomer> GetCustomer()
        {
        }
    }

    public class GinzaSerializer<T>
    {
        private readonly DataContractSerializer selializer;

        public GinzaSerializer()
        {
            selializer = new DataContractSerializer(typeof(T));
        }

        public void Serialize(Stream stream, RootCustomer customer)
        {
            selializer.WriteObject(stream, customer);
        }
    }

    public class Exam1225
    {
        public Exam1225()
        {
            var instance = new DerivedCustomerSample();
            var result = instance.GetCustomer()
                .Select(c => new {N = c.Name != null ? c.Name : "null-taro"});
        }
    }
}