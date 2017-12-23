using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class DataProtecter
    {
        public static void DoProc()
        {
            var data = new byte[] { 1, 2, 3 };

            ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);

            // async read
            var reader = new StreamReader();


        }


    }
}
