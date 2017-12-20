using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    // 属性クラス
    [AttributeUsage(AttributeTargets.All)]
    public class DeveloperAttribute : Attribute
    {
        // private fields
        private string name;

        private string level;
        private bool reviewd;

        // this constructor defines two required parameters: name and level
        public DeveloperAttribute(string name, string level)
        {
            this.name = name;
            this.level = level;
            this.reviewd = true;
        }

        // this is read-only attribute
        public virtual string Name
        {
            get { return name; }
        }

        public virtual string Level
        {
            get { return level; }
        }

        public virtual bool Reviewed { get; set; }

    }
}
