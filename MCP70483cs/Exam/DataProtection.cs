using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.VisualBasic.ApplicationServices;
using Xunit.Sdk;

namespace MCP70483cs.Exam
{
    class DataProtection
    {
        private static byte[] s_additionalEntropy = {9, 8, 7, 6, 5};

        public static void DoProc()
        {
            byte[] secret = {0, 1, 2, 3, 4, 1, 2, 3, 4};
            byte[] encryptedSecret = Protect(secret);
            foreach (var b in encryptedSecret)
            {
                Console.Write(b);
            }
        }

        public static byte[] Protect(byte[] data)
        {
            return ProtectedData.Protect(data, s_additionalEntropy, DataProtectionScope.CurrentUser);
        }

        public static byte[] UnProtect(byte[] data)
        {
            return ProtectedData.Unprotect(data, s_additionalEntropy, DataProtectionScope.CurrentUser);
        }
    }
}
