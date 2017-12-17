using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    [ServiceContract]
    public class ServiceSample
    {
        [OperationContract]
        public void EncryptData(byte[] data)
        {
            q.Add(data);
        }

        private static BlockingCollection<byte[]> q;

        static ServiceSample()
        {
            q = new BlockingCollection<byte[]>();
            new Thread(WorkerMethod).Start();
            new Thread(WorkerMethod).Start();
        }

        static void WorkerMethod()
        {
            foreach (var data in q.GetConsumingEnumerable())
            {
                Encrypt(data);
            }
        }

        private static void Encrypt(object data)
        {

            throw new NotImplementedException();
        }


    }
}
