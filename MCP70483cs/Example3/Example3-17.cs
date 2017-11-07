using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;

namespace MCP70483cs.Example3
{
    class Example3_17
    {
        public static void DoProc()
        {
            string original = "my secret data!";
            using (SymmetricAlgorithm sa = new AesManaged())
            {
                byte[] encrypted = Encrypt(sa, original);
                string roundtrip = Decrypt(sa, encrypted);



            }
        }

        public static byte[] Encrypt(SymmetricAlgorithm aes, string text)
        {
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        public static string Decrypt(SymmetricAlgorithm aes, byte[] cipherText)
        {
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using (MemoryStream msDecrypt = new MemoryStream())
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}
