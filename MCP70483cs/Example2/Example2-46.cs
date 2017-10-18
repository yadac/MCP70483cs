using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_46
    {
        public static void DoProc()
        {

        }
    }

    interface IEntity
    {
        int Id { get; set; }
    }

    class Repository246<T> where T : IEntity
    {
        protected IEnumerable<T> _elements;

        public Repository246(IEnumerable<T> elements)
        {
            _elements = elements;
        }

        public T FindById(int id)
        {
            return _elements.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> All()
        {
            return _elements;
        }
    }

    class Order246 : IEntity
    {
        public int Id { get; set; }

    }

    class OrderRepository246 : Repository246<Order246>
    {
        public OrderRepository246(IEnumerable<Order246> orders) : base(orders)
        {
        }

        public IEnumerable<Order246> FilterOrdersOnAmount(decimal amount)
        {
            List<Order246> result = null;
            return result;
        }

    }
}
