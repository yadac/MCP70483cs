using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_14
    {
        public static void DoProc()
        {

            string path = @"c:\temp\csharp\test.dat";
            File.Delete(path);

            //using (FileStream fs = File.Create(path))
            //{
            //    string myValue = "myvalue";
            //    byte[] data = Encoding.UTF8.GetBytes(myValue);
            //    fs.Write(data, 0, data.Length);
            //}

            using (StreamWriter sw = File.CreateText(path))
            {
                string myValue = "myvalue";
                sw.Write(myValue);
            }

            using (FileStream fs = File.OpenRead(path))
            {
                byte[] data = new byte[fs.Length];
                for (int i = 0; i < fs.Length; i++)
                {
                    data[i] = (byte)fs.ReadByte();
                }
                Console.Write("convert bytes to string:");
                Console.WriteLine(Encoding.UTF8.GetString(data));
            }

            using (StreamReader sr = File.OpenText(path))
            {
                Console.Write("read lien:");
                Console.WriteLine(sr.ReadLine());
            }
        }
    }
}
