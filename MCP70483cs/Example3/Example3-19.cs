using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example3
{
    class Example3_19
    {
        private static string publicKeyXML;
        private static string privateKeyXML;

        public static void DoProc()
        {
            // first need to convert the data to a byte sequence.
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToEncypt = byteConverter.GetBytes("my secret data!");

            // encrypt
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKeyXML);
                encryptedData = rsa.Encrypt(dataToEncypt, false);
            }

            // decrypt
            byte[] decryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKeyXML);
                decryptedData = rsa.Decrypt(encryptedData, false);
            }

            // display
            string decryptedString = byteConverter.GetString(decryptedData);
            Console.WriteLine(decryptedString);

        }
    }

    class Example3_20
    {
        // using key-container instead of directly using key
        private static string containerName = "SecretContainer";

        public static void DoProc()
        {
            // key-container
            CspParameters csp = new CspParameters()
            {
                KeyContainerName = containerName
            };

            // first need to convert the data to a byte sequence.
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToEncypt = byteConverter.GetBytes("my secret data!");

            // encrypt
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp))
            {
                //rsa.FromXmlString(publicKeyXML);
                encryptedData = rsa.Encrypt(dataToEncypt, false);
            }

            // decrypt
            byte[] decryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp))
            {
                //rsa.FromXmlString(privateKeyXML);
                decryptedData = rsa.Decrypt(encryptedData, false);
            }

            // display
            string decryptedString = byteConverter.GetString(decryptedData);
            Console.WriteLine(decryptedString);

        }
    }

}
