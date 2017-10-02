using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCP70483cs
{

    public class DelegateSample2
    {
        // event definition
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public DelegateSample2()
        {
            WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkA);
        }

        public void DoProc()
        {
            DoWork(1, WorkType.GoToMeeting);
            DoWork(3, WorkType.Golf);
            DoWork(5, WorkType.GenerateReports);
        }

        private void WorkA(object o, WorkPerformedEventArgs args)
        {
            Console.WriteLine($"worktype = {args.WorkType.ToString()}, work hours = {args.Hours}.");
        }

        public void DoWork(int hours, WorkType workType) 
        {
            for (int i = 0; i < hours; i++)
            {
                if (WorkPerformed != null)
                {
                    Thread.Sleep(1000);
                    WorkPerformed(this, new WorkPerformedEventArgs(i + 1, workType));
                }
            }
            OnWorkCompleted(null, null);
        }

        protected void OnWorkCompleted(object o, EventArgs e)
        {
            Console.WriteLine("work completed.");
        }

    }

    public class WorkPerformedEventArgs : EventArgs
    {
        public WorkPerformedEventArgs(int hours, WorkType workType)
        {
            Hours = hours;
            WorkType = workType;
        }
        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }

    public enum WorkType
    {
        GoToMeeting,
        Golf,
        GenerateReports,
    }
}
