using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    [Serializable]
    public class PersonComplex4 : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private bool isDirty;

        public PersonComplex4()
        {
            isDirty = false;
        }

        protected PersonComplex4(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetInt32("value1");
            Name = info.GetString("value2");
            isDirty = info.GetBoolean("value3");
        }

        [System.Security.Permissions.SecurityPermission(
            SecurityAction.Demand,
            SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("value1", Id);
            info.AddValue("value2", Name);
            info.AddValue("value3", isDirty);

        }
    }
}
