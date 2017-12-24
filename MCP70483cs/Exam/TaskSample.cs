using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class TaskSample
    {
        public static void DoProc()
        {

        }

        public IEnumerable<Task> Execute(Action[] jobs)
        {
            var tasks = new Task[jobs.Length];
            for (int i = 0; i < jobs.Length; i++)
            {
                tasks[i] = new Task((index) => RunJob(jobs[(int)index], (int)index), i);
            }

            return tasks;
        }

        internal void RunJob(Action action, int index)
        {

        }
    }
}
