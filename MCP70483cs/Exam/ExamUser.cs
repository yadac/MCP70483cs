using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    [DebuggerDisplay("Id is {Id}, Name is {Name}")]
    public class ExamUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ExamUserSample
    {
        public static void DoProc()
        {
            var user1 = new ExamUser(){Id = 1, Name = "Taro"};
            var user2 = new ExamUser() { Id = 1, Name = "Taro" };
        }

    }

}
