using System;

namespace MCP70483cs.Exam
{
    internal class DaysOfWeekWork
    {
        public static void DoProc()
        {
            var weekend = DaysOfWeek.Saturday | DaysOfWeek.Sunday;

            var oneday = DaysOfWeek.Monday;

            if (weekend.HasFlag(oneday))
                Console.WriteLine("it's weekend!!!");
            else
                Console.WriteLine("it's weekday...");

            //foreach (var day in Enum.GetNames(typeof(DaysOfWeek)))
            //{
            //    Console.WriteLine(day);
            //}

            //foreach (var day in Enum.GetValues(typeof(DaysOfWeek)))
            //{
            //    Console.WriteLine(day);
            //}
        }
    }

    [Flags]
    public enum DaysOfWeek : short
    {
        None = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }
}