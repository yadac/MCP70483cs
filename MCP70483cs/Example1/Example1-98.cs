using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example1
{
    class Example1_98
    {

    }

    [Serializable]
    public class OrderProcessException98 : Exception, ISerializable
    {
        public int OrderId { get; private set; }

        public OrderProcessException98(int orderId)
        {
            OrderId = orderId;
            this.HelpLink = "https://msdn.microsoft.com/ja-jp/library/system.exception(v=vs.110).aspx";
        }

        public OrderProcessException98(int orderId, string message): base(message)
        {
            OrderId = orderId;
            this.HelpLink = "https://msdn.microsoft.com/ja-jp/library/system.exception(v=vs.110).aspx";
        }

        public OrderProcessException98(int orderId, string message, Exception innerException) : 
            base(message, innerException)
        {
            OrderId = orderId;
            this.HelpLink = "https://msdn.microsoft.com/ja-jp/library/system.exception(v=vs.110).aspx";
        }

        protected OrderProcessException98(SerializationInfo info, StreamingContext context)
        {
            OrderId = (int) info.GetValue("OrderId", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OrderId", OrderId, typeof(int));
        }


    }
}
