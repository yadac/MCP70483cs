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
            var human = new HumanRepository().FindById(1);
            Console.WriteLine(human?.Name);
            var humans = new HumanRepository().GetItems();
            foreach (var h in humans)
            {
                Console.WriteLine(h.Name);
            }
        }
    }

    public interface IRepository243<T> where T : class
    {
        T FindById(int id);
        IEnumerable<T> GetItems();
    }

    public class HumanRepository : IRepository243<Human243>
    {
        private Human243 _instance; // to be singleton

        public HumanRepository()
        {
            _instance = new Human243();
            _instance.Humans = new List<Human243>()
            {
                new Human243() {Id = 1, Name = "taro", Age = 20},
                new Human243() {Id = 2, Name = "hanako", Age = 18}
            };
        }

        public Human243 FindById(int id)
        {
            return _instance.Humans.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Human243> GetItems()
        {
            return _instance.Humans;
        }
    }


    public class Human243
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public List<Human243> Humans { get; set; }
    }

}
