using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace MCP70483cs.Example3
{
    class Example3_24
    {
        public static void DoProc()
        {
            string textToSign = "test paragraph";
            byte[] signature = Sign(textToSign, "cn=WouterDeKort");
            signature[0] = 0;
            Console.WriteLine(Verify(textToSign, signature));
        }

        public static byte[] Sign(string text, string certSubject)
        {
            // 証明書を取得、ハッシュ化したデータを、秘密鍵で暗号化
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] hash = HashData(text);
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }

        static bool Verify(string text, byte[] signature)
        {
            // 証明書を取得、共有鍵で復号したデータと元のデータをハッシュ化したデータが一致しているか検証
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider) cert.PublicKey.Key;
            byte[] hash = HashData(text);
            return csp.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
        }

        private static byte[] HashData(string text)
        {
            // SHA1でハッシュ化
            HashAlgorithm hashAlgorithm = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(text);
            byte[] hash = hashAlgorithm.ComputeHash(data);
            return hash;
        }

        private static X509Certificate2 GetCertificate()
        {
            // 証明書を取り出して返却
            X509Store my = new X509Store("testCertStore",
                StoreLocation.CurrentUser);
            my.Open(OpenFlags.ReadOnly);
            var certificate = my.Certificates[0];
            return certificate;
        }
    }
}
