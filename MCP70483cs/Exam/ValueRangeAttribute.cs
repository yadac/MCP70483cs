using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    // このサンプル
    // http://blog.livedoor.jp/rizriver/archives/23360716.html

    public class CustomAttributeSample
    {
        public static void DoProc()
        {
            ISampleFactory factory = new EmployeeFactory();
            var employee = (EmployeeEntity)factory.Create();
            Console.WriteLine(employee.ToString());

            // 固定長文字列
            Console.WriteLine(employee.CreateFixedData());
        }
    }

    public class EmployeeFactory : ISampleFactory
    {
        public ISample Create()
        {
            var instance = new EmployeeEntity()
            {
                Number = 1,
                Name = "Taro",
                Phone = "000-1111-2222",
                Mail = "hoge@example.com"
            };
            return instance;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FixedDataAttribute : Attribute
    {
        public int Order { get; set; }
        public int FixedLength { get; set; }
        public char PadChar { get; set; }

    }

    public class EmployeeEntity : FixedDataEntityBase, ISample
    {
        [FixedData(Order = 1, FixedLength = 5, PadChar = '0')]
        public int Number { get; set; }
        [FixedData(Order = 2, FixedLength = 20, PadChar = ' ')]
        public string Name { get; set; }
        [FixedData(Order = 3, FixedLength = 15, PadChar = ' ')]
        public string Phone { get; set; }
        [FixedData(Order = 4, FixedLength = 20, PadChar = ' ')]
        public string Mail { get; set; }

        public override string ToString()
        {
            return string.Format($"Number = {Number}, Name = {Name}, Phone = {Phone}, Mail = {Mail},");
        }
    }

    public class FixedDataEntityBase
    {
        public string CreateFixedData()
        {
            PropertyInfo[] pis = this.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            FixedDataAttribute attrTmp = null;
            var q = pis.Where(pi =>
                {
                    FixedDataAttribute[] attr =
                        (FixedDataAttribute[])pi.GetCustomAttributes(typeof(FixedDataAttribute), true);
                    if (attr.Length > 0)
                    {
                        attrTmp = attr[0];
                        return true;
                    }
                    return false;
                })
                .Select(pi => new { TargetProp = pi, FixedDefine = attrTmp })
                .OrderBy(e => e.FixedDefine.Order);

            StringBuilder sb = new StringBuilder();
            foreach (var item in q.ToArray())
            {
                string value = item.TargetProp.GetValue(this, null).ToString();
                if (item.FixedDefine.FixedLength < value.Length)
                {
                    throw new InvalidOperationException("指定された長さ以上");
                }

                if (value.Length < item.FixedDefine.FixedLength)
                {
                    value = value.PadLeft(item.FixedDefine.FixedLength, item.FixedDefine.PadChar);
                }
                sb.Append(value);
            }
            return sb.ToString();
        }
    }
}
