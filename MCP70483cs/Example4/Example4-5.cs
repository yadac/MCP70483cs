using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example4
{
    class Example4_5
    {
        public static void DoProc()
        {
            // list the subdirectories for program files containing the character 'a' 
            // with a maximum depth of 5
            DirectoryInfo directoryInfo = new DirectoryInfo(@"c:\program files");
            ListDirectories(directoryInfo, "*a*", 5, 0);
        }

        private static void ListDirectories(DirectoryInfo directoryInfo
            , string searchPath
            , int maxLevel
            , int currentLevel)
        {
            // if already maxlevel
            if (currentLevel >= maxLevel)
            {
                return;
            }
            string indent = new string('-', currentLevel);
            try
            {
                var subDirectories = directoryInfo.GetDirectories(searchPath);
                foreach (var subDirectory in subDirectories)
                {
                    Console.WriteLine(indent + subDirectory.Name);
                    ListDirectories(subDirectory
                        , searchPath
                        , maxLevel
                        , currentLevel + 1);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // you don't have access to this folder.
                Console.WriteLine(indent + "can't access: " + directoryInfo.Name);
                return;
            }
            catch (DirectoryNotFoundException)
            {
                // the folder is removed while iterating
                Console.WriteLine(indent + "can't find: " + directoryInfo.Name);
                return;
            }
        }
    }
}
