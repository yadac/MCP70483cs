using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
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

        private IEnumerable<SampleBook> GetBooks()
        {
            return new List<SampleBook>();
        }

        public void DoProc()
        {
            var query = from l in GetBooks()
                        select new MailingAddress
                        {
                            Name = l.Name ?? "our neighbors",
                            Address = "japan"
                        };

            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            //PrincipalPermission p = new PrincipalPermission(null, "builtin\\users");
            //p.Demand();


            mousemove += (s, e) => { Console.WriteLine(e.ToString()); };
        }

        public event EventHandler<EventArgs> mousemove;

    }

    internal class MailingAddress
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
