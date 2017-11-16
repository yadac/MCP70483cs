using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class ZipReader
    {
        [FileIOPermission(SecurityAction.Demand, AllFiles = FileIOPermissionAccess.Read)]
        public static void DoProc()
        {
            try
            {
                WriteFile();

                string zipFile = @"C:\Temp\software\installer\DocAve_v5_Manager.zip";
                Console.WriteLine(zipFile);
                using (FileStream zipToOpen = new FileStream(zipFile, FileMode.Open))
                {
                    using (ZipArchive zip = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
                    {
                        Console.WriteLine("information about this package");
                        Console.WriteLine("------------------------------");
                        foreach (var entry in zip.Entries)
                        {
                            Console.Write(entry.FullName);
                            Console.Write(" / ");
                            Console.Write(entry.Length);
                            Console.Write(" / ");
                            Console.Write(entry.LastWriteTime);
                            Console.WriteLine("");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // throw;
            }
        }

        [FileIOPermission(SecurityAction.Demand, AllFiles = FileIOPermissionAccess.Read)]
        private static void WriteFile()
        {
            string file = @"C:\Temp\test.txt";
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.Write("hello");
                    sw.Flush();
                }
            }
        }
    }
}
