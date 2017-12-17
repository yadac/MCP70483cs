using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    internal class TplSample
    {
        public IEnumerable<Task> Execute(Action[] jobs)
        {
            var tasks = new Task[jobs.Length];
            for (var i = 0; i < jobs.Length; i++)
            {
                // it is possible to different value of i when calling and return.
                // tasks[i] = Task.Run(() => RunJob(jobs[i], i)); i = index. closure?
                tasks[i] = new Task(index => RunJob(jobs[(int) index], (int) index), i);
                tasks[i].Start();
            }
            return tasks;
        }

        public void RunJob(Action job, int index)
        {
        }
    }
}