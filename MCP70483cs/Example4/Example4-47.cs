using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MCP70483cs.Example4
{
    class Example4_47
    {
        public static void DoProc()
        {
            List<Person4> persons = new List<Person4>()
            {
                new Person4()
                {
                    Id = 1,
                    Name = "Jeff",
                    Age = 40,
                },
                new Person4()
                {
                    Id = 2,
                    Name = "Mark",
                    Age = 20,
                },
                new Person4()
                {
                    Id = 3,
                    Name = "Henry",
                    Age = 60,
                },
            };

            // using Newtonsoft.Json lib
            var json = JsonConvert.SerializeObject(persons);
            Console.WriteLine(json);
            Console.WriteLine("---------------------");

            // de
            var list = JsonConvert.DeserializeObject<List<Person4>>(json);
            foreach (var person in list)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine("---------------------");

            // work with linq
            string temp = "{'people':" + json + "}"; // parse用に整形
            var obj = JObject.Parse(temp);
            var oldest = obj["people"].OrderByDescending(p => p["age"]).FirstOrDefault();
            Console.WriteLine($"oldest: {oldest?.ToString()}");
        }
    }

    
}
