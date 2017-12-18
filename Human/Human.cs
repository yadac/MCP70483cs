using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCP70483cs.Exam;

namespace Human
{
    public class Human : ISample
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format($"id = {Id}, name = {FirstName}.{LastName}, age = {Age}");
        }
    }
}
