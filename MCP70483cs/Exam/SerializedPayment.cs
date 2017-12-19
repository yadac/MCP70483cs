using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    [Serializable]
    class SerializedPayment : ISample
    {
        public double Amount;
        [NonSerialized]
        public string CardNumber; // this field is not serialized.
        public string Payee;

        public override string ToString()
        {
            return string.Format($"amount is {Amount}, cardNumber is {CardNumber}, Payee is {Payee}.");
        }
    }

    class SerializedPaymentFactory : ISampleFactory
    {
        public ISample Create()
        {
            return new SerializedPayment()
            {
                Amount = 10.0,
                CardNumber = "12345",
                Payee = "Taro",
            };
        }
    }

    public class PaymentSerializer
    {
        
        public static void DoProc()
        {
            // binaryfomatter work with stream
            ISampleFactory factory = new SerializedPaymentFactory();
            var instance = (SerializedPayment)factory.Create();
            Console.WriteLine(instance.ToString());

            // change to binary stream
            using (FileStream fs = new FileStream(@"c:\temp\test\payment.txt", FileMode.Create))
            {
                // skip field which have NonSerialized attribute. 
                BinaryFormatter _formatter = new BinaryFormatter();
                _formatter.Serialize(fs, instance);
            }
            
            // reverse
            using (FileStream fs = new FileStream(@"c:\temp\test\payment.txt", FileMode.Open))
            {
                BinaryFormatter _formatter = new BinaryFormatter();
                var reversedInstance = (ISample)_formatter.Deserialize(fs);
                Console.WriteLine($"reversed = {reversedInstance}.");
            }

        }



    }
}
