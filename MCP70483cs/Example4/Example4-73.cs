using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using log4net;
using log4net.Core;

namespace MCP70483cs.Example4
{
    internal class Example4_73
    {
        private static readonly ILog _logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void DoProc()
        {

            _logger.Debug(DateTime.Now);
            var person = new Person4
            {
                Id = 1,
                Name = "Taro",
                Age = 20
            };

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("data.bin", FileMode.Create))
            {
                formatter.Serialize(stream, person);
            }

            using (Stream stream = new FileStream("data.bin", FileMode.Open))
            {
                var dPerson = (Person4) formatter.Deserialize(stream);
                Console.WriteLine(dPerson.ToString());
            }
        }
    }
}