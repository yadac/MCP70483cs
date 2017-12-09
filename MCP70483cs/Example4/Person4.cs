using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    public class Person4
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Example4_37
    {
        public static void DoProc()
        {
            using (PeopleContext context = new PeopleContext())
            {
                context.People4.Add(new Person4() { Id = 1, Name = "Steave", });
                context.People4.Add(new Person4() { Id = 2, Name = "Bill", });
                context.People4.Add(new Person4() { Id = 3, Name = "Mark", });
                context.SaveChanges();
            }

            using (PeopleContext context = new PeopleContext())
            {
                Person4 person = context.People4.SingleOrDefault(p => p.Id == 3);
                Console.WriteLine(person.Name);

            }
        }
    }

    public class PeopleContext : DbContext
    {
        public IDbSet<Person4> People4 { get; set; }
    }

}
