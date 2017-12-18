using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCP70483cs.Exam;

namespace Human
{
    public class HumanFactory : ISampleFactory
    {
        public ISample Create()
        {
            return new Human()
            {
                Id = 1,
                FirstName = "Taro",
                LastName = "Tanaka",
                Age = 10,
            };
        }
    }
}
