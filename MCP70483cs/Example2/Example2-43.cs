using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_43
    {
        public static void DoProc()
        {
            // test data
            IEnumerable<Human243> humans = new List<Human243>()
            {
                new Human243() {Id = 1, Name = "taro", Age = 20},
                new Human243() {Id = 2, Name = "hanako", Age = 18}
            };

            IRepository243<Human243> repos = new HumanRepository(humans);
            Console.WriteLine(repos.FindById(1).Name);
            foreach (var human in repos.GetItems())
            {
                Console.WriteLine("----");
                Console.WriteLine(human.Id);
                Console.WriteLine(human.Name);
                Console.WriteLine(human.Age);
            }

        }
    }

    public interface IRepository243<T> where T : IEntity243
    {
        IEnumerable<T> Members { get; set; }
        T FindById(int id);
        IEnumerable<T> GetItems();
    }

    public class Repository243<T> : IRepository243<T> where T : IEntity243
    {
        public IEnumerable<T> Members { get; set; }

        public Repository243(IEnumerable<T> members)
        {
            Members = members;
        }


        public T FindById(int id)
        {
            return Members.First();
        }

        public IEnumerable<T> GetItems()
        {
            return Members;
        }
    }

    public class HumanRepository : Repository243<Human243>
    {

        public HumanRepository(IEnumerable<Human243> members) : base(members)
        {            
        }

    }

    public interface IEntity243
    {
        int Id { get; set; }
    }


    public class Human243 : IEntity243
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }

}
