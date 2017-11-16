using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class ZipReader
    {
        public static void DoProc()
        {
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
    }
}
