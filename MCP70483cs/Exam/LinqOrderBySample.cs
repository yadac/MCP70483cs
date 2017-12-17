using System;
using System.Collections.Generic;
using System.Linq;
using MCP70483cs.Example4;

namespace MCP70483cs.Exam
{
    internal class LinqOrderBySample
    {
        public static void DoProc()
        {
            var persons = new List<Person4>
            {
                new Person4 {Id = 1, Name = "alice", Age = 10},
                new Person4 {Id = 2, Name = "bob", Age = 30},
                new Person4 {Id = 3, Name = "chris", Age = 20},
                new Person4 {Id = 4, Name = "chris", Age = 40}
            };

            // you should use only one orderby method.
            // if you use multiple orderby methods, only the last method is used to determine the order of the returned data.
            // to order results by multiple keys, you must call the thenby method.
            var result = persons.OrderBy(p => p.Name).ThenBy(p => p.Age);
            foreach (var person in result)
                Console.WriteLine(person.ToString());
        }
    }
}