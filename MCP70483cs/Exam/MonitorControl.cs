using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    public class MonitorControl<T>
    {
        private List<T> list = new List<T>();

        public void Add(T entry)
        {
            Monitor.Enter(list);
            try
            {
                list.Add(entry);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Monitor.Exit(list);
            }
        }
    }
}
