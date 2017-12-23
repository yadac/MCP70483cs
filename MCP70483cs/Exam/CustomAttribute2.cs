using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    [AttributeUsage(System.AttributeTargets.All)]
    class CustomAttribute2 : Attribute
    {
        private string Author;
        public string Modified;

        public CustomAttribute2(string Author)
        {
            this.Author = Author;
            Modified = DateTime.Now.ToString();
        }
    }

    class SampleBook
    {
        [CustomAttribute2("taro", Modified = "jiro")]
        private string Name;

        [CustomAttribute2("saburo")]
        private string Name2;
    }
}
