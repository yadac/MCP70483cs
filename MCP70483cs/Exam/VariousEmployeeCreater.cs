using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class VariousEmployeeCreater
    {
        public static void DoProc(EmployeeTypeSample code)
        {
            switch (code)
            {
                case EmployeeTypeSample.Hourly:
                    Console.WriteLine("houly");
                    break;
                case EmployeeTypeSample.Salary:
                    Console.WriteLine("salaly");
                    break;
                case EmployeeTypeSample.Director:
                    Console.WriteLine("director");
                    goto case EmployeeTypeSample.Manager;
                case EmployeeTypeSample.Manager:
                    Console.WriteLine("manager");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }

    enum EmployeeTypeSample
    {
        Hourly,
        Salary,
        Manager,
        Director,
    }
}
