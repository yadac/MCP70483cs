using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace MCP70483cs.Example4
{
    internal class Example4_79
    {
        public static void DoProc()
        {
            var p = new PersonDataContract
            {
                Id = 1,
                Name = "Taro"
            };

            // memorystream class can inmemory processing!
            using (var stream = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(typeof(PersonDataContract));
                ser.WriteObject(stream, p);

                // change current stream position to head, then read all stream data.
                stream.Position = 0;
                var reader = new StreamReader(stream);
                Console.WriteLine(reader.ReadToEnd());

                // again set position to head.
                stream.Position = 0;
                var person = (PersonDataContract) ser.ReadObject(stream);
                Console.WriteLine(person.ToString());
            }
        }
    }
}