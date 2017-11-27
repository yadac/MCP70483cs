using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_1
    {
        public static void DoProc()
        {
            DriveInfo[] drivesInfo = DriveInfo.GetDrives();
            foreach (var driveInfo in drivesInfo)
            {
                Console.WriteLine($"Drive {driveInfo.Name}");
                Console.WriteLine($" File type: {driveInfo.DriveType}");

                if (driveInfo.IsReady == true)
                {
                    Console.WriteLine($" Volume label: {driveInfo.VolumeLabel}");
                    Console.WriteLine($" Drive format: {driveInfo.DriveFormat}");
                    Console.WriteLine($" Available FreeSpace: {driveInfo.AvailableFreeSpace}");
                    Console.WriteLine($" Total FreeSpace: {driveInfo.TotalFreeSpace}");
                    Console.WriteLine($" Total Size: {driveInfo.TotalSize}");

                }
            }
        }
    }
}
