using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_18
    {
        public static void DoProc()
        {
            string folder = @"c:\temp";
            string uncompressedFilePath = Path.Combine(folder, "uncompressed.dat");
            string compressedFilePath = Path.Combine(folder, "compressed.gz");

            // data
            byte[] dataToCompress = 
                Enumerable.Repeat((byte) 'a', 1024 * 1024).ToArray();

            // create UnCompressedFile
            using (FileStream unCompFs = File.Create(uncompressedFilePath))
            {
                unCompFs.Write(dataToCompress, 0, dataToCompress.Length);
            }

            // create CompressedFile by GZip
            using (FileStream compFs = File.Create(compressedFilePath))
            {
                // gzipstream constructor receive other type stream.
                using (GZipStream compStream = new GZipStream(compFs, CompressionMode.Compress))
                {
                    compStream.Write(dataToCompress, 0, dataToCompress.Length);
                }
            }
            
            // confirm
            FileInfo uncompressFile = new FileInfo(uncompressedFilePath);
            FileInfo compressFile = new FileInfo(compressedFilePath);
            Console.WriteLine(uncompressFile.Length);
            Console.WriteLine(compressFile.Length);
        }
    }
}
